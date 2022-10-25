using Windows.Devices.Bluetooth;
using Serilog;
using Windows.Devices.Enumeration;
using BluetoothDevice = HASS.Agent.Models.Internal.BluetoothDevice;
using WindowsBluetoothDevice = Windows.Devices.Bluetooth.BluetoothDevice;
using Windows.Devices.Bluetooth.Advertisement;
using HASS.Agent.Models.Internal;
using System.Threading.Tasks;

namespace HASS.Agent.Managers
{
    internal static class BluetoothManager
    {
        private static readonly SemaphoreSlim Semaphore = new(1, 1);

        private static BluetoothLEAdvertisementWatcher _leWatcher;
        private static readonly List<BluetoothLeDevice> DetectedLeDevices = new();
        private static bool _isWatchingLeDevices;

        /// <summary>
        /// Gets all known (connected) bluetooth devices
        /// </summary>
        /// <returns></returns>
        internal static async Task<List<BluetoothDevice>> GetDevicesAsync()
        {
            try
            {
                // first get all paired devices
                var pairedBluetoothDevices = await DeviceInformation.FindAllAsync(WindowsBluetoothDevice.GetDeviceSelectorFromPairingState(true));
                var devices = pairedBluetoothDevices.Select(pairedDevice => new BluetoothDevice { Id = pairedDevice.Id, Name = pairedDevice.Name, Paired = pairedDevice.Pairing.IsPaired, Connected = false, Kind = pairedDevice.Kind.ToString(), LastSeenUtc = DateTime.UtcNow}).ToList();

                // then get all connected devices
                var connectedBluetoothDevices = await DeviceInformation.FindAllAsync(WindowsBluetoothDevice.GetDeviceSelectorFromConnectionStatus(BluetoothConnectionStatus.Connected));
                foreach (var connectedDevice in connectedBluetoothDevices)
                {
                    // do we have it already?
                    if (devices.Any(x => x.Id == connectedDevice.Id))
                    {
                        // set it to connected
                        devices.Find(x => x.Id == connectedDevice.Id)!.Connected = true;
                        continue;
                    }

                    // add new one
                    var device = new BluetoothDevice
                    {
                        Id = connectedDevice.Id,
                        Name = connectedDevice.Name,
                        Paired = connectedDevice.Pairing.IsPaired,
                        Connected = true
                    };

                    devices.Add(device);
                }

                // done
                return devices;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BLUETOOTH] Error getting devices: {err}", ex.Message);
                return new List<BluetoothDevice>();
            }
        }

        /// <summary>
        /// Initialises the LE scanner
        /// </summary>
        internal static void StartWatchingForLeDevices()
        {
            if (_isWatchingLeDevices) return;

            try
            {
                _isWatchingLeDevices = true;

                _leWatcher = new BluetoothLEAdvertisementWatcher
                {
                    ScanningMode = BluetoothLEScanningMode.Active
                };

                _leWatcher.Received += ScanOnReceived;
                _leWatcher.Stopped += ScanOnStopped;

                _leWatcher.Start();

                Log.Information("[BLUETOOTH] LE scanner started");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BLUETOOTH] Error starting LE scanner: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Stops the LE scanner
        /// </summary>
        internal static void StopLeScan()
        {
            if (!_isWatchingLeDevices) return;

            try
            {
                _isWatchingLeDevices = false;
                _leWatcher.Stop();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BLUETOOTH] Error stopping LE scanner: {err}", ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of all detected LE devices since the last retrieval (unless clearList is set to false)
        /// </summary>
        /// <param name="clearList"></param>
        /// <returns></returns>
        internal static async Task<List<BluetoothLeDevice>> GetDetectedLeDevicesAsync(bool clearList = true)
        {
            try
            {
                // wait for the semaphore
                await Semaphore.WaitAsync(TimeSpan.FromSeconds(5));

                // make a copy of the devices
                var deviceList = DetectedLeDevices.ToList();

                // if requested, clear the current list
                if (clearList) DetectedLeDevices.Clear();

                // release our semaphore
                Semaphore?.Release();

                // done
                return deviceList;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BLUETOOTH] Error retrieving LE devices: {err}", ex.Message);
                return new List<BluetoothLeDevice>();
            }
        }

        private static void ScanOnStopped(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementWatcherStoppedEventArgs args)
        {
            Log.Information("[BLUETOOTH] LE scanner stopped");
        }

        private static async void ScanOnReceived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            try
            {
                // fetch the device based on its address
                using var device = await BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress);
                if (device == null) return;

                // do we already have it?
                if (DetectedLeDevices.Any(x => x.Id == device.DeviceId))
                {
                    // just update lastseen
                    DetectedLeDevices.Find(x => x.Id == device.DeviceId)!.LastSeenUtc = DateTime.UtcNow;
                    return;
                }

                // prepare the device
                var leDevice = new BluetoothLeDevice
                {
                    Id = device.DeviceId,
                    Name = device.Name,
                    Connected = device.ConnectionStatus == BluetoothConnectionStatus.Connected,
                    LastSeenUtc = DateTime.UtcNow
                };

                // wait for the semaphore
                await Semaphore.WaitAsync(TimeSpan.FromSeconds(5));

                // add it to the list
                DetectedLeDevices.Add(leDevice);

                // done, release our semaphore
                Semaphore?.Release();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[BLUETOOTH] Error processing LE device: {err}", ex.Message);
            }
        }
    }
}
