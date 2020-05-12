using System;
using System.Drawing;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow.Forms
{
    public partial class ConfigurationForm : Form
    {
        private SwitcherSettings Settings { get; }

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        public ConfigurationForm(SwitcherSettings settings, Point desieredLocation)
        {
            InitializeComponent();

            this.Text = string.Format(this.Text, AppInfo.AppTitle);

            this.Settings = settings;
            this.WinKeyCheckBox.Checked = this.Settings.HotkeyModifiers.HasFlag(KeyModifiers.Win);
            this.ShiftKeyCheckBox.Checked = this.Settings.HotkeyModifiers.HasFlag(KeyModifiers.Shift);
            this.CtrlKeyCheckBox.Checked = this.Settings.HotkeyModifiers.HasFlag(KeyModifiers.Ctrl);
            this.AltKeyCheckBox.Checked = this.Settings.HotkeyModifiers.HasFlag(KeyModifiers.Alt);

            this.KeysDropDown.Items.AddRange(GetKeys());
            this.KeysDropDown.SelectedItem = this.Settings.HotkeyKey;

            this.AutoChangeMultiMonitorModeCheckBox.Checked = this.Settings.AutoChangeMultiMonitorMode;

            this.AdjustWindowLocation(desieredLocation);
        }

        private void AdjustWindowLocation(Point desieredLocation)
        {
            var area = Screen.GetWorkingArea(desieredLocation);
            area.Inflate(-16, -16);
            this.Location = new Point(
                Math.Min(Math.Max(area.Left, desieredLocation.X - this.Width / 2), area.Right - this.Width),
                Math.Min(Math.Max(area.Top, desieredLocation.Y - this.Height / 2), area.Bottom - this.Height));
        }

        private object[] GetKeys()
        {
            return new object[] {
                #region Numbers
		        Keys.D0,
                Keys.D1,
                Keys.D2,
                Keys.D3,
                Keys.D4,
                Keys.D5,
                Keys.D6,
                Keys.D7,
                Keys.D8,
                Keys.D9,
                #endregion

                #region Alphabets
                Keys.A,
                Keys.B,
                Keys.C,
                Keys.D,
                Keys.E,
                Keys.F,
                Keys.G,
                Keys.H,
                Keys.I,
                Keys.J,
                Keys.K,
                Keys.L,
                Keys.M,
                Keys.N,
                Keys.O,
                Keys.P,
                Keys.Q,
                Keys.R,
                Keys.S,
                Keys.T,
                Keys.U,
                Keys.V,
                Keys.W,
                Keys.X,
                Keys.Y,
                Keys.Z,
                #endregion

                #region Function Keys
                Keys.F1,
                Keys.F2,
                Keys.F3,
                Keys.F4,
                Keys.F5,
                Keys.F6,
                Keys.F7,
                Keys.F8,
                Keys.F9,
                Keys.F10,
                Keys.F11,
                Keys.F12,
                Keys.F13,
                Keys.F14,
                Keys.F15,
                Keys.F16,
                #endregion

                #region Special Characters
                Keys.Space,
                Keys.Tab,
                Keys.Escape,
                Keys.Enter,
                Keys.Back,
                Keys.Delete,
                Keys.Insert,
                #endregion

                #region Cursor Control
                Keys.Left,
                Keys.Right,
                Keys.Up,
                Keys.Down,
                Keys.PageUp,
                Keys.PageDown,
                Keys.Home,
                Keys.End,
                #endregion

                #region Others
                Keys.PrintScreen,
                Keys.Scroll,
                Keys.NumLock,
                Keys.CapsLock
                #endregion
            };
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Settings.HotkeyModifiers =
                (this.WinKeyCheckBox.Checked ? KeyModifiers.Win : 0) |
                (this.ShiftKeyCheckBox.Checked ? KeyModifiers.Shift : 0) |
                (this.CtrlKeyCheckBox.Checked ? KeyModifiers.Ctrl : 0) |
                (this.AltKeyCheckBox.Checked ? KeyModifiers.Alt : 0);

            this.Settings.HotkeyKey = (Keys)this.KeysDropDown.SelectedItem;

            this.Settings.AutoChangeMultiMonitorMode = this.AutoChangeMultiMonitorModeCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
