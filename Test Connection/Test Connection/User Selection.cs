using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Test_Connection
{
    public partial class User_Selection : Form
    {
        string grID1;
        string grID2;
        string T1ID1;
        string T1ID2;
        string T1ID3;
        string T2ID1;
        string T2ID2;
        string T2ID3;
        List<string> AllNames = new List<string>();
        bool OtherTeam = false;
        public User_Selection()
        {
            InitializeComponent();
            string command = String.Format(@"SELECT ID from users");
            MakeCBs(sql.GetData(ConnectString, command));
            command = String.Format(@"SELECT name FROM groups ORDER BY NAME");
            sql.AddItemsCB(ConnectString, command, team1);
            sql.AddItemsCB(ConnectString, command, team2);
        }
        readonly string ConnectString = "datasource = localhost; port = 3306; username = root; password=; database = snooker";
        //ConnectString = "datasource = 94.224.89.152; port = 85; username = root; password=; database = snooker";
        SQLFunctions sql = new SQLFunctions();

        private void team1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!OtherTeam) OtherTeam = true;
            else ShowPlayers();
        }

        private void team2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!OtherTeam) OtherTeam = true;
            else ShowPlayers();
        }

        private void startMatch_Click(object sender, EventArgs e)
        {
            getAllData();
            Form1 f1 = new Form1(grID1, grID2, T1ID1, T1ID2, T1ID3, T2ID1, T2ID2, T2ID3);
            f1.Width = 800;
            f1.Show();
            this.Hide();
        }

        private void getAllData()
        {
            T1ID1 = Regex.Match(user1team1.Text, @"\d+").Value;
            T1ID2 = Regex.Match(user2team1.Text, @"\d+").Value;
            T1ID3 = Regex.Match(user3team1.Text, @"\d+").Value;
            T2ID1 = Regex.Match(user1team2.Text, @"\d+").Value;
            T2ID2 = Regex.Match(user2team2.Text, @"\d+").Value;
            T2ID3 = Regex.Match(user3team2.Text, @"\d+").Value;
            string command = String.Format(@"SELECT ID from groups WHERE name = '{0}'", team1.Text);
            grID1 = String.Join("", sql.GetData(ConnectString, command));
            command = String.Format(@"SELECT ID from groups WHERE name = '{0}'", team2.Text);
            grID2 = String.Join("", sql.GetData(ConnectString, command));
        }

        private void RemoveUsers()
        {
            List<ComboBox> cbl = new List<ComboBox> { user1team1, user2team1, user3team1, user1team2, user2team2, user3team2 };
            cbl.ForEach(delegate (ComboBox cb)
            {
                cbl.ForEach(delegate (ComboBox cb2)
                {
                    if (cb != cb2 && cb.SelectedItem != null) cb.Items.Remove(cb2.SelectedItem);
                });
                AllNames.ForEach(delegate (string name)
                {
                    bool available = true;
                    cbl.ForEach(delegate (ComboBox cb2)
                    {
                        if (cb != cb2 && cb2.SelectedItem != null && cb2.SelectedItem.ToString() == name) available = false;
                        if (cb.Items.Contains(name)) available = false;
                    });
                    if (available) cb.Items.Add(name);
                });
            });
            CheckDoubles();
        }

        private void MakeCBs(List<string> IDs)
        {
            IDs.ForEach(delegate (string ID)
            {
                string command = String.Format(@"SELECT name FROM users WHERE ID = '{0}'", ID);
                string name = String.Join("", sql.GetData(ConnectString, command));
                user1team1.Items.Add(name + " (" + ID + ")");
                user2team1.Items.Add(name + " (" + ID + ")");
                user3team1.Items.Add(name + " (" + ID + ")");
                user1team2.Items.Add(name + " (" + ID + ")");
                user2team2.Items.Add(name + " (" + ID + ")");
                user3team2.Items.Add(name + " (" + ID + ")");
                AllNames.Add(name + " (" + ID + ")");
            });
        }

        private void ShowPlayers()
        {
            user1team1.Visible = true;
            user2team1.Visible = true;
            user3team1.Visible = true;
            closeT1U1.Visible = true;
            closeT1U2.Visible = true;
            closeT1U3.Visible = true;
            user1team2.Visible = true;
            user2team2.Visible = true;
            user3team2.Visible = true;
            closeT2U1.Visible = true;
            closeT2U2.Visible = true;
            closeT2U3.Visible = true;
            string[] users = new String[3] { "user1ID", "user2ID", "user3ID" };
            for (int i = 0; i < 3; i++)
            {
                string command = String.Format(@"SELECT {0} FROM groups WHERE name = '{1}'", users[i], team2.Text);
                string ID = String.Join("", sql.GetData(ConnectString, command));
                command = String.Format(@"SELECT name FROM users WHERE ID = {0}", ID);
                string a = String.Join("", sql.GetData(ConnectString, command)) + " (" + ID + ")";
                if (i == 0) user1team2.Text = a;
                else if (i == 1) user2team2.Text = a;
                else if (i == 2) user3team2.Text = a;
            }
            for (int i = 0; i < 3; i++)
            {
                string command = String.Format(@"SELECT {0} FROM groups WHERE name = '{1}'", users[i], team1.Text);
                string ID = String.Join("", sql.GetData(ConnectString, command));
                command = String.Format(@"SELECT name FROM users WHERE ID = {0}", ID);
                string a = String.Join("", sql.GetData(ConnectString, command)) + " (" + ID + ")";
                if (i == 0) user1team1.Text = a;
                else if (i == 1) user2team1.Text = a;
                else if (i == 2) user3team1.Text = a;
            }
            RemoveUsers();
        }

        private void CheckDoubles()
        {
            List<ComboBox> cbl = new List<ComboBox> { user1team1, user2team1, user3team1, user1team2, user2team2, user3team2 };
            cbl.ForEach(delegate (ComboBox cb)
            {
                List<string> UsedNames = new List<string>();
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    if (!UsedNames.Contains(cb.Items[i].ToString())) UsedNames.Add(cb.Items[i].ToString());
                    else cb.Items.RemoveAt(i);
                }
            });


        }

        private void closeT1U1_Click(object sender, EventArgs e)
        {
            user1team1.Items.Add(" ");
            user1team1.SelectedItem = " ";
        }
        private void closeT1U2_Click(object sender, EventArgs e)
        {
            user2team1.Items.Add(" ");
            user2team1.SelectedItem = " ";
        }

        private void closeT1U3_Click(object sender, EventArgs e)
        {
            user3team1.Items.Add(" ");
            user3team1.SelectedItem = " ";
        }

        private void closeT2U1_Click(object sender, EventArgs e)
        {
            user1team2.Items.Add(" ");
            user1team2.SelectedItem = " ";
        }

        private void closeT2U2_Click(object sender, EventArgs e)
        {
            user2team2.Items.Add(" ");
            user2team2.SelectedItem = " ";
        }

        private void closeT2U3_Click(object sender, EventArgs e)
        {
            user3team2.Items.Add(" ");
            user3team2.SelectedItem = " ";
        }

        private void user1team1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void user2team1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void user3team1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void user1team2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void user2team2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void user3team2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveUsers();
        }

        private void test_Click(object sender, EventArgs e)
        {
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}