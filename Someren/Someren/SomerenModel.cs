using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    class SomerenModel
    {
        // class for Student
        public class Student
        {
            int id;
            string firstName;
            string lastName;
            int roomNumber;


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

            public void setRoomNumber(int room_number)
            {
                roomNumber = room_number;
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

            public int getRoomNumber()
            {
                return roomNumber;
            }

        }

        public class StudentList
        {
            List<Student> student = new List<Student>();

            public void addList(Student s)
            {
                student.Add(s);
            }

            public List<Student> getList()
            {
                return student;
            }
        }

        public class Teacher
        {
            private int id;
            private string firstName;
            private string lastName;
            private bool isSupervisor;
            int roomNumber;

            /*
            could use properties instead:

            public string LastName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            */

            public void setId(int teacherId)
            {
                id = teacherId;

            }

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

            public void setRoomNumber(int room_number)
            {
                roomNumber = room_number;
            }

            public int getId()
            {
                return id;
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

            public int getRoomNumber()
            {
                return roomNumber;
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
            List<Rooms> room = new List<Rooms>();

            public void addList(Rooms r)
            {
                room.Add(r);
            }

            public List<Rooms> getList()
            {
                return room;
            }
        }

        // class for BarService
        public class BarService
        {
            int drinkId;
            string drinkName;
            decimal drinkPrice;
            int stockAmount;

            public void setDrinkId(int drink_id)
            {
                drinkId = drink_id;
            }

            public void setDrinkName(string drink_name)
            {
                drinkName = drink_name;
            }

            public void setDrinkPrice(decimal drink_price)
            {
                drinkPrice = drink_price;
            }

            public void setStockAmount(int stock_amount)
            {
                stockAmount = stock_amount;
            }

            public int getDrinkId()
            {
                return drinkId;
            }

            public string getDrinkName()
            {
                return drinkName;
            }

            public decimal getDrinkPrice()
            {
                return drinkPrice;
            }

            public int getStockAmount()
            {
                return stockAmount;
            }

        }


        public class BarServiceList
        {
            List<BarService> barServiceList = new List<BarService>();

            public void addList(BarService barService)
            {
                barServiceList.Add(barService);
            }

            public List<BarService> getList()
            {
                return barServiceList;
            }
        }

        // class for cash register
        public class CashRegister
        {
            int studentId;
            int drinkId;

            public void setStudentId(int studentId)
            {
                this.studentId = studentId; // when the two names are similiar we put this.
            }

            public void setDrinkId(int drinkId)
            {
                this.drinkId = drinkId;
            }

            public int getStudentId()
            {
                return studentId;
            }

            public int getDrinkId()
            {
                return drinkId;
            }

        }

        public class CashRegisterList
        {
            List<CashRegister> cashRegisterList = new List<CashRegister>();

            public void addList(CashRegister cashRegister)
            {
                cashRegisterList.Add(cashRegister);
            }

            public List<CashRegister> getList()
            {
                return cashRegisterList;
            }
        }



        //class for Report (Sales, Turnover, Number of customers)
        public class Report
        {
            int numberOfDrinks;

            //total[sales*sales price of those drinks]
            decimal turnover;

            //custormers who bought at least one drink
            int numberOfCustomers;

            //set into the class Report
            public void SetNumberOfDrinks(int sales)
            {
                numberOfDrinks = sales;
            }

            public void SetTurnover(decimal totalSales)
            {
                turnover = totalSales;
            }
            public void SetnumberOfCustomers(int numberCust)
            {
                numberOfCustomers = numberCust;
            }

            //get from the class Report
            public int getNumberOfDrinks()
            {
                return numberOfDrinks;
            }
            public decimal getTurnover()
            {
                return turnover;
            }
            public int getNumberOfCustomers()
            {
                return numberOfCustomers;
            }
        }

        public class ReportList
        {
            List<Report> reportList = new List<Report>();

            public void addList(SomerenModel.Report report)
            {
                reportList.Add(report);
            }

            public List<Report> getList()
            {
                return reportList;
            }
        }

        public class Supervisor
        {
            string FirstName;
            string LastName;



            //set into the class Supervisor
            public void setFirstName(string f_name)
            {
                FirstName = f_name;
            }

            public void setLastName(string l_name)
            {
                LastName = l_name;
            }

            //get from the class Supervisor
            public string getFirstName()
            {
                return FirstName;
            }
            public string getLastName()
            {
                return LastName;
            }
           }

        public class SupervisorList
        {
            List<Supervisor> SupervisorsList = new List<Supervisor>();

            public void addList(SomerenModel.Supervisor supervisor)
            {
                SupervisorsList.Add(supervisor);
            }

            public List<Supervisor> getList()
            {
                return SupervisorsList;
            }
        }
        // class for activities
        public class Activities
        {
            public int id;
            public string activity_desc;
            public int numOfStudents;
            public int numOfSupervisors;



            public void setId(int activityId)
            {
                id = activityId;
            }

            public void setActivity_desc(string activityDesc)
            {
                activity_desc = activityDesc;
            }

            public void setNumOfStudents(int numOfstudent)
            {
                numOfStudents = numOfstudent;
            }

            public void setNumOfSupervisors(int numOfSupervisor)
            {
                numOfSupervisors = numOfSupervisor;
            }

            public int getId()
            {
                return id;
            }

            public string getActivity_desc()
            {
                return activity_desc;
            }

            public int getNumOfStudents()
            {
                return numOfStudents;
            }

            public int getNumOfSupervisors()
            {
                return numOfSupervisors;
            }

        }

        public class ActivitiesList
        {
            List<Activities> activitiesList = new List<Activities>();

            public void addList(Activities activity)
            {
                activitiesList.Add(activity);
            }

            public List<Activities> getList()
            {
                return activitiesList;
            }
        }


    }

}

