using Npgsql;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=rogue.db.elephantsql.com;Port=5432;Database=cxdvhkfk;User Id=cxdvhkfk;Password=UfAT2N1gBo0FT2L-6n7kfNXgVx_a4pZs;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string delquery = "DELETE FROM lobby1;";
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(delquery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
