using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public class Deck
    {
        public static Random rnd = new Random();
        public static string[] deck = new string[52];
        public static int deckIndex = 0;
        public void shuffleDeck()
        {
            var cardNum = new List<char>() { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };
            var cardSuit = new List<char>() { 'C', 'D', 'H', 'S' };
            for (int i = 0; i < 52; i++)
            {
                int suitIndex = rnd.Next(cardSuit.Count);
                int numIndex = rnd.Next(cardNum.Count);
                string newitem = Char.ToString(cardSuit[suitIndex]) + char.ToString(cardNum[numIndex]);
                while (deck.Contains(newitem))
                {
                    suitIndex = rnd.Next(cardSuit.Count);
                    numIndex = rnd.Next(cardNum.Count);
                    newitem = Char.ToString(cardSuit[suitIndex]) + char.ToString(cardNum[numIndex]);
                }
                deck[i] = newitem;
                System.Diagnostics.Debug.WriteLine(deck[i]);
            }
        }

        public string Assignhand()
        {
            string hand = deck[deckIndex++];
            return hand;
        }
    }
}
