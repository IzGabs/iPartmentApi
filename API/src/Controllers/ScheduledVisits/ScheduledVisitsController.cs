using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Domain.User.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.src.Controllers.ScheduledVisits
{
    public class ScheduledVisitsController : ControllerBase
    {
        private readonly IScheduledVisitsService scheduleService;

        public ScheduledVisitsController(IScheduledVisitsService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<IEnumerable<string>> GetVisitsOfUsers(int id)
        {
            return Ok(scheduleService.GetAllVisitsOfUsers(id));
        }

        [HttpPost]
        public ActionResult PostVisit([FromBody] ScheduledVisitsObject scheduledVisit)
        {
            try
            {
                scheduleService.Add(scheduledVisit);
                return Ok("Visita Agendada!");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
