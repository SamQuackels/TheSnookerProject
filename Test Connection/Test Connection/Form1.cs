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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DBConnection();
            AddItems(ConnectString, @"SELECT id FROM groupmatches", listBox1);
            DetermineWinner(ConnectString, 3);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            // getGroupMatchData(Convert.ToInt32(listBox1.SelectedItem), ConnectString);
            CreateNewMatch(ConnectString, "2", "3", "1", "2", "5", "6", "7", "8");

        }

        private void DBConnection()
        {
            if (tryConnection(ConnectString))
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

            //string highestPKID =
            //    @"SELECT max(ID) FROM groupmatches";

            // Voert SQL Querys uit
            //ExecuteCommand(ConnectString, addUser);
            //ExecuteCommand(ConnectString, updateName);
            //ExecuteCommand(ConnectString, deleteUser);        
            //string s = GetData(ConnectString, writeNames);
            //string a = GetData(ConnectString, highestPKID);
            //getGroupMatchData(3, ConnectString);
        }

        List<string> getGroupMatchData(int ID, string ConnectString)
        {
            string command = String.Format(@"SELECT ID FROM matches WHERE GroupMatchID = '{0}'", ID);
            List<string> ids = GetData(ConnectString, command);
            command = String.Format(@"SELECT * FROM frames WHERE MatchID = '{0}' OR MatchID = '{1}' OR MatchID = '{2}'", ids[0], ids[1], ids[2]);
            List<string> fids = GetData(ConnectString, command);
            //MessageBox.Show(String.Join(", ",  fids.ToArray()));
            return fids;
        }

        void ExecuteCommand(string connectionString, string commandString)
        {
            // Controleert of er een verbinding is
            if (tryConnection(connectionString))
            {
                // Met gebruik van de connectie
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Command aanmaken
                    MySqlCommand command = new MySqlCommand(commandString, connection);
                    // Connectie openen
                    connection.Open();
                    // Commando doorsturen
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        bool tryConnection(string connectionString)
        {
            bool connected = true;
            MySqlConnection DBConnect = new MySqlConnection(connectionString);
            try
            {
                DBConnect.Open();
            }
            catch (Exception ex)
            {
                connected = false;
                MessageBox.Show(ex.Message);
            }
            return connected;
        }


        List<string> GetData(string connectionString, string commandString)
        {
            List<string> a = new List<string>();
            // Controleert of er een verbinding is
            if (tryConnection(connectionString))
            {
                // Met gebruik van de connectie
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Commando aanmaken
                    MySqlCommand command = new MySqlCommand(commandString, connection);
                    // Connectie openen
                    connection.Open();
                    // Met gebruik van de "DataReader"
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Terwijl het verschillende objecten leest 
                        while (reader.Read())
                        {
                            // Laat elk individueel object zien in een MessageBox
                            //MessageBox.Show(String.Format(Convert.ToString(reader[0])));
                            a.Add(String.Format(Convert.ToString(reader[0])));
                        }
                    }
                }
            }
            return a;
        }

        void AddItems(string connectionString, string commandString, ListBox lb)
        {
            if (tryConnection(connectionString))
            {
                lb.Items.Clear();
                // Met gebruik van de connectie
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Commando aanmaken
                    MySqlCommand command = new MySqlCommand(commandString, connection);
                    // Connectie openen
                    connection.Open();
                    // Met gebruik van de "DataReader"
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Terwijl het verschillende objecten leest 
                        while (reader.Read())
                        {
                            lb.Items.Add(Convert.ToString(reader[0]));
                        }
                    }
                }
            }
        }

        void DetermineWinner(string connectString, int ID)
        {
            List<string> IDS = getGroupMatchData(ID, ConnectString);
            int matcheswon = 0;
            //MessageBox.Show(String.Join(", ", IDS.ToArray()));          
            for (int i = 0 ;i <= 8 ;i += 3)
            {
                int matchwon = 0;
                string command = String.Format(@"SELECT user1won FROM frames WHERE ID = '{0}' OR ID = '{1}' OR ID = '{2}'", IDS[0 + i], IDS[1 + i], IDS[2 + i]);
                List<string> a = GetData(connectString, command);
                //MessageBox.Show(String.Join(", ", a.ToArray()));
                a.ForEach(delegate (string s)
                {
                    if (Convert.ToBoolean(s)) matchwon++;
                });
                if (matchwon >= 2)
                {
                    matchwon = 1;
                    matcheswon += 1;
                }
                else matchwon = 0;
                a.Clear();
                //MessageBox.Show(Convert.ToString(matchwon));
                command = String.Format(@"UPDATE matches SET user1won = {0} WHERE Frame1ID = {1}", matchwon, IDS[0 + i]);
                ExecuteCommand(connectString, command);
            }
            if (matcheswon >= 2) matcheswon = 1;
            else matcheswon = 0;
            string c = String.Format(@"UPDATE groupmatches SET group1won = {0} WHERE ID = {1}", matcheswon, ID);
            ExecuteCommand(connectString, c);
        }
        void CreateNewMatch(string connectString, string groupID1, string groupID2, string team1user1ID, string team1user2ID, string team1user3ID, string team2user1ID, string team2user2ID, string team2user3ID)
        {
            string[] users = new string[6]{ team1user1ID, team1user2ID, team1user3ID, team2user1ID, team2user2ID, team2user3ID};
            string[] matches = new string[3] { "match1ID", "match2ID", "match3ID" };
            string[] frames = new string[3] { "Frame1ID", "Frame2ID", "Frame3ID" };
            string c = String.Format(@"INSERT INTO groupmatches (group1ID, group2ID) VALUES ('{0}', '{1}');", groupID1, groupID2);
            ExecuteCommand(connectString, c);
            c = String.Format(@"SELECT max(ID)from groupmatches");
            List<string> ls = GetData(connectString, c);
            string gmID = string.Join(",", ls);

            for (int i = 0; i <= 2; i++) {
                c = String.Format(@"INSERT INTO matches (GroupMatchID) VALUES ('{0}');", gmID);
                ExecuteCommand(connectString, c);
                c = String.Format(@"SELECT max(ID)from matches");
                ls = GetData(connectString, c);
                string mID = string.Join(",", ls);
                c = String.Format(@"UPDATE groupmatches SET {0} = (SELECT max(ID) from matches) WHERE ID = (SELECT max(ID) from groupmatches)", matches[i]);
                ExecuteCommand(connectString, c);

                for (int j = 0; j <= 2; j++) {
                    c = String.Format(@"INSERT INTO frames (user1ID, user2ID, matchID) VALUES ('{0}', '{1}', '{2}');", users[i], users[i + 3], mID);
                    ExecuteCommand(connectString, c);
                    bool fwon = false;
                    Random rand = new Random();
                    if (rand.NextDouble() >= 0.5) fwon = true;      
                    c = String.Format(@"UPDATE frames SET user1won = {0} WHERE ID = (SELECT max(ID) from frames)", fwon);
                    ExecuteCommand(connectString, c);
                    c = String.Format(@"UPDATE matches SET {0} = (SELECT max(ID) from frames) WHERE ID = '{1}'", frames[j], mID);
                    ExecuteCommand(connectString, c);
                }
            }
            DetermineWinner(connectString, Convert.ToInt32(gmID));
        }
    }
}
