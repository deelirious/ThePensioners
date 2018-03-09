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
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // make a list to store data from DB into it
            List<SomerenModel.Student> students_list = new List<SomerenModel.Student>();

            // string builder to write query
            StringBuilder sb = new StringBuilder();
            
            // the sql query
            sb.Append("SELECT student_id, FirstName,LastName ,room_number_id  FROM Students");

            // convert the sql query to string
            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            // retrieving data from DB
            while (reader.Read())
            {
                // store data to the list
                SomerenModel.Student student = new SomerenModel.Student();
                student.setId((int)reader["student_id"]);
                student.setFirstName((string)reader["FirstName"]);
                student.setLastName((string)reader["LastName"]);
                student.setRoomNumber((int)reader["room_number_id"]);
                students_list.Add(student);
            }

            // close the reader and sql connection
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

            // close all connections
            reader.Close();
            connection.Close();

            return teacherList;
        }

        public static List<SomerenModel.BarService> DB_getBarServices()
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // make a list to store data from DB into it
            List<SomerenModel.BarService> barServiceList = new List<SomerenModel.BarService>();

            // the sql queries
            string sqlOne = "SELECT DISTINCT m.drink_id , m.drink_name, m.stock_amount, m.price, p.drink_sold";
            string sqlTwo = " FROM BarService AS m LEFT JOIN studentbarservice AS p on m.drink_id = p.drink_id";
            string sqlThree = " WHERE m.stock_amount > 1 AND m.price > 1";
            string sqlFour = " AND m.drink_name not IN('Water', 'Orangeade', 'Cherry juice')";
            string sqlFive = " ORDER BY 3 ,4, 5";
            string finalQuery = sqlOne + sqlTwo + sqlThree + sqlFour + sqlFive;

            SqlCommand command = new SqlCommand(finalQuery, connection);
            SqlDataReader reader = command.ExecuteReader();

            // retrieving data from DB
            while (reader.Read())
            {
                // store data to the list
                SomerenModel.BarService barService = new SomerenModel.BarService();
                barService.setDrinkId((int)reader["drink_id"]);
                barService.setDrinkName((string)reader["drink_name"]);
                barService.setDrinkPrice((decimal)reader["price"]); // use decimal to avoid any conflict with DB
                barService.setStockAmount((int)reader["stock_amount"]);
                barServiceList.Add(barService);
            }

            // close all connections
            reader.Close();
            connection.Close();

            return barServiceList;
        }

        public static void DB_addBarService(SomerenModel.BarService newBarSrvice)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for inserting new data to the DB
            string sqlQuery = "INSERT INTO BarService(drink_name, price, stock_amount) VALUES(@drink_name, @price, @stock_amount)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@drink_name", newBarSrvice.getDrinkName());
            command.Parameters.AddWithValue("@price", newBarSrvice.getDrinkPrice());
            command.Parameters.AddWithValue("@stock_amount", newBarSrvice.getStockAmount());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();
        }

        public static void DB_uppdateBarService(SomerenModel.BarService newBarSrvice)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for updating data of the DB
            string sqlQuery = "UPDATE BarService SET drink_name = @drink_name, price = @price, stock_amount= @stock_amount WHERE drink_id = @drink_id ";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@drink_id", newBarSrvice.getDrinkId());
            command.Parameters.AddWithValue("@drink_name", newBarSrvice.getDrinkName());
            command.Parameters.AddWithValue("@price", newBarSrvice.getDrinkPrice());
            command.Parameters.AddWithValue("@stock_amount", newBarSrvice.getStockAmount());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();
        }

        public static void DB_deleteBarService(SomerenModel.BarService newBarSrvice)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for deleting data from DB
            string sqlQuery = "DELETE FROM BarService WHERE drink_id = @drink_id";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@drink_id", newBarSrvice.getDrinkId());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();

        }



    }
}    