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

            // adding some useful tips to the buttons and labels of Bar Services when hovering over
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(lblId, "Enter an ID only for updating and deletion !!not for add!!");
            ToolTip1.SetToolTip(drinkNameLbl, "Please Start with an Uppercase letter");
            ToolTip1.SetToolTip(drinkPriceLbl, "Type a price in a floating point like: '3.50'");
            ToolTip1.SetToolTip(drinkAmountLbl, "Type a whole number like: '2'");
            ToolTip1.SetToolTip(drinkAddBtn, "Enter a name, price and amount to add a drink !no ID is needed!");
            ToolTip1.SetToolTip(drinkUpdateBtn, "Enter the ID first then a name, price and amount to uppdate a drink");
            ToolTip1.SetToolTip(drinkDeleteBtn, "Enter just an ID to delete a drink");
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
            this.panel1.Controls.Clear(); // clear stuff on panel
            this.groupBox1.Text = "Students"; // set name for groupbox
            this.panel1.Controls.Add(SomerenUI.showStudents()); // add data to the panel
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
            panel1.Controls.Clear();// clear stuff on panel
            groupBox1.Text = "Rooms"; // set name for groupbox
            panel1.Controls.Add(SomerenUI.showRooms()); // add data to the panel
        }

        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //groupBox1.Controls.Clear();
            panel1.Controls.Clear(); // clear stuff on panel1
            groupBox1.Text = "Teachers"; // set title of groupbox
            panel1.Controls.Add(SomerenUI.showTeachers()); // show table in panel1 
        }

        private void drankvoorraadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // clear stuff on panel1
            groupBox1.Text = "Bar Service"; // set title of groupbox
            panel1.Controls.Add(SomerenUI.showBarService()); // show table in panel1 

            // add buttons and labels to the panel
            panel1.Controls.Add(drinkAddBtn);
            panel1.Controls.Add(drinkDeleteBtn);
            panel1.Controls.Add(drinkUpdateBtn);
            panel1.Controls.Add(drinkNameLbl);
            panel1.Controls.Add(drinkPriceLbl);
            panel1.Controls.Add(drinkAmountLbl);
            panel1.Controls.Add(drinkAmountBox);
            panel1.Controls.Add(drinkNameBox);
            panel1.Controls.Add(drinkPriceBox);
            panel1.Controls.Add(refreshBtn);
            panel1.Controls.Add(LblInstructions);
            panel1.Controls.Add(boxId);
            panel1.Controls.Add(lblId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (drinkNameBox.Text == "" || drinkPriceBox.Text == "" || drinkAmountBox.Text == "")
            {
                // show a message if a user did not enter a value
                MessageBox.Show("Please enter a value for (Name, Price, Amount) fields before clicking on Add", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // reading data from the textboxes
                string name = drinkNameBox.Text;
                decimal price = decimal.Parse(drinkPriceBox.Text);
                int amount = int.Parse(drinkAmountBox.Text);

                // passing data to the UI layer
                SomerenUI.addBarServiceUI(name, price, amount);

                // show a messagebox after clicking on add button
                MessageBox.Show("You have successfully added a new drink!!\n" +
                    "Enter Refresh the list to see the changes", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
               
            // clearing data from textboxes
            drinkAmountBox.Clear();
            drinkNameBox.Clear();
            drinkPriceBox.Clear();
            boxId.Clear();
        }

        private void drinkUpdateBtn_Click(object sender, EventArgs e)
        {

            if (boxId.Text=="" || drinkNameBox.Text=="" || drinkPriceBox.Text=="" || drinkAmountBox.Text=="")
            {
                // show a message if a user did not enter a value
                MessageBox.Show("Please enter a value for all fields before clicking on Update", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // reading data from the textboxes
                int id = int.Parse(boxId.Text);
                string name = drinkNameBox.Text;
                decimal price = decimal.Parse(drinkPriceBox.Text);
                int amount = int.Parse(drinkAmountBox.Text);

                // passing data to the UI layer
                SomerenUI.uppdateBarServiceUI(id, name, price, amount);

                // show a messagebox after clicking on update button
                MessageBox.Show("You have successfully updated a drink!!\n" +
                    "Enter Refresh the list to see the changes", "",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // clearing data from textboxes
            drinkAmountBox.Clear();
            drinkNameBox.Clear();
            drinkPriceBox.Clear();
            boxId.Clear();
        }

        private void drinkDeleteBtn_Click(object sender, EventArgs e)
        {
            
            if (boxId.Text == "")
            {
                // show a message if a user did not enter a value
                MessageBox.Show("Please enter a value for ID before clicking on Delete", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // reading data from the textboxes
                int id = int.Parse(boxId.Text);

                // passing data to the UI layer
                SomerenUI.deleteBarServiceUI(id);

                // show a messagebox after clicking on update button
                MessageBox.Show("You have successfully deleted a drink!!\n " +
               "Enter Refresh the list to see the changes", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
     
            // clearing data from textboxes
            drinkAmountBox.Clear();
            drinkNameBox.Clear();
            drinkPriceBox.Clear();
            boxId.Clear();
        }

        private void drinkNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void drinkPriceBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void drinkAmountBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void drinkNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void drinkPriceLbl_Click(object sender, EventArgs e)
        {

        }

        private void drinkAmountLbl_Click(object sender, EventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // clear stuff on panel1
            groupBox1.Text = "Bar Service"; // set title of groupbox
            panel1.Controls.Add(SomerenUI.showBarService()); // show table in panel1 

            // add buttons and labels to the panel after refreshing the list
            panel1.Controls.Add(drinkAddBtn);
            panel1.Controls.Add(drinkDeleteBtn);
            panel1.Controls.Add(drinkUpdateBtn);
            panel1.Controls.Add(drinkNameLbl);
            panel1.Controls.Add(drinkPriceLbl);
            panel1.Controls.Add(drinkAmountLbl);
            panel1.Controls.Add(drinkAmountBox);
            panel1.Controls.Add(drinkNameBox);
            panel1.Controls.Add(drinkPriceBox);
            panel1.Controls.Add(refreshBtn);
            panel1.Controls.Add(LblInstructions);
            panel1.Controls.Add(boxId);
            panel1.Controls.Add(lblId);
        }

        private void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            groupBox1.Text = "The Revenue Report";
            panel1.Controls.Add(SomerenUI.showRevenueReport());

            //add the interface for the report (calendar and button)

            panel1.Controls.Add(picker_from_form);
            panel1.Controls.Add(picker_to_form);
            panel1.Controls.Add(From_text_button);
            panel1.Controls.Add(To_text_button);
            panel1.Controls.Add(limited_report_button);

            //formating date into dd-mm-yyyy
            picker_from_form.Format = DateTimePickerFormat.Custom;
            picker_from_form.CustomFormat = "dd-MM-yyyy";
            picker_to_form.Format = DateTimePickerFormat.Custom;
            picker_to_form.CustomFormat = "dd-MM-yyyy";

        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void limited_report_Click(object sender, EventArgs e)
        {

        }


        private void limited_report_button_Click(object sender, EventArgs e)
        {
            //taking selected dates from the user
            DateTime start = picker_from_form.Value;
            DateTime end = picker_to_form.Value;
            //clear the panel for new data
            panel1.Controls.Clear();

            //add the interface for the limited report (buttons)

            panel1.Controls.Add(limited_report_button);
            panel1.Controls.Add(From_text_button);
            panel1.Controls.Add(To_text_button);
            panel1.Controls.Add(picker_from_form);
            panel1.Controls.Add(picker_to_form);

            //formating date into dd-mm-yyyy
            picker_from_form.Format = DateTimePickerFormat.Custom;
            picker_from_form.CustomFormat = "dd-MM-yyyy";
            picker_to_form.Format = DateTimePickerFormat.Custom;
            picker_to_form.CustomFormat = "dd-MM-yyyy";

            //check if the dates are correct
            if (end <= DateTime.Today && start < end)
            {
                panel1.Controls.Add(SomerenUI.showLimitedRevenueReport(start, end)); }
            else
            {
                //saying to a user to try again
                MessageBox.Show("Please, enter the valid dates ('from - to' and max. is 'today')", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void kassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.AddRange(SomerenUI.showCashier());
        }
    }
}
