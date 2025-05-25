using MySql.Data.MySqlClient; // Needed for database interaction
using System;
using System.Windows.Forms;

namespace RestManageSystem
{
    public partial class Recovery : Form
    {
        // Connection string for your MySQL database
        private const string connectionString = "Server=127.0.0.1;Database=restaurant management database;Uid=root;Pwd=kentominaga08;"; //

        // This field is crucial to store the email of the user
        private string? userEmail;

        public Recovery(string email)
        {
            InitializeComponent();
            this.userEmail = email;
        }

        public Recovery()
        {
            InitializeComponent();
            this.userEmail = null;
        }

        private void Recovery_Load(object sender, EventArgs e)
        {
            if (recovery_newpassword != null)
                recovery_newpassword.PasswordChar = '*';
            if (recovery_confirmpassword != null)
                recovery_confirmpassword.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // THIS IS THE KEY METHOD FOR SHOW/HIDE PASSWORD
        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            // Ensure these controls exist and are named correctly in your Designer.cs
            // The 'login_showpass' checkbox should be the one linked to this event.
            if (login_showpass != null && recovery_newpassword != null && recovery_confirmpassword != null)
            {
                if (login_showpass.Checked)
                {
                    recovery_newpassword.PasswordChar = '\0'; // This should show characters
                    recovery_confirmpassword.PasswordChar = '\0';
                }
                else
                {
                    recovery_newpassword.PasswordChar = '*'; // This should hide characters
                    recovery_confirmpassword.PasswordChar = '*';
                }
            }
        }

        private void recovery_btn_Click(object sender, EventArgs e)
        {
            string newPassword = recovery_newpassword.Text;
            string confirmPassword = recovery_confirmpassword.Text;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter and confirm your new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Error: User email not identified for password update. Please restart the recovery process.", "Recovery Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE staffs SET password = @newPassword WHERE email = @email"; //
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@email", this.userEmail);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login loginForm = new Login();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password. Email not found or no changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void recovery_confirmpass_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed here.
        }

        private void recovery_newpassword_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed here.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // This event handler is for 'checkBox1'. If 'login_showpass_CheckedChanged'
            // is not working, it's likely this one is actually connected to your checkbox.
            // If you want to use 'checkBox1', move the content from 'login_showpass_CheckedChanged' here.
            // For example:
            /*
            if (recovery_newpassword != null && recovery_confirmpassword != null)
            {
                if (checkBox1.Checked) // Make sure 'checkBox1' is accessible here
                {
                    recovery_newpassword.PasswordChar = '\0';
                    recovery_confirmpassword.PasswordChar = '\0';
                }
                else
                {
                    recovery_newpassword.PasswordChar = '*';
                    recovery_confirmpassword.PasswordChar = '*';
                }
            }
            */
            // After moving the logic, delete the empty 'login_showpass_CheckedChanged' method.
        }
    }
}