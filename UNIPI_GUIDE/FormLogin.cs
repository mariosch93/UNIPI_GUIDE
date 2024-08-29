using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class FormLogin : Form
    {
        string connectionString = "Data source=unipiguide.db;Version=3;";
        SQLiteConnection connection;

        public FormLogin()
        {
            connection = new SQLiteConnection(connectionString);
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var username = this.username.Text;
            var password = this.password.Text;

            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT id FROM users WHERE username = @username AND password = @password", connection);
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var loginInfo = new LoginInfo()
                {
                    UserName = username,
                    IsLoggedIn = true,
                    UserId = reader.GetInt32(0),
                };
                command.Dispose();
                reader.Close();
                connection.Close();

                var form1 = new Form1(loginInfo);
                form1.ShowDialog();
            }
            else 
            {
                error.Text = "Unable to sign in";

                command.Dispose();
                reader.Close();
                connection.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
