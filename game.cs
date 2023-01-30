using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    internal class game : Form1
    {
        public static string[,] hands = new string[6, 3];
        public static string[] midhand = new string[3];


        public static int sharedindex; //this is here because i need a parameter from one swapcard to the other
        public static string tempcard = string.Empty;
        public static Random rnd1 = new Random();

        public static void startGame(int pCount)
        {
            Form1 formcont = new Form1();
            Deck dealer = new Deck();
            dealer.shuffleDeck();
            System.Diagnostics.Debug.WriteLine("starting game with " + (pCount) + " players");
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
                midhand = temphand;
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
        }
}
