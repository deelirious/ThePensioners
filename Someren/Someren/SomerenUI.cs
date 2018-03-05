using System;
using System.Collections.Generic;
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
            List<SomerenModel.Student> students = new List<SomerenModel.Student>();

            // linking the list to the DB connection in order to get data from it
            students = SomerenDB.DB_getStudents();

            // Making a list and editing its format 
            //int aantal = students.Count();
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

            teacherListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("First Name", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Last Name", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Supervisor", -2, HorizontalAlignment.Left);
            teacherListView.Columns.Add("Room Number", -2, HorizontalAlignment.Left);

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

            return teacherListView;
        }
    }
}
