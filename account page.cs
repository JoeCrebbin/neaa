using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace NEA
{
    public partial class account_page : Form
    {
        public account_page()
        {
            InitializeComponent();
        }
        // create connection string with Npgsql
        string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

        // handle register button click
        private void button1_Click(object sender, EventArgs e)
        {
            // create a new NpgsqlConnection object
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // check if the 'users' table exists in the database
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'users')", connection))
                    {
                        bool tableExists = (bool)command.ExecuteScalar();

                        // if the table does not exist, create it
                        if (!tableExists)
                        {
                            using (NpgsqlCommand createTableCommand = new NpgsqlCommand("CREATE TABLE users (id SERIAL PRIMARY KEY, username TEXT NOT NULL UNIQUE, password TEXT NOT NULL)", connection))
                            {
                                createTableCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // create a new user account
                    using (NpgsqlCommand createUserCommand = new NpgsqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", connection))
                    {
                        createUserCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                        createUserCommand.Parameters.AddWithValue("@password", txtPassword.Text);

                        try
                        {
                            createUserCommand.ExecuteNonQuery();
                            MessageBox.Show("Account created successfully!");
                        }
                        catch (NpgsqlException ex)
                        {
                            if (ex.Message.Contains("duplicate key value"))
                            {
                                MessageBox.Show("Username already exists. Please choose a different username.");
                            }
                            else
                            {
                                MessageBox.Show("Error creating account. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database. Please check your network connection and try again.");
                }
            }
        }

        // handle login button click
        private void button2_Click(object sender, EventArgs e)
        {
            // create a new NpgsqlConnection object
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // authenticate the user
                    using (NpgsqlCommand authenticateCommand = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = @password", connection))
                    {
                        authenticateCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                        authenticateCommand.Parameters.AddWithValue("@password", txtPassword.Text);

                        int userCount = Convert.ToInt32(authenticateCommand.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful!");
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database. Please check your network connection and try again.");
                }
            }
        }
    }
}
