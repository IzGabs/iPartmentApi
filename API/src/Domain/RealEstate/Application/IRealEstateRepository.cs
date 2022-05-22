using API.src.Domain.Images;
using API.src.Domain.RealState.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateRepository
    {
        Task<RealEstateBase> Create(RealEstateBase body);
        Task<RealEstateBase> Get(int id);
    }

    public interface IRealEstateImagesRepository
    {
        Task<List<ImageReference>> AddImages(List<ImageFile> files, RealEstateBase realEstate);
    }



    public interface IRealEstateCondoRepository
    {
        Task<RealEstateCondo> Create(RealEstateCondo body);
        Task<RealEstateCondo> Get(int id);
    }
}