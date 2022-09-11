
using API.src.Controllers.RealState.ViewModel;
using API.src.Domain.Announcement.Application;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.ML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.RealState
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {
        private readonly IRealEstateService _service;
        private readonly IRealEstateCondoService _condoService;
        protected IMLPredictService predict;

        public RealStateController(IRealEstateService service, IRealEstateCondoService condoService, IMLPredictService predict)
        {
            _service = service;
            _condoService = condoService;
            this.predict = predict;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RealEstateBase>> Details(int id)
        { 
            var request = await _service.GetByID(id);
            return request == null ? NotFound() : request;
        }

        [HttpGet]
        public async Task<ActionResult<List<RealEstateBase>>> GetAll()
        {

            return Ok(await _service.GetAll());
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RealEstateCreateSuccess>> Create(CreateViewModel body)
        {
            if (body.realEstate.isCondoRequired()) return BadRequest("Esse tipo de imóvel requer um condominio");
            if (body.realEstate.ID != null) return BadRequest("A ID é gerada automaticamente");

            try
            {
                RealEstateBase createdObject = null;
                var predictedValue = 0.0;
                 
                if (body.condoId != null) { createdObject = await _condoService.Create(body.realEstate, body.condoId ?? 0); }
                else { createdObject = await _service.Create(body.realEstate); }

                if (createdObject == null) return BadRequest();

                if (body.type == src.Domain.Announcement.Entities.AnnouncementTypeEnum.Rent)
                {
                    var rentDTO = new PredictRentDTO(
                       createdObject.squareMeters,
                       createdObject.Rooms,
                       createdObject.Bathrooms,
                       createdObject.Garage ? 1 : 0,
                       body.IPTU
                       );

                    predictedValue = await predict.Rent(rentDTO);
                   
                }
                else
                {
                     var sellDto = new PredictSellDTO(2000, 4,
                        createdObject.Rooms + createdObject.Bathrooms,
                        createdObject.Rooms, 10000);

                    predictedValue = await predict.Sell(sellDto);
                    
                }

                return Created("CreateRealState", new RealEstateCreateSuccess(createdObject.ID ?? 0, predictedValue));

            }
            catch (Exception e) { return BadRequest(e.Message); }
        }


    }
}


