using System;
using System.Text;
using SwitchToDesktopFromSlideshow.Events;
using SwitchToDesktopFromSlideshow.Interfaces;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow
{
    internal class Switcher : IDisposable
    {
        private enum MultiMonitorMode
        {
            Clone,
            Extend
        }

        private ISwitcherUI SwitcherUI { get; }

        private IHotkeyEventProvier HotkeyEventProvier { get; }

        public ISwitcherSettingsProvider SettingsProvider { get; }

        private SwitcherSettings Settings { get; set; }

        private bool Switching { get; set; }

        public Switcher(
            IHotkeyEventProvier hotkeyEventProvier,
            ISwitcherSettingsProvider settingsProvider,
            ISwitcherUI switcherUI
        )
        {
            this.HotkeyEventProvier = hotkeyEventProvier;
            this.SettingsProvider = settingsProvider;
            this.SwitcherUI = switcherUI;

            this.HotkeyEventProvier.HotkeyPressed += HotkeyEventProvier_HotkeyPressed;
            this.SettingsProvider.SwitcherSettingsChanged += SettingsProvider_SwitcherSettingsChanged;

            this.Settings = this.SettingsProvider.GetSwitcherSettings();
            this.RegisterHotkey();
        }

        private void RegisterHotkey() => this.HotkeyEventProvier.RegisterHotKey(id: 0, this.Settings.HotkeyModifiers, this.Settings.HotkeyKey);

        private void UnregisterHotkey() => this.HotkeyEventProvier.UnregisterHotKey(id: 0);

        private Rect SlideShowWndRect = default;

        private Rect PresenterViewWndRect = default;

        private void HotkeyEventProvier_HotkeyPressed(object sender, EventArgs e)
        {
            if (this.Switching) return;
            this.Switching = true;
            try
            {
                SwitchingCore(this.SwitcherUI);
            }
            finally { this.Switching = false; }
        }

        private void SwitchingCore(ISwitcherUI switcherUI = null, bool restoreOnly = false)
        {
            // Find slideshow window, and if not found then nothing to do.
            var hAppWnd = FindApplicationWindow();
            if (hAppWnd == IntPtr.Zero) return;
            var (hSlideShowWnd, hPresenterViewWnd) = FindSlideShowWindow();
            if (hSlideShowWnd == IntPtr.Zero) return;

            var visible = API.IsWindowVisible(hSlideShowWnd);
            var enablePresenterView = hPresenterViewWnd != IntPtr.Zero;

            if (restoreOnly && visible) return;

            // Hide or Show slide-show window.

            // Hide slideshow...
            if (visible)
            {
                // Minimize application window.
                API.ShowWindow(hAppWnd, ShowWindows.ShowMinNoActive);

                API.GetWindowRect(hSlideShowWnd, out SlideShowWndRect);
                if (enablePresenterView) API.GetWindowRect(hPresenterViewWnd, out PresenterViewWndRect);

                switcherUI?.OnBeforeSwitch(SlideShowWndRect.ToRectandle());

                SetWindowsShowing(ShowWindows.Hide, hSlideShowWnd, hPresenterViewWnd);
                API.SetForegroundWindow(API.GetDesktopWindow());

                switcherUI?.OnAfterSwitch();

                if (enablePresenterView) SwitchMultiMonitorMode(MultiMonitorMode.Clone);
            }

            // Restore slideshow...
            else
            {
                if (enablePresenterView) SwitchMultiMonitorMode(MultiMonitorMode.Extend);

                switcherUI?.OnBeforeSwitch(SlideShowWndRect.ToRectandle());

                SetWindowPos(hSlideShowWnd, SlideShowWndRect);
                if (enablePresenterView) SetWindowPos(hPresenterViewWnd, PresenterViewWndRect);

                SetWindowsShowing(ShowWindows.Show, hSlideShowWnd, hPresenterViewWnd);

                API.SetForegroundWindow(hSlideShowWnd);
                if (enablePresenterView) API.SetForegroundWindow(hPresenterViewWnd);

                switcherUI?.OnAfterSwitch();
            }
        }

        private void SetWindowPos(IntPtr hWnd, Rect rect)
        {
            if (rect.Top == 0 && rect.Bottom == 0) return;
            API.SetWindowPos(hWnd, IntPtr.Zero, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, SetWindowPosFlags.NoZOrder);
        }

        private void SetWindowsShowing(ShowWindows cmd, params IntPtr[] hWnds)
        {
            foreach (var hWnd in hWnds)
            {
                if (hWnd == IntPtr.Zero) continue;
                API.ShowWindow(hWnd, cmd);
            }
        }

        private (IntPtr hSlideShowWnd, IntPtr hPresenterViewWnd) FindSlideShowWindow()
        {
            var hSlideShowWnd = default(IntPtr);
            var hPresenterViewWnd = default(IntPtr);

            API.EnumWindows((IntPtr hWnd, IntPtr lparam) =>
            {
                // Find by Window Class Name...
                var className = new StringBuilder(50);
                API.GetClassName(hWnd, className, className.Capacity);
                if (className.ToString() != "screenClass") return true;

                // and detect Presenter View.
                var caption = new StringBuilder(400);
                API.GetWindowText(hWnd, caption, caption.Capacity);

                if (caption.ToString().EndsWith("Presenter View"))
                    hPresenterViewWnd = hWnd;
                else
                    hSlideShowWnd = hWnd;

                return hSlideShowWnd != IntPtr.Zero && hPresenterViewWnd != IntPtr.Zero ? false : true;
            }, IntPtr.Zero);

            return (hSlideShowWnd, hPresenterViewWnd);
        }

        private IntPtr FindApplicationWindow() => API.FindWindow(className: "PPTFrameClass", windowName: null);

        private void SwitchMultiMonitorMode(MultiMonitorMode mode)
        {

            if (this.Settings.AutoChangeMultiMonitorMode == false) return;

            switch (mode)
            {
                case MultiMonitorMode.Clone:
                    API.SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, SetDisplayConfigFlags.TopologyClone | SetDisplayConfigFlags.Apply);
                    break;
                case MultiMonitorMode.Extend:
                    API.SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, SetDisplayConfigFlags.TopologyExtend | SetDisplayConfigFlags.Apply);
                    break;
            }
        }

        private void SettingsProvider_SwitcherSettingsChanged(object sender, SwitcherSettingsChangedEventArgs args)
        {
            this.UnregisterHotkey();
            this.Settings = args.NewSettings;
            this.RegisterHotkey();
        }

        public void Dispose()
        {
            this.SettingsProvider.SwitcherSettingsChanged -= SettingsProvider_SwitcherSettingsChanged;
            this.HotkeyEventProvier.HotkeyPressed -= HotkeyEventProvier_HotkeyPressed;
            this.UnregisterHotkey();

            this.SwitchingCore(restoreOnly: true);
        }
    }
}
