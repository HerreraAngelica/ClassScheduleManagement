using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BusinessLayer
{
    public class Services
    {
        private SqlDbData scheduleData;

        public Services()
        {
            scheduleData = new SqlDbData();
        }

        public List<Schedule> GetSchedules()
        {
            return scheduleData.GetSchedules();
        }

        public List<Schedule> GetSchedulesByDay(string inputDay)
        {
            return scheduleData.GetSchedulesForDay(inputDay, string.Empty, string.Empty);
        }

        public bool AddSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            try
            {
                scheduleData.AddSchedule(Class, Day, Subject, Time, Professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSchedule(string Class, string Subject, string Professor)
        {
            try
            {
                scheduleData.DeleteSchedule(Class, Subject, Professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            try
            {
                scheduleData.UpdateSchedule(Class, Day, Subject, Time, Professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
