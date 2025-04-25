using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestManageSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // button1 = Customers
        private void button1_Click(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>(); // Empty list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = customers;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button2 = Inventory
        private void button2_Click(object sender, EventArgs e)
        {
            List<Inventory> inventory = new List<Inventory>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inventory;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button3 = Menu
        private void button3_Click(object sender, EventArgs e)
        {
            List<Menu> menu = new List<Menu>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = menu;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button6 = Orders
        private void button6_Click(object sender, EventArgs e)
        {
            List<Order> orders = new List<Order>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orders;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button5 = Order Details
        private void button5_Click(object sender, EventArgs e)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orderDetails;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button4 = Staffs
        private void button4_Click(object sender, EventArgs e)
        {
            List<Staff> staffs = new List<Staff>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = staffs;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // button7 = Suppliers
        private void button7_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = new List<Supplier>();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = suppliers;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

    // Entity Classes

    public class Customer
    {
        public int customer_id { get; set; }
        public string lname { get; set; }
        public string fname { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }

    public class Staff
    {
        public int staff_id { get; set; }
        public string lname { get; set; }
        public string fname { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
    }

    public class Menu
    {
        public int menu_id { get; set; }
        public string item_name { get; set; }
        public string category { get; set; }
        public string price { get; set; }
    }

    public class Inventory
    {
        public int inventory_id { get; set; }
        public string item_name { get; set; }
        public string quantity_in_stock { get; set; }
        public string reorder_level { get; set; }
        public int supplier_id { get; set; }
        public int staff_id { get; set; }
    }

    public class Order
    {
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int staff_id { get; set; }
        public string order_date { get; set; }
        public float total_amount { get; set; }
    }

    public class OrderDetail
    {
        public int order_detail_id { get; set; }
        public int order_id { get; set; }
        public int menu_id { get; set; }
        public string quantity { get; set; }
        public float subtotal { get; set; }
    }

    public class Supplier
    {
        public int supplier_id { get; set; }
        public string name { get; set; }
        public string contact_person { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
    }
}