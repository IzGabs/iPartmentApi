using API.src.Domain.ScheduledVisits.Application;
using API.src.Domain.ScheduledVisits.Entities.ValueObject;
using API.src.Infra.Firebase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API.src.Controllers.ScheduledVisits
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledVisitsController : ControllerBase
    {
        private readonly IScheduledVisitsService scheduleService;

        public ScheduledVisitsController(IScheduledVisitsService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet("user/{userID}")]
        [Authorize]
        public ActionResult<IEnumerable<ScheduledVisitsObject>> GetVisitsOfUsers(int userID) => Ok(scheduleService.GetAllVisitsOfUsers(userID));

        [HttpGet("agent/{agentId}")]
        [Authorize]
        public ActionResult<IEnumerable<ScheduledVisitsObject>> GetVisitsOfAgent(int agentId) => Ok(scheduleService.GetAllVisitsOfAgent(agentId));

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<IEnumerable<ScheduledVisitsObject>> GetByID(int id) => Ok(scheduleService.GetById(id));

        [HttpGet("scheduled/{id}")]
        [Authorize]
        public ActionResult<IEnumerable<ScheduledVisitsObject>> GetAllScheduledVisitsFromAnnounce(int id) => Ok(scheduleService.GetAllScheduledVisitsFromAnnounce(id));


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create( ScheduledVisitDTO scheduledVisit)
        {
            try
            {


                var saveVisit  = await scheduleService.Add(scheduledVisit);

                if (!saveVisit) return Conflict("Nao foi possivel agendar visita");

                return Ok("Visita Agendada!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
