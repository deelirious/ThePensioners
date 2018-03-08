using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace Someren
{
    class SomerenDB
    {  
        private static SqlConnection openConnectionDB()
        {

            string host = "den1.mssql5.gear.host";
            string db = "projectdbgroupb2";
            string user = "projectdbgroupb2";
            string password = "Ps48dm3X-X4!";
          
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                
                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }            
        }

        private void sluitConnectieDB(SqlConnection connection)
        {
            connection.Close();
        }

        public static List<SomerenModel.Student> DB_getStudents()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Student> students_list = new List<SomerenModel.Student>();
            
            StringBuilder sb = new StringBuilder();
            // write your query here to ensure a list of students is shown
            sb.Append("SELECT student_id, FirstName,LastName ,room_number_id  FROM Students");
           
            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Student student = new SomerenModel.Student();
                student.setId((int)reader["student_id"]);
                student.setFirstName((string)reader["FirstName"]);
                student.setLastName((string)reader["LastName"]);
                student.setRoomNumber((int)reader["room_number_id"]);

                students_list.Add(student);
            }
            reader.Close();
            connection.Close();

            return students_list;
        }

        public static List<SomerenModel.Rooms> DB_getRooms()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Rooms> rooms_list = new List<SomerenModel.Rooms>();

            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT room_number_id, RoomCapacity, RoomType  FROM Rooms");
           
            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Rooms room = new SomerenModel.Rooms();
                room.setRoomNumber((int)reader["room_number_id"]);
                room.setRoomCapacity((int)reader["RoomCapacity"]);
                room.setRoomType((bool)reader["RoomType"]);
                rooms_list.Add(room);
            }
            reader.Close();
            connection.Close();

            return rooms_list;
        }

        internal static List<SomerenModel.Teacher> DB_getTeachers()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Teacher> teacherList = new List<SomerenModel.Teacher>();
            
            string sql = "SELECT teacher_id, FirstName, LastName, IsSupervisor, " +
                "room_number_id   FROM Teachers";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Teacher teacher = new SomerenModel.Teacher();

                teacher.setId((int)reader["teacher_id"]);
                teacher.setFirstName((string)reader["FirstName"]);
                teacher.setLastName((string)reader["LastName"]);
                teacher.setIsSupervisor((bool)reader["IsSupervisor"]);
                teacher.setRoomNumber((int)reader["room_number_id"]);

                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();

            return teacherList;
        }

        public static List<SomerenModel.Report> DB_getReport()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();


            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT sum(StudentBarService.drink_sold) as 'NumberOfDrinks', sum(BarService.price * StudentBarService.drink_sold) as 'Turnover', COUNT(distinct StudentBarService.student_id) as 'NumberOfCustomers' FROM StudentBarService INNER JOIN BarService ON StudentBarService.drink_id = BarService.drink_id");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Report record = new SomerenModel.Report();
                record.SetNumberOfDrinks((int)reader["NumberOfDrinks"]);
                record.SetTurnover((decimal)reader["Turnover"]);
                record.SetnumberOfCustomers((int)reader["NumberOfCustomers"]);
                report.Add(record);
            }
            reader.Close();
            connection.Close();

            return report;
        }
        //if user wants to get date-limited report
        public static List<SomerenModel.Report> DB_getLimitedReport(DateTime start, DateTime end)
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();

            //editing dates in proper format yyyy-MM-dd 
            string start_edit = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string end_edit = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT sum(StudentBarService.drink_sold) as 'NumberOfDrinks', sum(BarService.price * StudentBarService.drink_sold) as 'Turnover', COUNT(distinct StudentBarService.student_id) as 'NumberOfCustomers' FROM StudentBarService INNER JOIN BarService ON StudentBarService.drink_id = BarService.drink_id WHERE  StudentBarService.date BETWEEN '"+ start_edit +"' AND '"+ end_edit + "'");

            String sql = sb.ToString();
            
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Report record = new SomerenModel.Report();
                record.SetNumberOfDrinks((int)reader["NumberOfDrinks"]);
                record.SetTurnover((decimal)reader["Turnover"]);
                record.SetnumberOfCustomers((int)reader["NumberOfCustomers"]);
                report.Add(record);
            }
            reader.Close();
            connection.Close();

            return report;
        }
    }
}    