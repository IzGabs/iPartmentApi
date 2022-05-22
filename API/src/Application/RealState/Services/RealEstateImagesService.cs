using API.src.Core.Errors;
using API.src.Domain.Images;
using API.src.Domain.RealState.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Application.RealState.Services
{
    public class RealEstateImagesService : IRealEstateImagesService
    {
        protected IRealEstateImagesRepository repository;
        protected IRealEstateService service;

        public RealEstateImagesService(IRealEstateImagesRepository repository, IRealEstateService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<ImageReference>> AddImages(List<ImageFile> imageReferences, int iDRealEstate)
        {
            var realEstate = await service.GetByID(iDRealEstate) ?? throw new TypeNotFound("RealEstate no found");

            return await repository.AddImages(imageReferences, realEstate);
        }
    }
}
