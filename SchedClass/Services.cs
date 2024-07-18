using DataLayer;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Services
    {
        private ScheduleData scheduleData;


        private readonly DataServices _dataServices;

        public Services()
        {
            scheduleData = new ScheduleData();
            _dataServices = new DataServices();
        }

        public List<Schedule> GetSchedules()
        {
            return scheduleData.GetSchedules();
        }

        public List<Schedule> GetSchedulesByDay(string inputDay)
        {
            return _dataServices.schedules.Where(schedule => schedule.Day == inputDay).ToList();
        }

        public void AddSchedule(Schedule schedule)
        {
            _dataServices.AddSchedule(schedule);
        }

        public void DeleteSchedule(Schedule deleteschedule)
        {
            _dataServices.DeleteSchedule(deleteschedule);
        }

        public void UpdateSchedule(Schedule updatedSchedule)
        {
            _dataServices.UpdateSchedule(updatedSchedule);
        }
    }
}
