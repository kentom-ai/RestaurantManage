namespace RestManageSystem
{
    partial class Register
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
            login_close = new Label();
            register_btn = new Button();
            login_showpass = new CheckBox();
            register_email = new TextBox();
            register_username = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            register_password = new TextBox();
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
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 411);
            panel2.TabIndex = 1;
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
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Location = new Point(605, 10);
            login_close.Name = "login_close";
            login_close.Size = new Size(14, 15);
            login_close.TabIndex = 26;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // register_btn
            // 
            register_btn.BackColor = Color.Firebrick;
            register_btn.Cursor = Cursors.Hand;
            register_btn.FlatStyle = FlatStyle.Flat;
            register_btn.ForeColor = SystemColors.Control;
            register_btn.Location = new Point(277, 304);
            register_btn.Name = "register_btn";
            register_btn.Size = new Size(326, 35);
            register_btn.TabIndex = 25;
            register_btn.Text = "SIGNUP";
            register_btn.UseVisualStyleBackColor = false;
            register_btn.Click += register_btn_Click;
            // 
            // login_showpass
            // 
            login_showpass.AutoSize = true;
            login_showpass.Location = new Point(495, 263);
            login_showpass.Name = "login_showpass";
            login_showpass.Size = new Size(108, 19);
            login_showpass.TabIndex = 24;
            login_showpass.Text = "Show Password";
            login_showpass.UseVisualStyleBackColor = true;
            login_showpass.CheckedChanged += login_showpass_CheckedChanged;
            // 
            // register_email
            // 
            register_email.Location = new Point(277, 155);
            register_email.Multiline = true;
            register_email.Name = "register_email";
            register_email.Size = new Size(326, 35);
            register_email.TabIndex = 23;
            register_email.TextChanged += register_email_TextChanged;
            // 
            // register_username
            // 
            register_username.Location = new Point(277, 91);
            register_username.Multiline = true;
            register_username.Name = "register_username";
            register_username.Size = new Size(326, 35);
            register_username.TabIndex = 22;
            register_username.TextChanged += register_username_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(277, 132);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 21;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 68);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 20;
            label2.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 24);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 19;
            label1.Text = "Register";
            // 
            // register_password
            // 
            register_password.Location = new Point(277, 222);
            register_password.Multiline = true;
            register_password.Name = "register_password";
            register_password.Size = new Size(326, 35);
            register_password.TabIndex = 28;
            register_password.TextChanged += register_password_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(277, 199);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 27;
            label4.Text = "Password:";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 411);
            Controls.Add(register_password);
            Controls.Add(label4);
            Controls.Add(login_close);
            Controls.Add(register_btn);
            Controls.Add(login_showpass);
            Controls.Add(register_email);
            Controls.Add(register_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
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
        private Label login_close;
        private Button register_btn;
        private CheckBox login_showpass;
        private TextBox register_email;
        private TextBox register_username;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox register_password;
        private Label label4;
    }
}