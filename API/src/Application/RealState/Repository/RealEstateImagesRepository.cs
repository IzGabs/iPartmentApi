using API.src.Domain.Images;
using API.src.Domain.RealEstate.Entities.Aggregates;
using API.src.Domain.RealState.Application;
using API.src.Domain.RealState.Entities;
using API.src.Infra.Bucket;
using API.src.Infra.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.RealState.Repository
{
    public class RealEstateImagesRepository : IRealEstateImagesRepository
    {

        protected BuildContext context;
        protected BucketOperations bucketOperations;

        public RealEstateImagesRepository(BuildContext context, BucketOperations bucketOperations)
        {
            this.context = context;
            this.bucketOperations = bucketOperations;
        }

        public async Task<List<ImageReference>> AddImages(List<ImageFile> files, RealEstateBase realEstate)
        {
            var returnList = new List<ImageReference>();

            foreach (var image in files)
            {
                var link =bucketOperations.UploadImage(image);

                if (link != null) {
                    image.data.pathToFile = link;

                    var realEstateImage = new RealEstateImages(image.data, realEstate);
                    var added = await context.RealEstateImages.AddAsync(realEstateImage);

                    if(added.State == Microsoft.EntityFrameworkCore.EntityState.Added) returnList.Add(image.data);
                }
            }

            await context.SaveChangesAsync();
            return returnList;
        }
    }
}
