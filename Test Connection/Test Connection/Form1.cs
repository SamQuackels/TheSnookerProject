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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnection();
        }

        private void DBConnection()
        {
            // String aanmaken zodat je kan verbinden met de server
            string ConnectString = "datasource = localhost; port = 3306; username = root; password=; database = snooker";   
            
            // SQL Query om alle users met ID 2 hun naam aan te passen
            string updateName =
                @"UPDATE users
                  SET name = 'Ali Addas'
                  WHERE ID = '2';";

            // SQL Query om alle namen van Users te verkrijgen
            string writeNames =
                @"SELECT name FROM users;";

            // Voert SQL Querys uit
            ExecuteCommand(ConnectString, updateName);
            GetData(ConnectString, writeNames);          
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

        void GetData(string connectionString, string commandString)
        {
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
                            MessageBox.Show(String.Format(Convert.ToString(reader[0])));
                        }
                    }
                }
            }
        }

        // Controleert of er connectie is
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
    }
}
