
using API.src.Controllers.ViewModels;
using API.src.Core.Errors;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary.Entities;
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
        [Route("Sell")]
        public async Task<ActionResult<int>> CreateSell(AnnouncementViewModel<AnnouncementSellMonetary> vm)
        {
            try
            {
                var create = await service.Create(vm.idRealEstate, vm.idAdvertiser, vm.announcement, vm.monetary, AnnouncementTypeEnum.Sell);

                return CreatedAtAction("Created", new { id = create.ID });
            }
            catch (TypeNotFound nf)
            {
                return NotFound(nf.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Rent")]
        public async Task<ActionResult<int>> CreateRent(AnnouncementViewModel<AnnouncementRentMonetary> vm)
        {
            try
            {
                var create = await service.Create(vm.idRealEstate, vm.idAdvertiser, vm.announcement, vm.monetary, AnnouncementTypeEnum.Rent);

                return CreatedAtAction("Created", new { id = create.ID });
            }
            catch (TypeNotFound nf)
            {
                return NotFound(nf.Message);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult> SearchFromFilter()
        {

            return null;

        }
    }
}
