
using API.src.Domain.RealState.Entities;
using API.src.Controllers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.src.Domain.RealEstate.Entities.Aggregates;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using API.src.Domain.Images;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateService
    {
        Task<bool> Update(RealEstateBase body);
        Task<bool> Delete(RealEstateBase body);
        Task<RealEstateBase> Create(RealEstateBase body);

        Task<RealEstateBase> GetByID(int id);
        Task<List<RealEstateBase>> GetList();
    }

    public interface IRealEstateImagesService
    {
        Task<List<ImageReference>> AddImages(List<ImageFile> images, int iDRealEstate);
    }



    public interface IRealEstateCondoService
    {
        Task<RealEstateCondo> Create(RealEstateBase body, int condoId);
        Task<RealEstateCondo> GetByID(int id);
    }
}
