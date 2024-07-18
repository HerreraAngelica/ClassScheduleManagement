using BusinessLayer;
using ClassScheduleManagementAPI;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassSchedManagementAPI.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly Services _services;

        public ScheduleController()
        {
            _services = new Services();
        }

      

        [HttpGet]
        [Route("classSchedules")]
        public IEnumerable<ClassSchedule> GetClassSchedules()
        {
            var schedules = _services.GetSchedules();
            List<ClassSchedule> classSchedules = new List<ClassSchedule>();

            foreach (var item in schedules)
            {
                classSchedules.Add(new ClassSchedule
                {
                    Class = item.Class,
                    Day = item.Day,
                    Subject = item.Subject,
                    Time = item.Time,
                    Professor = item.Professor
                });
            }

            return classSchedules;
        }

        //[HttpGet]
        //[Route("day/{day}")]
        //public IEnumerable<Schedule> GetSchedulesByDay(string day)
        //{
        //    return _services.GetSchedulesByDay(day);
        //}


       [HttpDelete("DeleteSchedule")]
public JsonResult DeleteSchedule(Schedule Sched)
{
    var result = _services.DeleteSchedule(Sched.Class, Sched.Subject, Sched.Day, Sched.Professor);

    return new JsonResult(result);
}

        //[HttpPatch]
        //[Route("update")]
        //public IActionResult UpdateSchedule(Schedule updatedSchedule)
        //{
        //    _services.UpdateSchedule(updatedSchedule);
        //    return Ok(new { Message = $"Schedule updated successfully" });
        //}


        [HttpPost("AddSchedule")]
        public JsonResult AddSchedule(ClassSchedule Sched)
        {
            var result = _services.AddSchedule(Sched.Class, Sched.Day, Sched.Subject, Sched.Time, Sched.Professor);

            return new JsonResult(result);
        }
    }

}
