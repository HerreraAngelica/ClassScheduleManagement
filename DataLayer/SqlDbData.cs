using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SqlDbData
    {
        static string connectionString = "Data Source=ANGELICA\\SQLEXPRESS02; Initial Catalog=ClassScheduleManagementSystem; Integrated Security=True;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Connect()
        {
            sqlConnection.Open();
        }

        public static List<Schedule> GetSchedules()
        {
            string selectStatement = "SELECT Class, Day FROM Class";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> sched = new List<Schedule>();

            while (reader.Read())
            {
                string Class = reader["Class"].ToString();
                string Day = reader["Day"].ToString();

                Schedule readUser = new Schedule();
                readUser.Class = Class;
                readUser.Day = Day;

                sched.Add(readUser);
            }

            sqlConnection.Close();
            return sched;
        }

        public static List<Schedule> GetSchedulesForDay(string day)
        {
            string selectStatement = "SELECT Class, Day FROM Class WHERE Day = @Day";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            selectCommand.Parameters.AddWithValue("@Day", day);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> sched = new List<Schedule>();

            while (reader.Read())
            {
                string Class = reader["Class"].ToString();
                string Day = reader["Day"].ToString();

                Schedule readUser = new Schedule();
                readUser.Class = Class;
                readUser.Day = Day;

                sched.Add(readUser);
            }

            sqlConnection.Close();
            return sched;
        }

        public static int AddSchedule(string Class, string Day)
        {
            int success;

            string insertStatement = "INSERT INTO Class (Class, Day) VALUES (@Class, @Day)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Class", Class);
            insertCommand.Parameters.AddWithValue("@Day", Day);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public static void UpdateSchedule(string Class, string Day)
        {
            string updateStatement = "UPDATE Class SET Day = @Day WHERE Class = @Class";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Class", Class);
            updateCommand.Parameters.AddWithValue("@Day", Day);
            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteSchedule(string Class)
        {
            string deleteStatement = "DELETE FROM Class WHERE Class = @Class";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@Class", Class);
            sqlConnection.Open();

            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
