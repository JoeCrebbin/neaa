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
    public partial class online_podium : Form
    {
        public online_podium()
        {
            InitializeComponent();
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
    }
}
