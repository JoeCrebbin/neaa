using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class gameForm : Form
    {
        public gameForm()
        {
            InitializeComponent();
        }

        bool started = false;
        int numPlayersTotal;
        public void CheckAllPlayersStarted(int lobbycount)
        {
            Console.WriteLine("method ran");

            // Create a new timer with a 1 second interval
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(CheckAllPlayersStarted_Tick);
            timer.Start();
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Check if all players in the lobby have started the game
                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT COUNT(*) FROM lobby1 WHERE gamestarted = true", connection))
                {
                    int numPlayersStarted = Convert.ToInt32(command.ExecuteScalar());
                    numPlayersTotal = lobbycount;

                    started = numPlayersStarted == numPlayersTotal;
                }
            }
        }

        private void CheckAllPlayersStarted_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("clock started");

            if (started)
            {
                // All players are ready, close the timer and start the game
                Timer timer = (Timer)sender;
                timer.Stop();
                StartGame();
            }
        }

        private void StartGame()
        {
            // Start the game
            Console.WriteLine("HELLOOOOOO");

            waitmsg.Hide();
            //deckcard.Show();
            //p1card1.Show();
            //p1card2.Show();
            //p1card3.Show();
            //midcard1.Show();
            //midcard2.Show();
            //midcard3.Show();
            //button1.Show();
            //togglehide.Show();
            //knockbutton.Show();
            onlinegame.startGame(numPlayersTotal);
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

    }
}
