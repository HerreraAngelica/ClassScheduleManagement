using System;
using System.Collections.Generic;
using Model;
using DataLayer;

namespace ClassScheduleManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            // SqlDbData.AddSchedule("Math", "Sunday");

            SqlDbData.UpdateSchedule("Math", "Saturday");

            // SqlDbData.DeleteSchedule("Math");

           
            Console.Write("Enter a Day: ");
            string day = Console.ReadLine();
            DisplayScheduleForDay(day);

           
            Console.WriteLine();

            
            GetSchedules();
        }

        public static void GetSchedules()
        {
            List<Schedule> schedulesFromDB = SqlDbData.GetSchedules();
            HashSet<string> uniqueSchedules = new HashSet<string>();

            foreach (var item in schedulesFromDB)
            {
                string scheduleEntry = $"Class: {item.Class}, Day: {item.Day}";
                if (uniqueSchedules.Add(scheduleEntry)) 
                {
                    Console.WriteLine(scheduleEntry);
                }
            }
        }

        public static void DisplayScheduleForDay(string day)
        {
            List<Schedule> schedulesForDay = SqlDbData.GetSchedulesForDay(day);

            if (schedulesForDay.Count == 0)
            {
                Console.WriteLine($"No schedules found for {day}");
            }
            else
            {
                HashSet<string> uniqueSchedules = new HashSet<string>();
                foreach (var item in schedulesForDay)
                {
                    string scheduleEntry = $"Class: {item.Class}, Day: {item.Day}";
                    if (uniqueSchedules.Add(scheduleEntry)) 
                    {
                        Console.WriteLine(scheduleEntry);
                    }
                }
            }
        }
    }
}
