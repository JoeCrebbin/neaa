using System;
using System.CodeDom.Compiler;
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
    public partial class podium : Form
    {
        public podium()
        {
            InitializeComponent();
            afterGameShowHands();
        }

        private int temp = 0;

        public void afterGameShowHands()
        {
            card1.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[game.winner, 0]}.png");
            card2.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[game.winner, 1]}.png");
            card3.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[game.winner, 2]}.png");
            DisplayWinner();
        }

        public void DisplayWinner()
        {
            wtext.Text = $"Player {game.winner + 1}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (temp > 0)
            {
                temp--;
            }
            card1.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 0]}.png");
            card2.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 1]}.png");
            card3.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 2]}.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp++;
            if (temp == game.playercount)
            {
                temp--;
            }
            card1.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 0]}.png");
            card2.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 1]}.png");
            card3.Image = Image.FromFile($"{Application.StartupPath}\\Resources\\{game.hands[temp, 2]}.png");
        }
    }
}
