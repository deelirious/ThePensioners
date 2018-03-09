using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Someren
{
    public partial class Someren_Form : Form
    {
       
        private static Someren_Form instance;

        public Someren_Form() { InitializeComponent(); }

        public static Someren_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Someren_Form();
                }
                return instance;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showDashboard();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void showDashboard()
        {
            panel1.Controls.Clear();
            
            groupBox1.Text = "TODO LIST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "-check beer supply ";
            l.Text += "\r\n-make room schedule for slumber party";
            panel1.Controls.Add(l);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // toon hier een message "Weet je zeker dat je wilt afsluiten?"
            // Message msg = new Message();
            if ((MessageBox.Show("Are you sure you want to quit SomerenAdministration?", "Exit SomerenAdministration?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                Application.Exit();
            }
           
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SomerenUI.showStudents();
        }

        private void overSomerenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            panel1.Controls.Clear();

            groupBox1.Text = "TODO LIST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "This application is developed for 1.3 Project Databases, programme IT, Inholland University of Applied Sciences Haarlem";
            
            panel1.Controls.Add(l);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // er gebeurt niks als je op de menustrip drukt
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.groupBox1.Text = "Students";
            this.panel1.Controls.Add(SomerenUI.showStudents());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            this.Visible = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bardienstToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Rooms";

            panel1.Controls.Add(SomerenUI.showRooms());
        }

        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear(); // clear stuff on panel1
            groupBox1.Text = "Teachers"; // set title of groupbox

            panel1.Controls.Add(SomerenUI.showTeachers()); // show table in panel1 
        }

        private void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            panel1.Controls.Clear();
            groupBox1.Text = "The Revenue Report";
            panel1.Controls.Add(SomerenUI.showRevenueReport());

            //add the interface for the report (calendar and button)
            
            panel1.Controls.Add(picker_from);
            panel1.Controls.Add(picker_to);
            panel1.Controls.Add(From_text);
            panel1.Controls.Add(To_text);
            panel1.Controls.Add(limited_report);

            //formating date into dd-mm-yyyy
            picker_from.Format = DateTimePickerFormat.Custom;
            picker_from.CustomFormat = "dd-MM-yyyy";
            picker_to.Format = DateTimePickerFormat.Custom;
            picker_to.CustomFormat = "dd-MM-yyyy";
             
        }
        

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void limited_report_Click(object sender, EventArgs e)
        {
            //taking selected dates from the user
            DateTime start = picker_from.Value;
            DateTime end = picker_to.Value;
            //clear the panel for new data
            panel1.Controls.Clear();

            //add the interface for the limited report (buttons)
            
            panel1.Controls.Add(limited_report);
            panel1.Controls.Add(From_text);
            panel1.Controls.Add(To_text);
            panel1.Controls.Add(picker_from);
            panel1.Controls.Add(picker_to);

            //formating date into dd-mm-yyyy
            picker_from.Format = DateTimePickerFormat.Custom;
            picker_from.CustomFormat = "dd-MM-yyyy";
            picker_to.Format = DateTimePickerFormat.Custom;
            picker_to.CustomFormat = "dd-MM-yyyy";

            //check if the dates are correct
            if (end <= DateTime.Today && start < end)
            { panel1.Controls.Add(SomerenUI.showLimitedRevenueReport(start, end)); }
            else {
                MessageBox.Show ("Please, enter the valid dates ('from - to' and max. is 'today')","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}
