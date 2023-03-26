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
    public partial class launch_menu : Form
    {
        public launch_menu()
        {
            InitializeComponent();
        }

        private void offlinepnp_Click(object sender, EventArgs e)
        {
            var howmany = new hmp();
            howmany.Show();
            Hide();
        }

        private void online_Click(object sender, EventArgs e)
        {
            var Login = new account_page();
            Login.Show();
            Hide();
        }
    }
}
