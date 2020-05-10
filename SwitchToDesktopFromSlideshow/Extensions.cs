using System.Drawing;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Properties;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow
{
    internal static class Extensions
    {
        public static SwitcherSettings ToSwitcherSettings(this Settings settings)
        {
            return new SwitcherSettings
            {
                HotkeyKey = (Keys)settings.HotkeyKey,
                HotkeyModifiers = (KeyModifiers)settings.HotkeyModifiers,
                AutoChangeMultiMonitorMode = settings.AutoChangeMultiMonitorMode
            };
        }

        public static void Apply(this SwitcherSettings switcherSettings, Settings settings)
        {
            settings.HotkeyKey = (int)switcherSettings.HotkeyKey;
            settings.HotkeyModifiers = (int)switcherSettings.HotkeyModifiers;
            settings.AutoChangeMultiMonitorMode = switcherSettings.AutoChangeMultiMonitorMode;
        }

        public static Rectangle ToRectandle(this ref Rect rect)
        {
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }
    }
}
