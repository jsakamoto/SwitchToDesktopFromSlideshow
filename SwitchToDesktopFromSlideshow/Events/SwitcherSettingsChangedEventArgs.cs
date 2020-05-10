using System;

namespace SwitchToDesktopFromSlideshow.Events
{
    public class SwitcherSettingsChangedEventArgs : EventArgs
    {
        public SwitcherSettings NewSettings { get; }

        public SwitcherSettingsChangedEventArgs(SwitcherSettings newSettings)
        {
            NewSettings = newSettings;
        }
    }
}
