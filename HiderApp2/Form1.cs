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
        private int keyBind;
        private string[] keyParts;

        private Process[] runningProcesses = Process.GetProcesses();
        private string selectedProcessName;
        private bool hidden;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HIDEACTION_HOTKEY_ID)
            {
                foreach (Process running in runningProcesses)
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
            this.Icon = Properties.Resources.hidericon;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            foreach (Process process in runningProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero && process.ProcessName != "explorer")
                {
                    comBoxPrograms.Items.Add(process.ProcessName + $" ({process.ProcessName}.exe)");
                }
            }
            hidden = false;
            notifyIcon1.Icon = Properties.Resources.hidericon;
            notifyIcon1.Visible = false;
            MessageBox.Show("WARNING: This program is very unsafe and has NOT been tested very well, use with caution", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("YOU MUST SET A HOTKEY WITH THE RIGHT FORMAT. EXAMPLE: CTRL+ALT+SHIFT+L");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (comBoxPrograms.SelectedItem != null && keyBind != 0)
            {
                string[] temp = comBoxPrograms.SelectedItem.ToString().Split(' ');
                selectedProcessName = temp[0];
                MessageBox.Show("Selected " + selectedProcessName);
                this.WindowState = FormWindowState.Minimized;
            }
            else if (keyBind == 0)
                MessageBox.Show("You have not selected a keybind!");
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


        // TODO: make this not crap (the array has to be a certain length)
        private void btnSetHotkey_Click(object sender, EventArgs e)
        {
            int fsModifiers;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            if (txtKeyBind.Text != "")
            {
                // 2: Control, 1: Alt, 4: Shift, 8: Win
                keyParts = txtKeyBind.Text.ToUpper().Split('+');
                switch (keyParts[0])
                {
                    case "CTRL":
                        p1 = 2;
                        break;
                    case "ALT":
                        p1 = 1;
                        break;
                    case "SHIFT":
                        p1 = 4;
                        break;
                    case "WIN":
                        p1 = 8;
                        break;
                    default:
                        MessageBox.Show("Invalid");
                        break;
                }
                switch (keyParts[1])
                {
                    case "CTRL":
                        p2 = 2;
                        break;
                    case "ALT":
                        p2 = 1;
                        break;
                    case "SHIFT":
                        p2 = 4;
                        break;
                    case "WIN":
                        p2 = 8;
                        break;
                    default:
                        MessageBox.Show("Invalid");
                        break;
                }
                switch (keyParts[2])
                {
                    case "CTRL":
                        p3 = 2;
                        break;
                    case "ALT":
                        p3 = 1;
                        break;
                    case "SHIFT":
                        p3 = 4;
                        break;
                    case "WIN":
                        p3 = 8;
                        break;
                    default:
                        MessageBox.Show("Invalid");
                        break;
                }
                fsModifiers = p1 | p2 | p3;
                foreach (Keys key in Enum.GetValues<Keys>())
                {
                    if (key.ToString() == keyParts[3])
                    {
                        keyBind = (int)key;
                        break;
                    }
                }
                RegisterHotKey(this.Handle, HIDEACTION_HOTKEY_ID, fsModifiers, keyBind);
                btnSetHotkey.Enabled = false;
                txtKeyBind.Enabled = false;
            }
            else
                MessageBox.Show("Please enter a value");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.MainWindowHandle != IntPtr.Zero && process.ProcessName != "explorer")
                {
                    comBoxPrograms.Items.Add(process.ProcessName + $" ({process.ProcessName}.exe)");
                }
            }
        }
    }
}
