using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    internal class onlinegame :Form1
    {
        public static string[,] hands = new string[6, 3];
        public static string[] midhand = new string[3];
        public static int[] score = new int[6];
        public static int playercount;
        public static bool flushed;
        public static bool ace;
        public static string currentPlayerName = account_page.currentPlayerName;
        public static bool dealt;
        public static int[] highCard = new int[6];
        public static int winner = 0;
        public static bool ran;
        public static int sharedindex; //this is here because i need a parameter from one swapcard to the other
        public static string tempcard = string.Empty;
        public static Random rnd1 = new Random();
        public static int playerNum;

        public static bool isAdmin(string CurrentPlayer)
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT player_num FROM lobby1 WHERE player_name = '{CurrentPlayer}'";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    playerNum = (int)command.ExecuteScalar();

                    if (playerNum == 1)
                    {
                        Console.WriteLine("The player has player_num 1.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("The player does not have player_num 1.");
                        return false;
                    }
                }
            }


        }

        public static void dealCards(int pCount)
        {
            //test if player is "admin"
            if (isAdmin(account_page.currentPlayerName) == true)
            {
                dealt = true;
                // code for dealing all hands
                Deck dealer = new Deck();
                dealer.shuffleDeck();
                System.Diagnostics.Debug.WriteLine("starting game with " + (pCount) + " players");

                playercount = pCount;
                string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {

                    // Loop through each card in the hands and insert it into the lobby1 table
                        string updateQuery = "UPDATE lobby1 SET hand1 = @hand1, hand2 = @hand2, hand3 = @hand3 WHERE player_num = @playerNum";

                            using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                            {
                                connection.Open();

                                for (int i = 1; i <= pCount+1; i++)
                                {
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@hand1", dealer.Assignonlinehand());
                                    command.Parameters.AddWithValue("@hand2", dealer.Assignonlinehand());
                                    command.Parameters.AddWithValue("@hand3", dealer.Assignonlinehand());
                                    command.Parameters.AddWithValue("@playerNum", i);

                                    command.ExecuteNonQuery();
                                }
                            }
                       
                    string query2 = "INSERT INTO lobby1 (player_num, player_name, ready_status, gamestarted, hand1, hand2, hand3) VALUES (0, 'midhand', true, true, '', '', ''); UPDATE lobby1 SET hand1 = @midhand1, hand2 = @midhand2, hand3 = @midhand3 WHERE player_num = 0";
                    using (NpgsqlCommand command = new NpgsqlCommand(query2, connection))
                    {
                        command.Parameters.Clear();
                        Console.WriteLine("shoudl work");
                        command.Parameters.AddWithValue("@midhand1", dealer.Assignonlinehand());
                        command.Parameters.AddWithValue("@midhand2", dealer.Assignonlinehand());
                        command.Parameters.AddWithValue("@midhand3", dealer.Assignonlinehand());
                        command.ExecuteNonQuery();
                    }
                }
                // Connect to the database
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    // Construct the SQL command
                    string sql = "UPDATE lobby1 SET turnstatus = true WHERE player_name = @PlayerName;";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("PlayerName", currentPlayerName);
                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                        
                }
                gameForm gameForm = new gameForm();
                UpdatePlayerGameState("playing");
            }

        }
        public static int GetCardValue(string card)
        {
            char value = card[1];

            if (value == 'A')
            {
                return 1;
            }
            else if (value >= '2' && value <= '9')
            {
                return value - '0';
            }
            else if (value == 'T')
            {
                return 10;
            }
            else if (value == 'J')
            {
                return 11;
            }
            else if (value == 'Q')
            {
                return 12;
            }
            else if (value == 'K')
            {
                return 13;
            }
            else
            {
                throw new ArgumentException($"Invalid card value '{value}'.");
            }
        }

        public static void swapCard1(int midIndex)
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string selectQuery = $"SELECT hand{midIndex+1} FROM lobby1 WHERE player_num = 0";

                using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    // get the value from midhand's hand
                    string tempcard = "";
                    using (NpgsqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tempcard = reader.GetString(0);
                            Console.WriteLine(tempcard);
                        }
                    }
                }
            }

        }

        public static int ScoreHand(string hand1, string hand2, string hand3)
        {
            // Sort the player's hand in descending order of card value
            string[] hand = new string[3] { hand1, hand2, hand3 };
            Array.Sort(hand, (x, y) => GetCardValue(y).CompareTo(GetCardValue(x)));
            Console.WriteLine($"{hand[0]}, {hand[1]} and {hand[2]}");

            // Check for special hands
            if (hand[0][1] == hand[1][1] && hand[1][1] == hand[2][1])
            {
                // Three of a kind
                if (hand[0][1] == 'A')
                {
                    return 31;
                }
                else
                {
                    return 30 + GetCardValue(hand[0]);
                }
            }
            else if (hand[0][1] == hand[1][1])
            {
                // Pair
                if (hand[0][1] == 'A')
                {
                    return 21;
                }
                else
                {
                    return 20 + GetCardValue(hand[0]);
                }
            }
            else if (hand[0][0] == hand[1][0] && hand[1][0] == hand[2][0])
            {
                // Flush
                return 15 + GetCardValue(hand[0]);
            }
            else if (GetCardValue(hand[0]) == 13 && GetCardValue(hand[1]) == 12 && GetCardValue(hand[2]) == 11)
            {
                // Run
                return 14;
            }
            else
            {
                // High card
                return GetCardValue(hand[0]);
            }
        }

        public static List<int> GeneratePodium(int pCount)
        {
            List<int> podium = new List<int>();

            // Score each player's hand and store the scores in a dictionary
            Dictionary<int, int> scores = new Dictionary<int, int>();
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT hand1, hand2, hand3 FROM lobby1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            string hand1 = reader.GetString(0);
                            string hand2 = reader.GetString(1);
                            string hand3 = reader.GetString(2);
                            scores[i] = ScoreHand(hand1, hand2, hand3);
                            i++;
                        }
                    }
                }
            }

            // Sort the scores in descending order and add the player indices to the podium
            var sortedScores = scores.OrderByDescending(x => x.Value);
            foreach (var score in sortedScores)
            {
                podium.Add(score.Key);
            }

            return podium;
        }


        public static void swapCard2(int handindex, int midindex)
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";
            string selectQuery = $"SELECT hand{handindex+1} FROM lobby1 WHERE player_name = @playerName";
            string updateQuery = $"UPDATE lobby1 SET hand{handindex+1} = @currentHand1 WHERE player_name = @playerName";
            string midhandSelectQuery = $"SELECT hand{midindex+1} FROM lobby1 WHERE player_num = 0";
            string midhandUpdateQuery = $"UPDATE lobby1 SET hand{midindex + 1} = @midhandHand1 WHERE player_num = 0";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection))
                {
                    using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                    {
                        using (NpgsqlCommand midhandSelectCommand = new NpgsqlCommand(midhandSelectQuery, connection))
                        {
                            using (NpgsqlCommand midhandUpdateCommand = new NpgsqlCommand(midhandUpdateQuery, connection))
                            {
                                connection.Open();

                                // Get the current player's hand1
                                selectCommand.Parameters.AddWithValue("@playerName", currentPlayerName);
                                string currentHand1 = "";
                                using (NpgsqlDataReader reader = selectCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        currentHand1 = reader.GetString(0);
                                    }
                                    reader.Close();
                                }

                                // Get the midhand's hand1
                                string midhandHand1 = "";
                                using (NpgsqlDataReader midhandReader = midhandSelectCommand.ExecuteReader())
                                {
                                    if (midhandReader.Read())
                                    {
                                        midhandHand1 = midhandReader.GetString(0);
                                    }
                                    midhandReader.Close();
                                }

                                // Update the current player's hand1 with the midhand's hand1
                                updateCommand.Parameters.AddWithValue("@currentHand1", midhandHand1);
                                updateCommand.Parameters.AddWithValue("@playerName", currentPlayerName);
                                updateCommand.ExecuteNonQuery();

                                // Update the midhand's hand1 with the current player's hand1
                                midhandUpdateCommand.Parameters.AddWithValue("@midhandHand1", currentHand1);
                                midhandUpdateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).BeginInit();
            this.SuspendLayout();
            // 
            // p1card1
            // 
            this.p1card1.Click += new System.EventHandler(this.p1card1_Click);
            // 
            // onlinegame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Name = "onlinegame";
            ((System.ComponentModel.ISupportInitialize)(this.p1card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1card1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static void UpdatePlayerGameState(string state)
        {
            // Connect to the database
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;"))
            {
                conn.Open();

                // Create the SQL statement to update the game_state column
                string sql = $"UPDATE lobby1 SET game_state = '{state}' WHERE player_name = '{account_page.currentPlayerName}';";

                Console.WriteLine($"set {account_page.currentPlayerName} to {state}");

                // Create the command object
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Execute the command
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void p1card1_Click(object sender, EventArgs e)
        {

        }   
    }
}
