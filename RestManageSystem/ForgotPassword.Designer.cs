namespace RestManageSystem
{
    partial class ForgotPassword
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
            label1 = new Label();
            label2 = new Label();
            forgotpass_email = new TextBox();
            forgotpass_btn = new Button();
            label3 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Firebrick;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 417);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 31);
            label1.Name = "label1";
            label1.Size = new Size(180, 28);
            label1.TabIndex = 2;
            label1.Text = "Forgot Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(282, 131);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            // 
            // forgotpass_email
            // 
            forgotpass_email.Location = new Point(282, 159);
            forgotpass_email.Multiline = true;
            forgotpass_email.Name = "forgotpass_email";
            forgotpass_email.Size = new Size(326, 35);
            forgotpass_email.TabIndex = 4;
            forgotpass_email.TextChanged += forgotpass_email_TextChanged;
            // 
            // forgotpass_btn
            // 
            forgotpass_btn.BackColor = Color.Firebrick;
            forgotpass_btn.FlatAppearance.BorderSize = 0;
            forgotpass_btn.FlatStyle = FlatStyle.Flat;
            forgotpass_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            forgotpass_btn.ForeColor = SystemColors.ControlLightLight;
            forgotpass_btn.Location = new Point(282, 241);
            forgotpass_btn.Name = "forgotpass_btn";
            forgotpass_btn.Size = new Size(326, 35);
            forgotpass_btn.TabIndex = 5;
            forgotpass_btn.Text = "Submit";
            forgotpass_btn.UseVisualStyleBackColor = false;
            forgotpass_btn.Click += forgotpass_btn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(608, 9);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 6;
            label3.Text = "X";
            label3.Click += label3_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 414);
            Controls.Add(label3);
            Controls.Add(forgotpass_btn);
            Controls.Add(forgotpass_email);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPassword";
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
        private Label label1;
        private Label label2;
        private TextBox forgotpass_email;
        private Button forgotpass_btn;
        private Label label3;
    }
}