namespace RestManageSystem
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            Customers = new Button();
            Inventory = new Button();
            groupBox1 = new GroupBox();
            button7 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button3 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(342, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(642, 383);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(27, 32);
            label1.Name = "label1";
            label1.Size = new Size(257, 21);
            label1.TabIndex = 0;
            label1.Text = "Restaurant Management System";
            label1.Click += label1_Click_1;
            // 
            // Customers
            // 
            Customers.AccessibleDescription = "";
            Customers.AccessibleName = "";
            Customers.Location = new Point(27, 78);
            Customers.Name = "Customers";
            Customers.Size = new Size(257, 32);
            Customers.TabIndex = 1;
            Customers.Text = "Customers";
            Customers.UseVisualStyleBackColor = true;
            Customers.Click += button1_Click;
            // 
            // Inventory
            // 
            Inventory.Location = new Point(27, 139);
            Inventory.Name = "Inventory";
            Inventory.Size = new Size(257, 32);
            Inventory.TabIndex = 2;
            Inventory.Text = "Inventory";
            Inventory.UseVisualStyleBackColor = true;
            Inventory.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(Inventory);
            groupBox1.Controls.Add(Customers);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(21, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 500);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button7
            // 
            button7.Location = new Point(27, 432);
            button7.Name = "button7";
            button7.Size = new Size(257, 32);
            button7.TabIndex = 7;
            button7.Text = "Suppliers";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button4
            // 
            button4.Location = new Point(27, 373);
            button4.Name = "button4";
            button4.Size = new Size(257, 32);
            button4.TabIndex = 6;
            button4.Text = "Staffs";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(27, 260);
            button5.Name = "button5";
            button5.Size = new Size(257, 32);
            button5.TabIndex = 5;
            button5.Text = "OrdersDetails";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(27, 317);
            button6.Name = "button6";
            button6.Size = new Size(257, 32);
            button6.TabIndex = 4;
            button6.Text = "Order";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.Location = new Point(27, 198);
            button3.Name = "button3";
            button3.Size = new Size(257, 32);
            button3.TabIndex = 3;
            button3.Text = "Menu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(342, 23);
            label2.Name = "label2";
            label2.Size = new Size(0, 21);
            label2.TabIndex = 2;
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 549);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button Customers;
        private Button Inventory;
        private GroupBox groupBox1;
        private Button button7;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button3;
        private Label label2;
    }
}
