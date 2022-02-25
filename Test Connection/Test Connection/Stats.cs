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
    public partial class Stats : Form
    {
        SQLFunctions sql = new SQLFunctions();
        readonly string ConnectString = "datasource = localhost; port = 3306; username = root; password=; database = snooker";
        //ConnectString = "datasource = 94.224.89.152; port = 85; username = root; password=; database = snooker";
        public Stats()
        {
            InitializeComponent();
            string command = String.Format(@"SELECT ID from users");
            MakeCBs(sql.GetData(ConnectString, command));
            EindDatumDTP.Value = DateTime.Now;
        }
        private void MakeCBs(List<string> IDs)
        {
            IDs.ForEach(delegate (string ID)
            {
                string command = String.Format(@"SELECT name FROM users WHERE ID = '{0}'", ID);
                string name = String.Join("", sql.GetData(ConnectString, command));
                spelerCB.Items.Add(name + " (" + ID + ")");
                speler2CB.Items.Add(name + " (" + ID + ")");
            });
        }
        private void spelerCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = Regex.Replace(spelerCB.Text, @"[^a-zA-Z ]+", String.Empty);
            nameP1.Text = String.Format("Winrate : {0}", name);
            string ID  = Regex.Match(spelerCB.Text, @"\d+").Value;
            string score = sql.FramesPerson(ConnectString, ID);
            frameScoreLBL.Text = score;
            List<string> IDS = sql.FramesInPeriod(ConnectString, ID, Convert.ToDateTime(startDatumDTP.Value), Convert.ToDateTime(EindDatumDTP.Value));
            framePeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, IDS);
            framePeriodeLBL.Visible = true;
            label8.Visible = true;
            if (speler2CB.SelectedIndex == -1) return;
            string ID2 = Regex.Match(speler2CB.Text, @"\d+").Value;
            List<string> frames = sql.FramesWithOpponent(ConnectString, ID, ID2);
            score = sql.IDSWinrate(ConnectString, ID, frames, ID2);
            framePlayersLBL.Text = score;
            frames = sql.GetDoubleIDS(ConnectString, IDS, frames);
            frame2PPeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, frames, ID2);
            label5.Visible = true;
            framePlayersLBL.Visible = true;
        }
        private void speler2CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spelerCB.SelectedIndex == -1) return;
            string ID = Regex.Match(spelerCB.Text, @"\d+").Value;
            string ID2 = Regex.Match(speler2CB.Text, @"\d+").Value;
            List<string> IDS = sql.FramesInPeriod(ConnectString, ID, Convert.ToDateTime(startDatumDTP.Value), Convert.ToDateTime(EindDatumDTP.Value));
            List<string> frames = sql.FramesWithOpponent(ConnectString, ID, ID2);
            string score = sql.IDSWinrate(ConnectString, ID, frames, ID2);
            framePlayersLBL.Text = score;
            frames = sql.GetDoubleIDS(ConnectString, IDS, frames);
            score = sql.IDSWinrate(ConnectString, ID, frames, ID2);
            frame2PPeriodeLBL.Text = score;
            label5.Visible = true;
            framePlayersLBL.Visible = true;
        }

        private void startDatumDTP_ValueChanged(object sender, EventArgs e)
        {
            if (spelerCB.SelectedIndex == -1) return;
            string ID = Regex.Match(spelerCB.Text, @"\d+").Value;
            List<string> IDS = sql.FramesInPeriod(ConnectString, ID, Convert.ToDateTime(startDatumDTP.Value), Convert.ToDateTime(EindDatumDTP.Value));
            framePeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, IDS);
            if (speler2CB.SelectedIndex == -1) return;
            string ID2 = Regex.Match(speler2CB.Text, @"\d+").Value;
            List<string> frames = sql.FramesWithOpponent(ConnectString, ID, ID2);
            frames = sql.GetDoubleIDS(ConnectString, IDS, frames);
            frame2PPeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, frames, ID2);
        }

        private void EindDatumDTP_ValueChanged(object sender, EventArgs e)
        {
            if (spelerCB.SelectedIndex == -1) return;
            string ID = Regex.Match(spelerCB.Text, @"\d+").Value;
            List<string> IDS = sql.FramesInPeriod(ConnectString, ID, Convert.ToDateTime(startDatumDTP.Value), Convert.ToDateTime(EindDatumDTP.Value));
            framePeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, IDS);
            if (speler2CB.SelectedIndex == -1) return;
            string ID2 = Regex.Match(speler2CB.Text, @"\d+").Value;
            List<string> frames = sql.FramesWithOpponent(ConnectString, ID, ID2);
            frames = sql.GetDoubleIDS(ConnectString, IDS, frames);
            frame2PPeriodeLBL.Text = sql.IDSWinrate(ConnectString, ID, frames, ID2);
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}