using BusinessLayer;
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
            Services services = new Services();
            List<Schedule> schedules = services.GetSchedules();

            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(">>>>>>>>BSIT 2-1 CLASS SCHEDULE MANAGEMENT SYSTEM<<<<<<<<");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Enter a number: ");
            Console.WriteLine("1. Display Schedule ");
            Console.WriteLine("2. Add Schedule ");
            Console.WriteLine("3. Delete Schedule ");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            if (choice == 1)
            {
                foreach (var schedule in schedules)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Class: {schedule.Class},\n Day: {schedule.Day},\n Subject: {schedule.Subject},\n Time: {schedule.Time},\n Professor: {schedule.Professor}");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter Class: ");
                string classInput = Console.ReadLine();

                Console.WriteLine("Enter Day: ");
                string dayInput = Console.ReadLine();

                Console.WriteLine("Enter Subject: ");
                string subjectInput = Console.ReadLine();

                Console.WriteLine("Enter Time: ");
                string timeInput = Console.ReadLine();

                Console.WriteLine("Enter Professor: ");
                string professorInput = Console.ReadLine();

                bool result = services.AddSchedule(classInput, dayInput, subjectInput, timeInput, professorInput);

                if (result)
                {
                    Console.WriteLine("Schedule added successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to add schedule.");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter Class: ");
                string classInput = Console.ReadLine();

                Console.WriteLine("Enter Subject: ");
                string subjectInput = Console.ReadLine();

                Console.WriteLine("Enter Professor: ");
                string professorInput = Console.ReadLine();

                // Call the DeleteSchedule method with the correct parameters
                bool result = services.DeleteSchedule(classInput, subjectInput, professorInput);

                if (result)
                {
                    Console.WriteLine("Schedule deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to delete schedule. No matching schedule found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
