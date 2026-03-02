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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(195, 115);
            Controls.Add(comBoxPrograms);
            Controls.Add(btnConfirm);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfirm;
        private ComboBox comBoxPrograms;
        private NotifyIcon notifyIcon1;
    }
}
