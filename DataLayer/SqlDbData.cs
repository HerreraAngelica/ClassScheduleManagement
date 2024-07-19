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
        string connectionString //= "Data Source=ANGELICA\\SQLEXPRESS02; Initial Catalog=ClassScheduleManagementSystem; Integrated Security=True;";
        = "Server=tcp:20.2.208.97,1433;Database=ClassScheduleManagementSystem; User Id=sa; Password=Angge10022003";
            SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Schedule> GetSchedules()
        {
            string selectStatement = "SELECT * FROM Class";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> sched = new List<Schedule>();

            while (reader.Read())
            {
                string Class = reader["Class"].ToString();
                string Day = reader["Day"].ToString();
                string Subject = reader["Subject"].ToString();
                string Time = reader["Time"].ToString();
                string Professor = reader["Professor"].ToString();

                Schedule readUser = new Schedule
                {
                    Class = Class,
                    Day = Day,
                    Subject = Subject,
                    Time = Time,
                    Professor = Professor
                };

                sched.Add(readUser);
            }

            sqlConnection.Close();
            return sched;
        }

        public void AddSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            string insertStatement = "INSERT INTO Class (Class, Day, Subject, Time, Professor) VALUES (@Class, @Day, @Subject, @Time, @Professor)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Class", Class);
            insertCommand.Parameters.AddWithValue("@Day", Day);
            insertCommand.Parameters.AddWithValue("@Subject", Subject);
            insertCommand.Parameters.AddWithValue("@Time", Time);
            insertCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteSchedule(string Class, string Subject, string Professor)
        {
            string deleteStatement = "DELETE FROM Class WHERE Class = @Class AND Subject = @Subject AND Professor = @Professor";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@Class", Class);
            deleteCommand.Parameters.AddWithValue("@Subject", Subject);
            deleteCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();
            deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Schedule> GetSchedulesForDay(string Day, string Subject, string Professor)
        {
            string selectStatement = "SELECT * FROM Class WHERE Day = @Day AND Subject = @Subject AND Professor = @Professor";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            selectCommand.Parameters.AddWithValue("@Day", Day);
            selectCommand.Parameters.AddWithValue("@Subject", Subject);
            selectCommand.Parameters.AddWithValue("@Professor", Professor);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Schedule> schedules = new List<Schedule>();

            while (reader.Read())
            {
                Schedule schedule = new Schedule
                {
                    Class = reader["Class"].ToString(),
                    Day = reader["Day"].ToString(),
                    Subject = reader["Subject"].ToString(),
                    Time = reader["Time"].ToString(),
                    Professor = reader["Professor"].ToString()
                };
                schedules.Add(schedule);
            }

            sqlConnection.Close();
            return schedules;
        }

        public void UpdateSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            string updateStatement = "UPDATE Class SET Day = @Day, Subject = @Subject, Time = @Time, Professor = @Professor WHERE Class = @Class";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Class", Class);
            updateCommand.Parameters.AddWithValue("@Day", Day);
            updateCommand.Parameters.AddWithValue("@Subject", Subject);
            updateCommand.Parameters.AddWithValue("@Time", Time);
            updateCommand.Parameters.AddWithValue("@Professor", Professor);

            try
            {
                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
