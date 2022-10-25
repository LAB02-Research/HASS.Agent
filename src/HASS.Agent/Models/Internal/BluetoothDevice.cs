using HASS.Agent.Shared.Models.Internal;
using Windows.Devices.Enumeration;

namespace HASS.Agent.Models.Internal
{
    public class BluetoothDeviceCollection
    {
        public BluetoothDeviceCollection()
        {
            //
        }

        public BluetoothDeviceCollection(List<BluetoothDevice> bluetoothDevices)
        {
            foreach (var bluetoothDevice in bluetoothDevices) BluetoothDevices.Add(bluetoothDevice);
        }

        public List<BluetoothDevice> BluetoothDevices { get; set; } = new();
    }

    public class BluetoothDevice
    {
        public BluetoothDevice()
        {
            //
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public bool Paired { get; set; }
        public bool Connected { get; set; }
        public DateTime LastSeenUtc { get; set; }
    }
}
