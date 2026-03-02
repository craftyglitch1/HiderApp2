using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HiderApp2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int HIDEACTION_HOTKEY_ID = 1;
        const int WM_HOTKEY = 0x0312;

        private Process[] openedProcesses = Process.GetProcesses();
        private string selectedProcessName;
        private bool hidden;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        public Form1()
        {
            InitializeComponent();

            // 0: Just the Key, 1: Alt, 2: Control, 4: Shift
            // also this is the only comment fuck it we ball
            RegisterHotKey(this.Handle, HIDEACTION_HOTKEY_ID, 2 | 1 | 4, (int)Keys.L);
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HIDEACTION_HOTKEY_ID)
            {
                foreach (Process running in openedProcesses)
                {
                    if (running.ProcessName == selectedProcessName && selectedProcessName != "")
                    {
                        IntPtr hWnd = running.MainWindowHandle;
                        if (hWnd != IntPtr.Zero)
                        {
                            if (!hidden)
                            {
                                ShowWindow(hWnd, SW_HIDE);
                                hidden = true;
                            }
                            else
                            {
                                ShowWindow(hWnd, SW_SHOW);
                                hidden = false;
                            }
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            foreach (Process process in openedProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero && process.ProcessName != "explorer")
                {
                    comBoxPrograms.Items.Add(process.ProcessName);
                }
            }
            hidden = false;
            notifyIcon1.Icon = Properties.Resources.hidericon;
            notifyIcon1.Visible = false;
            MessageBox.Show("This program will minimize to tray");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (comBoxPrograms.SelectedItem != null)
            {
                selectedProcessName = comBoxPrograms.SelectedItem.ToString();
                MessageBox.Show("Selected " + selectedProcessName);
                this.WindowState = FormWindowState.Minimized;
            }
            else
                MessageBox.Show("You have not selected a program!");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
