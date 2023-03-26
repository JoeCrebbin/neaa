using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace NEA
{
    public partial class onlinelobbies : Form
    {
        string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
        public onlinelobbies()
        {
            InitializeComponent();
            RetrieveLobby1();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // display the number of online players in console output
                    using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM players WHERE online_status = true", connection))
                    {
                        int onlinePlayers = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine("Number of online players: " + onlinePlayers);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database. Please check your network connection and try again.");
                }
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

            // create a new NpgsqlConnection object
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // open the database connection
                    connection.Open();

                    // update the user's online status to false
                    using (NpgsqlCommand command = new NpgsqlCommand("UPDATE players SET online_status = false WHERE player_name = @player_name", connection))
                    {
                        command.Parameters.AddWithValue("@player_name", account_page.currentPlayerName);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // handle the exception
                }
            }
                // Remove the player from lobby1
                string query = "DELETE FROM lobby1 WHERE player_name = @playerName;";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = account_page.currentPlayerName;
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Success
                        }
                        else
                        {
                            // Error
                        }
                    }
                }

                // Set the player's lobby_num to 0
                string updateQuery = "UPDATE players SET lobby_num = 0 WHERE player_name = @playerName;";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = account_page.currentPlayerName;
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Success
                        }
                        else
                        {
                            // Error
                        }
                    }
                }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update the lobby_num for the current player in the players table
            string updateQuery = "UPDATE players SET lobby_num = 1 WHERE player_name = @playerName;";

            //swap leave and join
            LobbyBtn.Hide();
            LeaveLobby1.Show();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Begin a transaction to ensure consistency between updating the players table and inserting into the lobby1 table
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update the lobby_num for the current player in the players table
                        using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@playerName", account_page.currentPlayerName);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Insert the current player into lobby1
                        string insertQuery = "INSERT INTO lobby1 (player_name) VALUES (@playerName);";
                        using (NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@playerName", account_page.currentPlayerName);
                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            // If the insert was successful, add the player to the listbox
                            if (rowsAffected > 0)
                            {
                                Lobby1List.Items.Add(account_page.currentPlayerName);
                                MessageBox.Show("Player added to lobby!");
                            }
                            else
                            {
                                MessageBox.Show("Error adding player to lobby.");
                            }
                        }

                        // Commit the transaction since everything was successful
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Something went wrong, rollback the transaction and show the error message
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            RetrieveLobby1();
        }

        private void LeaveLobby1_Click(object sender, EventArgs e)
        {
            //swap leave and join
            LobbyBtn.Show();
            LeaveLobby1.Hide();
            // remove the player from the lobby table
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        string query = "DELETE FROM lobby1 WHERE player_name = @playerName;";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = account_page.currentPlayerName;
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // update the lobby list
                                Lobby1List.Items.Remove(account_page.currentPlayerName);
                                MessageBox.Show("Player removed from lobby!");

                                // update the lobby_num to 0 in the players table
                                string updateQuery = "UPDATE players SET lobby_num = 0 WHERE player_name = @playerName;";
                                using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = account_page.currentPlayerName;
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error removing player from lobby.");
                            }
                    
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("done");
            // Get the current player's name
            string currentPlayerName = account_page.currentPlayerName; // Replace with your code to get the current player's name

            // Remove the player from lobby1
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string query = "DELETE FROM lobby1 WHERE player_name = @playerName;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = currentPlayerName;
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Success
                    }
                    else
                    {
                        // Error
                    }
                }
            }

            // Set the player's lobby_num to 0
            string updateQuery = "UPDATE players SET lobby_num = 0 WHERE player_name = @playerName;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                {
                    command.Parameters.Add("@playerName", NpgsqlDbType.Varchar).Value = currentPlayerName;
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Success
                    }
                    else
                    {
                        // Error
                    }
                }
            }
        }


        private void RetrieveLobby1()
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string query = "SELECT player_name FROM lobby1;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string playerName = reader.GetString(0);
                        if (!Lobby1List.Items.Contains(playerName))
                        {
                            Lobby1List.Items.Add(playerName);
                        }
                    }
                    reader.Close();
                }
            }

        }
    }
}
