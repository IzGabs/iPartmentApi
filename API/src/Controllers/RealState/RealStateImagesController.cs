using API.src.Core.Errors;
using API.src.Domain.Images;
using API.src.Domain.RealEstate.Entities.Aggregates;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
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
        public async Task<ActionResult> AddImages([Required] List<IFormFile> uploadedFiles, int id)
        {
            if (uploadedFiles.Count == 0) return BadRequest();

            var files = new List<ImageFile>();

            foreach (var file in uploadedFiles)
            {
                var imageReference = new RealEstateImages(file.ContentType);
                var openStream = file.OpenReadStream();
                byte[] imageBytes = new byte[openStream.Length];

                using (var memoryStream = new MemoryStream())
                {
                    openStream.CopyTo(memoryStream);

                    openStream.Close();
                    openStream.Dispose();

                    var meusBytes = memoryStream.ToArray();
                    

                    files.Add(new ImageFile(imageReference, meusBytes));
                }
            }

            try
            {
                var create = await ImagesService.AddImages(files, id);
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
