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

        public static void addBarServiceUI (string name, decimal price, int amount)
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

    }
}
