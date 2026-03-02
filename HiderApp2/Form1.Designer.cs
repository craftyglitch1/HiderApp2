namespace HiderApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnConfirm = new Button();
            comBoxPrograms = new ComboBox();
            notifyIcon1 = new NotifyIcon(components);
            txtKeyBind = new TextBox();
            label1 = new Label();
            btnSetHotkey = new Button();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(27, 45);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(151, 58);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm Program";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // comBoxPrograms
            // 
            comBoxPrograms.FormattingEnabled = true;
            comBoxPrograms.Location = new Point(27, 11);
            comBoxPrograms.Name = "comBoxPrograms";
            comBoxPrograms.Size = new Size(151, 28);
            comBoxPrograms.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // txtKeyBind
            // 
            txtKeyBind.Location = new Point(27, 147);
            txtKeyBind.Name = "txtKeyBind";
            txtKeyBind.Size = new Size(151, 27);
            txtKeyBind.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 125);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 3;
            label1.Text = "Key Bind: ";
            // 
            // btnSetHotkey
            // 
            btnSetHotkey.Location = new Point(27, 180);
            btnSetHotkey.Name = "btnSetHotkey";
            btnSetHotkey.Size = new Size(151, 29);
            btnSetHotkey.TabIndex = 4;
            btnSetHotkey.Text = "Set Hotkey";
            btnSetHotkey.UseVisualStyleBackColor = true;
            btnSetHotkey.Click += btnSetHotkey_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(195, 225);
            Controls.Add(btnSetHotkey);
            Controls.Add(label1);
            Controls.Add(txtKeyBind);
            Controls.Add(comBoxPrograms);
            Controls.Add(btnConfirm);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private ComboBox comBoxPrograms;
        private NotifyIcon notifyIcon1;
        private TextBox txtKeyBind;
        private Label label1;
        private Button btnSetHotkey;
    }
}
