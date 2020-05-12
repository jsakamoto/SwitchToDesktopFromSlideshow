namespace SwitchToDesktopFromSlideshow.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurationMenuItem,
            this.ExitMenuItem});
            this.NotifyIconContextMenu.Name = "ContextMenuStrip";
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(158, 48);
            // 
            // ConfigurationMenuItem
            // 
            this.ConfigurationMenuItem.Name = "ConfigurationMenuItem";
            this.ConfigurationMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ConfigurationMenuItem.Text = "&Configuration...";
            this.ConfigurationMenuItem.Click += new System.EventHandler(this.ConfigurationMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Switch to Desktop from Slideshow";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 122);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "{0}";
            this.NotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}