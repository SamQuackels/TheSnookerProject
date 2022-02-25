
namespace Test_Connection
{
    partial class Stats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spelerCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.speler2CB = new System.Windows.Forms.ComboBox();
            this.nameP1 = new System.Windows.Forms.Label();
            this.frameScoreLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.framePlayersLBL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startDatumDTP = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.EindDatumDTP = new System.Windows.Forms.DateTimePicker();
            this.framePeriodeLBL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.frame2PPeriodeLBL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spelerCB
            // 
            this.spelerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spelerCB.FormattingEnabled = true;
            this.spelerCB.Location = new System.Drawing.Point(13, 56);
            this.spelerCB.Name = "spelerCB";
            this.spelerCB.Size = new System.Drawing.Size(161, 24);
            this.spelerCB.Sorted = true;
            this.spelerCB.TabIndex = 0;
            this.spelerCB.SelectedIndexChanged += new System.EventHandler(this.spelerCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Speler 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Speler 2 :";
            // 
            // speler2CB
            // 
            this.speler2CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speler2CB.FormattingEnabled = true;
            this.speler2CB.Location = new System.Drawing.Point(212, 56);
            this.speler2CB.Name = "speler2CB";
            this.speler2CB.Size = new System.Drawing.Size(157, 24);
            this.speler2CB.Sorted = true;
            this.speler2CB.TabIndex = 3;
            this.speler2CB.SelectedIndexChanged += new System.EventHandler(this.speler2CB_SelectedIndexChanged);
            // 
            // nameP1
            // 
            this.nameP1.AutoSize = true;
            this.nameP1.Location = new System.Drawing.Point(689, 13);
            this.nameP1.Name = "nameP1";
            this.nameP1.Size = new System.Drawing.Size(65, 17);
            this.nameP1.TabIndex = 4;
            this.nameP1.Text = "Winrate :";
            // 
            // frameScoreLBL
            // 
            this.frameScoreLBL.AutoSize = true;
            this.frameScoreLBL.Location = new System.Drawing.Point(692, 43);
            this.frameScoreLBL.Name = "frameScoreLBL";
            this.frameScoreLBL.Size = new System.Drawing.Size(37, 17);
            this.frameScoreLBL.TabIndex = 5;
            this.frameScoreLBL.Text = "0 - 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(692, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Speler 1 vs Speler 2 :";
            this.label5.Visible = false;
            // 
            // framePlayersLBL
            // 
            this.framePlayersLBL.AutoSize = true;
            this.framePlayersLBL.Location = new System.Drawing.Point(692, 136);
            this.framePlayersLBL.Name = "framePlayersLBL";
            this.framePlayersLBL.Size = new System.Drawing.Size(37, 17);
            this.framePlayersLBL.TabIndex = 7;
            this.framePlayersLBL.Text = "0 - 0";
            this.framePlayersLBL.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start Datum";
            // 
            // startDatumDTP
            // 
            this.startDatumDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatumDTP.Location = new System.Drawing.Point(16, 170);
            this.startDatumDTP.Name = "startDatumDTP";
            this.startDatumDTP.Size = new System.Drawing.Size(116, 22);
            this.startDatumDTP.TabIndex = 9;
            this.startDatumDTP.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.startDatumDTP.ValueChanged += new System.EventHandler(this.startDatumDTP_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Eind Datum";
            // 
            // EindDatumDTP
            // 
            this.EindDatumDTP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EindDatumDTP.Location = new System.Drawing.Point(291, 169);
            this.EindDatumDTP.Name = "EindDatumDTP";
            this.EindDatumDTP.Size = new System.Drawing.Size(102, 22);
            this.EindDatumDTP.TabIndex = 11;
            this.EindDatumDTP.ValueChanged += new System.EventHandler(this.EindDatumDTP_ValueChanged);
            // 
            // framePeriodeLBL
            // 
            this.framePeriodeLBL.AutoSize = true;
            this.framePeriodeLBL.Location = new System.Drawing.Point(692, 213);
            this.framePeriodeLBL.Name = "framePeriodeLBL";
            this.framePeriodeLBL.Size = new System.Drawing.Size(37, 17);
            this.framePeriodeLBL.TabIndex = 12;
            this.framePeriodeLBL.Text = "0 - 0";
            this.framePeriodeLBL.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(692, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tussen Datum :";
            this.label8.Visible = false;
            // 
            // frame2PPeriodeLBL
            // 
            this.frame2PPeriodeLBL.AutoSize = true;
            this.frame2PPeriodeLBL.Location = new System.Drawing.Point(692, 278);
            this.frame2PPeriodeLBL.Name = "frame2PPeriodeLBL";
            this.frame2PPeriodeLBL.Size = new System.Drawing.Size(37, 17);
            this.frame2PPeriodeLBL.TabIndex = 14;
            this.frame2PPeriodeLBL.Text = "0 - 0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(692, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Speler 1 vs Speler 2 in Periode :";
            // 
            // backBTN
            // 
            this.backBTN.Location = new System.Drawing.Point(13, 524);
            this.backBTN.Name = "backBTN";
            this.backBTN.Size = new System.Drawing.Size(75, 23);
            this.backBTN.TabIndex = 16;
            this.backBTN.Text = "Back";
            this.backBTN.UseVisualStyleBackColor = true;
            this.backBTN.Click += new System.EventHandler(this.backBTN_Click);
            // 
            // Stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 559);
            this.Controls.Add(this.backBTN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.frame2PPeriodeLBL);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.framePeriodeLBL);
            this.Controls.Add(this.EindDatumDTP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.startDatumDTP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.framePlayersLBL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frameScoreLBL);
            this.Controls.Add(this.nameP1);
            this.Controls.Add(this.speler2CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spelerCB);
            this.Name = "Stats";
            this.Text = "Stats";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox spelerCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox speler2CB;
        private System.Windows.Forms.Label nameP1;
        private System.Windows.Forms.Label frameScoreLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label framePlayersLBL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDatumDTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker EindDatumDTP;
        private System.Windows.Forms.Label framePeriodeLBL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label frame2PPeriodeLBL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backBTN;
    }
}