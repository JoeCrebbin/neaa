using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    internal class game : Form1
    {
        public static string[,] hands = new string[6, 3];
        public static string[] midhand = new string[3];
        public static int[] score = new int[6];
        public static int playercount;
        public static bool flushed;
        public static bool ace;
        public static int[] highCard = new int[6];
        public static int winner = 0;
        public static bool ran;
        public static int sharedindex; //this is here because i need a parameter from one swapcard to the other
        public static string tempcard = string.Empty;
        public static Random rnd1 = new Random();

        public static void startGame(int pCount)
        {
            Form1 formcont = new Form1();
            Deck dealer = new Deck();
            dealer.shuffleDeck();
            System.Diagnostics.Debug.WriteLine("starting game with " + (pCount) + " players");
            playercount = pCount;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j != pCount; j++)
                {
                    hands[j, i] = dealer.Assignhand();
                }
                midhand[i] = dealer.Assignhand();
            }
        }

        public static void swapHand()
        {
            Form1 formc = new Form1();
            string[] temphand = new string[3];
            for (int i = 0; i < 3; i++)
            {
                temphand[i] = hands[playerwho, i];
                hands[playerwho, i] = midhand[i];
                midhand[i] = temphand[i];
            }
            //System.Diagnostics.Debug.WriteLine($"Mid hand should be {midhand[0]}, {midhand[1]} and {midhand[2]}");
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
            sharedindex = midIndex;
            tempcard = (midhand[midIndex]);

        }
        public static void swapCard2(int handIndex)
        {
            midhand[sharedindex] = hands[playerwho, handIndex];
            hands[playerwho, handIndex] = tempcard;
        }

        public static int ScoreHand(string[,] hands, int playerIndex)
        {
            // Sort the player's hand in descending order of card value
            string[] hand = new string[3] { hands[playerIndex, 0], hands[playerIndex, 1], hands[playerIndex, 2] };
            Array.Sort(hand, (x, y) => GetCardValue(y).CompareTo(GetCardValue(x)));

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

        public static List<int> GeneratePodium(string[,] hands, int pCount)
        {
            List<int> podium = new List<int>();

            // Score each player's hand and store the scores in a dictionary
            Dictionary<int, int> scores = new Dictionary<int, int>();
            for (int i = 0; i < pCount; i++)
            {
                scores[i] = ScoreHand(hands, i);
            }

            // Sort the scores in descending order and add the player indices to the podium
            var sortedScores = scores.OrderByDescending(x => x.Value);
            foreach (var score in sortedScores)
            {
                podium.Add(score.Key);
            }

            return podium;
        }
    }
}
