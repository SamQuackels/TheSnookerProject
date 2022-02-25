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
    class SQLFunctions
    {
        private bool frameover;
        public bool Frameover
        {
            get { return frameover; }
            set { frameover = value; }
        }
        private int score1;
        public int Score1
        {
            get { return score1; }
            set { score1 = value; }
        }
        private int score2;
        public int Score2
        {
            get { return score2; }
            set { score2 = value; }
        }
        // Haalt lijst van frames gebaseerd op groupmatch ID
        public List<string> getGroupMatchData(int ID, string ConnectString)
        {
            string command = String.Format(@"SELECT ID FROM matches WHERE GroupMatchID = '{0}'", ID);
            List<string> ids = GetData(ConnectString, command);
            command = String.Format(@"SELECT * FROM frames WHERE MatchID = '{0}' OR MatchID = '{1}' OR MatchID = '{2}' OR MatchID = '{3}' OR MatchID = '{4}' OR MatchID = '{5}' OR MatchID = '{6}' OR MatchID = '{7}' OR MatchID = '{8}'", ids[0], ids[1], ids[2], ids[3], ids[4], ids[5], ids[6], ids[7], ids[8]) ;
            List<string> fids = GetData(ConnectString, command);
            //MessageBox.Show(String.Join(", ",  fids.ToArray()));
            return fids;
        }

        // Voert een SQL commando uit
        public void ExecuteCommand(string connectionString, string commandString)
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
        // Test de verbinding met de database
        public bool tryConnection(string connectionString)
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

        // Haalt data in de vorm van een lijst van de database mbv een sql querie
        public List<string> GetData(string connectionString, string commandString)
        {
            List<string> Items = new List<string>();
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
                            Items.Add(String.Format(Convert.ToString(reader[0])));
                        }
                    }
                }
            }
            return Items;
        }

        // Voegt een lijst van items aan een listbox toe (handig voor speler selectie)
        public void AddItemsLB(string connectionString, string commandString, ListBox lb)
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

        public void AddItemsCB(string connectionString, string commandString, ComboBox cb)
        {
            if (tryConnection(connectionString))
            {
                cb.Items.Clear();
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
                            cb.Items.Add(Convert.ToString(reader[0]));
                        }
                    }
                }
            }
        }
        // Bepaalt winnaar adhv groupmatch ID, wordt automatisch uitgevoerd na einde van match.
        public void DetermineWinner(string connectString, int ID)
        {
            // Maakt string arrays om over te loopen
            string[] matches = new string[9] { "match1ID", "match2ID", "match3ID", "match4ID", "match5ID", "match6ID", "match7ID", "match8ID", "match9ID" };
            string[] frames = new string[2] { "Frame1ID", "Frame2ID" };
            int wonTotal = 0;
            string command;
            // Loopen over alle matches van een groupmatch
            for (int i = 0; i < 9; i++)
            {
                command = String.Format(@"SELECT {0} from groupmatches WHERE ID = {1}", matches[i], ID);
                string mID = String.Join("", GetData(connectString, command));

                int won = 0;
                // Loopen over beide frames van de match
                for (int j = 0; j < 2; j++)
                {
                    command = String.Format(@"SELECT {0} FROM matches WHERE ID = {1}", frames[j], mID);
                    string fID = String.Join("", GetData(connectString, command));
                    command = String.Format(@"SELECT user1won FROM frames WHERE ID = {0}", fID);
                    string didWin = String.Join("", GetData(connectString, command));
                    if (didWin == "1")
                    {
                        won++;
                        wonTotal++;
                    }
                }
                // Update de winnaar van de match
                command = String.Format(@"UPDATE matches SET user1won = '1' WHERE ID = {0}", mID);
                if (won == 1) command = String.Format(@"UPDATE matches SET user1won = 'NULL' WHERE ID = {0}", mID);
                else if (won == 0) command = String.Format(@"UPDATE matches SET user1won = '0' WHERE ID = {0}", mID);

                ExecuteCommand(connectString, command);
            }
            // Update de winnaar van de groupmatch
            command = String.Format(@"UPDATE groupmatches SET group1won = '1' WHERE ID = {0}", ID);
            if (wonTotal == 9) command = String.Format(@"UPDATE groupmatches SET group1won = 'NULL' WHERE ID = {0}", ID);
            else if (wonTotal < 9) command = String.Format(@"UPDATE groupmatches SET group1won = '0' WHERE ID = {0}", ID);

            ExecuteCommand(connectString, command);
        }
        // Maakt nieuwe match aan en zorgt ervoor dat alle data geupload wordt.
        public async Task CreateNewMatchAsync
        (string connectString, 
            string groupID1, 
            string groupID2, 
            string team1user1ID, 
            string team1user2ID, 
            string team1user3ID, 
            string team2user1ID, 
            string team2user2ID, 
            string team2user3ID)
        {
            // Lijst die we kunnen gebruiken om alles te updaten met een for loop
            string[] matches = new string[9] { "match1ID", "match2ID", "match3ID", "match4ID", "match5ID", "match6ID", "match7ID", "match8ID", "match9ID" };
            string[] frames = new string[2] { "Frame1ID", "Frame2ID"};
            string c = String.Format(@"INSERT INTO groupmatches (group1ID, group2ID) VALUES ('{0}', '{1}');", groupID1, groupID2);
            ExecuteCommand(connectString, c);
            c = String.Format(@"SELECT max(ID)from groupmatches");
            string gmID = string.Join(",", GetData(connectString, c));
            // Loopt over elke match van de groupmatch
            for (int i = 0; i < 9; i++)
            {
                string user1 = team1user3ID;
                string user2 = team2user3ID;
                // Haalt momentele spelers
                if (i == 0 || i == 5 || i == 7) user1 = team1user1ID;
                else if (i == 1 || i == 3 || i == 8) user1 = team1user2ID;
                if (i == 0 || i == 3 || i == 6) user2 = team2user1ID;
                else if (i == 1 || i == 4 || i == 7) user2 = team2user2ID;
                c = String.Format(@"INSERT INTO matches (GroupMatchID) VALUES ('{0}');", gmID);
                ExecuteCommand(connectString, c);
                c = String.Format(@"SELECT max(ID)from matches");
                string mID = string.Join(",", GetData(connectString, c));
                c = String.Format(@"UPDATE groupmatches SET {0} = {1} WHERE ID = {2}", matches[i], mID, gmID);
                ExecuteCommand(connectString, c);
                LoadPage(connectString, Convert.ToInt32(user1), Convert.ToInt32(user2), Convert.ToInt32(groupID1), Convert.ToInt32(groupID2));
                // Loopt over beide frames van de match
                for (int j = 0; j < 2; j++)
                {
                    //Maakt nieuwe frame aan en voegt de frame toe aan de match
                    c = String.Format(@"INSERT INTO frames (user1ID, user2ID, matchID) VALUES ('{0}', '{1}', '{2}');", user1, user2, mID);
                    ExecuteCommand(connectString, c);
                    c = String.Format(@"SELECT max(ID)from frames");
                    string fID = string.Join(",", GetData(connectString, c));
                    c = String.Format(@"UPDATE matches SET {0} = {1} WHERE ID = '{2}'", frames[j], fID, mID);
                    ExecuteCommand(connectString, c);
                    // Wacht tot frame over is
                    while (!Frameover) { await Task.Delay(1); }
                    // Update de frame met winnaar en scores
                    if (score1 > score2) c = String.Format(@"UPDATE frames SET user1won = 1 WHERE ID = {0}", fID);
                    else if (score1 < score2) c = String.Format(@"UPDATE frames SET user1won = 0 WHERE ID = {0}", fID);
                    else c = String.Format(@"UPDATE frames SET user1won = NULL WHERE ID = {0}", fID);
                    ExecuteCommand(connectString, c);
                    // Scores updaten in de database
                    c = String.Format(@"UPDATE frames SET score1 = {0} WHERE ID = {1}", score1, fID);
                    ExecuteCommand(connectString, c);
                    c = String.Format(@"UPDATE frames SET score2 = {0} WHERE ID = {1}", score2, fID);
                    ExecuteCommand(connectString, c);
                    Frameover = false;
                }
            }
            DetermineWinner(connectString, Convert.ToInt32(gmID));
        }

        // Update alles op de form 
        // Geeft de ID's van de momentele spelers / groepen mee.
        public void LoadPage(string connectString, int lID, int rID, int glID, int grID)
        {
            // Haalt de open form van type 'Form1'
            Form1 OpenForm = (Form1)Application.OpenForms["Form1"];
            // Roept de functie van de open form om het aan te passen
            OpenForm.UpdatePage("leftScore", "0");
            OpenForm.UpdatePage("rightScore", "0");
            string c = String.Format(@"SELECT name FROM users WHERE ID = {0}", lID);
            List<string> s = GetData(connectString, c);
            OpenForm.UpdatePage("leftName", String.Join("", s.ToArray()));
            c = String.Format(@"SELECT name FROM users WHERE ID = {0}", rID);
            s = GetData(connectString, c);
            OpenForm.UpdatePage("rightName", String.Join("", s.ToArray()));
            c = String.Format(@"SELECT name FROM groups WHERE ID = {0}", glID);
            s = GetData(connectString, c);
            OpenForm.UpdatePage("leftGroup", String.Join("", s.ToArray()));
            c = String.Format(@"SELECT name FROM groups WHERE ID = {0}", grID);
            s = GetData(connectString, c);
            OpenForm.UpdatePage("rightGroup", String.Join("", s.ToArray()));
        }



        // Maakt ook een nieuwe match aan enkel wordt het niet geupload
        public async Task CreateNewMatchNoUpload
            (string connectString, 
            string groupID1, 
            string groupID2, 
            string team1user1ID, 
            string team1user2ID, 
            string team1user3ID, 
            string team2user1ID, 
            string team2user2ID, 
            string team2user3ID
            )
        {
            string c = String.Format(@"SELECT max(ID)from groupmatches");
            // Loopt over elke match die gespeeld zal worden
            for (int i = 0; i < 9; i++)
            {
                string user1 = team1user3ID;
                string user2 = team2user3ID;
                if (i == 0 || i == 5 || i == 7) user1 = team1user1ID;
                else if (i == 1 || i == 3 || i == 8) user1 = team1user2ID;
                if (i == 0 || i == 3 || i == 6) user2 = team2user1ID;
                else if (i == 1 || i == 4 || i == 7) user2 = team2user2ID;
                LoadPage(connectString, Convert.ToInt32(user1), Convert.ToInt32(user2), Convert.ToInt32(groupID1), Convert.ToInt32(groupID2));
                // Loopt over beide frames in de match
                for (int j = 0; j < 2; j++)
                {
                    while (!Frameover) { await Task.Delay(1); }
                    Frameover = false;
                }
            }
        }


        // Verwijdert alle gegevens van een groupmatch adhv ID
        public void DeleteGroupMatch(string connectString, string ID)
        {
            // Haalt alle ID's van alle matches uit de groupmatch
            string command = String.Format(@"SELECT ID FROM matches WHERE GroupMatchID = '{0}'", ID);
            List<string> ids = GetData(connectString, command);
            List<string> fids = new List<string>();
            ids.ForEach(delegate (string id) {
                // Haalt alle ID's van alle frames uit elke match
                command = String.Format(@"SELECT ID FROM frames WHERE matchID = {0}", id);
                fids.AddRange(GetData(connectString, command));
            });
            // Verwijdert alle frames
            fids.ForEach(delegate (string id)
            {
                command = String.Format(@"DELETE FROM frames WHERE ID = {0}", id);
                ExecuteCommand(connectString, command);
            });
            // Verwijdert alle matches
            ids.ForEach(delegate (string id)
            {
                command = String.Format(@"DELETE FROM matches WHERE ID = {0}", id);
                ExecuteCommand(connectString, command);
            });
            // Verwijdert de groupmatch
            command = String.Format(@"DELETE FROM groupmatches WHERE ID = '{0}'", ID);
            ExecuteCommand(connectString, command);
        }
        
        public List<int> GetBreaks(string connectString, string ID)
        {
            // Haalt de lijst van breaks van een speler
            string command = String.Format(@"SELECT break FROM users WHERE ID = {0}", ID);
            string breaks = String.Join("", GetData(connectString, command));
            // Haalt alle breaks uit elkaar van een string naar een lijst van integers
            List<int> breakL = new List<int>(breaks.Split(',').Select(int.Parse));
            // Haalt de basis 0 weg.
            breakL.RemoveAt(0);
            return breakL;
        }

        public void AddBreak(string connectString, string ID, int score)
        {
            // Voegt een break toe aan een speler
            string command = String.Format(@"SELECT break FROM users WHERE ID = {0}", ID);
            // Haalt de string van alle momentele 30+ breaks
            string breaks = String.Join("", GetData(connectString, command));
            // Voegt een komma en de score toe
            breaks += (",");
            breaks += (score);
            // Update breaks
            command = String.Format(@"UPDATE users SET break = '{0}' WHERE ID = '{1}'", breaks, ID);
            ExecuteCommand(connectString, command);
        }

        public void ResetBreaks(string connectString)
        {
            // Reset alle breaks van iedereen (kan gebruikt worden op het einde van een seizoen ofzo)
            string command = String.Format(@"UPDATE `users` SET `break` = 0");
            ExecuteCommand(connectString, command);
        }

        // Haalt alle groupmatches van een persoon
        public List<string> GetMatchHistory(string connectString, string id)
        {
            // Haalt alle matches van de speler
            string command = String.Format(@"SELECT matchID from frames WHERE user1ID = {0} OR user2ID = {0}", id);
            List<string> matchIDS = GetData(connectString, command);
            // Dubbele matches weghalen
            matchIDS = matchIDS.Distinct().ToList();
            List<string> gMatchIDS = new List<string>();
            // Voor elke match de groupmatchID halen
            matchIDS.ForEach(delegate (string fID) {
                command = String.Format(@"SELECT GroupMatchID from matches WHERE ID = {0}", fID);
                gMatchIDS.Add(String.Join("", GetData(connectString, command)));
            });
            // Verwijdert dubbele
            gMatchIDS = gMatchIDS.Distinct().ToList();
            return gMatchIDS;
        }
        // Returnt een lijst van alle frames die je hebt gespeeld tegen een gekozen speler
        public List<string> FramesWithOpponent(string connectString, string id1, string id2, List<string> IDS = null)
        {
            // Controleert of de lijst werd meegegeven
            IDS = IDS ?? new List<string>();
            string command;
            // Als de lijst leeg is
            List<string> temp = new List<string>();
            command = String.Format(@"SELECT ID from frames WHERE user1ID = {0} OR user2ID = {0}", id1);
            List<string> p1IDS = GetData(connectString, command);
            p1IDS = p1IDS.Distinct().ToList();
            command = String.Format(@"SELECT ID from frames WHERE user1ID = {0} OR user2ID = {0}", id2);
            List<string> p2IDS = GetData(connectString, command);
            p2IDS = p2IDS.Distinct().ToList();
            if (IDS.Count == 0)
            {
                p1IDS.ForEach(delegate (string id)
                {
                    if (p2IDS.Contains(id)) IDS.Add(id);
                });
            }
            else
            {
                List<string> ID = new List<string>();
                p1IDS.ForEach(delegate (string id)
                {
                    if (p2IDS.Contains(id)) ID.Add(id);
                });
                IDS.ForEach(delegate (string id) {
                    if (ID.Contains(id)) temp.Add(id);
                });
                return temp;
            }
            IDS = IDS.Distinct().ToList();
            return IDS;
        }
        // Haalt alle frames van een persoon en geeft een winrate
        public string FramesPerson(string connectString, string id)
        {
            int won1 = 0;
            int lost = 0;
            int total = 0;
            string command = String.Format(@"SELECT ID from frames WHERE user1ID = {0} OR user2ID = {0}", id);
            List<string> IDS = GetData(connectString, command);
            IDS = IDS.Distinct().ToList();
            IDS.ForEach(delegate (string ID) {
                command = String.Format(@"SELECT user1ID from frames WHERE ID = {0}", ID);
                string id2 = String.Join("", GetData(connectString, command));
                command = String.Format(@"SELECT user1won FROM frames WHERE ID = {0}", ID);
                string won = String.Join("", GetData(connectString, command));
                if (won == "1")
                {
                    if (id == id2) won1++;
                    else lost++;
                }
                else if (won == "0")
                {
                    if (id == id2) lost++;
                    else won1++;
                }
                total++;
            });
            return Convert.ToString(won1) + "-" + Convert.ToString(lost) + "  (" + Convert.ToString(total) + ")";
        }
        // Lijst van frames in een specifieke periode
        public List<string> FramesInPeriod(string connectString, string id, DateTime? startDate = null, DateTime? endDate = null, List<string> ID = null)
        {
            ID = ID ?? new List<string>();
            startDate = startDate ?? DateTime.MinValue;
            endDate = endDate ?? DateTime.Now;
            string command = String.Format(@"SELECT ID from frames WHERE user1ID = {0} OR user2ID = {0}", id);
            List<string> IDS = GetData(connectString, command);
            if (ID.Count != 0)
            {
                IDS.ForEach(delegate (string tID)
                {
                    if (!ID.Contains(tID)) IDS.Remove(tID);
                });
            }
            List<string> InPeriod = new List<string>();
            IDS.ForEach(delegate (string tID)
            {
                command = String.Format(@"SELECT timestamp FROM frames WHERE ID = {0}", tID);
                DateTime frame = Convert.ToDateTime(String.Join("", GetData(connectString, command)));
                int afterStart = DateTime.Compare((DateTime)startDate, frame);
                int beforeEnd = DateTime.Compare(frame, (DateTime)endDate);
                if (afterStart < 0 && beforeEnd < 0)
                {
                    InPeriod.Add(tID);
                }
            });
            return InPeriod;
        }

        // Geeft de winrate van 1 of 2 spelers van een lijst frames
        public string IDSWinrate(string connectString, string id, List<string> IDS, string idP2 = null)
        {
            int won1 = 0;
            int won2 = 0;
            int lost = 0;
            int total = 0;
            IDS = IDS.Distinct().ToList();
            // Als id gelijk is aan idP2 is het dezelfde speler en bestaan er dus geen matches
            if (id == idP2) return null;
            // Als er maar 1 speler is meegegeven
            if (idP2 == null)
            {
                IDS.ForEach(delegate (string ID)
                {
                    string command = String.Format(@"SELECT user1ID from frames WHERE ID = {0}", ID);
                    string id2 = String.Join("", GetData(connectString, command));
                    command = String.Format(@"SELECT user1won FROM frames WHERE ID = {0}", ID);
                    string won = String.Join("", GetData(connectString, command));
                    if (won == "1")
                    {
                        if (id == id2) won1++;
                        else lost++;
                    }
                    else if (won == "0")
                    {
                        if (id == id2) lost++;
                        else won1++;
                    }
                    total++;
                });
                return Convert.ToString(won1) + "-" + Convert.ToString(lost) + "  (" + Convert.ToString(total) + ")";
            }
            IDS.ForEach(delegate (string ID) {
                string command = String.Format(@"SELECT user1ID from frames WHERE ID = {0}", ID);
                string user1id = String.Join("", GetData(connectString, command));
                command = String.Format(@"SELECT user1won from frames WHERE ID = {0}", ID);
                string user1won = String.Join("", GetData(connectString, command));
                if (user1id == id)
                {
                    if (user1won == "1") won1++;
                    else if (user1won == "0") won2++;
                }
                else if (user1id == idP2)
                {
                    if (user1won == "1") won2++;
                    else if (user1won == "0") won1++;
                }
                total++;
            });
            return Convert.ToString(won1) + "-" + Convert.ToString(won2) + "  (" + Convert.ToString(total) + ")";
        }
        // Verwijdert dubbele objecten van 2 lijsten
        public List<string> GetDoubleIDS(string connectString, List<string> ID1, List<string> ID2)
        {
            List<string> IDS = new List<string>();
            ID1.ForEach(delegate (string id) 
            {
                if (ID2.Contains(id)) IDS.Add(id);
            });
            return IDS;
        }
    }
}