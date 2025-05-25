namespace RestManageSystem
{
    partial class Dashboard
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
            Excel_btn = new Button();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            dash_address = new TextBox();
            dash_pnumber = new TextBox();
            dash_lname = new TextBox();
            dash_fname = new TextBox();
            login_close = new Label();
            dash_search = new TextBox();
            search_btn = new Button();
            delete_btn = new Button();
            update_btn = new Button();
            add_btn = new Button();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            dash_order_details = new Button();
            dash_order = new Button();
            dash_menu = new Button();
            dash_customer = new Button();
            dash_confidential = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(Excel_btn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dash_address);
            panel1.Controls.Add(dash_pnumber);
            panel1.Controls.Add(dash_lname);
            panel1.Controls.Add(dash_fname);
            panel1.Controls.Add(login_close);
            panel1.Controls.Add(dash_search);
            panel1.Controls.Add(search_btn);
            panel1.Controls.Add(delete_btn);
            panel1.Controls.Add(update_btn);
            panel1.Controls.Add(add_btn);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(223, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 450);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // Excel_btn
            // 
            Excel_btn.BackColor = Color.Firebrick;
            Excel_btn.FlatAppearance.BorderSize = 0;
            Excel_btn.FlatStyle = FlatStyle.Flat;
            Excel_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Excel_btn.ForeColor = SystemColors.ControlLightLight;
            Excel_btn.Location = new Point(565, 42);
            Excel_btn.Name = "Excel_btn";
            Excel_btn.Size = new Size(164, 35);
            Excel_btn.TabIndex = 33;
            Excel_btn.Text = "Export to Excel";
            Excel_btn.UseVisualStyleBackColor = false;
            Excel_btn.Click += Excel_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(565, 295);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 32;
            label4.Text = "Address";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(565, 222);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 31;
            label3.Text = "Phone Number:";
            label3.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(565, 153);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 30;
            label1.Text = "Last Name:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(565, 80);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 29;
            label2.Text = "First Name:";
            label2.Click += label2_Click;
            // 
            // dash_address
            // 
            dash_address.Location = new Point(565, 318);
            dash_address.Multiline = true;
            dash_address.Name = "dash_address";
            dash_address.Size = new Size(164, 35);
            dash_address.TabIndex = 28;
            dash_address.TextChanged += dash_address_TextChanged;
            // 
            // dash_pnumber
            // 
            dash_pnumber.Location = new Point(565, 245);
            dash_pnumber.Multiline = true;
            dash_pnumber.Name = "dash_pnumber";
            dash_pnumber.Size = new Size(164, 35);
            dash_pnumber.TabIndex = 27;
            dash_pnumber.TextChanged += dash_pnumber_TextChanged;
            // 
            // dash_lname
            // 
            dash_lname.Location = new Point(565, 176);
            dash_lname.Multiline = true;
            dash_lname.Name = "dash_lname";
            dash_lname.Size = new Size(164, 35);
            dash_lname.TabIndex = 26;
            dash_lname.TextChanged += dash_lname_TextChanged;
            // 
            // dash_fname
            // 
            dash_fname.Location = new Point(565, 103);
            dash_fname.Multiline = true;
            dash_fname.Name = "dash_fname";
            dash_fname.Size = new Size(164, 35);
            dash_fname.TabIndex = 25;
            dash_fname.TextChanged += dash_fname_TextChanged;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Location = new Point(715, 9);
            login_close.Name = "login_close";
            login_close.Size = new Size(14, 15);
            login_close.TabIndex = 24;
            login_close.Text = "X";
            login_close.Click += login_close_Click;
            // 
            // dash_search
            // 
            dash_search.Location = new Point(193, 21);
            dash_search.Multiline = true;
            dash_search.Name = "dash_search";
            dash_search.Size = new Size(356, 35);
            dash_search.TabIndex = 23;
            dash_search.TextChanged += dash_search_TextChanged;
            // 
            // search_btn
            // 
            search_btn.BackColor = Color.Firebrick;
            search_btn.FlatAppearance.BorderSize = 0;
            search_btn.FlatStyle = FlatStyle.Flat;
            search_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            search_btn.ForeColor = SystemColors.ControlLightLight;
            search_btn.Location = new Point(24, 21);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(148, 35);
            search_btn.TabIndex = 22;
            search_btn.Text = "Search";
            search_btn.UseVisualStyleBackColor = false;
            search_btn.Click += search_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.Firebrick;
            delete_btn.FlatAppearance.BorderSize = 0;
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delete_btn.ForeColor = SystemColors.ControlLightLight;
            delete_btn.Location = new Point(401, 375);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(148, 35);
            delete_btn.TabIndex = 21;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // update_btn
            // 
            update_btn.BackColor = Color.Firebrick;
            update_btn.FlatAppearance.BorderSize = 0;
            update_btn.FlatStyle = FlatStyle.Flat;
            update_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            update_btn.ForeColor = SystemColors.ControlLightLight;
            update_btn.Location = new Point(217, 375);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(148, 35);
            update_btn.TabIndex = 20;
            update_btn.Text = "Update";
            update_btn.UseVisualStyleBackColor = false;
            update_btn.Click += update_btn_Click;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.Firebrick;
            add_btn.FlatAppearance.BorderSize = 0;
            add_btn.FlatStyle = FlatStyle.Flat;
            add_btn.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            add_btn.ForeColor = SystemColors.ControlLightLight;
            add_btn.Location = new Point(24, 375);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(148, 35);
            add_btn.TabIndex = 19;
            add_btn.Text = "Add";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(526, 291);
            dataGridView1.TabIndex = 18;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Firebrick;
            panel2.Controls.Add(dash_confidential);
            panel2.Controls.Add(dash_order_details);
            panel2.Controls.Add(dash_order);
            panel2.Controls.Add(dash_menu);
            panel2.Controls.Add(dash_customer);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(226, 450);
            panel2.TabIndex = 0;
            // 
            // dash_order_details
            // 
            dash_order_details.Location = new Point(31, 239);
            dash_order_details.Name = "dash_order_details";
            dash_order_details.Size = new Size(157, 34);
            dash_order_details.TabIndex = 3;
            dash_order_details.Text = "Order_Details";
            dash_order_details.UseVisualStyleBackColor = true;
            dash_order_details.Click += dash_order_details_Click;
            // 
            // dash_order
            // 
            dash_order.Location = new Point(31, 176);
            dash_order.Name = "dash_order";
            dash_order.Size = new Size(157, 34);
            dash_order.TabIndex = 2;
            dash_order.Text = "Order";
            dash_order.UseVisualStyleBackColor = true;
            dash_order.Click += dash_order_Click;
            // 
            // dash_menu
            // 
            dash_menu.Location = new Point(31, 108);
            dash_menu.Name = "dash_menu";
            dash_menu.Size = new Size(157, 34);
            dash_menu.TabIndex = 1;
            dash_menu.Text = "Menu";
            dash_menu.UseVisualStyleBackColor = true;
            dash_menu.Click += dash_menu_Click;
            // 
            // dash_customer
            // 
            dash_customer.Location = new Point(31, 35);
            dash_customer.Name = "dash_customer";
            dash_customer.Size = new Size(157, 34);
            dash_customer.TabIndex = 0;
            dash_customer.Text = "Customer";
            dash_customer.UseVisualStyleBackColor = true;
            dash_customer.Click += dash_customer_Click;
            // 
            // dash_confidential
            // 
            dash_confidential.Location = new Point(31, 311);
            dash_confidential.Name = "dash_confidential";
            dash_confidential.Size = new Size(157, 34);
            dash_confidential.TabIndex = 4;
            dash_confidential.Text = "Confidential";
            dash_confidential.UseVisualStyleBackColor = true;
            dash_confidential.Click += dash_confidential_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(964, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button dash_customer;
        private Button dash_order_details;
        private Button dash_order;
        private Button dash_menu;
        private DataGridView dataGridView1;
        private Button delete_btn;
        private Button update_btn;
        private Button add_btn;
        private TextBox dash_search;
        private Button search_btn;
        private Label login_close;
        private TextBox dash_fname;
        private TextBox dash_address;
        private TextBox dash_pnumber;
        private TextBox dash_lname;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Button Excel_btn;
        private Button dash_confidential;
    }
}