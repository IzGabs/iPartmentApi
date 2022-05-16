
using API.src.Domain.Images;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateService
    {
        Task<RealEstateBase> Create(RealEstateBase body);
        Task<RealEstateBase> GetByID(int id);
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
