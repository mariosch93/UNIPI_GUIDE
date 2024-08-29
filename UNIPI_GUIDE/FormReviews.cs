using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class FormReviews : Form
    {
        bool sidebarExpand;
        bool UniCollapse;
        bool SchoolCollapse;
        LoginInfo loginInfo;
        string connectionString = "Data source=unipiguide.db;Version=3;";
        SoundPlayer player = new SoundPlayer("./music/background_music.wav");
        SQLiteConnection connection;

        public FormReviews(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            InitializeComponent();

            if (loginInfo != null)
            {
                reviewPanel.Visible = true;
            }

            connection = new SQLiteConnection(connectionString);
            UpdateReviews();
        }

        private void UpdateReviews()
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT username, review FROM reviews, users WHERE reviews.user_id = users.id", connection);
            var reader = command.ExecuteReader();

            richTextBoxPastReviews.Clear();
            while (reader.Read())
            {
                richTextBoxPastReviews.AppendText($"{reader.GetString(0)}:   {reader.GetString(1)}\n");
            }
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        private void buttonSubmitReview_Click(object sender, EventArgs e) {
            
        if (string.IsNullOrWhiteSpace(RichTextboxUserReview.Text)) return;

            connection.Open();

            SQLiteCommand command = new SQLiteCommand("INSERT INTO reviews (user_id, review) VALUES (@user_id, @review)", connection);
            command.Parameters.AddWithValue("user_id", loginInfo.UserId);
            command.Parameters.AddWithValue("review", RichTextboxUserReview.Text);

            int rows = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            if (rows > 0)
            {
                RichTextboxUserReview.Clear();
                UpdateReviews();
    }
}

        private void pictureExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reviewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            reviewPanel.BackColor = Color.LightBlue;
        }

        private void reviewPanel_MouseLeave(object sender, EventArgs e)
        {
            reviewPanel.BackColor= Color.White;
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                    panelMenuExtras.Visible = false;

                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {

                    sidebarExpand = true;
                    sidebarTimer.Stop();
                    panelMenuExtras.Visible = true;

                }
            }
        }

        private void sidebarTeacherTimer_Tick(object sender, EventArgs e)
        {

            if (sidebar.Width == sidebar.MinimumSize.Width)
            {
                panelTeacherInfo.Visible = true;
            }
            else
            {
                panelTeacherInfo.Visible = false;
            }

        }

        private void menuIcon_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
            sidebarTeacherTimer.Start();
        }

        private void UniTimer_Tick(object sender, EventArgs e)
        {
            if (UniCollapse)
            {
                UniContainer.Height += 10;
                if (UniContainer.Height == UniContainer.MaximumSize.Height)
                {
                    UniCollapse = false;
                    UniTimer.Stop();
                }
            }
            else
            {
                UniContainer.Height -= 10;
                if (UniContainer.Height == UniContainer.MinimumSize.Height)
                {
                    UniCollapse = true;
                    UniTimer.Stop();
                }
            }
        }

        private void buttonUni_Click(object sender, EventArgs e)
        {
            UniTimer.Start();
        }

        private void SchoolTimer_Tick(object sender, EventArgs e)
        {
            if (SchoolCollapse)
            {
                SchoolContainer.Height += 10;
                if (SchoolContainer.Height == SchoolContainer.MaximumSize.Height)
                {
                    SchoolCollapse = false;
                    SchoolTimer.Stop();
                }
            }
            else
            {
                SchoolContainer.Height -= 10;
                if (SchoolContainer.Height == SchoolContainer.MinimumSize.Height)
                {
                    SchoolCollapse = true;
                    SchoolTimer.Stop();
                }
            }
        }


        private void buttonSchools_Click(object sender, EventArgs e)
        {
            SchoolTimer.Start();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void calendarButton_Click(object sender, EventArgs e)
        {
            FormCalendar formCalendar = new FormCalendar(loginInfo);
            formCalendar.ShowDialog();
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            FormReviews formReview = new FormReviews(loginInfo);
            formReview.ShowDialog();
        }

        private void buttonPlaymusic_Click(object sender, EventArgs e)
        {
            player.PlayLooping();
        }

        private void buttonPausemusic_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            FormUniHistory formHistory = new FormUniHistory();
            formHistory.ShowDialog();
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            FormUniGuide formUniGuide = new FormUniGuide();
            formUniGuide.ShowDialog();
        }

        private void buttonManageSchool_Click(object sender, EventArgs e)
        {
            FormSchoolsManagement formSchoolsManagement = new FormSchoolsManagement();
            formSchoolsManagement.ShowDialog();
        }

        private void buttonMarineSchool_Click(object sender, EventArgs e)
        {
            FormSchoolsMarine formSchoolsMarine = new FormSchoolsMarine();
            formSchoolsMarine.ShowDialog();
        }

        private void buttonEconShool_Click(object sender, EventArgs e)
        {
            FormSchoolsEcon formSchoolsEcon = new FormSchoolsEcon();
            formSchoolsEcon.ShowDialog();
        }

        private void buttonTechSchool_Click(object sender, EventArgs e)
        {
            FormSchoolsTech formSchoolsTech = new FormSchoolsTech();
            formSchoolsTech.ShowDialog();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void richTextBoxPastReviews_MouseEnter(object sender, EventArgs e)
        {
            richTextBoxPastReviews.BackColor = Color.LightBlue;
        }

        private void richTextBoxPastReviews_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxPastReviews.BackColor = Color.White;
        }

        private void RichTextboxUserReview_MouseEnter(object sender, EventArgs e)
        {
            RichTextboxUserReview.BackColor = Color.LightBlue;
        }

        private void RichTextboxUserReview_MouseLeave(object sender, EventArgs e)
        {
            RichTextboxUserReview.BackColor = Color.White;
        }
    }
}
