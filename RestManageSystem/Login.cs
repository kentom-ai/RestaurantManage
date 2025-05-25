using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace RestManageSystem
{
    public partial class Login : Form
    {
        // Connection string for your MySQL database
        private const string connectionString = "Server=127.0.0.1;Database=restaurant management database;Uid=root;Pwd=kentominaga08;"; //

        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void login_register_Click(object sender, EventArgs e)
        {
            // This event handler is for a button that might navigate to a registration form.
            // The actual navigation logic is in label5_Click.
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {
            // If you want to show/hide password, you can modify this along with checkbox
            if (login_showpass.Checked)
            {
                login_password.PasswordChar = '\0'; // Show password
            }
            else
            {
                login_password.PasswordChar = '*'; // Hide password
            }
        }

        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on checkbox state
            if (login_showpass.Checked)
            {
                login_password.PasswordChar = '\0'; // Show password
            }
            else
            {
                login_password.PasswordChar = '*'; // Hide password
            }
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This is likely your login button
            string enteredUsername = login_username.Text.Trim(); // This will be the combined fname and lname
            string enteredPassword = login_password.Text;

            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Modified query to check against combined fname and lname, and the password column
                    string query = "SELECT COUNT(1) FROM staffs WHERE CONCAT(fname, ' ', lname) = @username AND password = @password"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", enteredUsername);
                        cmd.Parameters.AddWithValue("@password", enteredPassword);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Navigate to your main application form here (Dashboard.cs)
                            Dashboard mainForm = new Dashboard(); // Create an instance of your Dashboard form
                            mainForm.Show(); // Show the Dashboard form
                            this.Hide(); // Hide the current Login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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

        private void label4_Click_1(object sender, EventArgs e)
        {
            ForgotPassword sForm = new ForgotPassword();
            sForm.Show();
            this.Hide();
        }

        private void label4_Click_2(object sender, EventArgs e)
        {
            // Duplicate event handler, can be removed if label4_Click_1 is sufficient
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register sForm = new Register();
            sForm.Show();
            this.Hide();
        }
    }
}