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

    }
}
