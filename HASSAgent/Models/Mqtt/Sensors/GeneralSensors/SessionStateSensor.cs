using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using HASSAgent.Enums;
using Serilog;

namespace HASSAgent.Models.Mqtt.Sensors.GeneralSensors
{
    public class SessionStateSensor : AbstractSensor
    {
        public SessionStateSensor(int? updateInterval = null, string name = "SessionState", Guid id = default) : base(name ?? "SessionState", updateInterval ?? 10, id) { }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return AutoDiscoveryConfigModel ?? SetAutoDiscoveryConfigModel(new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Device = Variables.DeviceConfig,
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Icon = "mdi:lock",
                Availability_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/availability"
            });
        }

        public override string GetState()
        {
            return GetPcUserStatus().ToString();
        }

        private static PcUserStatus GetPcUserStatus()
        {
            try
            {
                var scope = new ManagementScope();
                scope.Connect();

                var explorerProcesses = Process.GetProcessesByName("explorer")
                                            .Select(p => p.Id.ToString())
                                            .ToHashSet();

                var processId = new Regex(@"(?<=Handle="").*?(?="")", RegexOptions.Compiled);
                int numberOfLogonSessionsWithExplorer;

                using (var managemntObjectSearcher = new ManagementObjectSearcher(scope, new SelectQuery("SELECT * FROM Win32_SessionProcess")))
                {
                    numberOfLogonSessionsWithExplorer = managemntObjectSearcher.Get()
                                                                .Cast<ManagementObject>()
                                                                .Where(mo => explorerProcesses.Contains(processId.Match(mo["Dependent"].ToString()).Value))
                                                                .Select(mo => mo["Antecedent"].ToString())
                                                                .Distinct()
                                                                .Count();
                }
                var numberOfUserDesktops = 1;

                // this can fail sometimes, that's why we set numberOfUserDesktops to 1
                try
                {
                    using (var managementObjectSearcher = new ManagementObjectSearcher(scope, new SelectQuery("select * from win32_Perfrawdata_TermService_TerminalServicesSession")))
                    {
                        numberOfUserDesktops = managementObjectSearcher.Get().Count - 1; // don't count Service desktop
                    }
                }
                catch
                {
                    //
                }

                var numberOfLogonUiProcesses = Process.GetProcessesByName("LogonUI").Length;

                if (numberOfLogonUiProcesses >= numberOfUserDesktops) return numberOfLogonSessionsWithExplorer > 0 ? PcUserStatus.Locked : PcUserStatus.LoggedOff;
                return PcUserStatus.InUse;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
                return PcUserStatus.Unknown;
            }
        }
    }
}
