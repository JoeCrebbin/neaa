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
    public partial class hmp : Form
    {
        public static int selectedp = 0;
        public hmp()
        {
            InitializeComponent();
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);
            comboBox1.Items.Add(6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedp = int.Parse(comboBox1.SelectedItem.ToString());
            }
            game.startGame(selectedp);
            var menu = new Form1();
            Hide();
            menu.Show();
        }
    }
}
