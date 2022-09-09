using API.src.Core.Errors;
using API.src.Domain.RealEstate.Entities.Aggregates;
using API.src.Domain.RealState.Application;
using API.src.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API.src.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateImagesController : ControllerBase
    {
        private readonly IRealEstateImagesService ImagesService;

        public RealStateImagesController(IRealEstateImagesService service)
        {
            this.ImagesService = service;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddImages([Required] List<IFormFile> images, int id)
        {
            if (images.Count == 0) return BadRequest("nao atingiu o minimo");

            var converter = new FormFileImageConverter(new RealEstateImages());
            var newImages = converter.fromList(images);

            try
            {
                var create = await ImagesService.AddImages(newImages, id);
                return Created("AddedImages", create);
            }
            catch (TypeNotFound e)
            {
                return NotFound(e.Message);
            }
            catch
            {
                return Problem();
            }

        }
    }
}
