using System.Collections.Generic;
using Model;
using DataLayer;

namespace BusinessLayer
{
    public class Services
    {
        DataServices dataServices = new DataServices();
        public List<Schedule> GetSchedules()
        {
            return dataServices.schedules;
        }

        public List<Schedule> GetSchedulesByDay(string inputDay)
        {
            List<Schedule> found = new List<Schedule>();
            foreach (Schedule schedule in dataServices.schedules)
            {
                if (schedule.Day == inputDay)
                {
                    found.Add(schedule);
                }
            }
            return found;
        }
    }

}
