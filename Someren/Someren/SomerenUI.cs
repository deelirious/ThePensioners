using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Someren
{
    public static class SomerenUI
    {
        public static Control showStudents()
        {
            // make a list for retrieving data from it
            List<SomerenModel.Student> students = new List<SomerenModel.Student>();

            // linking the list to the DB connection in order to get data from it
            students = SomerenDB.DB_getStudents();

            // Making a list and editing its format 
            ListView studentsListView = new ListView();
            studentsListView.Height = 370;
            studentsListView.Width = 370;
            studentsListView.View = View.Details;
            studentsListView.FullRowSelect = true;

            // adding colums to the list
            studentsListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            studentsListView.Columns.Add("First Name", -2, HorizontalAlignment.Left);
            studentsListView.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
            studentsListView.Columns.Add("Room Number", -2, HorizontalAlignment.Left);

            // storing data into the list
            foreach (SomerenModel.Student student in students)
            {
                ListViewItem entryListItem = studentsListView.Items.Add(student.getId().ToString());
                entryListItem.SubItems.Add(student.getFirstName().ToString());
                entryListItem.SubItems.Add(student.getLastName().ToString());
                entryListItem.SubItems.Add(student.getRoomNumber().ToString());
            }

            // return a list view 
            return studentsListView;
        }

        public static Control showRooms()
        {
            List<SomerenModel.Rooms> rooms = new List<SomerenModel.Rooms>();

            // linking the list to the DB connection in order to get data from it
            rooms = SomerenDB.DB_getRooms();

            // Making a list and editing its format 
            //int aantal = rooms.Count();
            ListView roomsListView = new ListView();
            roomsListView.Height = 370;
            roomsListView.Width = 370;
            roomsListView.View = View.Details;
            roomsListView.FullRowSelect = true;

            // adding colums to the list
            roomsListView.Columns.Add("Room Number", -2, HorizontalAlignment.Left);
            roomsListView.Columns.Add("Room Capacity", -2, HorizontalAlignment.Left);
            roomsListView.Columns.Add("Room Type", -2, HorizontalAlignment.Left);

            // storing data into the list
            foreach (SomerenModel.Rooms room in rooms)
            {
                ListViewItem entryListItem = roomsListView.Items.Add(room.getRoomNumber().ToString());
                entryListItem.SubItems.Add(room.getRoomCapacity().ToString());

                if (room.getRoomType() == true)
                {
                    entryListItem.SubItems.Add("Teachers Room");
                }
                else
                {
                    entryListItem.SubItems.Add("Students Room");
                }
            }

            return roomsListView;
        }

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }

        internal static Control showTeachers()
        {
            List<SomerenModel.Teacher> teachers = new List<SomerenModel.Teacher>();

            teachers = SomerenDB.DB_getTeachers();

            // we will add this list view to the panel later so the UI updates
            ListView teacherListView = new ListView();


            teacherListView.Height = 370;
            teacherListView.Width = 370;
            teacherListView.View = View.Details;
            teacherListView.FullRowSelect = true;

            // add columns to the list view
            teacherListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("First Name", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Supervisor", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Room Number", -2, HorizontalAlignment.Left);

            // store data to the list view
            foreach (SomerenModel.Teacher teacher in teachers)
            {
                ListViewItem entryListItem = teacherListView.Items.Add(teacher.getId().ToString());
                entryListItem.SubItems.Add(teacher.getFirstName());
                entryListItem.SubItems.Add(teacher.getLastName());

                if (teacher.getIsSupervisor() == true)
                {
                    entryListItem.SubItems.Add("yes");
                }
                else
                {
                    entryListItem.SubItems.Add("no");
                }
                entryListItem.SubItems.Add(teacher.getRoomNumber().ToString());
            }

            // return a list view
            return teacherListView;
        }

        public static Control showBarService()
        {
            // make a list for retrieving data from it
            List<SomerenModel.BarService> barServices = new List<SomerenModel.BarService>();

            // linking the list to the DB connection in order to get data from it
            barServices = SomerenDB.DB_getBarServices();

            // Making a list and editing its format 
            ListView barServiceListView = new ListView();
            barServiceListView.Height = 370;
            barServiceListView.Width = 370;
            barServiceListView.View = View.Details;
            barServiceListView.FullRowSelect = true;

            // add columns to the list view
            barServiceListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            barServiceListView.Columns.Add("Drink Name", -2, HorizontalAlignment.Left);
            barServiceListView.Columns.Add("Drink Price", -2, HorizontalAlignment.Left);
            barServiceListView.Columns.Add("Amount (In Stock)", -2, HorizontalAlignment.Left);

            // declare a string variable for adding new text to stock amount data
            string StockState;

            // store data to the list view
            foreach (SomerenModel.BarService barService in barServices)
            {
                ListViewItem entryListItem = barServiceListView.Items.Add(barService.getDrinkId().ToString());
                entryListItem.SubItems.Add(barService.getDrinkName().ToString());
                entryListItem.SubItems.Add(barService.getDrinkPrice().ToString());

                // adding new text to stock amount data depending on its value
                if (barService.getStockAmount() < 10)
                {
                    StockState = barService.getStockAmount() + "   (Stock nearly depleted)";
                }
                else
                {
                    StockState = barService.getStockAmount() + "   (Stock sufficient)";
                }
                entryListItem.SubItems.Add(StockState.ToString());
            }

            // return a list view
            return barServiceListView;
        }

        public static Control[] showCashier()
        {
            // array cause we want to add two listviews, a label and a button to the view
            Control[] controls = new Control[4];

            /***********************************
             **** Create Students list view ****
             ***********************************/

            // load the students using existing method
            ListView studentsListView = (ListView)showStudents();

            // make list half height
            studentsListView.Height /= 2;

            studentsListView.CheckBoxes = true;

            // add to array of controls
            controls[0] = studentsListView;

            /*********************************
             **** Create Drinks list view ****
             *********************************/

            ListView barServiceListView = (ListView)showBarService();

            // make list half height
            barServiceListView.Height /= 2;

            // move list down so they don't overlap (move drinks down
            // by the nr of pixels the other list takes up vertically)
            barServiceListView.Top += studentsListView.Height;

            barServiceListView.CheckBoxes = true;

            // add to array of controls
            controls[1] = barServiceListView;

            /****************************
             **** Create Total label ****
             ****************************/

            Label totalLabel = new Label();

            // move to the right of the lists
            totalLabel.Left = studentsListView.Width + 10;

            totalLabel.AutoSize = true;

            totalLabel.Text = "Total price:";

            // add to the controls
            controls[2] = totalLabel;

            /********************************
             **** Create Checkout button ****
             ********************************/

            Button checkoutButton = new Button();

            // move to the right of the lists
            checkoutButton.Left = studentsListView.Width + 10;

            checkoutButton.Height = 50;
            checkoutButton.Width = 180;
            checkoutButton.Font = new Font(checkoutButton.Font, FontStyle.Bold);

            // move to the bottom of the panel
            checkoutButton.Top = barServiceListView.Bottom - checkoutButton.Height;

            checkoutButton.Text = "Checkout";

            controls[3] = checkoutButton;

            /*******************************
             **** Set up event handlers ****
             *******************************/

            // store the other controls in the tag so we can access them in the
            // event handlers later
            studentsListView.Tag = controls;
            barServiceListView.Tag = controls;
            checkoutButton.Tag = controls;

            // store the total amount in the label's tag
            totalLabel.Tag = 0.0;

            // when the event happens, call the registered function (event handler)
            barServiceListView.ItemChecked += Handle_CashierDrinkChecked;
            checkoutButton.Click += Handle_CheckoutButtonClicked;

            return controls;
        }

        private static void Handle_CheckoutButtonClicked(object sender, EventArgs eventArgs)
        {
            // find the button
            Button checkoutButton = (Button)sender;

            // find the other controls
            Control[] otherControls = (Control[])checkoutButton.Tag;

            // find the two lists
            ListView studentsListView = (ListView)otherControls[0];
            ListView barServiceListView = (ListView)otherControls[1];

            // we only support one student per order
            if (studentsListView.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one student.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get the selected student
            int studentId = int.Parse(studentsListView.CheckedItems[0].Text);

            // get the selected drinks
            List<int> drinkIds = new List<int>();

            foreach (ListViewItem checkedDrink in barServiceListView.CheckedItems)
            {
                int drinkId = int.Parse(checkedDrink.Text);

                drinkIds.Add(drinkId);
            }


            SomerenModel.CashRegisterList cashLines = new SomerenModel.CashRegisterList();

            // add each of the drinks to the list
            foreach (int drinkId in drinkIds)
            {
                SomerenModel.CashRegister cashLine = new SomerenModel.CashRegister();
                cashLine.setDrinkId(drinkId);
                cashLine.setStudentId(studentId);

                cashLines.addList(cashLine);
            }

            // invoke database query to store the stuff
            SomerenDB.DB_updateCashRegister(cashLines);

            // reset the view
            foreach (ListViewItem student in studentsListView.Items)
            {
                student.Checked = false;
            }

            foreach (ListViewItem drink in barServiceListView.Items)
            {
                drink.Checked = false;
            }
        }

        private static void Handle_CashierDrinkChecked(object sender, ItemCheckedEventArgs eventArgs)
        {
            // the sender is the student list view
            ListView barServiceListView = (ListView)sender;

            // the label is in the tag on the list view (index 2)
            Control[] otherControls = (Control[])barServiceListView.Tag;
            Label totalLabel = (Label)otherControls[2];

            double totalAmount = (double)totalLabel.Tag;

            ListViewItem item = eventArgs.Item;

            // the amount is the text value for the 3rd column
            double itemAmount = double.Parse(item.SubItems[2].Text);

            if (item.Checked)
            {
                // we must add amount to total                
                totalAmount += itemAmount;
            }
            // the event is somehow also fired when items are added initially
            // so we must make sure we don't go below 0
            else if (totalAmount >= itemAmount)
            {
                // remove amount from total
                totalAmount -= itemAmount;
            }

            totalLabel.Text = "Total amount: " + totalAmount.ToString("C");
            totalLabel.Tag = totalAmount;
        }

        public static void addBarServiceUI(string name, decimal price, int amount)
        {
            // make a new variable of type SomerenModel.BarService in order to store data to it
            SomerenModel.BarService newBarService = new SomerenModel.BarService();

            // store data to the newBarSrvice variable
            newBarService.setDrinkName(name);
            newBarService.setDrinkPrice(price);
            newBarService.setStockAmount(amount);

            // passing data to the DB layer
            SomerenDB.DB_addBarService(newBarService);
        }

        public static void uppdateBarServiceUI(int id, string name, decimal price, int amount)
        {
            // make a new variable of type SomerenModel.BarService in order to store data to it
            SomerenModel.BarService newBarService = new SomerenModel.BarService();

            // store data to the newBarSrvice variable
            newBarService.setDrinkId(id);
            newBarService.setDrinkName(name);
            newBarService.setDrinkPrice(price);
            newBarService.setStockAmount(amount);

            // passing data to the DB layer
            SomerenDB.DB_uppdateBarService(newBarService);
        }

        public static void deleteBarServiceUI(int id)
        {
            // make a new variable of type SomerenModel.BarService in order to store data to it
            SomerenModel.BarService newBarService = new SomerenModel.BarService();

            // store data to the newBarSrvice variable
            newBarService.setDrinkId(id);

            // passing data to the DB layer
            SomerenDB.DB_deleteBarService(newBarService);
        }


        //
        public static Control showRevenueReport()
        {
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();

            // to get data from DataBase
            report = SomerenDB.DB_getRevenueReport();

            // Making a list and editing its format 

            ListView reportListView = new ListView();
            reportListView.Height = 370;
            reportListView.Width = 370;
            reportListView.View = View.Details;
            reportListView.FullRowSelect = true;

            // adding colums to the list
            reportListView.Columns.Add("Sales", -2, HorizontalAlignment.Left);
            reportListView.Columns.Add("Turnover", -2, HorizontalAlignment.Left);
            reportListView.Columns.Add("Number of customers", -2, HorizontalAlignment.Left);

            // storing data into the list
            foreach (SomerenModel.Report record in report)
            {
                ListViewItem entryListItem = reportListView.Items.Add(record.getNumberOfDrinks().ToString());
                entryListItem.SubItems.Add(record.getTurnover().ToString());
                entryListItem.SubItems.Add(record.getNumberOfCustomers().ToString());

            }

            return reportListView;
        }

        public static Control showLimitedRevenueReport(DateTime start, DateTime end)
        {
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();

            // to get data from DataBase
            report = SomerenDB.DB_getLimitedRevenueReport(start, end);

            // Making a list and editing its format 

            ListView reportListView = new ListView();
            reportListView.Height = 370;
            reportListView.Width = 370;
            reportListView.View = View.Details;
            reportListView.FullRowSelect = true;

            // adding colums to the list
            reportListView.Columns.Add("Sales", -2, HorizontalAlignment.Left);
            reportListView.Columns.Add("Turnover", -2, HorizontalAlignment.Left);
            reportListView.Columns.Add("Number of customers", -2, HorizontalAlignment.Left);

            // storing data into the list
            foreach (SomerenModel.Report record in report)
            {
                ListViewItem entryListItem = reportListView.Items.Add(record.getNumberOfDrinks().ToString());
                entryListItem.SubItems.Add(record.getTurnover().ToString());
                entryListItem.SubItems.Add(record.getNumberOfCustomers().ToString());

            }

            return reportListView;
        }

        public static Control showActivity()
        {
            // make a list for retrieving data from it
            List<SomerenModel.Activities> activities = new List<SomerenModel.Activities>();

            // linking the list to the DB connection in order to get data from it
            activities = SomerenDB.DB_getActivities();

            // Making a list and editing its format 
            ListView activityListView = new ListView();
            activityListView.Height = 370;
            activityListView.Width = 370;
            activityListView.View = View.Details;
            activityListView.FullRowSelect = true;

            // add columns to the list view
            activityListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            activityListView.Columns.Add("Activity Description", -2, HorizontalAlignment.Left);
            activityListView.Columns.Add("Number of Students", -2, HorizontalAlignment.Left);
            activityListView.Columns.Add("Number of Supervisors", -2, HorizontalAlignment.Left);



            // store data to the list view
            foreach (SomerenModel.Activities activity in activities)
            {
                ListViewItem entryListItem = activityListView.Items.Add(activity.getId().ToString());
                entryListItem.SubItems.Add(activity.getActivity_desc().ToString());
                entryListItem.SubItems.Add(activity.getNumOfStudents().ToString());
                entryListItem.SubItems.Add(activity.getNumOfSupervisors().ToString());
            }

            // return a list view
            return activityListView;
        }
      
        public static void addActivity(string desc, int numOfStudents, int numberOfSupervisor)
        {
            // make a list for retrieving data from it
            List<SomerenModel.Activities> activities = new List<SomerenModel.Activities>();

            // linking the list to the DB connection in order to get data from it
            activities = SomerenDB.DB_getActivities();

            // make a new variable of type SomerenModel.Activities in order to store data to it
            SomerenModel.Activities newActivity = new SomerenModel.Activities();

            // make a list to store avtivity description in it
            List<string> activityDesc = new List<string>();

            // add avtivity description to the activityDesc list 
            foreach (SomerenModel.Activities activity in activities)
            {
                activityDesc.Add(activity.getActivity_desc().ToLower());
            }

            // make a validation to know if the data entered is diffrenet from DB data
            if (activityDesc.Contains(desc.ToLower()))
            {
                // show a message if the entered data exists in the DB
                MessageBox.Show("You can not add the same activity twice, please enter another activity name!", 
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //store data to the newActivity variable
                newActivity.setActivity_desc(desc);
                newActivity.setNumOfStudents(numOfStudents);
                newActivity.setNumOfSupervisors(numberOfSupervisor);
                // passing data to the DB layer
                SomerenDB.DB_addActivity(newActivity);

                // show a messagebox after a successfull addition
                MessageBox.Show("You have successfully added a new activity!!\n" +
                    "Enter Refresh the list to see the changes", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        public static void uppdateActivity(int id, string desc, int numOfStudents, int numberOfSupervisor)
        {
            // make a new variable of type SomerenModel.Activities in order to store data to it
            SomerenModel.Activities newActivity = new SomerenModel.Activities();

            // store data to the newActivity variable
            newActivity.setId(id);
            newActivity.setActivity_desc(desc);
            newActivity.setNumOfStudents(numOfStudents);
            newActivity.setNumOfSupervisors(numberOfSupervisor);

            // passing data to the DB layer
            SomerenDB.DB_uppdateActivity(newActivity);
        }

        public static void deleteActivity(int id)
        {
            // make a new variable of type SomerenModel.Activities in order to store data to it
            SomerenModel.Activities newActivity = new SomerenModel.Activities();

            // store data to the newActivity variable
            newActivity.setId(id);

            // passing data to the DB layer
            SomerenDB.DB_deleteActivity(newActivity);
        }

    }
}
