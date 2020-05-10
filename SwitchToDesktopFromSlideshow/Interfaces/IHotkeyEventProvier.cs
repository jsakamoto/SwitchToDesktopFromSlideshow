using System;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow.Interfaces
{
    public interface IHotkeyEventProvier
    {
        event EventHandler HotkeyPressed;

        void RegisterHotKey(int id, KeyModifiers keyModifiers, Keys key);

        void UnregisterHotKey(int id);
    }
}
