using Model;

using System.Collections.Generic;
using System.ComponentModel;

namespace DataLayer
{
    public class DataServices
    {

        public List<Schedule> schedules = new List<Schedule>();

        public DataServices()
        {
            Schedule sched1 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Monday",
                Subject = "PATHFIT",
                Time = "4:00-6:00 PM",
                Professor = "Ms. Noemi Apostol"

            };


            Schedule sched2 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Monday",
                Subject = "Quantitative Methods with Modeling and Simulation",
                Time = "6:00-9:00 PM",
                Professor = "Mr. Rowell Marquina"
            };
            Schedule sched3 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Tuesday",
                Subject = "Information Management",
                Time = "7:30-12:30 PM",
                Professor = "Mr. Michael Angelo Miguel"
            };
            Schedule sched4 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Tuesday",
                Subject = "Network Administration",
                Time = "5:00-8:00 PM",
                Professor = "Mr. Aaron Atienza"
            };
            Schedule sched5 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Wednesday",
                Subject = "Free Elective",
                Time = "5:00-8:00 PM",
                Professor = "Ms. Abigail Verterra"
            };
            Schedule sched6 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Wednesday",
                Subject = "Human Computer Interaction",
                Time = "4:00-6:00 PM",
                Professor = "Mr. Ramon Almazan"
            };
            Schedule sched7 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Saturday",
                Subject = "Object Oriented Programming",
                Time = "07:30-12:30 AM",
                Professor = "Mr. Ed Dela Cruz"
            };
            Schedule sched8 = new Schedule
            {
                Class = "BSIT 2-1",
                Day = "Saturday",
                Subject = "Integrative Programming and Technologies 1",
                Time = "2:00-7:00 PM",
                Professor = "Ms. Indaleen Quinsayas"
            };

            schedules.Add(sched1);
            schedules.Add(sched2);
            schedules.Add(sched3);
            schedules.Add(sched4);
            schedules.Add(sched5);
            schedules.Add(sched6);
            schedules.Add(sched7);
            schedules.Add(sched8);
        }

    }
}
