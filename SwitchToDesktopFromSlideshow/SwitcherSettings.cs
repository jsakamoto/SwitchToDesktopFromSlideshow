using System.Linq;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow
{
    public class SwitcherSettings
    {
        public KeyModifiers HotkeyModifiers { get; set; }

        public Keys HotkeyKey { get; set; }

        public bool AutoChangeMultiMonitorMode { get; set; }

        public string GetHotkeyText()
        {
            var keyTexts = new[] {
                this.HotkeyModifiers.HasFlag(KeyModifiers.Win) ? KeyModifiers.Win.ToString() : "",
                this.HotkeyModifiers.HasFlag(KeyModifiers.Shift) ? KeyModifiers.Shift.ToString() : "",
                this.HotkeyModifiers.HasFlag(KeyModifiers.Ctrl) ? KeyModifiers.Ctrl.ToString() : "",
                this.HotkeyModifiers.HasFlag(KeyModifiers.Alt) ? KeyModifiers.Alt.ToString() : "",
                HotkeyKey.ToString()
            }
            .Where(t => t != "")
            .ToArray();

            return string.Join(" + ", keyTexts);
        }

        public SwitcherSettings Clone()
        {
            return new SwitcherSettings
            {
                HotkeyModifiers = this.HotkeyModifiers,
                HotkeyKey = this.HotkeyKey,
                AutoChangeMultiMonitorMode = this.AutoChangeMultiMonitorMode
            };
        }
    }
}
