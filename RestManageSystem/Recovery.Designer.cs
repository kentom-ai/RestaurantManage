namespace RestManageSystem
{
    partial class Recovery
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
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            recovery_btn = new Button();
            recovery_newpassword = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            recovery_showpass = new CheckBox();
            login_showpass = new CheckBox();
            recovery_confirmpassword = new TextBox();
            label4 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Firebrick;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(-1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 415);
            panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(77, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(102, 155);
            label6.Name = "label6";
            label6.Size = new Size(57, 28);
            label6.TabIndex = 0;
            label6.Text = "User";
            // 
            // recovery_btn
            // 
            recovery_btn.BackColor = Color.Firebrick;
            recovery_btn.FlatAppearance.BorderSize = 0;
            recovery_btn.FlatStyle = FlatStyle.Flat;
            recovery_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recovery_btn.ForeColor = SystemColors.ControlLightLight;
            recovery_btn.Location = new Point(277, 339);
            recovery_btn.Name = "recovery_btn";
            recovery_btn.Size = new Size(326, 35);
            recovery_btn.TabIndex = 9;
            recovery_btn.Text = "Submit";
            recovery_btn.UseVisualStyleBackColor = false;
            recovery_btn.Click += recovery_btn_Click;
            // 
            // recovery_newpassword
            // 
            recovery_newpassword.Location = new Point(277, 148);
            recovery_newpassword.Multiline = true;
            recovery_newpassword.Name = "recovery_newpassword";
            recovery_newpassword.Size = new Size(326, 35);
            recovery_newpassword.TabIndex = 8;
            recovery_newpassword.TextChanged += recovery_newpassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 114);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 7;
            label2.Text = "New Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 37);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 6;
            label1.Text = "Forgot Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(609, 9);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 10;
            label3.Text = "X";
            label3.Click += label3_Click;
            // 
            // recovery_showpass
            // 
            recovery_showpass.AutoSize = true;
            recovery_showpass.Location = new Point(495, 189);
            recovery_showpass.Name = "recovery_showpass";
            recovery_showpass.Size = new Size(108, 19);
            recovery_showpass.TabIndex = 15;
            recovery_showpass.Text = "Show Password";
            recovery_showpass.UseVisualStyleBackColor = true;
            recovery_showpass.CheckedChanged += login_showpass_CheckedChanged;
            // 
            // login_showpass
            // 
            login_showpass.AutoSize = true;
            login_showpass.Location = new Point(495, 295);
            login_showpass.Name = "login_showpass";
            login_showpass.Size = new Size(108, 19);
            login_showpass.TabIndex = 18;
            login_showpass.Text = "Show Password";
            login_showpass.UseVisualStyleBackColor = true;
            login_showpass.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // recovery_confirmpassword
            // 
            recovery_confirmpassword.Location = new Point(277, 254);
            recovery_confirmpassword.Multiline = true;
            recovery_confirmpassword.Name = "recovery_confirmpassword";
            recovery_confirmpassword.Size = new Size(326, 35);
            recovery_confirmpassword.TabIndex = 17;
            recovery_confirmpassword.TextChanged += recovery_confirmpass_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(277, 220);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 16;
            label4.Text = "Confirm Password:";
            // 
            // Recovery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 414);
            Controls.Add(login_showpass);
            Controls.Add(recovery_confirmpassword);
            Controls.Add(label4);
            Controls.Add(recovery_showpass);
            Controls.Add(label3);
            Controls.Add(recovery_btn);
            Controls.Add(recovery_newpassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Recovery";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recovery";
            Load += Recovery_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label6;
        private Button recovery_btn;
        private TextBox recovery_newpassword;
        private Label label2;
        private Label label1;
        private Label label3;
        private CheckBox recovery_showpass;
        private CheckBox login_showpass;
        private TextBox recovery_confirmpassword;
        private Label label4;
    }
}