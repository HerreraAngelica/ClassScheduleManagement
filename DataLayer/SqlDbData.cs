using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DataLayer
{
    public class SqlDbData
    {
        private string connectionString = "Data Source=ANGELICA\\SQLEXPRESS02; Initial Catalog=ClassScheduleManagementSystem; Integrated Security=True;";
        private readonly EmailService _emailService;

        public SqlDbData()
        {
            _emailService = new EmailService();
        }

        public List<Schedule> GetSchedules()
        {
            List<Schedule> sched = new List<Schedule>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT * FROM Class";
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
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

                            sched.Add(schedule);
                        }
                    }
                }
            }

            return sched;
        }

        public int AddSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO Class (Class, Day, Subject, Time, Professor) VALUES (@Class, @Day, @Subject, @Time, @Professor)";
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection))
                {
                    insertCommand.Parameters.Add("@Class", System.Data.SqlDbType.NVarChar).Value = Class;
                    insertCommand.Parameters.Add("@Day", System.Data.SqlDbType.NVarChar).Value = Day;
                    insertCommand.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject;
                    insertCommand.Parameters.Add("@Time", System.Data.SqlDbType.NVarChar).Value = Time;
                    insertCommand.Parameters.Add("@Professor", System.Data.SqlDbType.NVarChar).Value = Professor;

                    sqlConnection.Open();
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (rowsAffected > 0) 
                    {
                        _emailService.SendEmail("angelicalherrera@gmail.com", "Schedule Added", $"Schedule updated: {Class}, {Subject}");
                    }
                    return rowsAffected;
                }
            }
        }

        public int DeleteSchedule(string Class, string Subject, string Professor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM Class WHERE Class = @Class AND Subject = @Subject AND Professor = @Professor";
                using (SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection))
                {
                    deleteCommand.Parameters.Add("@Class", System.Data.SqlDbType.NVarChar).Value = Class;
                    deleteCommand.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject;
                    deleteCommand.Parameters.Add("@Professor", System.Data.SqlDbType.NVarChar).Value = Professor;

                    sqlConnection.Open();
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (rowsAffected > 0) 
                    {
                        _emailService.SendEmail("angelicalherrera@gmail.com", "Schedule Deleted", $"Schedule deleted: {Class}, {Subject}");
                    }
                    return rowsAffected;
                }
            }
        }

        public List<Schedule> GetSchedulesForDay(string Day, string Subject, string Professor)
        {
            List<Schedule> schedules = new List<Schedule>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT * FROM Class WHERE Day = @Day AND Subject = @Subject AND Professor = @Professor";
                using (SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection))
                {
                    selectCommand.Parameters.Add("@Day", System.Data.SqlDbType.NVarChar).Value = Day;
                    selectCommand.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject;
                    selectCommand.Parameters.Add("@Professor", System.Data.SqlDbType.NVarChar).Value = Professor;

                    sqlConnection.Open();
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
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
                    }
                }
            }

            return schedules;
        }

        public int UpdateSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE Class SET Day = @Day, Subject = @Subject, Time = @Time, Professor = @Professor WHERE Class = @Class";
                using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
                {
                    updateCommand.Parameters.Add("@Class", System.Data.SqlDbType.NVarChar).Value = Class;
                    updateCommand.Parameters.Add("@Day", System.Data.SqlDbType.NVarChar).Value = Day;
                    updateCommand.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject;
                    updateCommand.Parameters.Add("@Time", System.Data.SqlDbType.NVarChar).Value = Time;
                    updateCommand.Parameters.Add("@Professor", System.Data.SqlDbType.NVarChar).Value = Professor;

                    sqlConnection.Open();
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (rowsAffected > 0) 
                    {
                        _emailService.SendEmail("angelicalherrera@gmail.com", "Schedule Updated", $"Schedule updated: {Class}, {Subject}");
                    }
                    return rowsAffected;
                }
            }
        }
    }
}
