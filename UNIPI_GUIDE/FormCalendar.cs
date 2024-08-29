using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNIPI_GUIDE
{
    public partial class FormCalendar : Form
    {
        bool sidebarExpand;
        bool UniCollapse;
        bool SchoolCollapse;
        SoundPlayer player = new SoundPlayer("./music/background_music.wav");
        LoginInfo loginInfo;

        public FormCalendar(LoginInfo loginInfo)
        {
            this.loginInfo = loginInfo;
            InitializeComponent();
            AddDatesForLoggedIn();

            monthCalendar.AnnuallyBoldedDates = annuallyCalendarDates.Keys.ToArray();
        }

        Dictionary<DateTime, string> annuallyCalendarDates = new Dictionary<DateTime, string>()
        {
            { new DateTime(2024, 8, 15), "15 Αυγούστου, Κοίμηση της Θεοτόκου" },
            { new DateTime(2024, 10, 28), "28η Οκτωβρίου, Επέτειος του Όχι." },
            { new DateTime(2025, 3, 25), "15 Αυγούστου, Επέτειος της Ελληνικής Επανάστασης του 1821."},
            { new DateTime(2025, 1, 1), "1 Ιανουαρίου, Πρωτοχρονιά." },
            { new DateTime(2025, 1, 6), "6 Ιανουαρίου, Θεοφάνια." },
            { new DateTime(2025, 5, 1), "1 Μαΐου, Εργατική Πρωτομαγιά." },
            { new DateTime(2024, 12, 25), "25 Δεκεμβρίου, Χριστούγεννα." },
            { new DateTime(2024, 12, 26), "26 Δεκεμβρίου, Σύναξη της Υπεραγίας Θεοτόκου." },
            { new DateTime(2025, 3, 24), "24 Μαρτίου, Εορταστικές εκδηλώσεις για την επέτειο της εθνικής εορτής της 25ης Μαρτίου." },
            { new DateTime(2024, 11, 17), "17 Νοεμβρίου, Επέτειο του Πολυτεχνείου." }
        };

        private void AddDatesForLoggedIn()
        {
            if (loginInfo == null) return;

            annuallyCalendarDates.Add(new DateTime(2024, 9, 6), "Εξετασεις Μαθήματος: Εισαγωγή στην Επιστήμη των Υπολογιστών ");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 12), "Εξετασεις Μαθήματος: Αρχές Προγραμματισμού – Γλώσσα C, C++");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 14), "Εξετασεις Μαθήματος: Δομές Δεδομένων");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 17), "Εξετασεις Μαθήματος: Γλώσσες Προγραμματισμού και Μεταγλωττιστές");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 21), "Εξετασεις Μαθήματος: Λειτουργικά Συστήματα");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 24), "Εξετασεις Μαθήματος: Ειδικά Κεφάλαια Μαθηματικών");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 28), "Εξετασεις Μαθήματος: Λογικός Προγραμματισμός");
            annuallyCalendarDates.Add(new DateTime(2024, 9, 29), "Εξετασεις Μαθήματος: Αντικειμενοστρεφής Προγραμματισμός – Τεχνολογίες Διαδικτύου");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 3), "Εξετασεις Μαθήματος: Βάσεις και Αποθήκες Δεδομένων");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 6), "Εξετασεις Μαθήματος: Τεχνητή Νοηµοσύνη – Έµπειρα Συστήµατα");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 11), "Εξετασεις Μαθήματος: Αλληλεπίδραση Ανθρώπου – Υπολογιστή");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 15), "Εξετασεις Μαθήματος: Ταχεία Ανάπτυξη Εφαρμογών");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 19), "Εξετασεις Μαθήματος: Θεωρία και Εφαρµογές Γραφηµάτων");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 22), "Εξετασεις Μαθήματος Γραµµικός Προγραµµατισµός");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 26), "Εξετασεις Μαθήματος: Πολυµεσικά Σήµατα και Συστήµατα");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 21), "Εξετασεις Μαθήματος: Ειδικά Θέµατα Συνδυαστικής Ανάλυσης");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 29), "Εξετασεις Μαθήματος: Τεχνολογία Λογισµικού");
            annuallyCalendarDates.Add(new DateTime(2024, 10, 30), "Εξετασεις Μαθήματος: Αναγνώριση Προτύπων");
            annuallyCalendarDates.Add(new DateTime(2024, 12, 12), "Περίοδος Ορκωμοσίας Δεκεμβρίου");
            annuallyCalendarDates.Add(new DateTime(2025, 1, 19), "Περίοδος Ορκωμοσίας Ιανουαρίου");
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (annuallyCalendarDates.TryGetValue(e.Start, out var description))
            {
                richTextBoxEvents.Text = description;
            }
            else
            {
                richTextBoxEvents.Text = "";
            }
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBoxEvents_MouseEnter(object sender, EventArgs e)
        {
            richTextBoxEvents.BackColor = Color.LightBlue;
        }

        private void richTextBoxEvents_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxEvents.BackColor = Color.White;
        }

        private void richTextBoxInformation1_MouseEnter(object sender, EventArgs e)
        {
            richTextBoxInformation1.BackColor = Color.LightBlue;
        }

        private void richTextBoxInformation1_MouseLeave(object sender, EventArgs e)
        {
            richTextBoxInformation1.BackColor = Color.White;
        }

        private void pictureExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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
    }
}

