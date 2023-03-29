﻿using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NEA
{
    public partial class gameForm : Form
    {
        public static string[] myhand = new string[3];
        public static string[] midhand = new string[3];
        public static int turncounter = 1;
        string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
        public static int midindex;
        public int pCount = onlinelobbies.numPlayersTotal;
        public bool knocked = false;
        public bool myturnran = false;
        public int currentplayernum;
        public static string currentPlayerName = account_page.currentPlayerName;



        public gameForm()
        {
            InitializeComponent();
        }

        bool started = false;
        int numPlayersTotal;
        public void CheckAllPlayersStarted(int lobbycount)
        {
            Console.WriteLine("method ran");
            pCount = lobbycount;
            // Create a new timer with a 1 second interval
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(CheckAllPlayersStarted_Tick);
            timer.Start();
        }



        private void CheckAllPlayersStarted_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("clock started");
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Check if all players in the lobby have started the game
                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT COUNT(*) FROM lobby1 WHERE gamestarted = true", connection))
                {
                    int numPlayersStarted = Convert.ToInt32(command.ExecuteScalar());
                    numPlayersTotal = pCount;

                    started = numPlayersStarted == numPlayersTotal;
                    Console.WriteLine("should have started ngl");
                }
            }
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
            //midcard3.Show();
            //button1.Show();
            //togglehide.Show();
            //knockbutton.Show();

            //code to reset playernum
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string query = "UPDATE lobby1 SET player_num = subquery.row_num FROM (SELECT player_name, ROW_NUMBER() OVER (ORDER BY player_name) as row_num FROM lobby1) AS subquery WHERE lobby1.player_name = subquery.player_name;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            //stores number of players locally

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                using (NpgsqlCommand countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM lobby1", con))
                {
                    pCount = Convert.ToInt32(countCommand.ExecuteScalar());
                    pCount--;

                }

                con.Close();
            }


            //store currentplayernum locally
            string selectQuery = "SELECT player_num FROM lobby1 WHERE player_name = @playerName";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    selectCommand.Parameters.AddWithValue("@playerName", currentPlayerName);

                    using (NpgsqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentplayernum = reader.GetInt32(0);
                            Console.WriteLine($"This player is playernum: {currentplayernum}");
                        }
                    }
                }
            }

            onlinegame.dealCards(numPlayersTotal);

        }

        public void DisplayHud()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Check if any player has knocked
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM lobby1 WHERE knocked = true", connection))
                {
                    int numKnocked = Convert.ToInt32(command.ExecuteScalar());

                    if (numKnocked == 0)
                    {
                        knockbutton.Show();
                    }
                }

                connection.Close();
            }

            button1.Show();
            togglehide.Show();
            label3.Show();
            label4.Show();
        }

        public void HideHud()
        {
            button1.Hide();
            togglehide.Hide();
            knockbutton.Hide();
            label3.Hide();
            label4.Hide();
        }

        public void DisplayCards()
        {
            // Get the current player's hand from the lobby1 table
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string selectQuery = "SELECT hand1, hand2, hand3 FROM lobby1 WHERE player_name = @playerName";


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@playerName", currentPlayerName);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Store the hand in an array called myhand
                            myhand[0] = reader.GetString(0);
                            myhand[1] = reader.GetString(1);
                            myhand[2] = reader.GetString(2);


                            p1card1.Show();
                            p1card2.Show();
                            p1card3.Show();
                            p1card1.Image = Properties.Resources.ResourceManager.GetObject(myhand[0]) as Image;
                            p1card2.Image = Properties.Resources.ResourceManager.GetObject(myhand[1]) as Image;
                            p1card3.Image = Properties.Resources.ResourceManager.GetObject(myhand[2]) as Image;
                        }
                    }
                }

                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@playerName", "midhand");

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Store the hand in an array called myhand
                            midhand[0] = reader.GetString(0);
                            midhand[1] = reader.GetString(1);
                            midhand[2] = reader.GetString(2);

                            // Now you can use myhand to do whatever you need to do with the player's hand
                            midcard1.Show();
                            midcard2.Show();
                            midcard3.Show();
                            midcard1.Image = Properties.Resources.ResourceManager.GetObject(midhand[0]) as Image;
                            midcard2.Image = Properties.Resources.ResourceManager.GetObject(midhand[1]) as Image;
                            midcard3.Image = Properties.Resources.ResourceManager.GetObject(midhand[2]) as Image;
                        }
                    }
                }
                connection.Close();
            }
        
}
            
            //if (playerNum == turncounter)
           // {
            //    DisplayHud();
          //  }
            //else
            //{
            //    HideHud();
           // }

        

        public void SwapHands()
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string selectQuery = "SELECT hand1, hand2, hand3 FROM lobby1 WHERE player_name = @playerName";
            string updateQuery = "UPDATE lobby1 SET hand1 = @hand1, hand2 = @hand2, hand3 = @hand3 WHERE player_name = @playerName";
            string midhandSelectQuery = "SELECT hand1, hand2, hand3 FROM lobby1 WHERE player_num = 0";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                    {
                        using (NpgsqlCommand midhandSelectCommand = new NpgsqlCommand(midhandSelectQuery, connection))
                        {
                            connection.Open();

                            selectCommand.Parameters.AddWithValue("@playerName", currentPlayerName);

                            // get the current player's hand
                            using (NpgsqlDataReader reader = selectCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string hand1 = reader.GetString(0);
                                    string hand2 = reader.GetString(1);
                                    string hand3 = reader.GetString(2);

                                    reader.Close();

                                    // get the midhand's hand
                                    using (NpgsqlDataReader midhandReader = midhandSelectCommand.ExecuteReader())
                                    {
                                        if (midhandReader.Read())
                                        {
                                            string midhandHand1 = midhandReader.GetString(0);
                                            string midhandHand2 = midhandReader.GetString(1);
                                            string midhandHand3 = midhandReader.GetString(2);

                                            midhandReader.Close();

                                            // update the current player's hand with the midhand's hand
                                            updateCommand.Parameters.Clear();
                                            updateCommand.Parameters.AddWithValue("@hand1", midhandHand1);
                                            updateCommand.Parameters.AddWithValue("@hand2", midhandHand2);
                                            updateCommand.Parameters.AddWithValue("@hand3", midhandHand3);
                                            updateCommand.Parameters.AddWithValue("@playerName", currentPlayerName);

                                            updateCommand.ExecuteNonQuery();

                                            // update the midhand's hand with the current player's hand
                                            updateCommand.Parameters.Clear();
                                            updateCommand.Parameters.AddWithValue("@hand1", hand1);
                                            updateCommand.Parameters.AddWithValue("@hand2", hand2);
                                            updateCommand.Parameters.AddWithValue("@hand3", hand3);
                                            updateCommand.Parameters.AddWithValue("@playerName", "midhand");

                                            updateCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            DisplayCards();

        }

        private static void CheckIfPlayerTurn()
        {
            if (turncounter == onlinegame.playerNum) ;
            {

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
                }
            }
        }

        private void nextTurn()
        {
            if (knocked == false)
            {
                knockbutton.Show();
            }

        }

        private void myTurn()
        {
            if (myturnran == false)
            {
                DisplayHud();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwapHands();
            button1.Hide();
        }

        private void knockbutton_Click(object sender, EventArgs e)
        {
                // Get the current player's name
                string currentPlayerName = account_page.currentPlayerName;

                // Update the current player's "knocked" status to true
                string updateQuery = "UPDATE lobby1 SET knocked = true WHERE player_name = @currentPlayerName";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@currentPlayerName", currentPlayerName);
                        command.ExecuteNonQuery();
                    }

                    // Check if anyone has knocked
                    string selectQuery = "SELECT COUNT(*) FROM lobby1 WHERE knocked = true";
                    using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                    {
                        int numPlayersKnocked = Convert.ToInt32(command.ExecuteScalar());

                        // If everyone has knocked, end the game
                        if (numPlayersKnocked == pCount - 1)
                        {
                            // Set game state to finished for all players
                            NpgsqlCommand finishGameCmd = new NpgsqlCommand("UPDATE lobby1 SET game_state = 'finished'", connection);
                            finishGameCmd.ExecuteNonQuery();

                            // Determine the next player number and set their game state to playing
                            int nextPlayerNum = (currentplayernum % pCount) + 1;
                            NpgsqlCommand nextPlayerCmd = new NpgsqlCommand("UPDATE lobby1 SET game_state = 'playing' WHERE player_num = @playerNum", connection);
                            nextPlayerCmd.Parameters.AddWithValue("playerNum", nextPlayerNum);
                            nextPlayerCmd.ExecuteNonQuery();

                            // Close the database connection
                            connection.Close();

                        // Display the game results
                        Console.WriteLine("penisssss");
                            //DisplayResults();
                        }
                        // If not everyone has knocked, move to the next player's turn
                        else
                        {
                            // Determine the next player number and set their game state to playing
                            int nextPlayerNum = (currentplayernum % pCount) + 1;
                            NpgsqlCommand nextPlayerCmd = new NpgsqlCommand("UPDATE lobby1 SET game_state = 'playing' WHERE player_num = @playerNum", connection);
                            nextPlayerCmd.Parameters.AddWithValue("playerNum", nextPlayerNum);
                            nextPlayerCmd.ExecuteNonQuery();

                            // Close the database connection
                            connection.Close();

                            // Display the next player's turn
                            DisplayHud();
                            DisplayCards();
                        }
                    }
                }
            

        }

        private void togglehide_Click(object sender, EventArgs e)
        {
            if (turncounter == pCount)
            {
                turncounter = 1;
            }
            else
            {
                turncounter++;
            }
            if (onlinegame.knocked)
            {
                onlinegame.UpdatePlayerGameState("knocked");
            }
            onlinegame.UpdatePlayerGameState("finished");
            HideHud();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


        private bool midbeforehand = false;

        private void midcard1_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                onlinegame.swapCard1(0);
                midbeforehand = true;
                midindex = 0;

            }
        }

        private void midcard2_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                onlinegame.swapCard1(1);
                midbeforehand = true;
                midindex = 1;
            }
        }

        private void midcard3_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                onlinegame.swapCard1(2);
                midbeforehand = true;
                midindex = 2;
            }
        }

        private void p1card1_Click(object sender, EventArgs e)
        {
            if (midbeforehand == true)
            {
                onlinegame.swapCard2(0, midindex);
                midbeforehand = false;
                DisplayCards();

            }
            midbeforehand = false;

        }

        private void p1card2_Click(object sender, EventArgs e)
        {

            if (midbeforehand == true)
            {
                onlinegame.swapCard2(1, midindex);
                midbeforehand = false;
                DisplayCards();

            }
            midbeforehand = false;

        }

        private void p1card3_Click(object sender, EventArgs e)
        {
            if (midbeforehand == true)
            {
                onlinegame.swapCard2(2, midindex);
                midbeforehand = false;
                DisplayCards();
            }
            midbeforehand = false;

        }

        private void deckcard_Click(object sender, EventArgs e)
        {

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayCards();
            DisplayHud();
            waitmsg.Hide();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Get the current player's name
            string currentPlayerName = account_page.currentPlayerName;

            // Check the current player's status in the database
            string queryString = "SELECT game_state FROM lobby1 WHERE player_name = @currentPlayerName";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@currentPlayerName", currentPlayerName);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Get the player's current game state
                            string gameState = reader.GetString(0);
                            reader.Close();

                            // Do something based on the player's game state
                            switch (gameState)
                            {
                                case "waiting":
                                    // Do nothing
                                    break;
                                case "playing":
                                    // Do something if the player is playing
                                    DisplayHud();
                                    DisplayCards();
                                    break;
                                case "finished":
                                    // determine the next player number
                                    HideHud();
                                    int nextPlayerNum = currentplayernum;
                                    if (currentplayernum == onlinelobbies.numPlayersTotal)
                                    {
                                        nextPlayerNum = 1;
                                    }
                                    else
                                    {
                                        nextPlayerNum = (currentplayernum + 1);
                                    }

                                    // update the current player's game_status to "waiting"
                                    NpgsqlCommand updateCurrentPlayerCmd = new NpgsqlCommand("UPDATE lobby1 SET game_state = 'waiting' WHERE player_num = @playerNum", connection);
                                    updateCurrentPlayerCmd.Parameters.AddWithValue("playerNum", currentplayernum);
                                    Console.WriteLine($"changed {currentplayernum} to waiting");

                                    updateCurrentPlayerCmd.ExecuteNonQuery();

                                    // update the next player's game_status to "playing"
                                    NpgsqlCommand updateNextPlayerCmd = new NpgsqlCommand("UPDATE lobby1 SET game_state = 'playing' WHERE player_num = @playerNum", connection);
                                    Console.WriteLine($"changed {nextPlayerNum} to playing");
                                    updateNextPlayerCmd.Parameters.AddWithValue("playerNum", nextPlayerNum);
                                    updateNextPlayerCmd.ExecuteNonQuery();
                                    break;

                                case "knocked":

                                    break;

                                case "ending":

                                    break;
                            }
                            
                        }

                        // close the reader and the connection
                        connection.Close();
                    }

                }
            }
            

        }
    }
}
