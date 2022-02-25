using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Test_Connection
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void competitieBTN_Click(object sender, EventArgs e)
        {
            Form UserSelection = new User_Selection();
            UserSelection.Show();
            this.Hide();
        }

        private void statsBTN_Click(object sender, EventArgs e)
        {
            Form Stats = new Stats();
            Stats.Show();
            this.Hide();
        }
    }
}
