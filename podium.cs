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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            card1.Image = Properties.Resources.ResourceManager.GetObject(game.hands[game.winner, 0]) as Image;
            card2.Image = Properties.Resources.ResourceManager.GetObject(game.hands[game.winner, 1]) as Image;
            card3.Image = Properties.Resources.ResourceManager.GetObject(game.hands[game.winner, 2]) as Image;
            DisplayWinner();
        }

        public void DisplayWinner()
        {
            // Get the podium of top scoring players
            List<int> podium = game.GeneratePodium(game.hands, hmp.selectedp);

            // Print the podium
            Console.WriteLine("Podium:");
            for (int i = 0; i < podium.Count; i++)
            {
                int playerIndex = podium[i];
                Console.WriteLine($"#{i + 1}: Player {playerIndex + 1} scored {game.ScoreHand(game.hands, playerIndex)} points.");
            }
            wtext.Text = $"";
            //plabel.Text = ($"Player {game.winner+1}'s hand");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (temp > 0)
            {
                temp--;
            }
            card1.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 0]) as Image;
            card2.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 1]) as Image;
            card3.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 2]) as Image;
            plabel.Text = ($"Player {temp+1}'s hand");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp++;
            if (temp == game.playercount)
            {
                temp--;
            }
            card1.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 0]) as Image;
            card2.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 1]) as Image;
            card3.Image = Properties.Resources.ResourceManager.GetObject(game.hands[temp, 2]) as Image;
            plabel.Text = ($"Player {temp+ 1}'s hand");
        }
    }
}
