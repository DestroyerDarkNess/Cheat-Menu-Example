using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MakeMenuLib;
using System.IO;
using System.Diagnostics;

namespace CheatMenuSampleC
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// //////////////////////// Pinvoke
        /// </summary>
        /// 

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport("user32.dll")]
        static extern int ShowCursor(bool bShow);


        /// <summary>
        /// //////////////////////// No windows focus
        /// </summary>
        /// 

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private const int WS_EX_TOPMOST = 0x8;

        private const int WS_THICKFRAME = 0x40000;
        private const int WS_CHILD = 0x40000000;
        private const int WS_EX_NOACTIVATE = 0x8000000;
        private const int WS_EX_TOOLWINDOW = 0x80;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParamsA = base.CreateParams;
                createParamsA.ExStyle = createParamsA.ExStyle | WS_EX_TOPMOST | WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return createParamsA;
            }
        }


        /// <summary>
        /// //////////////////////// Declare
        /// </summary>
        /// 

        public string ProcessGameN = "Notepad.exe";
        private MakeMenuLib.Overlay AttachClienGame;
        private bool VisibleMenu = false;
        private Keys KeyShowMenu = Keys.Insert;
        private string UserName = Environment.UserName;

        public Form1()
        {
            InitializeComponent();
            AttachClienGame = new MakeMenuLib.Overlay(ProcessGameN, this);

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LogTextBox.BackColor = Color.FromArgb(40, Color.FromArgb(25, 25, 25));
            ManagementMenu();
            this.InitializeDrag();
            WriteLog("Cheat Menu Example [Versión 1.0.0]", false);
            WriteLog("Welcome " + UserName + ", I enjoy the Cheat!");
        }

        /// <summary>
        /// //////////////////////// ToolStripMenu
        /// </summary>
        /// 

        private void UnloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// ////////////////////////  Show Or Hide Menu
        /// </summary>
        /// 

        private static System.Windows.Forms.Timer TimerShowHideMenu = new System.Windows.Forms.Timer() { Enabled = true, Interval = 50 };

        private void ManagementMenu()
        {
            TimerShowHideMenu.Tick += new System.EventHandler(TimerShowHideMenu_Tick);
        }

        private void TimerShowHideMenu_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(KeyShowMenu) == Int16.MinValue)
            {
                if (VisibleMenu == false)
                {
                    ShowMenu(true);
                    return;
                }
                if (VisibleMenu == true)
                {
                    ShowMenu(false);
                    return;
                }
            }
            Process[] GameProcess = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ProcessGameN));
            if (GameProcess.Count() == 0)
                this.Close();
        }

        private void ShowMenu(bool ShowOrHide)
        {
            this.TopMost = ShowOrHide;
            VisibleMenu = ShowOrHide;
            ShowCursor(ShowOrHide);
            if (ShowOrHide == true)
                this.Show();
            else
                this.Hide();
        }


        /// <summary>
        /// ////////////////////////  Dragger - Minimize
        /// </summary>
        /// 
        
        private void InitializeDrag()
        {
            // ----------------------------------------------------
            // PanelFX1 Moving | Main Cheats
            // ----------------------------------------------------
           MakeMenuLib.MiscFunc.InitializeDrag(PanelFX2, PanelFX1);
            MakeMenuLib.MiscFunc.InitializeDrag(GunaLabel1, PanelFX1);
            MakeMenuLib.MiscFunc.InitializeDrag(GunaPanel2, PanelFX1);
            MakeMenuLib.MiscFunc.InitializeDrag(GunaSeparator1, PanelFX1);
            MakeMenuLib.MiscFunc.InitializeDrag(Panel1, PanelFX1);

            // ----------------------------------------------------
            // PanelFX3 Moving | LOG
            // ----------------------------------------------------

            MakeMenuLib.MiscFunc.InitializeDrag(Panel2, PanelFX3);
            MakeMenuLib.MiscFunc.InitializeDrag(GunaPanel1, PanelFX3);
            MakeMenuLib.MiscFunc.InitializeDrag(GunaLabel18, PanelFX1);
            MakeMenuLib.MiscFunc.InitializeDrag(LogTextBox, PanelFX3);
            
        }

        /// <summary>
        /// ////////////////////////  LogSystem
        /// </summary>
        /// 
        
            public enum InfoType
            {
                Information,
                Exception,
                Critical,
                None
            }

            public void WriteLog(string Message, bool Prefix = true, InfoType InfoType = Form1.InfoType.None)
            {
            string LocalDate = MakeMenuLib.MiscFunc.GetLocalDate();
            string LocalTime = MakeMenuLib.MiscFunc.GetLocalTime();
                string LogDate = " [ " + LocalTime + " ]  ";
                string MessageType = string.Empty;

                switch (InfoType)
                {
                    case InfoType.Information:
                        {
                            MessageType = "Information: ";
                            break;
                        }

                    case InfoType.Exception:
                        {
                            MessageType = "Error: ";
                            break;
                        }

                    case InfoType.Critical:
                        {
                            MessageType = "Critical: ";
                            break;
                        }

                    case InfoType.None:
                        {
                            MessageType = "";
                            break;
                        }
                }
          
            if (Prefix == true)
                    LogTextBox.Text += @".\\" + UserName + ">" + LogDate + MessageType + Message + Environment.NewLine;
                else
                    LogTextBox.Text += MessageType + Message + Environment.NewLine;

                if ((LogTextBox.Text.Split(Environment.NewLine.ToCharArray()).Count() - 1) >= 12)
                {
                    LogTextBox.ScrollBars = ScrollBars.Vertical;
                    LogTextBox.SelectionStart = LogTextBox.Text.Length;
                    LogTextBox.ScrollToCaret();
                }
            }


            public void ClearLog()
            {
                LogTextBox.Text = "";
            }

        
        /// <summary>
        /// ////////////////////////  Cheats
        /// </summary>
        /// 



    }
}
