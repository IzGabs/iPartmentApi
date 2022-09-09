using API.src.Domain.Images;
using API.src.Domain.RealEstate;
using API.src.Domain.RealState.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateRepository
    {
        Task<RealEstateBase> Create(RealEstateBase body);
        Task<RealEstateBase> Get(int id);
        Task<List<RealEstateBase>> GetAll();
    }

    public interface IRealEstateImagesRepository
    {
        Task<List<ImageReference>> AddImages(List<ImageFile> files, RealEstateBase realEstate);
    }
}