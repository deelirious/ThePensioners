using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Someren
{
    class SomerenDB
    {  
        private static SqlConnection openConnectionDB()
        {

            // replace this with the connection string you received from Thijs Otter
            string host = "den1.mssql5.gear.host";
            string db = "projectdbgroupb2";
            string user = "projectdbgroupb2";
            string password = "Ps48dm3X-X4!";
            //string port = "3306";

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
            
           
            //connection.Open();
            StringBuilder sb = new StringBuilder();
            // write your query here to ensure a list of students is shown
            sb.Append("SELECT * FROM Students");
           
            //sb.Append("");

            /* EXAMPLE QUERY */
            //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            //sb.Append("JOIN [SalesLT].[Product] p ");
            //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
            /* */

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Student student = new SomerenModel.Student();
                student.setId((int)reader["student_id"]);
                student.setFirstName((string)reader["FirstName"]);
                student.setLastName((string)reader["LastName"]);

                students_list.Add(student);
            }
            reader.Close();
            connection.Close();

            return students_list;
        }

        public static List<SomerenModel.Rooms> DB_getRooms()
        {
            SqlConnection connection = openConnectionDB();
            // SqlConnection connection = new SqlConnection(connString);
            List<SomerenModel.Rooms> rooms_list = new List<SomerenModel.Rooms>();

            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Rooms");
            //  SqlCommand command = new SqlCommand(sqlQuery, dbConnection);


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
            
            string sql = "SELECT * FROM Teachers";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Teacher teacher = new SomerenModel.Teacher();

                teacher.setId((int)reader["teacher_id"]);
                teacher.setFirstName((string)reader["FirstName"]);
                teacher.setLastName((string)reader["LastName"]);
                teacher.setIsSupervisor((bool)reader["IsSupervisor"]);

                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();

            return teacherList;
        }
    }
}    