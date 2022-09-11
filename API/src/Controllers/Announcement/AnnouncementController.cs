
using API.src.Controllers.Announcement.ViewModel;
using API.src.Controllers.ViewModels;
using API.src.Core.Errors;
using API.src.Domain.Announcement.Application;
using API.src.Domain.Announcement.Entities;
using API.src.Domain.Monetary.Entities;
using API.src.Infra.ML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
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

                var realEstate = create.RealEstate;

                return CreatedAtAction("Created",create.ID);
            }
            catch (TypeNotFound nf) { return NotFound(nf.Message); }
            catch (HttpRequestException e) { return Problem(e.Message); }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Authorize]
        [Route("Rent")]
        public async Task<ActionResult<int>> CreateRent(AnnouncementViewModel<AnnouncementRentMonetary> vm)
        {
            try
            {
                var create = await service.Create(vm.idRealEstate, vm.idAdvertiser, vm.announcement, vm.monetary, AnnouncementTypeEnum.Rent);

                var realEstate = create.RealEstate;

                return CreatedAtAction("Created", create.ID);
            }
            catch (TypeNotFound nf) { return NotFound(nf.Message); }
            catch (HttpRequestException e) { return Problem(e.Message); }
            catch { return BadRequest(); }
        }

     


        [HttpGet]
        [Route("City/{city}")]
        public async Task<ActionResult<List<AnnouncementResponseViewModel>>> SearchFromCity([Required] string city)
        {
            var result = await service.GetByCity(city);
            var convertedResult = result.ConvertAll(x => new AnnouncementResponseViewModel(x));
            return convertedResult.Count > 0 ? Ok(convertedResult) : NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);

                return Ok();
            }
            catch (TypeNotFound e) { return NotFound(); }
            catch (Exception e) { return Problem(e.Message); }
        }



    }
}
