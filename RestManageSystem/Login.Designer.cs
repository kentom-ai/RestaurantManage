namespace RestManageSystem
{
    partial class Login
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
            panel1 = new Panel();
            register_login = new Label();
            label4 = new Label();
            login_forgotpass = new Label();
            login_close = new Label();
            login_btn = new Button();
            login_showpass = new CheckBox();
            login_password = new TextBox();
            login_username = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(register_login);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(login_forgotpass);
            panel1.Controls.Add(login_close);
            panel1.Controls.Add(login_btn);
            panel1.Controls.Add(login_showpass);
            panel1.Controls.Add(login_password);
            panel1.Controls.Add(login_username);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 414);
            panel1.TabIndex = 0;
            // 
            // register_login
            // 
            register_login.AutoSize = true;
            register_login.ForeColor = Color.FromArgb(128, 128, 255);
            register_login.Location = new Point(453, 374);
            register_login.Name = "register_login";
            register_login.Size = new Size(80, 15);
            register_login.TabIndex = 20;
            register_login.Text = "Register Here!";
            register_login.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 374);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 19;
            label4.Text = "No Account Yet?";
            label4.Click += label4_Click_2;
            // 
            // login_forgotpass
            // 
            login_forgotpass.AutoSize = true;
            login_forgotpass.BackColor = Color.Transparent;
            login_forgotpass.ForeColor = Color.FromArgb(128, 128, 255);
            login_forgotpass.Location = new Point(509, 317);
            login_forgotpass.Name = "login_forgotpass";
            login_forgotpass.Size = new Size(100, 15);
            login_forgotpass.TabIndex = 18;
            login_forgotpass.Text = "Forgot Password?";
            login_forgotpass.Click += label4_Click_1;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Location = new Point(608, 9);
            login_close.Name = "login_close";
            login_close.Size = new Size(14, 15);
            login_close.TabIndex = 17;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.Firebrick;
            login_btn.Cursor = Cursors.Hand;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.ForeColor = SystemColors.Control;
            login_btn.Location = new Point(283, 279);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(326, 35);
            login_btn.TabIndex = 15;
            login_btn.Text = "LOGIN";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += button1_Click;
            // 
            // login_showpass
            // 
            login_showpass.AutoSize = true;
            login_showpass.Location = new Point(501, 248);
            login_showpass.Name = "login_showpass";
            login_showpass.Size = new Size(108, 19);
            login_showpass.TabIndex = 14;
            login_showpass.Text = "Show Password";
            login_showpass.UseVisualStyleBackColor = true;
            login_showpass.CheckedChanged += login_showpass_CheckedChanged;
            // 
            // login_password
            // 
            login_password.Location = new Point(283, 207);
            login_password.Multiline = true;
            login_password.Name = "login_password";
            login_password.Size = new Size(326, 35);
            login_password.TabIndex = 13;
            login_password.TextChanged += login_password_TextChanged;
            // 
            // login_username
            // 
            login_username.Location = new Point(280, 130);
            login_username.Multiline = true;
            login_username.Name = "login_username";
            login_username.Size = new Size(326, 35);
            login_username.TabIndex = 12;
            login_username.TextChanged += login_username_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(283, 184);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 11;
            label3.Text = "Password:";
            label3.Click += label3_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(280, 107);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(280, 32);
            label1.Name = "label1";
            label1.Size = new Size(167, 28);
            label1.TabIndex = 1;
            label1.Text = "Welcome Back!";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Firebrick;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 411);
            panel2.TabIndex = 0;
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
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 411);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Signup";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Label label6;
        private PictureBox pictureBox1;
        private Label label3;
        private TextBox login_username;
        private TextBox login_password;
        private CheckBox login_showpass;
        private Button login_btn;
        private Label login_close;
        private Label login_forgotpass;
        private Label label4;
        private Label register_login;
    }
}