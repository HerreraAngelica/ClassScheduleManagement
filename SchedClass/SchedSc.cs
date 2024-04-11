using System;
using Model;
namespace SchedClass
{
    public class SchedSc
    {
            public static void Main(string[] args)
            {
                void DisplaySchedules(List<Class1> schedules = null)
                {
                    if (schedules == null)
                    {
                        schedules = new List<Class1>();
                    }

                    Console.WriteLine("Class Schedule:");
                    foreach (var schedule in schedules)
                    {
                        Console.WriteLine($"Class: {schedule.Class}");
                        Console.WriteLine($"Day: {schedule.Day}");
                        Console.WriteLine($"Subject: {schedule.Subject}");
                        Console.WriteLine($"Time: {schedule.Time}");
                        Console.WriteLine($"Professor: {schedule.Professor}");
                        Console.WriteLine();
                    }
                }
            }

    }
}
