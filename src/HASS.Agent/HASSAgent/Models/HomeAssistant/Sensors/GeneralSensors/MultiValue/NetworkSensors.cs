using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using ByteSizeLib;
using HASSAgent.Functions;
using HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes;
using Newtonsoft.Json;
using Serilog;

namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue
{
    public class NetworkSensors : AbstractMultiValueSensor
    {
        private readonly int _updateInterval;

        public sealed override Dictionary<string, AbstractSingleValueSensor> Sensors { get; protected set; } = new Dictionary<string, AbstractSingleValueSensor>();
        
        public NetworkSensors(int? updateInterval = null, string name = "network", string id = default) : base(name ?? "network", updateInterval ?? 30, id)
        {
            _updateInterval = updateInterval ?? 30;

            UpdateSensorValues();
        }

        public sealed override void UpdateSensorValues()
        {
            // lowercase and safe name of the multivalue sensor
            var parentSensorSafeName = HelperFunctions.GetSafeValue(Name);

            // get nic info
            var nicCount = 0;
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var nic in networkInterfaces)
            {
                try
                {
                    if (nic == null) continue;

                    // id
                    var id = nic.Id.Replace("{", "").Replace("}", "").Replace("-", "").ToLower();
                    if (string.IsNullOrWhiteSpace(id)) continue;
                
                    // name
                    var name = nic.Name;
                    var nameId = $"{parentSensorSafeName}_{id}_name";

                    var nameSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Name", nameId, string.Empty, "mdi:lan", string.Empty, Name);
                    nameSensor.SetState(name);

                    if (!Sensors.ContainsKey(nameId)) Sensors.Add(nameId, nameSensor);
                    else Sensors[nameId] = nameSensor;

                    // interfacetype
                    var interfaceType = nic.NetworkInterfaceType.ToString();
                    var interfaceTypeId = $"{parentSensorSafeName}_{id}_interface_type";

                    var interfaceTypeSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Interface Type", interfaceTypeId, string.Empty, "mdi:lan", string.Empty, Name);
                    interfaceTypeSensor.SetState(interfaceType);

                    if (!Sensors.ContainsKey(interfaceTypeId)) Sensors.Add(interfaceTypeId, interfaceTypeSensor);
                    else Sensors[interfaceTypeId] = interfaceTypeSensor;

                    // speed
                    var speed = nic.Speed;
                    var speedId = $"{parentSensorSafeName}_{id}_speed";

                    var speedIdSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Speed", speedId, string.Empty, "mdi:lan", string.Empty, Name);
                    speedIdSensor.SetState(speed);

                    if (!Sensors.ContainsKey(speedId)) Sensors.Add(speedId, speedIdSensor);
                    else Sensors[speedId] = speedIdSensor;

                    // operational status
                    var operationalStatus = nic.OperationalStatus.ToString();
                    var operationalStatusId = $"{parentSensorSafeName}_{id}_operational_status";

                    var operationalStatusSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Operational Status", operationalStatusId, string.Empty, "mdi:lan", string.Empty, Name);
                    operationalStatusSensor.SetState(operationalStatus);

                    if (!Sensors.ContainsKey(operationalStatusId)) Sensors.Add(operationalStatusId, operationalStatusSensor);
                    else Sensors[operationalStatusId] = operationalStatusSensor;

                    // get interface stats
                    var interfaceStats = nic.GetIPv4Statistics();

                    // data received
                    var dataReceivedMb = Math.Round(ByteSize.FromBytes(interfaceStats.BytesReceived).MegaBytes);
                    var dataReceivedMbId = $"{parentSensorSafeName}_{id}_data_received";

                    var dataReceivedMbSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Received", dataReceivedMbId, string.Empty, "mdi:lan", "MB", Name);
                    dataReceivedMbSensor.SetState(dataReceivedMb);

                    if (!Sensors.ContainsKey(dataReceivedMbId)) Sensors.Add(dataReceivedMbId, dataReceivedMbSensor);
                    else Sensors[dataReceivedMbId] = dataReceivedMbSensor;

                    // data sent
                    var dataSentMb = Math.Round(ByteSize.FromBytes(interfaceStats.BytesSent).MegaBytes);
                    var dataSentMbId = $"{parentSensorSafeName}_{id}_data_sent";

                    var dataSentMbSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Sent", dataSentMbId, string.Empty, "mdi:lan", "MB", Name);
                    dataSentMbSensor.SetState(dataSentMb);

                    if (!Sensors.ContainsKey(dataSentMbId)) Sensors.Add(dataSentMbId, dataSentMbSensor);
                    else Sensors[dataSentMbId] = dataSentMbSensor;

                    // incoming discarded packets
                    var incomingPacketsDiscarded = interfaceStats.IncomingPacketsDiscarded;
                    var incomingPacketsDiscardedId = $"{parentSensorSafeName}_{id}_incoming_discarded_packets";

                    var incomingPacketsDiscardedSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Incoming Packets Discarded", incomingPacketsDiscardedId, string.Empty, "mdi:lan", string.Empty, Name);
                    incomingPacketsDiscardedSensor.SetState(incomingPacketsDiscarded);

                    if (!Sensors.ContainsKey(incomingPacketsDiscardedId)) Sensors.Add(incomingPacketsDiscardedId, incomingPacketsDiscardedSensor);
                    else Sensors[incomingPacketsDiscardedId] = incomingPacketsDiscardedSensor;

                    // incoming discarded packets
                    var incomingPacketsWithErrors = interfaceStats.IncomingPacketsWithErrors;
                    var incomingPacketsWithErrorsId = $"{parentSensorSafeName}_{id}_incoming_error_packets";

                    var incomingPacketsWithErrorsSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Incoming Packets With Errors", incomingPacketsWithErrorsId, string.Empty, "mdi:lan", string.Empty, Name);
                    incomingPacketsWithErrorsSensor.SetState(incomingPacketsWithErrors);

                    if (!Sensors.ContainsKey(incomingPacketsWithErrorsId)) Sensors.Add(incomingPacketsWithErrorsId, incomingPacketsWithErrorsSensor);
                    else Sensors[incomingPacketsWithErrorsId] = incomingPacketsWithErrorsSensor;

                    // incoming discarded packets
                    var incomingPacketsWithUnknownProtocol = interfaceStats.IncomingUnknownProtocolPackets;
                    var incomingPacketsWithUnknownProtocolId = $"{parentSensorSafeName}_{id}_incoming_unknown_protocol_packets";

                    var incomingPacketsWithUnknownProtocolSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Incoming Unknown Protocol Packets", incomingPacketsWithUnknownProtocolId, string.Empty, "mdi:lan", string.Empty, Name);
                    incomingPacketsWithUnknownProtocolSensor.SetState(incomingPacketsWithUnknownProtocol);

                    if (!Sensors.ContainsKey(incomingPacketsWithUnknownProtocolId)) Sensors.Add(incomingPacketsWithUnknownProtocolId, incomingPacketsWithUnknownProtocolSensor);
                    else Sensors[incomingPacketsWithUnknownProtocolId] = incomingPacketsWithUnknownProtocolSensor;

                    // outgoing discarded packets
                    var outgoingPacketsDiscarded = interfaceStats.OutgoingPacketsDiscarded;
                    var outgoingPacketsDiscardedId = $"{parentSensorSafeName}_{id}_outgoing_discarded_packets";

                    var outgoingPacketsDiscardedSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Outgoing Packets Discarded", outgoingPacketsDiscardedId, string.Empty, "mdi:lan", string.Empty, Name);
                    outgoingPacketsDiscardedSensor.SetState(outgoingPacketsDiscarded);

                    if (!Sensors.ContainsKey(outgoingPacketsDiscardedId)) Sensors.Add(outgoingPacketsDiscardedId, outgoingPacketsDiscardedSensor);
                    else Sensors[outgoingPacketsDiscardedId] = outgoingPacketsDiscardedSensor;

                    // outgoing discarded packets
                    var outgoingPacketsWithErrors = interfaceStats.OutgoingPacketsWithErrors;
                    var outgoingPacketsWithErrorsId = $"{parentSensorSafeName}_{id}_outgoing_error_packets";

                    var outgoingPacketsWithErrorsSensor = new DataTypeDoubleSensor(_updateInterval, $"{Name} {name} Outgoing Packets With Errors", outgoingPacketsWithErrorsId, string.Empty, "mdi:lan", string.Empty, Name);
                    outgoingPacketsWithErrorsSensor.SetState(outgoingPacketsWithErrors);

                    if (!Sensors.ContainsKey(outgoingPacketsWithErrorsId)) Sensors.Add(outgoingPacketsWithErrorsId, outgoingPacketsWithErrorsSensor);
                    else Sensors[outgoingPacketsWithErrorsId] = outgoingPacketsWithErrorsSensor;

                    // get nic properties
                    var nicProperties = nic.GetIPProperties();

                    // ip's and mac addresses
                    var ips = new List<string>();
                    var macs = new List<string>();
                    foreach (var unicast in nicProperties.UnicastAddresses)
                    {
                        var ip = unicast.Address.ToString();
                        if (!string.IsNullOrEmpty(ip) && !ips.Contains(ip)) ips.Add(ip);

                        var mac = nic.GetPhysicalAddress().ToString();
                        if (!string.IsNullOrEmpty(mac) && !macs.Contains(mac)) macs.Add(mac);
                    }

                    var ipList = JsonConvert.SerializeObject(ips);
                    var ipListId = $"{parentSensorSafeName}_{id}_ip_addresses";

                    var ipListSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} IP Addresses", ipListId, string.Empty, "mdi:lan", string.Empty, Name);
                    ipListSensor.SetState(ipList);

                    if (!Sensors.ContainsKey(ipListId)) Sensors.Add(ipListId, ipListSensor);
                    else Sensors[ipListId] = ipListSensor;

                    var macList = JsonConvert.SerializeObject(macs);
                    var macListId = $"{parentSensorSafeName}_{id}_mac_addresses";

                    var macListSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} MAC Addresses", macListId, string.Empty, "mdi:lan", string.Empty, Name);
                    macListSensor.SetState(macList);

                    if (!Sensors.ContainsKey(macListId)) Sensors.Add(macListId, macListSensor);
                    else Sensors[macListId] = macListSensor;

                    // gateways
                    var gateways = new List<string>();
                    foreach (var gateway in nicProperties.GatewayAddresses)
                    {
                        var gatewayAddress = gateway.Address.ToString();
                        if (!string.IsNullOrEmpty(gatewayAddress) && !gateways.Contains(gatewayAddress)) gateways.Add(gatewayAddress);
                    }

                    var gatewayList = JsonConvert.SerializeObject(gateways);
                    var gatewayListId = $"{parentSensorSafeName}_{id}_gateway_addresses";

                    var gatewayListSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} Gateway Addresses", gatewayListId, string.Empty, "mdi:lan", string.Empty, Name);
                    gatewayListSensor.SetState(gatewayList);

                    if (!Sensors.ContainsKey(gatewayListId)) Sensors.Add(gatewayListId, gatewayListSensor);
                    else Sensors[gatewayListId] = gatewayListSensor;

                    // dhcp enabled
                    var dhcpEnabled = nicProperties.GetIPv4Properties().IsDhcpEnabled ? "TRUE" : "FALSE";
                    var dhcpEnabledId = $"{parentSensorSafeName}_{id}_dhcp_enabled";

                    var dhcpEnabledSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} DHCP Enabled", dhcpEnabledId, string.Empty, "mdi:lan", string.Empty, Name);
                    dhcpEnabledSensor.SetState(dhcpEnabled);

                    if (!Sensors.ContainsKey(dhcpEnabledId)) Sensors.Add(dhcpEnabledId, dhcpEnabledSensor);
                    else Sensors[dhcpEnabledId] = dhcpEnabledSensor;

                    // dhcp
                    var dhcps = new List<string>();
                    foreach (var dhcp in nicProperties.DhcpServerAddresses)
                    {
                        var dhcpAddress = dhcp.ToString();
                        if (!string.IsNullOrEmpty(dhcpAddress) && !dhcps.Contains(dhcpAddress)) dhcps.Add(dhcpAddress);
                    }

                    var dhcpList = JsonConvert.SerializeObject(dhcps);
                    var dhcpListId = $"{parentSensorSafeName}_{id}_dhcp_addresses";

                    var dhcpListSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} DHCP Addresses", dhcpListId, string.Empty, "mdi:lan", string.Empty, Name);
                    dhcpListSensor.SetState(dhcpList);

                    if (!Sensors.ContainsKey(dhcpListId)) Sensors.Add(dhcpListId, dhcpListSensor);
                    else Sensors[dhcpListId] = dhcpListSensor;

                    // dns enabled
                    var dnsEnabled = nicProperties.IsDnsEnabled ? "TRUE" : "FALSE";
                    var dnsEnabledId = $"{parentSensorSafeName}_{id}_dns_enabled";

                    var dnsEnabledSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} DNS Enabled", dnsEnabledId, string.Empty, "mdi:lan", string.Empty, Name);
                    dnsEnabledSensor.SetState(dnsEnabled);

                    if (!Sensors.ContainsKey(dnsEnabledId)) Sensors.Add(dnsEnabledId, dnsEnabledSensor);
                    else Sensors[dnsEnabledId] = dnsEnabledSensor;

                    // dns suffix
                    var dnsSuffix = nicProperties.DnsSuffix;
                    var dnsSuffixId = $"{parentSensorSafeName}_{id}_dns_suffix";

                    var dnsSuffixSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} DNS Suffix", dnsSuffixId, string.Empty, "mdi:lan", string.Empty, Name);
                    dnsSuffixSensor.SetState(dnsSuffix);

                    if (!Sensors.ContainsKey(dnsSuffixId)) Sensors.Add(dnsSuffixId, dnsSuffixSensor);
                    else Sensors[dnsSuffixId] = dnsSuffixSensor;

                    // dns
                    var dnses = new List<string>();
                    foreach (var dns in nicProperties.DnsAddresses)
                    {
                        var dnsAddress = dns.ToString();
                        if (!string.IsNullOrEmpty(dnsAddress) && !dnses.Contains(dnsAddress)) dnses.Add(dnsAddress);
                    }
                    
                    var dnsList = JsonConvert.SerializeObject(dnses);
                    var dnsListId = $"{parentSensorSafeName}_{id}_dns_addresses";

                    var dnsListSensor = new DataTypeStringSensor(_updateInterval, $"{Name} {name} DNS Addresses", dnsListId, string.Empty, "mdi:lan", string.Empty, Name);
                    dnsListSensor.SetState(dnsList);

                    if (!Sensors.ContainsKey(dnsListId)) Sensors.Add(dnsListId, dnsListSensor);
                    else Sensors[dnsListId] = dnsListSensor;

                    // nic count
                    nicCount++;
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[NETWORK] Error querying NIC: {msg}", ex.Message);
                }
            }

            // nic count
            var nicCountId = $"{parentSensorSafeName}_total_network_card_count";
            var nicCountSensor = new DataTypeIntSensor(_updateInterval, $"{Name} Network Card Count", nicCountId, string.Empty, "mdi:harddisk", string.Empty, Name);
            nicCountSensor.SetState(nicCount);

            if (!Sensors.ContainsKey(nicCountId)) Sensors.Add(nicCountId, nicCountSensor);
            else Sensors[nicCountId] = nicCountSensor;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig() => null;
    }
}
