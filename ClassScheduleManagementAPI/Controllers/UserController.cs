using BusinessLayer;
using ClassScheduleManagementAPI;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;

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

        [HttpGet("classSchedules")]
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

        [HttpDelete("DeleteSchedule")]
        public IActionResult DeleteSchedule([FromQuery] string className, [FromQuery] string subject, [FromQuery] string professor)
        {
            var result = _services.DeleteSchedule(className, subject, professor);

            if (result)
            {
                return Ok(new { Success = true });
            }
            else
            {
                return NotFound(new { Success = false, Message = "Schedule not found" });
            }
        }

        [HttpPatch("UpdateSchedule")]
        public IActionResult UpdateSchedule([FromBody] ClassSchedule sched)
        {
            var result = _services.UpdateSchedule(sched.Class, sched.Day, sched.Subject, sched.Time, sched.Professor);

            if (result)
            {
                return Ok(new { Success = true });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Failed to update schedule" });
            }
        }

        [HttpPost("AddSchedule")]
        public IActionResult AddSchedule([FromBody] ClassSchedule sched)
        {
            var result = _services.AddSchedule(sched.Class, sched.Day, sched.Subject, sched.Time, sched.Professor);

            if (result)
            {
                return Ok(new { Success = true });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "Failed to add schedule" });
            }
        }
    }
}
