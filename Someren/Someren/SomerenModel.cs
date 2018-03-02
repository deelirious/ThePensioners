using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    class SomerenModel
    {
        public class Student
        {
            int id;
            string firstName;
            string lastName;


            public void setId(int studentId)
            {
                id = studentId;

            }

            public void setFirstName(string firstNameStudent)
            {
                firstName = firstNameStudent;
            }

            public void setLastName(string lastNameStudent)
            {
                lastName = lastNameStudent;

            }

            public string getFirstName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public int getId()
            {
                return id;
            }

        }

        public class StudentList
        {
            List<SomerenModel.Student> sl = new List<SomerenModel.Student>();

            public void addList(SomerenModel.Student s) {
                sl.Add(s);
            }

            public List<SomerenModel.Student> getList()
            {
                return sl;
            }
        }

        public class Teacher
        {
            private string firstName;
            private string lastName;
            private bool isSupervisor;

            /*
            could use properties instead:

            public string LastName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            */

            public void setFirstName(string newName)
            {
                firstName = newName;
            }

            public void setLastName(string newName)
            {
                lastName = newName;
            }

            public void setIsSupervisor(bool newValue)
            {
                isSupervisor = newValue;
            }

            public string getFirstName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public bool getIsSupervisor()
            {
                return isSupervisor;
            }
        }

        public class TeacherList
        {
            List<Teacher> teacherList = new List<Teacher>();

            public void addList(Teacher teacher)
            {
                teacherList.Add(teacher);
            }

            public List<Teacher> getList()
            {
                return teacherList;
            }
        }

        public class Rooms
        {
            int roomNumber;
            int roomCapacity;
            bool roomType;

            public void setRoomNumber(int room_number)
            {
                roomNumber = room_number;
            }
            public void setRoomCapacity(int room_capacity)
            {
                roomCapacity = room_capacity;
            }
            public void setRoomType(bool type)
            {
                roomType = type;
            }

            public int getRoomNumber()
            {
                return roomNumber;
            }

            public int getRoomCapacity()
            {
                return roomCapacity;
            }

            public bool getRoomType()
            {
                return roomType;
            }
        }

       
        public class RoomsList
        {
            List<SomerenModel.Rooms> r = new List<SomerenModel.Rooms>();

            public void addList(SomerenModel.Rooms s)
            {
                r.Add(s);
            }

            public List<SomerenModel.Rooms> getList()
            {
                return r;
            }
        }
    }

    

}
