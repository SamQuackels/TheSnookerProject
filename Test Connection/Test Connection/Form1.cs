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
        readonly string ConnectString = "datasource = localhost; port = 3306; username = root; password=; database = snooker";
        //ConnectString = "datasource = 94.224.89.152; port = 85; username = root; password=; database = snooker";
        string score1 = "0";
        string tempscore1 = "0";
        string score2 = "0";
        string tempscore2 = "0";
        int frameScore1 = 0;
        int frameScore2 = 0;
        int frameTotal = 0;
        int round = 0;
        string T1U1;
        string T1U2;
        string T1U3;
        string T2U1;
        string T2U2;
        string T2U3;
        string player1;
        string player2;
        bool upload = false;

        SQLFunctions sql = new SQLFunctions();

        // Dit gebeurt er als er een nieuw Form1 object aangemaakt word.
        public Form1(string groupID1, string groupID2, string team1user1ID, string team1user2ID, string team1user3ID, string team2user1ID, string team2user2ID, string team2user3ID)
        {
            InitializeComponent();
            _ = startMatch(ConnectString, groupID1, groupID2, team1user1ID, team1user2ID, team1user3ID, team2user1ID, team2user2ID, team2user3ID);
            T1U1 = team1user1ID;
            T1U2 = team1user2ID;
            T1U3 = team1user3ID;
            T2U1 = team2user1ID;
            T2U2 = team2user2ID;
            T2U3 = team2user3ID;
            player1 = T1U1;
            player2 = T2U1;
        }

        // Test connectie met de database
        private void DBConnection()
        {
            if (sql.tryConnection(ConnectString))
            {
                MessageBox.Show("Verbinding Succesvol");
            }
        }
        // Start de match na 10 ms zodat alles eerst kan inladen
        private async Task startMatch(string connectionString, string groupID1, string groupID2, string team1user1ID, string team1user2ID, string team1user3ID, string team2user1ID, string team2user2ID, string team2user3ID)
        {
            await Task.Delay(10);
            _ = sql.CreateNewMatchNoUpload(ConnectString, groupID1, groupID2, team1user1ID, team1user2ID, team1user3ID, team2user1ID, team2user2ID, team2user3ID);
            //upload = true;
            //_ = sql.CreateNewMatchAsync(ConnectString, groupID1, groupID2, team1user1ID, team1user2ID, team1user3ID, team2user1ID, team2user2ID, team2user3ID);
        }



        /*
         * Hier is een soort van inventaris :
         * label1 : linker score label
         * deleteleft : linker delete knop
         * label2 : rechter score label
         * frameScoreLeft : aantal gewonnen frames voor de linker persoon
         * frameScoreRight : aantal gewonnen frames voor de rechter persoon
         * nameLeft : naam van de linker persoon
         * nameRight : naam van de rechter persoon
         * groupLeft : naam van de groep van de linker persoon
         * groupRight : naam van de rechter persoon
         */





        //
        // Button 1 met 1 erop dat 1 toevoegt aan de score van de linker speler, zelfde geld voor andere buttons (1-9)
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "1";
            else tempscore1 += "1";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "2";
            else tempscore1 += "2";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "3";
            else tempscore1 += "3";
            label1.Text = tempscore1;
            deleteleft.Enabled = true;
            deleteleft.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "4";
            else tempscore1 += "4";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "5";
            else tempscore1 += "5";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "6";
            else tempscore1 += "6";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "7";
            else tempscore1 += "7";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "8";
            else tempscore1 += "8";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tempscore1 == "0") tempscore1 = "9";
            else tempscore1 += "9";
            label1.Text = tempscore1;
            deleteleft.Visible = true;
            deleteleft.Enabled = true;
        }

        //
        // Plus knop 
        //
        private void button10_Click(object sender, EventArgs e)
        {
            // +
            score1 = Convert.ToString(Convert.ToInt32(score1) + Convert.ToInt32(tempscore1));
            if (Convert.ToInt32(tempscore1) >= 30)
            {
                if (upload) sql.AddBreak(ConnectString, player1, Convert.ToInt32(tempscore1));
                breaksLeft.Text = breaksLeft.Text + Convert.ToInt32(tempscore1) + ", ";
            }
            tempscore1 = "0";
            label1.Text = score1;
            deleteleft.Visible = false;
            deleteleft.Enabled = false;
        }
        //
        // 0 knop
        //
        private void button11_Click(object sender, EventArgs e)
        {
            if (tempscore1 != "0") tempscore1 += "0";
            label1.Text = tempscore1;
        }
        //
        // De min knop
        //
        private void button12_Click(object sender, EventArgs e)
        {
            // -
            if (Convert.ToInt32(score1) > Convert.ToInt32(tempscore1))
            {
                score1 = Convert.ToString(Convert.ToInt32(score1) - Convert.ToInt32(tempscore1));
                tempscore1 = "0";
                label1.Text = score1;
                deleteleft.Visible = false;
                deleteleft.Enabled = false;
            }
        }
        //
        // De delete knop
        //
        private void deleteleft_Click(object sender, EventArgs e)
        {
            if (tempscore1 != "0") tempscore1 = tempscore1.Remove(tempscore1.Length - 1, 1);
            if (tempscore1 == "")
            {
                tempscore1 = "0";
                label1.Text = score1;
                deleteleft.Visible = false;
                deleteleft.Enabled = false;
            }
            else label1.Text = tempscore1;
        }
        //
        //
        // Hier is alles hetzelfde maar alle buttons zijn voor de rechterkant
        //
        //
        private void add1right_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "1";
            else tempscore2 += "1";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "2";
            else tempscore2 += "2";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "3";
            else tempscore2 += "3";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "4";
            else tempscore2 += "4";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "5";
            else tempscore2 += "5";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "6";
            else tempscore2 += "6";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "7";
            else tempscore2 += "7";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "8";
            else tempscore2 += "8";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (tempscore2 == "0") tempscore2 = "9";
            else tempscore2 += "9";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }
        //
        // Rechter min knop
        //
        private void button23_Click(object sender, EventArgs e)
        {
            if (tempscore2 != "0") tempscore2 += "0";
            label2.Text = tempscore2;
            deleteright.Visible = true;
            deleteright.Enabled = true;
        }

        //
        // Rechter plus knop
        //
        private void plusright_Click(object sender, EventArgs e)
        {
            score2 = Convert.ToString(Convert.ToInt32(score2) + Convert.ToInt32(tempscore2));
            if (Convert.ToInt32(tempscore2) >= 30)
            {
                if (upload) sql.AddBreak(ConnectString, player2, Convert.ToInt32(tempscore2));
                breaksRight.Text = breaksRight.Text + Convert.ToInt32(tempscore2) + ", ";
            }
            tempscore2 = "0";
            label2.Text = score2;
            deleteright.Visible = false;
            deleteright.Enabled = false;
        }

        //
        // Rechter min knop
        //
        private void minusright_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(score2) > Convert.ToInt32(tempscore2))
            {
                score2 = Convert.ToString(Convert.ToInt32(score2) - Convert.ToInt32(tempscore2));
                tempscore2 = "0";
                label2.Text = score2;
                deleteright.Visible = false;
                deleteright.Enabled = false;
            }
        }
        //
        // Rechter delete knop
        //
        private void deleteright_Click(object sender, EventArgs e)
        {
            if (tempscore2 != "0") tempscore2 = tempscore2.Remove(tempscore2.Length - 1, 1);
            if (tempscore2 == "")
            {
                tempscore2 = "0";
                label2.Text = score2;
                deleteright.Visible = false;
                deleteright.Enabled = false;
            }
            else label2.Text = tempscore2;
        }
        // 
        //Knop om de momentele frame te beeindigen en de volgende te starten
        // 
        private void frameEnd_Click(object sender, EventArgs e)
        {
            // Kijkt wie heeft gewonnen
            if (Convert.ToInt32(score1) > Convert.ToInt32(score2))
            {
                // Voegt score toe aan speler 1
                frameScore1++;
                frameScoreLeft.Text = Convert.ToString(frameScore1);
            }
            else
            {
                if (score1 != score2)
                {
                    // Voegt score toe aan speler 2
                    frameScore2++;
                    frameScoreRight.Text = Convert.ToString(frameScore2);
                }
            }

            frameTotal++;

            sql.Score1 = Convert.ToInt32(score1);
            sql.Score2 = Convert.ToInt32(score2);
            sql.Frameover = true;

            score1 = "0";
            score2 = "0";
            tempscore1 = "0";
            tempscore2 = "0";
            breaksLeft.Text = "";
            breaksRight.Text = "";
            deleteleft.Visible = false;
            deleteleft.Enabled = false;
            deleteright.Visible = false;
            deleteright.Enabled = false;
            label1.Text = score1;
            label2.Text = score2;
            round += 1;

            // Als beide frames van de match zijn gespeeld
            if (frameTotal == 2)
            {
                frameScore1 = 0;
                frameScore2 = 0;
            }
            // Als alle groupmatches gespeeld zijn
            if (round >= 18)
            {
                User_Selection US = new User_Selection();
                US.ShowDialog();
                this.Hide();
            }
            // Stelt de spelers in
            switch (round)
            {
                case 1:
                case 2:
                    player1 = T1U1;
                    player2 = T2U1;
                    break;
                case 3:
                case 4:
                    player1 = T1U2;
                    player2 = T2U2;
                    break;
                case 5:
                case 6:
                    player1 = T1U3;
                    player2 = T2U3;
                    break;
                case 7:
                case 8:
                    player1 = T1U2;
                    player2 = T2U1;
                    break;
                case 9:
                case 10:
                    player1 = T1U3;
                    player2 = T2U2;
                    break;
                case 11:
                case 12:
                    player1 = T1U1;
                    player2 = T2U3;
                    break;
                case 13:
                case 14:
                    player1 = T1U3;
                    player2 = T2U1;
                    break;
                case 15:
                case 16:
                    player1 = T1U1;
                    player2 = T2U2;
                    break;
                case 17:
                case 18:
                    player1 = T1U2;
                    player2 = T2U3;
                    break;
                default:
                    break;
            }
        }
        //
        // Random knop om voor nu de match aan te maken en te starten, later wordt dit automatisch na de speler selectie
        //
        
        // Dit update de page, wordt gecalled in SQLFunctions zodat labels / forms niet moeten worden meegegeven.
        public void UpdatePage(string label, string ToWhat)
        {
            switch (label)
            {
                case "leftScore":
                    frameScoreLeft.Text = ToWhat;
                    break;
                case "rightScore":
                    frameScoreRight.Text = ToWhat;
                    break;
                case "leftName":
                    nameLeft.Text = ToWhat;
                    break;
                case "rightName":
                    rightName.Text = ToWhat;
                    break;
                case "leftGroup":
                    leftGroup.Text = ToWhat;
                    break;
                case "rightGroup":
                    rightGroup.Text = ToWhat;
                    break;
            }
        }
    }
}
