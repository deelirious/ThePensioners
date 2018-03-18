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




        public static List<SomerenModel.Report> DB_getRevenueReport()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();

            //put the query into string builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT sum(StudentBarService.drink_sold) as 'NumberOfDrinks', sum(BarService.price * StudentBarService.drink_sold) as 'Turnover', COUNT(distinct StudentBarService.student_id) as 'NumberOfCustomers' FROM StudentBarService INNER JOIN BarService ON StudentBarService.drink_id = BarService.drink_id");

            String sql = sb.ToString();

            //start connection with DB
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
        public static List<SomerenModel.Report> DB_getLimitedRevenueReport(DateTime start, DateTime end)
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Report> report = new List<SomerenModel.Report>();

            //editing dates in proper format yyyy-MM-dd for DB
            string start_edit = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string end_edit = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            //put the query into string builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT sum(StudentBarService.drink_sold) as 'NumberOfDrinks', " +
                "sum(BarService.price * StudentBarService.drink_sold) as 'Turnover', " +
                "COUNT(distinct StudentBarService.student_id) as 'NumberOfCustomers' " +
                "FROM StudentBarService INNER JOIN BarService ON StudentBarService.drink_id = BarService.drink_id " +
                "WHERE  StudentBarService.date BETWEEN '" + start_edit + "' AND '" + end_edit + "'");

            String sql = sb.ToString();

            //start connection with DB
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

        internal static void DB_updateCashRegister(SomerenModel.CashRegisterList list)
        {
            SqlConnection connection = openConnectionDB();

            // we generate the date on the server
            // we only support ordering one of the same drink at a time
            string sqlQuery = @"INSERT INTO StudentBarService
                        (drink_id, student_id, date, drink_sold)
                        VALUES
                        (@drink_id, @student_id, GETDATE(), 1)";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // insert the drinks one by one
            foreach (SomerenModel.CashRegister record in list.getList())
            {
                // clear from previous query
                command.Parameters.Clear();

                // add student and drink ids
                command.Parameters.AddWithValue("@drink_id", record.getDrinkId());
                command.Parameters.AddWithValue("@student_id", record.getStudentId());

                // execute the query
                command.ExecuteNonQuery();
            }

            // make sure to close the connection
            connection.Close();
        }

        public static List<SomerenModel.Supervisor> DB_getSupervisors()
        {
            SqlConnection connection = openConnectionDB();
            List<SomerenModel.Supervisor> supervisors = new List<SomerenModel.Supervisor>();

            //put the query into string builder
            StringBuilder sb = new StringBuilder();
            sb.Append("select FirstName, LastName  from Teachers where IsSupervisor = '1'");

            String sql = sb.ToString();

            //start connection with DB
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SomerenModel.Supervisor record = new SomerenModel.Supervisor();
                record.setFirstName((string)reader["FirstName"]);
                record.setLastName((string)reader["LastName"]);
               
                supervisors.Add(record);
            }
            reader.Close();
            connection.Close();

            return supervisors;
        }

        public static void DB_removeSupervisor(string remove_supervisor)
        {
            SqlConnection connection = openConnectionDB();
           // List<SomerenModel.Supervisor> supervisors = new List<SomerenModel.Supervisor>();

            //put the query into string builder
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Teachers SET IsSupervisor = '0'WHERE LastName like '" + remove_supervisor+"'");

            String sql = sb.ToString();

            //start connection with DB
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
              while (reader.Read())
              {
                command.ExecuteNonQuery();
            }
              reader.Close();
            
            connection.Close();
        }

        public static void DB_AddSupervisor(string add_supervisor)
        {
            SqlConnection connection = openConnectionDB();
            // List<SomerenModel.Supervisor> supervisors = new List<SomerenModel.Supervisor>();

            //put the query into string builder
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Teachers SET IsSupervisor = '1'WHERE LastName like '" + add_supervisor + "'");

            String sql = sb.ToString();

            //start connection with DB
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                command.ExecuteNonQuery();
            }
            reader.Close();

            connection.Close();
        }

        public static void DB_setTimeslotForActivity(int activityId, DateTime date, int startTime, int endTime)
        {
            SqlConnection connection = openConnectionDB();

            string query = @"UPDATE Timetable SET
                                [Date] = @date,
	                            StartTime = @startTime,
	                            EndTime = @endTime
                              WHERE activity_id = @activityId";

            SqlCommand command = new SqlCommand(query, connection);

            // make sure to use parameters to prevent sql injection
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@startTime", startTime);
            command.Parameters.AddWithValue("@endTime", endTime);
            command.Parameters.AddWithValue("@activityId", activityId);
            
            command.ExecuteNonQuery();

            // make sure to close the connection
            connection.Close();
        }

        public static List<SomerenModel.TimetableActivity> DB_getTimetable()
        {
            SqlConnection connection = openConnectionDB();

            List<SomerenModel.TimetableActivity> timetable = new List<SomerenModel.TimetableActivity>();

            string sqlQuery = @"
                SELECT Timetable.[activity_id]
                      ,[Date]
                      ,[StartTime]
                      ,[EndTime]
	                  ,[FirstName]
	                  ,[LastName]
	                  ,[activity_desc]
                FROM Timetable
                LEFT JOIN Teachers ON Timetable.teacher_id = Teachers.teacher_id
                LEFT JOIN Activities ON Timetable.activity_id = Activities.activity_id";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int activityId = (int)reader["activity_id"];
                string activityDescription = (string)reader["activity_desc"];

                string firstName = reader["FirstName"] == DBNull.Value ? null : (string)reader["FirstName"];
                string lastName = reader["LastName"] == DBNull.Value ? null : (string)reader["LastName"];

                DateTime date = (DateTime)reader["Date"];
                int startTime = (int)reader["StartTime"];
                int endTime = (int)reader["EndTime"];

                // if we already found this activity before, we should only add
                // the supervisor to the list. otherwise we should add the activity
                // as well.
                bool foundExisting = false;
                foreach (SomerenModel.TimetableActivity otherSlot in timetable) {
                    if (otherSlot.getActivityId() == activityId)
                    {
                        otherSlot.addSupervisor(firstName, lastName);
                        foundExisting = true;
                        break;
                    }
                }

                if (foundExisting)
                {
                    // skip this record
                    continue;
                }

                SomerenModel.TimetableActivity slot = new SomerenModel.TimetableActivity();
                slot.setActivityId(activityId);
                slot.setActivityDescription(activityDescription);
                slot.setSlot(date, startTime, endTime);
                slot.addSupervisor(firstName, lastName);

                timetable.Add(slot);
            }

            reader.Close();
            connection.Close();

            return timetable;
        }

        public static List<SomerenModel.Activities> DB_getActivities()
        {
            // make a sql connection
            SqlConnection connection = openConnectionDB();
            // make a list to store data from DB into it
            List<SomerenModel.Activities> activityList = new List<SomerenModel.Activities>();
            // sql query
            string sqlQuery = "SELECT activity_id, activity_desc, numberofStudents, numberofSupervisors " +
                "FROM Activities";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();

            // read data from DB
            while (reader.Read())
            {
                SomerenModel.Activities activities = new SomerenModel.Activities();

                activities.setId((int)reader["activity_id"]);
                activities.setActivity_desc((string)reader["activity_desc"]);
                activities.setNumOfStudents((int)reader["numberofStudents"]);
                activities.setNumOfSupervisors((int)reader["numberofSupervisors"]);
                activityList.Add(activities);
            }
            // close all connections
            reader.Close();
            connection.Close();


            return activityList;
        }

        public static void DB_addActivity(SomerenModel.Activities newActivity)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for inserting new data to the DB
            string sqlQuery = "INSERT INTO Activities(activity_desc, numberofStudents, numberofSupervisors) VALUES(@activity_desc, @numberofStudents, @numberofSupervisors)";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@activity_desc", newActivity.getActivity_desc());
            command.Parameters.AddWithValue("@numberofStudents", newActivity.getNumOfStudents());
            command.Parameters.AddWithValue("@numberofSupervisors", newActivity.getNumOfSupervisors());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();
        }

        public static void DB_uppdateActivity(SomerenModel.Activities newActivity)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for updating data of the DB
            string sqlQuery = "UPDATE Activities SET activity_desc = @activity_desc, " +
                "numberofStudents = @numberofStudents, numberofSupervisors= @numberofSupervisors " +
                "WHERE activity_id = @activity_id ";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@activity_id", newActivity.getId());
            command.Parameters.AddWithValue("@activity_desc", newActivity.getActivity_desc());
            command.Parameters.AddWithValue("@numberofStudents", newActivity.getNumOfStudents());
            command.Parameters.AddWithValue("@numberofSupervisors", newActivity.getNumOfSupervisors());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();
        }

        public static void DB_deleteActivity(SomerenModel.Activities newActivity)
        {
            // make a sql connection 
            SqlConnection connection = openConnectionDB();

            // the sql query for deleting data from DB
            string sqlQuery = "DELETE FROM Activities WHERE activity_id = @activity_id";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // execute queries
            command.Parameters.AddWithValue("@activity_id", newActivity.getId());
            command.ExecuteNonQuery();

            // close the connection
            connection.Close();

        }





    }
}