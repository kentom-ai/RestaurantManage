using MySql.Data.MySqlClient; // Needed for database interaction
using System;
using System.Windows.Forms;

namespace RestManageSystem
{
    public partial class Register : Form
    {
        // Connection string for your MySQL database
        private const string connectionString = "Server=127.0.0.1;Database=restaurant management database;Uid=root;Pwd=kentominaga08;"; //

        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set password character for the single password textbox on form load
            if (register_password != null)
                register_password.PasswordChar = '*';
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_username_TextChanged(object sender, EventArgs e)
        {
            // This textbox will now hold the combined first and last name.
            // No specific action needed here for this functionality.
        }

        private void register_email_TextChanged(object sender, EventArgs e)
        {
            // No specific action needed here for this functionality
        }

        private void register_password_TextChanged(object sender, EventArgs e)
        {
            // This event can be used to dynamically set password char if needed,
            // but usually handled by a 'show password' checkbox.
        }

        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility for the single password field.
            // Ensure 'login_showpass' checkbox and 'register_password' textbox are named correctly in your Designer.
            if (login_showpass != null && register_password != null)
            {
                if (login_showpass.Checked)
                {
                    register_password.PasswordChar = '\0'; // Show characters
                }
                else
                {
                    register_password.PasswordChar = '*'; // Hide characters with asterisk
                }
            }
        }

        // Event handler for the Register button (this is the one that saves the input and goes to login)
        private void register_btn_Click(object sender, EventArgs e)
        {
            // Get combined username, email, and password from input fields
            string combinedUsername = register_username.Text.Trim(); // Single textbox for combined name
            string email = register_email.Text.Trim();
            string password = register_password.Text;

            // Basic validation
            if (string.IsNullOrEmpty(combinedUsername) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all required fields.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Parse combined username into fname and lname ---
            string fname;
            string lname;
            string[] nameParts = combinedUsername.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 2)
            {
                fname = nameParts[0];
                lname = nameParts[1];
            }
            else if (nameParts.Length == 1)
            {
                fname = nameParts[0];
                lname = ""; // If only one part, assume it's the first name and last name is empty
            }
            else
            {
                MessageBox.Show("Please enter your full name (first name and last name) in the username field.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // In a real application, you should hash the password before storing it in the database.
            // For simplicity, this example stores it directly.

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Check if email already exists
                    string checkEmailQuery = "SELECT COUNT(1) FROM staffs WHERE email = @email"; //
                    using (MySqlCommand checkEmailCmd = new MySqlCommand(checkEmailQuery, connection))
                    {
                        checkEmailCmd.Parameters.AddWithValue("@email", email);
                        int emailCount = Convert.ToInt32(checkEmailCmd.ExecuteScalar());

                        if (emailCount > 0)
                        {
                            MessageBox.Show("This email is already registered. Please use a different email or log in.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Check if combined name (for login purposes) already exists to avoid confusion
                    // This is optional but good for user experience, especially if username is for login.
                    string checkNameQuery = "SELECT COUNT(1) FROM staffs WHERE CONCAT(fname, ' ', lname) = @combinedName"; //
                    using (MySqlCommand checkNameCmd = new MySqlCommand(checkNameQuery, connection))
                    {
                        checkNameCmd.Parameters.AddWithValue("@combinedName", combinedUsername);
                        int nameCount = Convert.ToInt32(checkNameCmd.ExecuteScalar());

                        if (nameCount > 0)
                        {
                            MessageBox.Show("A user with this full name already exists. Please adjust your name or log in.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 3. Insert new user into the staffs table
                    // The 'role' is set to 'Staff' by default.
                    // The 'phone_number' is set to an empty string as per your request, as it's NOT NULL.
                    string insertQuery = "INSERT INTO staffs (lname, fname, role, email, password, phone_number) " +
                                         "VALUES (@lname, @fname, @role, @email, @password, @phone_number)"; //

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@lname", lname);
                        insertCmd.Parameters.AddWithValue("@fname", fname);
                        insertCmd.Parameters.AddWithValue("@role", "Staff"); // Default role
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@phone_number", ""); // Empty string for phone_number as it's NOT NULL

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration Successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Redirect to the Login form
                            Login loginForm = new Login();
                            loginForm.Show();
                            this.Hide(); // Hide the current registration form
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // This method handles the click event for the 'Register Login' link/label.
        // It's already correctly set up to navigate back to the Login form.
        private void register_login_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}