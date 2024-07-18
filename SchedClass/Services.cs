using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Services
    {
        private ScheduleData scheduleData;

        public Services()
        {
            scheduleData = new ScheduleData();
     
        }

        public List<Schedule> GetSchedules()
        {
            return scheduleData.GetSchedules();
        }

        //public List<Schedule> GetSchedulesByDay(string inputDay)
        //{
        //    return _dataServices.schedules.Where(schedule => schedule.Day == inputDay).ToList();
        //}

        public bool AddSchedule(string Class, string Day, string Subject, string Time, string Professor)
        {
            return scheduleData.AddSchedules(Class, Day, Subject, Time, Professor);
        }

        //public void AddSchedule(Schedule schedule)
        //{
        //    _dataServices.AddSchedule(schedule);
        //}

        //public void DeleteSchedule(Schedule deleteschedule)
        //{
        //    _dataServices.DeleteSchedule(deleteschedule);
        //}

        public bool DeleteSchedule(string Class, string day, string Subject, string Professor)
        {
            return scheduleData.DeleteSchedules(Class, day, Subject, Professor);
        }


    }
}