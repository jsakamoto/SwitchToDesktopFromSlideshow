namespace SwitchToDesktopFromSlideshow.Forms
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.WinKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.CtrlKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.AltKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.KeysDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoChangeMultiMonitorModeCheckBox = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CANCELButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotkey";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WinKeyCheckBox
            // 
            this.WinKeyCheckBox.Location = new System.Drawing.Point(63, 12);
            this.WinKeyCheckBox.Name = "WinKeyCheckBox";
            this.WinKeyCheckBox.Size = new System.Drawing.Size(58, 23);
            this.WinKeyCheckBox.TabIndex = 1;
            this.WinKeyCheckBox.Text = "&Win +";
            this.WinKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShiftKeyCheckBox
            // 
            this.ShiftKeyCheckBox.Location = new System.Drawing.Point(127, 12);
            this.ShiftKeyCheckBox.Name = "ShiftKeyCheckBox";
            this.ShiftKeyCheckBox.Size = new System.Drawing.Size(58, 23);
            this.ShiftKeyCheckBox.TabIndex = 2;
            this.ShiftKeyCheckBox.Text = "&Shift +";
            this.ShiftKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // CtrlKeyCheckBox
            // 
            this.CtrlKeyCheckBox.Location = new System.Drawing.Point(191, 12);
            this.CtrlKeyCheckBox.Name = "CtrlKeyCheckBox";
            this.CtrlKeyCheckBox.Size = new System.Drawing.Size(58, 23);
            this.CtrlKeyCheckBox.TabIndex = 3;
            this.CtrlKeyCheckBox.Text = "&Ctrl +";
            this.CtrlKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AltKeyCheckBox
            // 
            this.AltKeyCheckBox.Location = new System.Drawing.Point(255, 12);
            this.AltKeyCheckBox.Name = "AltKeyCheckBox";
            this.AltKeyCheckBox.Size = new System.Drawing.Size(58, 23);
            this.AltKeyCheckBox.TabIndex = 4;
            this.AltKeyCheckBox.Text = "&Alt +";
            this.AltKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // KeysDropDown
            // 
            this.KeysDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeysDropDown.FormattingEnabled = true;
            this.KeysDropDown.Location = new System.Drawing.Point(314, 12);
            this.KeysDropDown.Name = "KeysDropDown";
            this.KeysDropDown.Size = new System.Drawing.Size(107, 23);
            this.KeysDropDown.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(427, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Key";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoChangeMultiMonitorModeCheckBox
            // 
            this.AutoChangeMultiMonitorModeCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.AutoChangeMultiMonitorModeCheckBox.Location = new System.Drawing.Point(12, 41);
            this.AutoChangeMultiMonitorModeCheckBox.Name = "AutoChangeMultiMonitorModeCheckBox";
            this.AutoChangeMultiMonitorModeCheckBox.Size = new System.Drawing.Size(323, 37);
            this.AutoChangeMultiMonitorModeCheckBox.TabIndex = 7;
            this.AutoChangeMultiMonitorModeCheckBox.Text = "Change &multi monitor settings of extend/dupulicate mode automatically when prese" +
    "nter view is enabled.";
            this.AutoChangeMultiMonitorModeCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.AutoChangeMultiMonitorModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(279, 87);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 27);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CANCELButton
            // 
            this.CANCELButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CANCELButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CANCELButton.Location = new System.Drawing.Point(372, 87);
            this.CANCELButton.Name = "CANCELButton";
            this.CANCELButton.Size = new System.Drawing.Size(87, 27);
            this.CANCELButton.TabIndex = 9;
            this.CANCELButton.Text = "Cancel";
            this.CANCELButton.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CANCELButton;
            this.ClientSize = new System.Drawing.Size(471, 126);
            this.Controls.Add(this.CANCELButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AutoChangeMultiMonitorModeCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeysDropDown);
            this.Controls.Add(this.AltKeyCheckBox);
            this.Controls.Add(this.CtrlKeyCheckBox);
            this.Controls.Add(this.ShiftKeyCheckBox);
            this.Controls.Add(this.WinKeyCheckBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Configuration - {0}";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox WinKeyCheckBox;
        private System.Windows.Forms.CheckBox ShiftKeyCheckBox;
        private System.Windows.Forms.CheckBox CtrlKeyCheckBox;
        private System.Windows.Forms.CheckBox AltKeyCheckBox;
        private System.Windows.Forms.ComboBox KeysDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AutoChangeMultiMonitorModeCheckBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CANCELButton;
    }
}

