using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace HASSAgent.Models.Mqtt.Commands
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class KeyCommand : AbstractCommand
    {
        internal const int KEYEVENTF_EXTENTEDKEY = 1;
        internal const int KEYEVENTF_KEYUP = 0;
        internal const int VK_MEDIA_NEXT_TRACK = 0xB0;
        internal const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        internal const int VK_MEDIA_PREV_TRACK = 0xB1;
        internal const int VK_VOLUME_MUTE = 0xAD;
        internal const int VK_VOLUME_UP = 0xAF;
        internal const int VK_VOLUME_DOWN = 0xAE;

        public byte KeyCode { get; set; }
        
        internal KeyCommand(byte keyCode, string name = "Key", Guid id = default) : base(name ?? "Key", id)
        {
            KeyCode = keyCode;
        }

        public override DiscoveryConfigModel GetAutoDiscoveryConfig()
        {
            return new CommandDiscoveryConfigModel
            {
                Name = Name,
                Unique_id = Id.ToString(),
                Availability_topic = $"homeassistant/sensor/{Variables.DeviceConfig.Name}/availability",
                Command_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/set",
                State_topic = $"homeassistant/{Domain}/{Variables.DeviceConfig.Name}/{ObjectId}/state",
                Device = Variables.DeviceConfig
            };
        }
        
        [DllImport("user32.dll")]
        internal static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public override string GetState()
        {
            return "OFF";
        }

        public override void TurnOff()
        {
            //
        }

        public override void TurnOn()
        {
            keybd_event(KeyCode, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }
    }
}
