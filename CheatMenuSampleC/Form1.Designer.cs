namespace CheatMenuSampleC
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelFX3 = new MakeMenuLib.PanelFX();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.LogTextBox = new MakeMenuLib.CustomTextBox();
            this.GunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.GunaLabel18 = new Guna.UI.WinForms.GunaLabel();
            this.PanelFX1 = new MakeMenuLib.PanelFX();
            this.PanelFX2 = new MakeMenuLib.PanelFX();
            this.GunaResizeControl1 = new Guna.UI.WinForms.GunaResizeControl();
            this.GunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.GunaPanel2 = new Guna.UI.WinForms.GunaPanel();
            this.MenuStripZ1 = new MakeMenuLib.CustomWindowsForm.MenuStripZ();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new Guna.UI.WinForms.GunaLabel();
            this.GunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.PanelFX3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.GunaPanel1.SuspendLayout();
            this.PanelFX1.SuspendLayout();
            this.MenuStripZ1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelFX3
            // 
            this.PanelFX3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFX3.Controls.Add(this.Panel2);
            this.PanelFX3.Controls.Add(this.GunaPanel1);
            this.PanelFX3.DoubleBuffered = true;
            this.PanelFX3.Location = new System.Drawing.Point(339, 12);
            this.PanelFX3.Name = "PanelFX3";
            this.PanelFX3.PreventFlickering = true;
            this.PanelFX3.Size = new System.Drawing.Size(429, 179);
            this.PanelFX3.TabIndex = 4;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Panel2.Controls.Add(this.LogTextBox);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 19);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(427, 158);
            this.Panel2.TabIndex = 2;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.White;
            this.LogTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(427, 158);
            this.LogTextBox.TabIndex = 0;
            // 
            // GunaPanel1
            // 
            this.GunaPanel1.BackColor = System.Drawing.Color.Red;
            this.GunaPanel1.Controls.Add(this.GunaLabel18);
            this.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.GunaPanel1.Name = "GunaPanel1";
            this.GunaPanel1.Size = new System.Drawing.Size(427, 19);
            this.GunaPanel1.TabIndex = 1;
            // 
            // GunaLabel18
            // 
            this.GunaLabel18.AutoSize = true;
            this.GunaLabel18.BackColor = System.Drawing.Color.Transparent;
            this.GunaLabel18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GunaLabel18.ForeColor = System.Drawing.Color.White;
            this.GunaLabel18.Location = new System.Drawing.Point(2, 3);
            this.GunaLabel18.Name = "GunaLabel18";
            this.GunaLabel18.Size = new System.Drawing.Size(26, 13);
            this.GunaLabel18.TabIndex = 1;
            this.GunaLabel18.Text = "Log";
            // 
            // PanelFX1
            // 
            this.PanelFX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.PanelFX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFX1.Controls.Add(this.PanelFX2);
            this.PanelFX1.Controls.Add(this.GunaResizeControl1);
            this.PanelFX1.Controls.Add(this.GunaSeparator1);
            this.PanelFX1.Controls.Add(this.GunaPanel2);
            this.PanelFX1.Controls.Add(this.MenuStripZ1);
            this.PanelFX1.Controls.Add(this.Panel1);
            this.PanelFX1.DoubleBuffered = true;
            this.PanelFX1.Location = new System.Drawing.Point(12, 12);
            this.PanelFX1.Name = "PanelFX1";
            this.PanelFX1.PreventFlickering = true;
            this.PanelFX1.Size = new System.Drawing.Size(321, 566);
            this.PanelFX1.TabIndex = 6;
            // 
            // PanelFX2
            // 
            this.PanelFX2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelFX2.DoubleBuffered = true;
            this.PanelFX2.Location = new System.Drawing.Point(0, 125);
            this.PanelFX2.Name = "PanelFX2";
            this.PanelFX2.PreventFlickering = true;
            this.PanelFX2.Size = new System.Drawing.Size(319, 421);
            this.PanelFX2.TabIndex = 6;
            // 
            // GunaResizeControl1
            // 
            this.GunaResizeControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GunaResizeControl1.ForeColor = System.Drawing.Color.White;
            this.GunaResizeControl1.ForeColorDepth = 255;
            this.GunaResizeControl1.Location = new System.Drawing.Point(0, 546);
            this.GunaResizeControl1.Name = "GunaResizeControl1";
            this.GunaResizeControl1.Size = new System.Drawing.Size(319, 18);
            this.GunaResizeControl1.TabIndex = 7;
            this.GunaResizeControl1.TargetControl = this;
            // 
            // GunaSeparator1
            // 
            this.GunaSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.GunaSeparator1.Location = new System.Drawing.Point(0, 109);
            this.GunaSeparator1.Name = "GunaSeparator1";
            this.GunaSeparator1.Size = new System.Drawing.Size(319, 10);
            this.GunaSeparator1.TabIndex = 4;
            // 
            // GunaPanel2
            // 
            this.GunaPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GunaPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GunaPanel2.BackgroundImage")));
            this.GunaPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GunaPanel2.Location = new System.Drawing.Point(-1, 48);
            this.GunaPanel2.Name = "GunaPanel2";
            this.GunaPanel2.Size = new System.Drawing.Size(321, 55);
            this.GunaPanel2.TabIndex = 5;
            // 
            // MenuStripZ1
            // 
            this.MenuStripZ1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.MenuStripZ1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem});
            this.MenuStripZ1.Location = new System.Drawing.Point(0, 21);
            this.MenuStripZ1.Name = "MenuStripZ1";
            this.MenuStripZ1.Size = new System.Drawing.Size(319, 24);
            this.MenuStripZ1.TabIndex = 3;
            this.MenuStripZ1.Text = "MenuStripZ1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UnloadToolStripMenuItem});
            this.MenuToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuToolStripMenuItem.Text = "Menu";
            // 
            // UnloadToolStripMenuItem
            // 
            this.UnloadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.UnloadToolStripMenuItem.Name = "UnloadToolStripMenuItem";
            this.UnloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.UnloadToolStripMenuItem.Text = "Unload";
            this.UnloadToolStripMenuItem.Click += new System.EventHandler(this.UnloadToolStripMenuItem_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Red;
            this.Panel1.Controls.Add(this.CloseButton);
            this.Panel1.Controls.Add(this.GunaLabel1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(319, 21);
            this.Panel1.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Font = new System.Drawing.Font("Verdana", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CloseButton.Location = new System.Drawing.Point(301, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(15, 14);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "X";
            // 
            // GunaLabel1
            // 
            this.GunaLabel1.AutoSize = true;
            this.GunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.GunaLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.GunaLabel1.ForeColor = System.Drawing.Color.White;
            this.GunaLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GunaLabel1.Location = new System.Drawing.Point(3, 1);
            this.GunaLabel1.Name = "GunaLabel1";
            this.GunaLabel1.Size = new System.Drawing.Size(131, 17);
            this.GunaLabel1.TabIndex = 3;
            this.GunaLabel1.Text = "Cheat Menu Example";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(780, 590);
            this.Controls.Add(this.PanelFX1);
            this.Controls.Add(this.PanelFX3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(339, 12);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelFX3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.GunaPanel1.ResumeLayout(false);
            this.GunaPanel1.PerformLayout();
            this.PanelFX1.ResumeLayout(false);
            this.PanelFX1.PerformLayout();
            this.MenuStripZ1.ResumeLayout(false);
            this.MenuStripZ1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal MakeMenuLib.PanelFX PanelFX3;
        internal System.Windows.Forms.Panel Panel2;
        internal MakeMenuLib.CustomTextBox LogTextBox;
        internal Guna.UI.WinForms.GunaPanel GunaPanel1;
        internal Guna.UI.WinForms.GunaLabel GunaLabel18;
        internal MakeMenuLib.PanelFX PanelFX1;
        internal MakeMenuLib.PanelFX PanelFX2;
        internal Guna.UI.WinForms.GunaResizeControl GunaResizeControl1;
        internal Guna.UI.WinForms.GunaSeparator GunaSeparator1;
        internal Guna.UI.WinForms.GunaPanel GunaPanel2;
        internal MakeMenuLib.CustomWindowsForm.MenuStripZ MenuStripZ1;
        internal System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem UnloadToolStripMenuItem;
        internal System.Windows.Forms.Panel Panel1;
        internal Guna.UI.WinForms.GunaLabel CloseButton;
        internal Guna.UI.WinForms.GunaLabel GunaLabel1;
    }
}

