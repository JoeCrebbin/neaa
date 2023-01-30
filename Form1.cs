﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NEA
{
    public partial class Form1 : Form

    {
        public static int turnnum = 0;
        public static int playerwho = 0;

        public static bool cardsHidden;

        public static Random rnd = new Random();

        public void displaycards()
        {
            Form1 formcont = new Form1();
            cardsHidden= false;

            p1card1.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.hands[playerwho, 0] + ".png");
            p1card2.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.hands[playerwho, 1] + ".png");
            p1card3.ImageLocation = ("C:\\Users\\josep\\source\\repos\\neaa\\Resources\\" + game.hands[playerwho, 2] + ".png");
            System.Diagnostics.Debug.WriteLine($"playerwho is {playerwho}");
            System.Diagnostics.Debug.WriteLine($"current hand is {game.hands[playerwho, 0]} and {game.hands[playerwho, 1]} and {game.hands[playerwho, 2]}");
            showMidCards();

        }

        public Form1()
        {
            InitializeComponent();
        }

        public void nextTurn()
        {
            togglehide.Show();
            label3.Show();
            button1.Show();
            label4.Show();
            button1.Show();
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
                Form1 former = new Form1();
            switch (hmp.selectedp)
                {
                case 2:
                    switch (playerwho)
                    {
                        case 0:
                            playerwho= 1; 
                            break;
                        case 1:
                            playerwho= 0;
                            break;
                    }
                break;

                case 3:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 2:
                            playerwho = 0;
                            break;
                    }
                break;

                case 4:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 3:
                            playerwho = 0;
                            break;
                    }
                break;

                case 5:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 4:
                            playerwho = 0;
                        break;
                    }
                break;
                case 6:
                    switch (playerwho)
                    {
                        default:
                            playerwho++;
                            break;
                        case 5:
                            playerwho = 0;
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
            displaycards();
            nextTurn();
            label5.Show();
            label5.Text = $"Player {playerwho + 1}'s turn";
            deckcard.Hide();
            System.Diagnostics.Debug.WriteLine("");
        }
        public void togglehide_Click(object sender, EventArgs e)
        {
            hidecards();
            calcplayerwho();
            button1.Hide();
            deckcard.Show();
            label1.Show();
            togglehide.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.swapHand();
            deckcard.Show();
            displaycards();
            button1.Hide();
            hidecards();
            calcplayerwho();
            nextTurn();
            togglehide.Hide();
            button1.Hide();
            label5.Text = $"Player {playerwho + 1}'s turn";
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
                button1.Hide();
                midbeforehand = false;
                label5.Text = $"Player {playerwho + 1}'s turn";
                togglehide.Hide();
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
                button1.Hide();
                label1.Show();
                midbeforehand = false;
                label5.Text = $"Player {playerwho + 1}'s turn";
                togglehide.Hide();
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
                button1.Hide();
                midbeforehand = false;
                label5.Text = $"Player {playerwho + 1}'s turn";
                togglehide.Hide();
            }
        }
    }
}

