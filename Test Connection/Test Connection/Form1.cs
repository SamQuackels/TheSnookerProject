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
    public partial class Form1 : Form
    {
        // String aanmaken zodat je kan verbinden met de server
        string ConnectString = "datasource = localhost; port = 3306; username = root; password=; database = snooker";
        SQLFunctions sql = new SQLFunctions();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DBConnection();
            sql.AddItems(ConnectString, @"SELECT id FROM groupmatches", listBox1);
            sql.DetermineWinner(ConnectString, 3);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            // getGroupMatchData(Convert.ToInt32(listBox1.SelectedItem), ConnectString);
            sql.CreateNewMatch(ConnectString, "2", "3", "1", "2", "5", "6", "7", "8");

        }

        private void DBConnection()
        {
            if (sql.tryConnection(ConnectString))
            {
                MessageBox.Show("Verbinding Succesvol");
            }

            // SQL Query om alle users met ID 2 hun naam aan te passen
            string updateName =
                @"UPDATE users
                  SET name = 'Joe Mama'
                  WHERE ID = '2';";

            // SQL Query om alle namen van Users te verkrijgen
            string writeNames =
                @"SELECT name FROM users;";

            // SQL Query om gebruiker toe te voegen en te verwijderen
            string addUser =
                @"INSERT into users (name, foto, break) values('Joe Dad', 'foto6.png', '58')";

            string deleteUser =
                @"DELETE FROM users WHERE users.id = 4";
        }
    }
}
