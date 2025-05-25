using MySql.Data.MySqlClient; // Needed for database interaction
using System;
using System.Data; // Needed for System.Data.DataTable
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel; // Needed for Excel automation
using System.IO; // Needed for file operations (CSV)
using System.Text; // Needed for StringBuilder (CSV)
using System.Collections.Generic; // Added for List<int> in DeleteCustomer

namespace RestManageSystem
{
    public partial class Dashboard : Form
    {
        // Connection string for your MySQL database
        private const string connectionString = "Server=127.0.0.1;Database=restaurant management database;Uid=root;Pwd=kentominaga08;";

        // Global variable to keep track of the currently selected table for CRUD operations
        private string currentTable = "customers"; // Default to customers

        public Dashboard()
        {
            InitializeComponent();
            LoadData(currentTable); // Load data for the default table
        }

        // Generic method to load data into the DataGridView
        private void LoadData(string tableName)
        {
            currentTable = tableName; // Update the current table tracker
            string query = "";

            // Determine the SELECT query based on the table name
            switch (tableName)
            {
                case "customers":
                    // Keep separate for individual input fields
                    query = "SELECT customer_id, lname, fname, phone_number, address FROM customers";
                    break;
                case "menu":
                    query = "SELECT menu_id, item_name, category, price FROM menu";
                    break;
                case "orders":
                    // Already concatenates customer names in the query for display
                    query = "SELECT o.order_id, CONCAT(c.fname, ' ', c.lname) AS customer_full_name, o.order_date, o.total_amount FROM orders o JOIN customers c ON o.customer_id = c.customer_id";
                    break;
                case "order_details":
                    query = "SELECT od.order_detail_id, od.order_id, m.item_name, m.category, od.quantity, od.subtotal FROM order_details od JOIN menu m ON od.menu_id = m.menu_id";
                    break;
                case "inventory":
                    query = "SELECT inventory_id, item_name, quantity_in_stock, reorder_level, supplier_id, staff_id FROM inventory";
                    break;
                case "staffs":
                    // Keep separate for individual input fields/future updates
                    query = "SELECT staff_id, lname, fname, role, email, phone_number FROM staffs";
                    break;
                case "suppliers":
                    query = "SELECT supplier_id, name, contact_person, phone_number, address FROM suppliers";
                    break;
                // Modified for confidential report - Customer Order Summary to show full name
                case "customer_order_summary":
                    query = @"
                        SELECT
                            c.customer_id,
                            CONCAT(c.fname, ' ', c.lname) AS customer_full_name, -- Concatenate fname and lname
                            COUNT(o.order_id) AS total_orders,
                            SUM(o.total_amount) AS total_spent
                        FROM customers c
                        LEFT JOIN orders o ON c.customer_id = o.customer_id
                        GROUP BY c.customer_id, c.fname, c.lname
                        ORDER BY total_spent DESC, total_orders DESC;
                    ";
                    break;
                // Modified for confidential report - Staff Order Summary to show full names
                case "staff_order_summary":
                    query = @"
                        SELECT
                            s.staff_id,
                            CONCAT(s.fname, ' ', s.lname) AS staff_full_name, -- Concatenate staff's full name
                            o.order_id,
                            CONCAT(c.fname, ' ', c.lname) AS customer_full_name, -- Concatenate customer's full name
                            o.order_date,
                            o.total_amount
                        FROM orders o
                        JOIN staffs s ON o.staff_id = s.staff_id
                        LEFT JOIN customers c ON o.customer_id = c.customer_id
                        ORDER BY s.lname, s.fname, o.order_date DESC;
                    ";
                    break;
                default:
                    MessageBox.Show("Unknown table: " + tableName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error loading " + tableName + " data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred loading " + tableName + " data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateDisplayLabels(tableName);
        }

        // Method to update label texts and clear textboxes based on the current table
        private void UpdateDisplayLabels(string tableName)
        {
            if (label1 != null) label1.Text = string.Empty;
            if (label2 != null) label2.Text = string.Empty;
            if (label3 != null) label3.Text = string.Empty;
            if (label4 != null) label4.Text = string.Empty;

            dash_fname.Clear();
            dash_lname.Clear();
            dash_pnumber.Clear();
            dash_address.Clear();
            dash_search.Clear();

            switch (tableName)
            {
                case "customers":
                    if (label1 != null) label1.Text = "First Name:";
                    if (label2 != null) label2.Text = "Last Name:";
                    if (label3 != null) label3.Text = "Phone Number:";
                    if (label4 != null) label4.Text = "Address:";
                    break;
                case "menu":
                    if (label1 != null) label1.Text = "Item Name:";
                    if (label2 != null) label2.Text = "Category:";
                    if (label3 != null) label3.Text = "Price:";
                    break;
                case "orders":
                    if (label1 != null) label1.Text = "Order ID:";
                    if (label2 != null) label2.Text = "Customer Name:"; // Now displaying full name
                    if (label3 != null) label3.Text = "Order Date:";
                    if (label4 != null) label4.Text = "Total Amount:";
                    break;
                case "order_details":
                    if (label1 != null) label1.Text = "Order Detail ID:";
                    if (label2 != null) label2.Text = "Item Name:";
                    if (label3 != null) label3.Text = "Quantity:";
                    if (label4 != null) label4.Text = "Subtotal:";
                    break;
                case "inventory":
                    if (label1 != null) label1.Text = "Item Name:";
                    if (label2 != null) label2.Text = "Quantity in Stock:";
                    if (label3 != null) label3.Text = "Reorder Level:";
                    break;
                case "staffs":
                    if (label1 != null) label1.Text = "First Name:";
                    if (label2 != null) label2.Text = "Last Name:";
                    if (label3 != null) label3.Text = "Role:";
                    if (label4 != null) label4.Text = "Email:";
                    break;
                case "suppliers":
                    if (label1 != null) label1.Text = "Supplier Name:";
                    if (label2 != null) label2.Text = "Contact Person:";
                    if (label3 != null) label3.Text = "Phone Number:";
                    if (label4 != null) label4.Text = "Address:";
                    break;
                case "customer_order_summary":
                    if (label1 != null) label1.Text = "Customer ID:";
                    if (label2 != null) label2.Text = "Customer Name:"; // Now displaying full name
                    if (label3 != null) label3.Text = "Total Orders:";
                    if (label4 != null) label4.Text = "Total Spent:";
                    break;
                case "staff_order_summary":
                    if (label1 != null) label1.Text = "Staff ID:";
                    if (label2 != null) label2.Text = "Staff Name:";
                    if (label3 != null) label3.Text = "Order ID:";
                    if (label4 != null) label4.Text = "Customer Name:"; // Now displaying full name
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // No specific action needed here
        }

        private void dash_search_TextChanged(object sender, EventArgs e)
        {
            // Search logic is typically triggered by the search button, not every text change.
            // For live search, you could call search_btn_Click logic here or directly filter the DataTable
        }

        private void dash_customer_Click(object sender, EventArgs e)
        {
            LoadData("customers");
        }

        private void dash_menu_Click(object sender, EventArgs e)
        {
            LoadData("menu");
        }

        private void dash_order_Click(object sender, EventArgs e)
        {
            LoadData("orders");
        }

        private void dash_order_details_Click(object sender, EventArgs e)
        {
            LoadData("order_details");
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string searchTerm = dash_search.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadData(currentTable);
                return;
            }

            string query = "";
            string idColumn = "";

            switch (currentTable)
            {
                case "customers":
                    idColumn = "customer_id";
                    query = $"SELECT customer_id, lname, fname, phone_number, address FROM customers WHERE lname LIKE @searchTerm OR fname LIKE @searchTerm OR phone_number LIKE @searchTerm OR address LIKE @searchTerm OR {idColumn} = @id";
                    break;
                case "menu":
                    idColumn = "menu_id";
                    query = $"SELECT menu_id, item_name, category, price FROM menu WHERE item_name LIKE @searchTerm OR category LIKE @searchTerm OR price LIKE @searchTerm OR {idColumn} = @id";
                    break;
                case "orders":
                    idColumn = "order_id";
                    query = "SELECT o.order_id, CONCAT(c.fname, ' ', c.lname) AS customer_full_name, o.order_date, o.total_amount " +
                            "FROM orders o JOIN customers c ON o.customer_id = c.customer_id " +
                            "WHERE o.order_id = @id OR c.fname LIKE @searchTerm OR c.lname LIKE @searchTerm OR o.order_date LIKE @searchTerm OR CONCAT(c.fname, ' ', c.lname) LIKE @searchTerm"; // Added full name search
                    break;
                case "order_details":
                    idColumn = "order_detail_id";
                    query = "SELECT od.order_detail_id, od.order_id, m.item_name, m.category, od.quantity, od.subtotal " +
                            "FROM order_details od JOIN menu m ON od.menu_id = m.menu_id " +
                            "WHERE od.order_detail_id = @id OR od.order_id = @id OR m.item_name LIKE @searchTerm OR m.category LIKE @searchTerm";
                    break;
                case "inventory":
                    idColumn = "inventory_id";
                    query = $"SELECT inventory_id, item_name, quantity_in_stock, reorder_level, supplier_id, staff_id FROM inventory WHERE item_name LIKE @searchTerm OR quantity_in_stock LIKE @searchTerm OR reorder_level LIKE @searchTerm OR {idColumn} = @id";
                    break;
                case "staffs":
                    idColumn = "staff_id";
                    query = $"SELECT staff_id, lname, fname, role, email, phone_number FROM staffs WHERE lname LIKE @searchTerm OR fname LIKE @searchTerm OR role LIKE @searchTerm OR email LIKE @searchTerm OR phone_number LIKE @searchTerm OR {idColumn} = @id";
                    break;
                case "suppliers":
                    idColumn = "supplier_id";
                    query = $"SELECT supplier_id, name, contact_person, phone_number, address FROM suppliers WHERE name LIKE @searchTerm OR contact_person LIKE @searchTerm OR phone_number LIKE @searchTerm OR address LIKE @searchTerm OR {idColumn} = @id";
                    break;
                case "customer_order_summary":
                    idColumn = "customer_id";
                    query = @"
                        SELECT
                            c.customer_id,
                            CONCAT(c.fname, ' ', c.lname) AS customer_full_name,
                            COUNT(o.order_id) AS total_orders,
                            SUM(o.total_amount) AS total_spent
                        FROM customers c
                        LEFT JOIN orders o ON c.customer_id = o.customer_id
                        WHERE CONCAT(c.fname, ' ', c.lname) LIKE @searchTerm OR c.customer_id = @id
                        GROUP BY c.customer_id, c.fname, c.lname
                        ORDER BY total_spent DESC, total_orders DESC;
                    ";
                    break;
                case "staff_order_summary":
                    idColumn = "staff_id";
                    query = @"
                        SELECT
                            s.staff_id,
                            CONCAT(s.fname, ' ', s.lname) AS staff_full_name,
                            o.order_id,
                            CONCAT(c.fname, ' ', c.lname) AS customer_full_name,
                            o.order_date,
                            o.total_amount
                        FROM orders o
                        JOIN staffs s ON o.staff_id = s.staff_id
                        LEFT JOIN customers c ON o.customer_id = c.customer_id
                        WHERE CONCAT(s.fname, ' ', s.lname) LIKE @searchTerm OR CONCAT(c.fname, ' ', c.lname) LIKE @searchTerm OR s.staff_id = @id OR o.order_id = @id
                        ORDER BY s.lname, s.fname, o.order_date DESC;
                    ";
                    break;
                default:
                    MessageBox.Show("Search not implemented for table: " + currentTable, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    int idValue;
                    if (int.TryParse(searchTerm, out idValue))
                    {
                        cmd.Parameters.AddWithValue("@id", idValue);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id", -1); // Use a value that won't match any real ID
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No matching records found for " + currentTable + ".", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error during search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred during search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCellValue(DataGridViewRow row, int columnIndex)
        {
            if (row != null && columnIndex >= 0 && columnIndex < row.Cells.Count)
            {
                object? cellValue = row.Cells[columnIndex].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    return Convert.ToString(cellValue) ?? string.Empty;
                }
            }
            return string.Empty;
        }

        private int GetColumnIndex(string columnName)
        {
            if (dataGridView1?.Columns != null && dataGridView1.Columns.Contains(columnName))
            {
                DataGridViewColumn? col = dataGridView1.Columns[columnName];
                if (col != null)
                {
                    return col.Index;
                }
            }
            return -1;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                dash_fname.Clear();
                dash_lname.Clear();
                dash_pnumber.Clear();
                dash_address.Clear();

                switch (currentTable)
                {
                    case "customers":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("fname"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("lname"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("phone_number"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("address"));
                        break;
                    case "menu":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("item_name"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("category"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("price"));
                        break;
                    case "orders":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("order_id"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("customer_full_name")); // Use the concatenated column
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("order_date"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("total_amount"));
                        break;
                    case "order_details":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("order_detail_id"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("item_name"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("quantity"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("subtotal"));
                        break;
                    case "inventory":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("item_name"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("quantity_in_stock"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("reorder_level"));
                        break;
                    case "staffs":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("fname"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("lname"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("phone_number"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("email"));
                        break;
                    case "suppliers":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("name"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("contact_person"));
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("phone_number"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("address"));
                        break;
                    case "customer_order_summary":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("customer_id"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("customer_full_name")); // Use the concatenated column
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("total_orders"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("total_spent"));
                        break;
                    case "staff_order_summary":
                        if (dash_fname != null) dash_fname.Text = GetCellValue(row, GetColumnIndex("staff_id"));
                        if (dash_lname != null) dash_lname.Text = GetCellValue(row, GetColumnIndex("staff_full_name")); // Use concatenated staff name
                        if (dash_pnumber != null) dash_pnumber.Text = GetCellValue(row, GetColumnIndex("order_id"));
                        if (dash_address != null) dash_address.Text = GetCellValue(row, GetColumnIndex("customer_full_name")); // Use concatenated customer name
                        break;
                    default:
                        dash_fname.Clear();
                        dash_lname.Clear();
                        dash_pnumber.Clear();
                        dash_address.Clear();
                        break;
                }
            }
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case "customers":
                    AddCustomer();
                    break;
                case "menu":
                    AddMenuItem();
                    break;
                default:
                    MessageBox.Show($"Add operation not implemented for {currentTable} table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void AddCustomer()
        {
            string newLName = dash_lname.Text.Trim();
            string newFName = dash_fname.Text.Trim();
            string newPhoneNumber = dash_pnumber.Text.Trim();
            string newAddress = dash_address.Text.Trim();

            if (string.IsNullOrEmpty(newLName) || string.IsNullOrEmpty(newFName) || string.IsNullOrEmpty(newPhoneNumber) || string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Please fill all customer detail fields to add a new customer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO customers (lname, fname, phone_number, address) VALUES (@lname, @fname, @phone, @address)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@lname", newLName);
                    cmd.Parameters.AddWithValue("@fname", newFName);
                    cmd.Parameters.AddWithValue("@phone", newPhoneNumber);
                    cmd.Parameters.AddWithValue("@address", newAddress);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData("customers");
                    dash_fname.Clear();
                    dash_lname.Clear();
                    dash_pnumber.Clear();
                    dash_address.Clear();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMenuItem()
        {
            string itemName = dash_fname.Text.Trim();
            string category = dash_lname.Text.Trim();
            string price = dash_pnumber.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Please fill Item Name, Category, and Price to add a menu item.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal parsedPrice;
                if (!decimal.TryParse(price, out parsedPrice))
                {
                    MessageBox.Show("Please enter a valid number for Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO menu (item_name, category, price) VALUES (@itemName, @category, @price)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", parsedPrice);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Menu item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData("menu");
                    dash_fname.Clear();
                    dash_lname.Clear();
                    dash_pnumber.Clear();
                    dash_address.Clear();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record from the table to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (currentTable)
            {
                case "customers":
                    UpdateCustomer();
                    break;
                case "menu":
                    UpdateMenuItem();
                    break;
                default:
                    MessageBox.Show($"Update operation not implemented for {currentTable} table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void UpdateCustomer()
        {
            int customerId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("customer_id")), out customerId))
            {
                MessageBox.Show("Could not retrieve Customer ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatedLName = dash_lname.Text.Trim();
            string updatedFName = dash_fname.Text.Trim();
            string updatedPhoneNumber = dash_pnumber.Text.Trim();
            string updatedAddress = dash_address.Text.Trim();

            if (string.IsNullOrEmpty(updatedLName) || string.IsNullOrEmpty(updatedFName) || string.IsNullOrEmpty(updatedPhoneNumber) || string.IsNullOrEmpty(updatedAddress))
            {
                MessageBox.Show("Please fill all customer detail fields for updating.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE customers SET lname = @lname, fname = @fname, phone_number = @phone, address = @address WHERE customer_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@lname", updatedLName);
                    cmd.Parameters.AddWithValue("@fname", updatedFName);
                    cmd.Parameters.AddWithValue("@phone", updatedPhoneNumber);
                    cmd.Parameters.AddWithValue("@address", updatedAddress);
                    cmd.Parameters.AddWithValue("@id", customerId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData("customers");
                        dash_fname.Clear();
                        dash_lname.Clear();
                        dash_pnumber.Clear();
                        dash_address.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Customer update failed. No changes made or customer not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMenuItem()
        {
            int menuId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("menu_id")), out menuId))
            {
                MessageBox.Show("Could not retrieve Menu ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatedItemName = dash_fname.Text.Trim();
            string updatedCategory = dash_lname.Text.Trim();
            string updatedPriceText = dash_pnumber.Text.Trim();

            if (string.IsNullOrEmpty(updatedItemName) || string.IsNullOrEmpty(updatedCategory) || string.IsNullOrEmpty(updatedPriceText))
            {
                MessageBox.Show("Please fill Item Name, Category, and Price for updating the menu item.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                decimal parsedPrice;
                if (!decimal.TryParse(updatedPriceText, out parsedPrice))
                {
                    MessageBox.Show("Please enter a valid number for Price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE menu SET item_name = @itemName, category = @category, price = @price WHERE menu_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@itemName", updatedItemName);
                    cmd.Parameters.AddWithValue("@category", updatedCategory);
                    cmd.Parameters.AddWithValue("@price", parsedPrice);
                    cmd.Parameters.AddWithValue("@id", menuId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Menu item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData("menu");
                        dash_fname.Clear();
                        dash_lname.Clear();
                        dash_pnumber.Clear();
                        dash_address.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Menu item update failed. No changes made or item not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record from the table to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete this record from {currentTable}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                switch (currentTable)
                {
                    case "customers":
                        DeleteCustomer();
                        break;
                    case "menu":
                        DeleteMenuItem();
                        break;
                    case "orders":
                        DeleteOrder();
                        break;
                    case "order_details":
                        DeleteOrderDetail();
                        break;
                    default:
                        MessageBox.Show($"Delete operation not implemented for {currentTable} table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void DeleteCustomer()
        {
            int customerId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("customer_id")), out customerId))
            {
                MessageBox.Show("Could not retrieve Customer ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string getOrderIdsQuery = "SELECT order_id FROM orders WHERE customer_id = @id";
                        MySqlCommand getOrderIdsCmd = new MySqlCommand(getOrderIdsQuery, connection, transaction);
                        getOrderIdsCmd.Parameters.AddWithValue("@id", customerId);

                        List<int> orderIds = new List<int>();
                        using (MySqlDataReader reader = getOrderIdsCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderIds.Add(reader.GetInt32("order_id"));
                            }
                        }

                        if (orderIds.Count > 0)
                        {
                            string deleteOrderDetailsQuery = "DELETE FROM order_details WHERE order_id IN (" + string.Join(",", orderIds) + ")";
                            MySqlCommand deleteOrderDetailsCmd = new MySqlCommand(deleteOrderDetailsQuery, connection, transaction);
                            deleteOrderDetailsCmd.ExecuteNonQuery();
                        }

                        string deleteOrdersQuery = "DELETE FROM orders WHERE customer_id = @id";
                        MySqlCommand deleteOrdersCmd = new MySqlCommand(deleteOrdersQuery, connection, transaction);
                        deleteOrdersCmd.Parameters.AddWithValue("@id", customerId);
                        deleteOrdersCmd.ExecuteNonQuery();

                        string deleteCustomerQuery = "DELETE FROM customers WHERE customer_id = @id";
                        MySqlCommand deleteCustomerCmd = new MySqlCommand(deleteCustomerQuery, connection, transaction);
                        deleteCustomerCmd.Parameters.AddWithValue("@id", customerId);
                        int rowsAffected = deleteCustomerCmd.ExecuteNonQuery();

                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer and all associated data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData("customers");
                            dash_fname.Clear();
                            dash_lname.Clear();
                            dash_pnumber.Clear();
                            dash_address.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Customer deletion failed. Customer not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (MySqlException innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error during deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An unexpected error occurred during deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteMenuItem()
        {
            int menuId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("menu_id")), out menuId))
            {
                MessageBox.Show("Could not retrieve Menu ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string deleteOrderDetailsQuery = "DELETE FROM order_details WHERE menu_id = @id";
                        MySqlCommand deleteOrderDetailsCmd = new MySqlCommand(deleteOrderDetailsQuery, connection, transaction);
                        deleteOrderDetailsCmd.Parameters.AddWithValue("@id", menuId);
                        deleteOrderDetailsCmd.ExecuteNonQuery();

                        string query = "DELETE FROM menu WHERE menu_id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, connection, transaction);
                        cmd.Parameters.AddWithValue("@id", menuId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Menu item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData("menu");
                            dash_fname.Clear();
                            dash_lname.Clear();
                            dash_pnumber.Clear();
                            dash_address.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Menu item deletion failed. Item not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (MySqlException innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error during menu item deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An unexpected error occurred during menu item deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder()
        {
            int orderId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("order_id")), out orderId))
            {
                MessageBox.Show("Could not retrieve Order ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string deleteOrderDetailsQuery = "DELETE FROM order_details WHERE order_id = @id";
                        MySqlCommand deleteOrderDetailsCmd = new MySqlCommand(deleteOrderDetailsQuery, connection, transaction);
                        deleteOrderDetailsCmd.Parameters.AddWithValue("@id", orderId);
                        deleteOrderDetailsCmd.ExecuteNonQuery();

                        string deleteOrderQuery = "DELETE FROM orders WHERE order_id = @id";
                        MySqlCommand deleteOrderCmd = new MySqlCommand(deleteOrderQuery, connection, transaction);
                        deleteOrderCmd.Parameters.AddWithValue("@id", orderId);
                        int rowsAffected = deleteOrderCmd.ExecuteNonQuery();

                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order and its details deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData("orders");
                            dash_fname.Clear();
                            dash_lname.Clear();
                            dash_pnumber.Clear();
                            dash_address.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Order deletion failed. Order not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (MySqlException innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Database Error during order deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception innerEx)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An unexpected error occurred during order deletion transaction: " + innerEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrderDetail()
        {
            int orderDetailId;
            if (!int.TryParse(GetCellValue(dataGridView1.SelectedRows[0], GetColumnIndex("order_detail_id")), out orderDetailId))
            {
                MessageBox.Show("Could not retrieve Order Detail ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM order_details WHERE order_detail_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", orderDetailId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order detail deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData("order_details");
                        dash_fname.Clear();
                        dash_lname.Clear();
                        dash_pnumber.Clear();
                        dash_address.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Order detail deletion failed. Item not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void dash_fname_TextChanged(object sender, EventArgs e) { }
        private void dash_lname_TextChanged(object sender, EventArgs e) { }
        private void dash_pnumber_TextChanged(object sender, EventArgs e) { }
        private void dash_address_TextChanged(object sender, EventArgs e) { }

        private void Excel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = $"Save {currentTable.Replace(" ", "_")} Data as CSV";
                saveFileDialog.FileName = $"{currentTable.Replace(" ", "_")}Data.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    StringBuilder csvBuilder = new StringBuilder();

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        csvBuilder.Append(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1)
                        {
                            csvBuilder.Append(",");
                        }
                    }
                    csvBuilder.AppendLine();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                object? cellValue = row.Cells[i].Value;
                                string formattedValue = (cellValue == null || cellValue == DBNull.Value) ? "" : cellValue.ToString() ?? string.Empty;
                                if (formattedValue.Contains(","))
                                {
                                    csvBuilder.AppendFormat("\"{0}\"", formattedValue.Replace("\"", "\"\""));
                                }
                                else
                                {
                                    csvBuilder.Append(formattedValue);
                                }

                                if (i < dataGridView1.Columns.Count - 1)
                                {
                                    csvBuilder.Append(",");
                                }
                            }
                            csvBuilder.AppendLine();
                        }
                    }

                    File.WriteAllText(filePath, csvBuilder.ToString(), Encoding.UTF8);
                    MessageBox.Show("Data exported to CSV successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data to CSV: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dash_confidential_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string totalRevenueQuery = "SELECT SUM(total_amount) FROM orders";
                    MySqlCommand revenueCmd = new MySqlCommand(totalRevenueQuery, connection);
                    object? totalRevenueResult = revenueCmd.ExecuteScalar();
                    decimal totalRevenue = (totalRevenueResult != DBNull.Value && totalRevenueResult != null) ? Convert.ToDecimal(totalRevenueResult) : 0m;

                    string totalCustomersQuery = "SELECT COUNT(customer_id) FROM customers";
                    MySqlCommand totalCustomersCmd = new MySqlCommand(totalCustomersQuery, connection);
                    object? totalCustomersResult = totalCustomersCmd.ExecuteScalar();
                    int totalCustomers = (totalCustomersResult != DBNull.Value && totalCustomersResult != null) ? Convert.ToInt32(totalCustomersResult) : 0;

                    string activeCustomersQuery = "SELECT COUNT(DISTINCT customer_id) FROM orders";
                    MySqlCommand activeCustomersCmd = new MySqlCommand(activeCustomersQuery, connection);
                    object? activeCustomersResult = activeCustomersCmd.ExecuteScalar();
                    int activeCustomers = (activeCustomersResult != DBNull.Value && activeCustomersResult != null) ? Convert.ToInt32(activeCustomersResult) : 0;

                    string ordersTakenByStaffQuery = "SELECT COUNT(order_id) FROM orders WHERE staff_id IS NOT NULL";
                    MySqlCommand ordersTakenByStaffCmd = new MySqlCommand(ordersTakenByStaffQuery, connection);
                    object? ordersTakenByStaffResult = ordersTakenByStaffCmd.ExecuteScalar();
                    int ordersTakenByStaff = (ordersTakenByStaffResult != DBNull.Value && ordersTakenByStaffResult != null) ? Convert.ToInt32(ordersTakenByStaffResult) : 0;

                    string summaryMessage = $"Total Revenue: {totalRevenue:C2}\n" +
                                            $"Total Customers: {totalCustomers}\n" +
                                            $"Active Customers (with orders): {activeCustomers}\n" +
                                            $"Orders Taken by Staff: {ordersTakenByStaff}\n\n" +
                                            "Customer Order Summary will now be loaded into the table.\n" +
                                            "To view Staff Order details, change the table view to 'Staffs' and click this button again.";
                    MessageBox.Show(summaryMessage, "Confidential Report Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Logic to load specific summary based on current table selection
                    if (currentTable == "staffs")
                    {
                        LoadData("staff_order_summary"); // Load staff order summary if 'staffs' is selected
                    }
                    else
                    {
                        LoadData("customer_order_summary"); // Default to customer order summary
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database Error fetching confidential data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while generating the confidential report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}