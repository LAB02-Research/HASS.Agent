using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HASSAgent.Models.Mqtt
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class DiscoveryConfigModel
    {
        /// <summary>
        /// (Optional) Information about the device this sensor is a part of to tie it into the device registry. Only works through MQTT discovery and when unique_id is set.
        /// </summary>
        /// <value></value>
        public DeviceConfigModel Device { get; set; }
        /// <summary>
        /// (Optional) The name of the MQTT sensor. Defaults to MQTT Sensor in hass.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// The MQTT topic subscribed to receive sensor values.
        /// </summary>
        /// <value></value>
        public string State_topic { get; set; }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SensorDiscoveryConfigModel : DiscoveryConfigModel
    {
        /// <summary>
        /// (Optional) The MQTT topic subscribed to receive availability (online/offline) updates.
        /// </summary>
        /// <value></value>
        public string Availability_topic { get; set; }
        /// <summary>
        /// (Optional) The type/class of the sensor to set the icon in the frontend. See https://www.home-assistant.io/integrations/sensor/#device-class for options.
        /// </summary>
        /// <value></value>
        public string Device_class { get; set; }
        /// <summary>
        /// (Optional) Defines the number of seconds after the sensor’s state expires, if it’s not updated. After expiry, the sensor’s state becomes unavailable. Defaults to 0 in hass.
        /// </summary>
        /// <value></value>
        public int? Expire_after { get; set; }
        /// <summary>
        /// Sends update events even if the value hasn’t changed. Useful if you want to have meaningful value graphs in history.
        /// </summary>
        /// <value></value>
        public bool? Force_update { get; set; }

        /// <summary>
        /// (Optional) The icon for the sensor.
        /// </summary>
        /// <value></value>
        public string Icon { get; set; }
        /// <summary>
        /// (Optional) Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic.
        /// </summary>
        /// <value></value>
        public string Json_attributes_template { get; set; }
        /// <summary>
        /// (Optional) The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Implies force_update of the current sensor state when a message is received on this topic.
        /// </summary>
        /// <value></value>
        public string Json_attributes_topic { get; set; }
        /// <summary>
        /// (Optional) The payload that represents the available state.
        /// </summary>
        /// <value></value>
        public string Payload_available { get; set; }
        /// <summary>
        /// (Optional) The payload that represents the unavailable state.
        /// </summary>
        /// <value></value>
        public string Payload_not_available { get; set; }
        /// <summary>
        /// (Optional) The maximum QoS level of the state topic.
        /// </summary>
        /// <value></value>
        public int? Qos { get; set; }
        /// <summary>
        /// (Optional) An ID that uniquely identifies this sensor. If two sensors have the same unique ID, Home Assistant will raise an exception.
        /// </summary>
        /// <value></value>
        public string Unique_id { get; set; }
        /// <summary>
        /// (Optional) Defines the units of measurement of the sensor, if any.
        /// </summary>
        /// <value></value>
        public string Unit_of_measurement { get; set; }
        /// <summary>
        /// (Optional) Defines a template to extract the value.
        /// </summary>
        /// <value></value>
        public string Value_template { get; set; }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CommandDiscoveryConfigModel : DiscoveryConfigModel
    {
        /// <summary>
        /// (Optional) The MQTT topic subscribed to receive availability (online/offline) updates.
        /// </summary>
        /// <value></value>
        public string Availability_topic { get; set; }
        /// <summary>
        /// (Optional) The MQTT topic to set the command
        /// </summary>
        /// <value></value>
        public string Command_topic { get; set; }
        /// <summary>
        /// (Optional) The type/class of the sensor to set the icon in the frontend. See https://www.home-assistant.io/integrations/sensor/#device-class for options.
        /// </summary>
        /// <value></value>
        public string Device_class { get; set; }

        /// <summary>
        /// Sends update events even if the value hasn’t changed. Useful if you want to have meaningful value graphs in history.
        /// </summary>
        /// <value></value>
        public bool? Force_update { get; set; }

        /// <summary>
        /// (Optional) The icon for the sensor.
        /// </summary>
        /// <value></value>
        public string Icon { get; set; }
        /// <summary>
        /// (Optional) Defines a template to extract the JSON dictionary from messages received on the json_attributes_topic.
        /// </summary>
        /// <value></value>
        public string Json_attributes_template { get; set; }
        /// <summary>
        /// (Optional) The MQTT topic subscribed to receive a JSON dictionary payload and then set as sensor attributes. Implies force_update of the current sensor state when a message is received on this topic.
        /// </summary>
        /// <value></value>
        public string Json_attributes_topic { get; set; }
        /// <summary>
        /// (Optional) The payload that represents the available state.
        /// </summary>
        /// <value></value>
        public string Payload_available { get; set; }
        /// <summary>
        /// (Optional) The payload that represents the unavailable state.
        /// </summary>
        /// <value></value>
        public string Payload_not_available { get; set; }
        /// <summary>
        /// (Optional) The maximum QoS level of the state topic.
        /// </summary>
        /// <value></value>
        public int? Qos { get; set; }
        /// <summary>
        /// (Optional) An ID that uniquely identifies this sensor. If two sensors have the same unique ID, Home Assistant will raise an exception.
        /// </summary>
        /// <value></value>
        public string Unique_id { get; set; }
        /// <summary>
        /// (Optional) Defines a template to extract the value.
        /// </summary>
        /// <value></value>
        public string Value_template { get; set; }
    }
    
    /// <summary>
    /// This information will be used when announcing this device on the mqtt topic
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DeviceConfigModel
    {
        /// <summary>
        /// (Optional) A list of connections of the device to the outside world as a list of tuples [connection_type, connection_identifier]. For example the MAC address of a network interface: "connections": [["mac", "02:5b:26:a8:dc:12"]].
        /// </summary>
        /// <value></value>
        public ICollection<Tuple<string, string>> Connections { get; set; }
        /// <summary>
        /// (Optional) An Id to identify the device. For example a serial number.
        /// </summary>
        /// <value></value>
        public string Identifiers { get; set; }
        /// <summary>
        /// (Optional) The manufacturer of the device.
        /// </summary>
        /// <value></value>
        public string Manufacturer { get; set; }
        /// <summary>
        /// (Optional) The model of the device.
        /// </summary>
        /// <value></value>
        public string Model { get; set; }
        /// <summary>
        /// (Optional) The name of the device.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// (Optional) The firmware version of the device.
        /// </summary>
        /// <value></value>
        public string Sw_version { get; set; }
        /// <summary>
        /// (Optional) Identifier of a device that routes messages between this device and Home Assistant. Examples of such devices are hubs, or parent devices of a sub-device. This is used to show device topology in Home Assistant.
        /// </summary>
        /// <value></value>
        public string Via_device { get; set; }
    }
}
