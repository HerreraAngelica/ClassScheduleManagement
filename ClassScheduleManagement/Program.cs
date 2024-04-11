using System;
using SchedClass;
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

        public static void DisplayScheduleForDay(string day)
        {

            string[] classes = { "BSIT 2-1", "BSIT 2-1", "BSIT 2-1", "BSIT 2-1", "BSIT 2-1", "BSIT 2-1", "BSIT 2-1", "BSIT 2-1" };
            string[] days = { "Monday", "Monday", "Tuesday", "Tuesday", "Wednesday", "Wednesday", "Saturday", "Saturday" };
            string[] subjects = { "PATHFIT", "Quantitative Methods with Modeling and Simulation", "Information Management", "Network Administration", "Free Elective", "Human Computer Interaction", "Object Oriented Programming", "Integrative Programming and Technologies 1" };
            string[] times = { "4:00-6:00 PM", "6:00-9:00 PM", "7:30-12:30 PM", "5:00-8:00 PM", "2:00-5:00 PM", "5:00-8:00 PM", "7:30-12:30 PM", "2:00-7:00 PM" };
            string[] professors = { "Ms. Noemi Apostol", "Mr. Rowell Marquina", "Mr. Michael Angelo Miguel", "Mr. Aaron Atienza", "Ms. Abigail Verterra", "Mr. Ramon Almazan", "Mr. Ed Dela Cruz", "Ms. Indaleen Quinsayas" };

            Console.WriteLine($"Schedule for {day}:");
            bool foundSchedule = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Class: {classes[i]}, Day: {days[i]}, Subject: {subjects[i]}, Time: {times[i]}, Professor: {professors[i]}");
                    foundSchedule = true;
                }
            }

            if (!foundSchedule)
            {
                Console.WriteLine("No classes scheduled for the specified day.");
            }
        }
    }
}
