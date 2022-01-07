namespace HASSAgent.Models.HomeAssistant.Sensors.GeneralSensors.MultiValue.DataTypes
{
    public class DataTypeStringSensor : AbstractSingleValueSensor
    {
        private readonly string _deviceClass;
        private readonly string _unitOfMeasurement;
        private readonly string _icon;

        private string _value = string.Empty;

        public DataTypeStringSensor(int? updateInterval, string name, string id, string deviceClass, string icon, string unitOfMeasurement, string multiValueSensorName) : base(name, updateInterval ?? 30, id)
        {
            TopicName = multiValueSensorName;

            _deviceClass = deviceClass;
            _unitOfMeasurement = unitOfMeasurement;
            _icon = icon;

            ObjectId = id;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            if (AutoDiscoveryConfigModel != null) return AutoDiscoveryConfigModel;

            var model = new SensorDiscoveryConfigModel()
            {
                Name = Name,
                Unique_id = Id,
                Device = Variables.DeviceConfig,
                State_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{TopicName}/{ObjectId}/state",
                Availability_topic = $"{Variables.AppSettings.MqttDiscoveryPrefix}/{Domain}/{Variables.DeviceConfig.Name}/{TopicName}/availability"
            };

            if (!string.IsNullOrWhiteSpace(_deviceClass)) model.Device_class = _deviceClass;
            if (!string.IsNullOrWhiteSpace(_unitOfMeasurement)) model.Unit_of_measurement = _unitOfMeasurement;
            if (!string.IsNullOrWhiteSpace(_icon)) model.Icon = _icon;

            return SetAutoDiscoveryConfigModel(model);
        }

        public void SetState(string value) => _value = value;

        public override string GetState() => _value;
    }
}
