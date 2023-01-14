using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    internal class game : Form1
    {
        public static string[] p1hand = new string[3];
        public static string[] p2hand = new string[3];
        public static string[] p3hand = new string[3];
        public static string[] p4hand = new string[3];
        public static string[] p5hand = new string[3];
        public static string[] p6hand = new string[3];
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
                p1hand[i] = dealer.Assignhand();
                System.Diagnostics.Debug.WriteLine($"hello this is working {p1hand[i]}");

                switch (pCount)
                {
                    case 2:
                        p2hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p2hand[i]}");
                        break;

                    case 3:
                        p2hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p2hand[i]}");

                        p3hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p3hand[i]}");
                        break;

                    case 4:
                        p2hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p2hand[i]}");

                        p3hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working3 {p3hand[i]}");

                        p4hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working4 {p4hand[i]}");
                        break;

                    case 5:
                        p2hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p2hand[i]}");

                        p3hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working3 {p3hand[i]}");
                        
                        p4hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working4 {p4hand[i]}");
                        
                        p5hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working5 {p5hand[i]}");
                        break;
                    
                    case 6:
                        p2hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working2 {p2hand[i]}");
                    
                        p3hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working3 {p3hand[i]}");
                        
                        p4hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working4 {p4hand[i]}");
                        
                        p5hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working6 {p5hand[i]}");
                        
                        p6hand[i] = dealer.Assignhand();
                        System.Diagnostics.Debug.WriteLine($"hello this is working6 {p6hand[i]}");
                        break;
                }
                midhand[i] = dealer.Assignhand();
            }
        }

        public static void swapHand()
        {
            Form1 formc = new Form1();
            string[] temphand = new string[3];

            switch (playerwho)
            {
                case 1:
                    {
                        System.Diagnostics.Debug.WriteLine($"p1 hand {p1hand[0]}");
                        temphand = p1hand;
                        p1hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p1 hand now {p1hand[0]} and playerwho is {playerwho}");
                        break;
                    }
                case 2:
                    {
                        System.Diagnostics.Debug.WriteLine($"p2 hand {p2hand[0]}");
                        temphand = p2hand;
                        p2hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p2 hand now {p2hand[0]} and playerwho is {playerwho}");
                        break;
                    }
                case 3:
                    {
                        System.Diagnostics.Debug.WriteLine($"p3 hand {p3hand[0]}");
                        temphand = p3hand;
                        p3hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p3 hand now {p3hand[0]} and playerwho is {playerwho}");
                        break;
                    }
                case 4:
                    {
                        System.Diagnostics.Debug.WriteLine($"p4 hand {p4hand[0]}");
                        temphand = p4hand;
                        p4hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p4 hand now {p4hand[0]} and playerwho is {playerwho}");
                        break;
                    }
                case 5:
                    {
                        System.Diagnostics.Debug.WriteLine($"p5 hand {p5hand[0]}");
                        temphand = p5hand;
                        p5hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p5 hand now {p5hand[0]} and playerwho is {playerwho}");
                        break;
                    }
                case 6:
                    {
                        System.Diagnostics.Debug.WriteLine($"p6 hand {p6hand[0]}");
                        temphand = p6hand;
                        p6hand = midhand;
                        midhand = temphand;
                        System.Diagnostics.Debug.WriteLine($"p6 hand now {p6hand[0]} and playerwho is {playerwho}");
                        break;
                    }
            }
        }

        public static void swapCard1(int midIndex)
        {
            sharedindex = midIndex;
            tempcard = (midhand[midIndex]);

        }
        public static void swapCard2(int handIndex)
        {
            switch (playerwho)
            {
                case 1:
                    {
                        midhand[sharedindex] = p1hand[handIndex];
                        p1hand[handIndex] = tempcard;
                        break;
                    }
                case 2:
                    {
                        midhand[sharedindex] = p2hand[handIndex];
                        p2hand[handIndex] = tempcard;
                        break;
                    }
                case 3:
                    {
                        midhand[sharedindex] = p3hand[handIndex];
                        p3hand[handIndex] = tempcard;
                        break;
                    }
                case 4:
                    {
                        midhand[sharedindex] = p4hand[handIndex];
                        p4hand[handIndex] = tempcard;
                        break;
                    }
                case 5:
                    {
                        midhand[sharedindex] = p5hand[handIndex];
                        p5hand[handIndex] = tempcard;
                        break;
                    }
                case 6:
                    {
                        midhand[sharedindex] = p6hand[handIndex];
                        p6hand[handIndex] = tempcard;
                        break;
                    }

            }
        }


    }
}
