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

        public static void endgame()
        {
            //big for loop which handles score
            for (int j = 0; j!=playercount; j++)
            {
                flushed = false;
                ran = false;
                //testing for flush
                if ((hands[j, 0][0] == hands[j, 1][0]) & (hands[j, 1][0] == hands[j, 2][0]))
                {
                    score[j] = score[j] + 100;
                    flushed = true;
                    System.Diagnostics.Debug.WriteLine($"FLUSH: Player {j + 1}'s score is {score[j]}");

                }

                //sanitises notation to ints and tests for run
                List<char> CardNumbers = new List<char> { hands[j, 0][1], hands[j, 1][1], hands[j, 2][1] };
                List<int> OrderedCardNumbers = new List<int> { 1, 1, 1};
                for (int i = 0; i < 3; i++)
                {
                    ace = false;
                    switch (CardNumbers[i])
                    {
                        case 'A':
                            OrderedCardNumbers[i] = 1;
                            ace = true;
                            break;
                        case 'J':
                            OrderedCardNumbers[i] = 11;
                            break;
                        case 'Q':
                            OrderedCardNumbers[i] = 12;
                            break;
                        case 'K':
                            OrderedCardNumbers[i] = 13;
                            break;
                        default:
                            OrderedCardNumbers[i] = CardNumbers[i];
                            break;
                    }
                }
                
                OrderedCardNumbers.Sort();
                if ((OrderedCardNumbers[0]+1) == OrderedCardNumbers[1] && ((OrderedCardNumbers[1] + 1) == OrderedCardNumbers[2]))
                {
                    score[j] = score[j] + 300;
                    System.Diagnostics.Debug.WriteLine($"RUN: Player {j}'s score is {score[j]}");
                    ran = true;
                }
                else if (OrderedCardNumbers.Contains(1) && OrderedCardNumbers.Contains(12) && OrderedCardNumbers.Contains(13))
                {
                    score[j] = score[j] + 300;
                    System.Diagnostics.Debug.WriteLine($"RUN VIA KING QUEEN ACE: Player {j+1}'s score is {score[j]}");
                    ran = true;
                }

                highCard[j] = OrderedCardNumbers[2];
                if (ace)
                {
                    highCard[j] = 14;
                }
                
                
                //test for running flush

                if (ran && flushed)
                {
                    score[j] = score[j] + 900;
                }

                //test for prial

                if ((hands[j, 0][1] == hands[j, 1][1]) && (hands[j, 1][1] == hands[j, 2][1]))
                {
                    score[j] = score[j] + 1000;
                    System.Diagnostics.Debug.WriteLine($"PRILEL: Player {j+1}'s score is {score[j]}");

                }
                //test for pair
                else if ((hands[j, 0][1] == hands[j, 1][1]) || (hands[j, 1][1] == hands[j, 2][1]) || (hands[j, 0][1] == hands[j, 2][1]))
                {
                    score[j] = score[j] + 200;
                    System.Diagnostics.Debug.WriteLine($"PAIR: Player {j+1}'s score is {score[j]}");
                }
                //add highest card
                score[j] = score[j] + highCard[j];
            }

            int winningscore = 0;
            for (int i = 0; i < playercount; i++)
            {
                if (score[i + 1] > score[i])
                {
                    winningscore = score[i + 1];
                }
            }
            winner = Array.IndexOf(score, winningscore);
            
        }
    }
}
