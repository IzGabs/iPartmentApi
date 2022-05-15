
using API.src.Core.Errors;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.src.Controllers.Announcement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {

        protected IAnnouncementService service;

        public AnnouncementController(IAnnouncementService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(int idRealEstate, int idAdvertiser, AnnouncementValueObject announcement)
        {
            try
            {
                var create = await service.Create(idRealEstate, idAdvertiser, announcement);

                return CreatedAtAction("Created", new { id = create.ID });
            }
            catch (TypeNotFound nf)
            {
                return NotFound(nf.Message);
            }
            catch {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<int>> Create()
        {
          
        }
    }
}
