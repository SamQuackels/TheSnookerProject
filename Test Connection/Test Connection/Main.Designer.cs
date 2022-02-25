
namespace Test_Connection
{
    partial class Main
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
            this.competitieBTN = new System.Windows.Forms.Button();
            this.trainingBTN = new System.Windows.Forms.Button();
            this.statsBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // competitieBTN
            // 
            this.competitieBTN.Location = new System.Drawing.Point(307, 170);
            this.competitieBTN.Name = "competitieBTN";
            this.competitieBTN.Size = new System.Drawing.Size(211, 117);
            this.competitieBTN.TabIndex = 0;
            this.competitieBTN.Text = "Competitie";
            this.competitieBTN.UseVisualStyleBackColor = true;
            this.competitieBTN.Click += new System.EventHandler(this.competitieBTN_Click);
            // 
            // trainingBTN
            // 
            this.trainingBTN.Location = new System.Drawing.Point(307, 39);
            this.trainingBTN.Name = "trainingBTN";
            this.trainingBTN.Size = new System.Drawing.Size(211, 125);
            this.trainingBTN.TabIndex = 1;
            this.trainingBTN.Text = "Training";
            this.trainingBTN.UseVisualStyleBackColor = true;
            // 
            // statsBTN
            // 
            this.statsBTN.Location = new System.Drawing.Point(307, 294);
            this.statsBTN.Name = "statsBTN";
            this.statsBTN.Size = new System.Drawing.Size(211, 144);
            this.statsBTN.TabIndex = 2;
            this.statsBTN.Text = "Stats";
            this.statsBTN.UseVisualStyleBackColor = true;
            this.statsBTN.Click += new System.EventHandler(this.statsBTN_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statsBTN);
            this.Controls.Add(this.trainingBTN);
            this.Controls.Add(this.competitieBTN);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button competitieBTN;
        private System.Windows.Forms.Button trainingBTN;
        private System.Windows.Forms.Button statsBTN;
    }
}