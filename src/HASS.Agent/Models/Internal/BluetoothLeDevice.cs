using Windows.Devices.Bluetooth;

namespace HASS.Agent.Models.Internal
{
    public class BluetoothLeDeviceCollection
    {
        public BluetoothLeDeviceCollection()
        {
            //
        }

        public BluetoothLeDeviceCollection(List<BluetoothLeDevice> bluetoothLeDevices)
        {
            foreach (var bluetoothLeDevice in bluetoothLeDevices) BluetoothLeDevices.Add(bluetoothLeDevice);
        }

        public List<BluetoothLeDevice> BluetoothLeDevices { get; set; } = new();
    }

    public class BluetoothLeDevice
    {
        public BluetoothLeDevice()
        {
            //
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Connected { get; set; }
        public DateTime LastSeenUtc { get; set; }
    }
}
