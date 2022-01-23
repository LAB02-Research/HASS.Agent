using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using ByteSizeLib;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class StorageSensors : AbstractMultiValueSensor
    {
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public StorageSensors(int? updateInterval = null, string name = "storage", string id = default) : base(name ?? "storage", updateInterval ?? 30, id)
        {
            _updateInterval = updateInterval ?? 30;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            var driveCount = 0;

            // lowercase and safe name of the multivalue sensor
            var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (drive == null || !drive.IsReady || drive.DriveType != DriveType.Fixed) continue;
                    if (string.IsNullOrWhiteSpace(drive.Name)) continue;

                    // name (letter)
                    var driveName = $"{drive.Name.Substring(0, 1).ToUpper()}";
                    var driveNameLower = driveName.ToLower();

                    // label
                    var driveLabel = string.IsNullOrEmpty(drive.VolumeLabel) ? "-" : drive.VolumeLabel;
                    var driveLabelId = $"{parentSensorSafeName}_{driveNameLower}_label";

                    var labelSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {driveName} Label", driveLabelId, string.Empty, "mdi:harddisk", string.Empty, Name);
                    labelSensor.SetState(driveLabel);

                    if (!Sensors.ContainsKey(driveLabelId)) Sensors.Add(driveLabelId, labelSensor);
                    else Sensors[driveLabelId] = labelSensor;

                    // total size
                    var totalSizeMb = Math.Round(ByteSize.FromBytes(drive.TotalSize).MegaBytes);
                    var totalSizeId = $"{parentSensorSafeName}_{driveNameLower}_total_size";

                    var totalSizeSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {driveName} Total Size", totalSizeId, string.Empty, "mdi:harddisk", "MB", Name);
                    totalSizeSensor.SetState(totalSizeMb);

                    if (!Sensors.ContainsKey(totalSizeId)) Sensors.Add(totalSizeId, totalSizeSensor);
                    else Sensors[totalSizeId] = totalSizeSensor;

                    // available space
                    var availableSpaceMb = Math.Round(ByteSize.FromBytes(drive.AvailableFreeSpace).MegaBytes);
                    var availableSpaceId = $"{parentSensorSafeName}_{driveNameLower}_available_space";

                    var availableSpaceSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {driveName} Available Space", availableSpaceId, string.Empty, "mdi:harddisk", "MB", Name);
                    availableSpaceSensor.SetState(availableSpaceMb);

                    if (!Sensors.ContainsKey(availableSpaceId)) Sensors.Add(availableSpaceId, availableSpaceSensor);
                    else Sensors[availableSpaceId] = availableSpaceSensor;

                    // used space
                    var usedSpaceMb = totalSizeMb - availableSpaceMb;
                    var usedSpaceId = $"{parentSensorSafeName}_{driveNameLower}_used_space";

                    var usedSpaceSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {driveName} Used Space", usedSpaceId, string.Empty, "mdi:harddisk", "MB", Name);
                    usedSpaceSensor.SetState(usedSpaceMb);

                    if (!Sensors.ContainsKey(usedSpaceId)) Sensors.Add(usedSpaceId, usedSpaceSensor);
                    else Sensors[usedSpaceId] = usedSpaceSensor;

                    // file system
                    var fileSystem = drive.DriveFormat;
                    var fileSystemId = $"{parentSensorSafeName}_{driveNameLower}_filesystem";

                    var fileSystemSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {driveName} File System", fileSystemId, string.Empty, "mdi:harddisk", string.Empty, Name);
                    fileSystemSensor.SetState(fileSystem);

                    if (!Sensors.ContainsKey(fileSystemId)) Sensors.Add(fileSystemId, fileSystemSensor);
                    else Sensors[fileSystemId] = fileSystemSensor;

                    // drive count
                    driveCount++;
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case UnauthorizedAccessException _:
                        case SecurityException _:
                            Log.Fatal(ex, "[STORAGE] Disk access denied: {msg}", ex.Message);
                            continue;
                        case DriveNotFoundException _:
                            Log.Fatal(ex, "[STORAGE] Disk not found: {msg}", ex.Message);
                            continue;
                        case IOException _:
                            Log.Fatal(ex, "[STORAGE] Disk IO error: {msg}", ex.Message);
                            continue;
                    }

                    Log.Fatal(ex, "[STORAGE] Error querying disk: {msg}", ex.Message);
                }
            }

            // drive count
            var driveCountId = $"{parentSensorSafeName}_total_disk_count";
            var driveCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Total Disk Count", driveCountId, string.Empty, "mdi:harddisk", string.Empty, Name);
            driveCountSensor.SetState(driveCount);

            if (!Sensors.ContainsKey(driveCountId)) Sensors.Add(driveCountId, driveCountSensor);
            else Sensors[driveCountId] = driveCountSensor;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
