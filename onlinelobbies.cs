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
        public static int numPlayersTotal;
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
            RetrieveLobby1();
            // Update the lobby_num for the current player in the players table
            string updateQuery = "UPDATE players SET lobby_num = 1 WHERE player_name = @playerName;";

            //swap leave and join, allow readys
            LobbyBtn.Hide();
            LeaveLobby1.Show();
            Lobby1Ready.Show();

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
            //swap leave and join, hide ready button
            LobbyBtn.Show();
            LeaveLobby1.Hide();
            Lobby1Ready.Hide();
            Lobby1Ready.Text = "Ready";
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

      
        

        private int GetPlayerCount()
        {
            string query = "SELECT COUNT(*) FROM lobby1";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    int playerCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return playerCount;
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

                    // Create a list to store the players currently in the lobby
                    List<string> currentPlayers = new List<string>();

                    while (reader.Read())
                    {
                        string playerName = reader.GetString(0);
                        currentPlayers.Add(playerName);

                        if (!Lobby1List.Items.Contains(playerName))
                        {
                            Lobby1List.Items.Add(playerName);
                        }
                    }
                    reader.Close();

                    // Remove any items in the list that don't match the current players in the lobby
                    foreach (string playerName in Lobby1List.Items)
                    {
                        if (!currentPlayers.Contains(playerName))
                        {
                            Lobby1List.Items.Remove(playerName);
                        }
                    }
                }
            }
        }


        private void Lobby1Ready_Click(object sender, EventArgs e)
        {
            RetrieveLobby1();
            TogglePlayerReadyStatus();
        }

        private void SetPlayerReadyStatus(bool readyStatus)
        {
            string query = "UPDATE lobby1 SET ready_status = @status WHERE player_name = @playerName";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("status", readyStatus);
                    cmd.Parameters.AddWithValue("playerName", account_page.currentPlayerName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void TogglePlayerReadyStatus()
        {
            // Get the current player's ready status
            bool currentStatus = GetPlayerReadyStatus();

            // Toggle the ready status
            bool newStatus = !currentStatus;

            // Update the player's ready status in the database
            SetPlayerReadyStatus(newStatus);

            // Update the "Ready" button text to reflect the new status
            Lobby1Ready.Text = newStatus ? "Unready" : "Ready";
        }
        private bool GetPlayerReadyStatus()
        {
            string query = "SELECT ready_status FROM lobby1 WHERE player_name = @playerName";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("playerName", account_page.currentPlayerName);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result);
                    }
                }
            }
            return false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Check if the current player is in the lobby
            string query = $"SELECT COUNT(*) FROM lobby1 WHERE player_name = '{account_page.currentPlayerName}'";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    int playerCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (playerCount == 0)
                    {
                        // Current player is not in the lobby, don't do anything
                        return;
                    }
                }
            }

            // Check if there are at least two players in the lobby
            int totalPlayers = GetPlayerCount();
            if (totalPlayers < 2)
            {
                // Not enough players in the lobby, disable the "Start Game" button
                startGameButton.Enabled = false;
                return;
            }

            // Check if all players in the lobby are ready
            query = "SELECT COUNT(*) FROM lobby1 WHERE ready_status = true";
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    int readyCount = Convert.ToInt32(cmd.ExecuteScalar());
                    if (readyCount == totalPlayers)
                    {
                        // All players are ready, enable the "Start Game" button
                        startGameButton.Enabled = true;
                    }
                    else
                    {
                        // Not all players are ready, disable the "Start Game" button
                        startGameButton.Enabled = false;
                    }
                }
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            RetrieveLobby1();
            // Create new instance of game form
            gameForm gameForm = new gameForm();
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = $"UPDATE lobby1 SET gamestarted = 'true' WHERE player_name = '{account_page.currentPlayerName}'";

                using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }


            // Open the game form for the current player
            gameForm.Show();

            // Start checking if all players have started the game
            numPlayersTotal = Lobby1List.Items.Count;
            gameForm.CheckAllPlayersStarted(numPlayersTotal);
        }

    }
   

}
