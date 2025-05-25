using MySql.Data.MySqlClient; // Add this using statement
using System;
using System.Windows.Forms;

namespace RestManageSystem
{
    public partial class ForgotPassword : Form
    {
        // Connection string for your MySQL database
        private const string connectionString = "Server=127.0.0.1;Database=restaurant management database;Uid=root;Pwd=kentominaga08;"; //

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void forgotpass_email_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed here for this functionality
        }

        private void forgotpass_btn_Click(object sender, EventArgs e)
        {
            string enteredEmail = forgotpass_email.Text.Trim();

            if (string.IsNullOrEmpty(enteredEmail))
            {
                MessageBox.Show("Please enter your email address.", "Forgot Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Query to check if the email exists in the staffs table
                    string query = "SELECT COUNT(1) FROM staffs WHERE email = @email"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", enteredEmail);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            // Email exists, proceed to the Recovery form and pass the email
                            MessageBox.Show("Email found. You can now recover your password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // This line assumes Recovery has a constructor that takes a string.
                            Recovery recoveryForm = new Recovery(enteredEmail);
                            recoveryForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email not found. Please check your email address.", "Forgot Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}