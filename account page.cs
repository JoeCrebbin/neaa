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
using System.Security.Cryptography;

namespace NEA
{
    public partial class account_page : Form
    {
        public static string currentPlayerName;
        public account_page()
        {
            InitializeComponent();
        }
        // create connection string with Npgsql
        string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

        // handle register button click
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Console.Beep();
            // create a new NpgsqlConnection object
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // check if the 'players' table exists in the database
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT EXISTS (SELECT FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'players')", connection))
                    {
                        bool tableExists = (bool)command.ExecuteScalar();

                        // if the table does not exist, create it
                        if (!tableExists)
                        {
                            using (NpgsqlCommand createTableCommand = new NpgsqlCommand("CREATE TABLE players (player_id SERIAL PRIMARY KEY, player_name TEXT NOT NULL UNIQUE, password TEXT NOT NULL, online_status BOOLEAN DEFAULT false, created_at TIMESTAMP DEFAULT NOW(), lobby_num INTEGER DEFAULT 0)", connection))
                            {
                                createTableCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // create a new player account
                    using (NpgsqlCommand createUserCommand = new NpgsqlCommand("INSERT INTO players (player_name, password) VALUES (@player_name, @password)", connection))
                    {
                        createUserCommand.Parameters.AddWithValue("@player_name", txtUsername.Text);

                        // hash the password using SHA256
                        SHA256 sha256 = SHA256.Create();
                        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashedPassword = builder.ToString();

                        createUserCommand.Parameters.AddWithValue("@password", hashedPassword);

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // create a new NpgsqlConnection object
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // authenticate the user
                    using (NpgsqlCommand authenticateCommand = new NpgsqlCommand("SELECT COUNT(*) FROM players WHERE player_name = @player_name AND password = @password", connection))
                    {
                        authenticateCommand.Parameters.AddWithValue("@player_name", txtUsername.Text);

                        // hash the password using SHA256
                        SHA256 sha256 = SHA256.Create();
                        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        string hashedPassword = builder.ToString();
                        authenticateCommand.Parameters.AddWithValue("@password", hashedPassword);

                        int userCount = Convert.ToInt32(authenticateCommand.ExecuteScalar());

                        // if authentication succeeds, log the user in
                        if (userCount > 0)
                        {
                            using (NpgsqlCommand setStatusCommand = new NpgsqlCommand("UPDATE players SET online_status = true WHERE player_name = @player_name", connection))
                            {
                                setStatusCommand.Parameters.AddWithValue("@player_name", txtUsername.Text);
                                setStatusCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Login successful!");

                            //set currently logged in player
                            currentPlayerName = txtUsername.Text;

                            // set player's online status to online in the database
                            using (NpgsqlCommand updateCommand = new NpgsqlCommand("UPDATE players SET online_status = true WHERE player_name = @player_name", connection))
                            {
                                updateCommand.Parameters.AddWithValue("@player_name", txtUsername.Text);
                                updateCommand.ExecuteNonQuery();
                            }

                            var startlobby = new onlinelobbies();
                            startlobby.Show();
                            Hide();
                        }
                        // otherwise, show an error message
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
