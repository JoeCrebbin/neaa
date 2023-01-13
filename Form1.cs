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
        public static int turnnum = 0;
        public static int playerwho = 1;

        public static bool cardsHidden;

        public static Random rnd = new Random();

        public void displaycards()
        {
            Form1 formcont = new Form1();
            cardsHidden= false;
            switch (playerwho)
            {
                case 1:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[2] + ".png");
                    showMidCards();
                    System.Diagnostics.Debug.WriteLine("it works!");
                    break;
                case 2:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p2hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p2hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p2hand[2] + ".png");
                    showMidCards();

                    break;
                case 3:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p3hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p3hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p3hand[2] + ".png");
                    showMidCards();
                    break;
                case 4:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p4hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p4hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p4hand[2] + ".png");
                    showMidCards();
                    break;
                case 5:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p5hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p5hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p5hand[2] + ".png");
                    showMidCards();
                    break;
                case 6:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p6hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p6hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p6hand[2] + ".png");
                    showMidCards();
                    break;
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        public void nextTurn()
        {
            togglehide.Show();
            label3.Show();
            label4.Show();
            button1.Show();
            deckcard.Hide();
            label1.Hide();
        }

        public void showMidCards()
        {
            midcard1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.midhand[0] + ".png");
            midcard2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.midhand[1] + ".png");
            midcard3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.midhand[2] + ".png");
        }

        public static void calcplayerwho()
            {
                switch (hmp.selectedp)
            {
                case 2:
                    switch (playerwho)
                    {
                        case 1:
                            playerwho= 2; 
                            break;
                        case 2:
                            playerwho= 1;
                            break;
                    }
                break;

                case 3:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 3:
                            playerwho = 1;
                            break;
                    }
                break;

                case 4:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 4:
                            playerwho = 1;
                            break;
                    }
                break;

                case 5:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 5:
                            playerwho = 1;
                        break;
                    }
                break;
                case 6:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 6:
                            playerwho = 1;
                            break;
                    }
                    break;
            }
            }

        public void hidecards()
        {
            cardsHidden= true;
            p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
            p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
            p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
        }

        
        public void pictureBox1_Click(object sender, EventArgs e)
        {

            if (turnnum == 0)
            {
                showMidCards();
                turnnum++;
                p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[0] + ".png");
                p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[1] + ".png");
                p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[2] + ".png");
                label1.Text = "Next player";

            }
            else
            {
                displaycards();
            }
            nextTurn();

            System.Diagnostics.Debug.WriteLine("");
        }
        public void togglehide_Click(object sender, EventArgs e)
        {
            hidecards();
            calcplayerwho();
            deckcard.Show();
            label1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.swapHand();
            displaycards();
            button1.Hide();
        }

        private bool midbeforehand = false;
        private void midcard1_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                game.swapCard1(0);
                midbeforehand = true;
            }
        }

        private void midcard2_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                game.swapCard1(1);
                midbeforehand = true;
            }
        }

        private void midcard3_Click(object sender, EventArgs e)
        {
            if (midbeforehand == false)
            {
                game.swapCard1(2);
                midbeforehand = true;

            }
        }


        private void p1card1_Click(object sender, EventArgs e)
        {
            if (midbeforehand == true && cardsHidden == false)
            {
                game.swapCard2(0);
                displaycards();
                hidecards();
                calcplayerwho();
                deckcard.Show();
                label1.Show();
                midbeforehand= false;
            }
        }

        private void p1card2_Click(object sender, EventArgs e)
        {
            if (midbeforehand == true && cardsHidden == false)
            {
                game.swapCard2(1);
                displaycards();
                hidecards();
                calcplayerwho();
                deckcard.Show();
                label1.Show();
                midbeforehand = false;
            }
        }

        private void p1card3_Click(object sender, EventArgs e)
        {
            if (midbeforehand == true && cardsHidden == false)
            {
                game.swapCard2(2);
                displaycards();
                hidecards();
                calcplayerwho();
                deckcard.Show();
                label1.Show();
                midbeforehand = false;
            }
        }
    }
}

