﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UNIPI_GUIDE
{
    public partial class FormSchoolsManagement : Form
    {
        bool sidebarExpand;
        bool UniCollapse;
        bool SchoolCollapse;
        SoundPlayer player = new SoundPlayer("./music/background_music.wav");
        OpenFileDialog opentext = new OpenFileDialog();
        LoginInfo loginInfo;
        private string[] lines;
        private int index = 0;

        public FormSchoolsManagement()
        {
            InitializeComponent();
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

        private void pictureBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void LoadMyFile()
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for TXT files.
            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "RTF Files|*.txt";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                richTextBoxInformation.LoadFile(openFile1.FileName);
            }
        }


        private void pictureBoxEcon_Click(object sender, EventArgs e)
        {
            TextReader reader = new StreamReader(@"./images/txt_files/schoolManageEconomy.txt");
            richTextBoxInformation.Text = reader.ReadToEnd();
            reader.Close();        
            
        }

        private void pictureBoxManage_Click(object sender, EventArgs e)
        {
            TextReader reader = new StreamReader(@"./images/txt_files/schoolManageManage.txt");
            richTextBoxInformation.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void pictureBoxGlobal_Click(object sender, EventArgs e)
        {
            TextReader reader = new StreamReader(@"./images/txt_files/schoolManageGlobal.txt");
            richTextBoxInformation.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void pictureBoxTourism_Click(object sender, EventArgs e)
        {
            TextReader reader = new StreamReader(@"./images/txt_files/schoolManageTourism.txt");
            richTextBoxInformation.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
}
