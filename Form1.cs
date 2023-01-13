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

        public Form1()
        {
            InitializeComponent();
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
                        case 1:
                            playerwho++;
                            break;
                        case 2:
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
                        case 1:
                            playerwho++;
                            break;
                        case 2:
                            playerwho++;
                            break;
                        case 3:
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
                        case 1:
                            playerwho++;
                            break;
                        case 2:
                            playerwho++;
                            break;
                        case 3:
                            playerwho++;
                            break;
                        case 4:
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
                        case 1:
                            playerwho++;
                            break;
                        case 2:
                            playerwho++;
                            break;
                        case 3:
                            playerwho++;
                            break;
                        case 4:
                            playerwho++;
                            break;
                        case 5:
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
            p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
            p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
            p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\card back black.png");
        }

        public void displaycards()
        {
            switch (playerwho)
            {
                case 1:
                    p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[0] + ".png");
                    p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[1] + ".png");
                    p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.p1hand[2] + ".png");
                    showMidCards();
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
                calcplayerwho();

            }
            else
            {
                displaycards();
                calcplayerwho();
            }
            System.Diagnostics.Debug.WriteLine("");
        }
        public void togglehide_Click(object sender, EventArgs e)
        {
            hidecards();
        }
    }
}

