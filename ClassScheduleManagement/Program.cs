using System;
using System.Collections.Generic;
using Model;
using BusinessLayer;

namespace ClassScheduleManagement
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.Write("Enter a Day: ");
            string day = Console.ReadLine();
            DisplayScheduleForDay(day);
        }

        public static void DisplayScheduleForDay(string stringDay)
        {
            Services businessServices = new Services();
            List<Schedule> foundSchedules = businessServices.GetSchedulesByDay(stringDay);

            if (foundSchedules.Count > 0)
            {
                Console.WriteLine($"Found schedule for {stringDay}(s):");

                for (int i = 0; i < foundSchedules.Count; i++)
                {
                    Console.WriteLine($"Class: {foundSchedules[i].Class}");
                    Console.WriteLine($"Day: {foundSchedules[i].Day}");
                    Console.WriteLine($"Subject: {foundSchedules[i].Subject}");
                    Console.WriteLine($"Time: {foundSchedules[i].Time}");
                    Console.WriteLine($"Professor: {foundSchedules[i].Professor}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No classes scheduled for the specified day.");

            }
        }
    }
}
