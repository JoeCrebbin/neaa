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
    public partial class Form1 : Form

    {
        public static string[] deck = new string[52];
        public static int deckIndex = 0;
        public static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] p1hand = new string[3];
            Deck dealer = new Deck();
            dealer.shuffleDeck();
            p1hand[0] = deck[deckIndex++];
            System.Diagnostics.Debug.WriteLine($"uhhhh {deck[deckIndex]}");
            p1hand[1] = deck[deckIndex++];
            p1hand[2] = deck[deckIndex++];
            System.Diagnostics.Debug.WriteLine("hand is " + p1hand[0] + p1hand[1] + p1hand[2]);
            deckdebug.Text = ("hand is " + p1hand[0] + " " + p1hand[1] + " " + p1hand[2]);
            p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\NEA\\Resources\\10_of_clubs.png");
        }

        public void Deal(string[] deck, int deckindex)
        {

        }

        public static string[] Deck(string[] deck)
        {
            return deck;
        }
    }
}
