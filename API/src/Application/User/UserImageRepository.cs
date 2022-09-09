using API.Domain.User;
using API.src.Core.Errors;
using API.src.Domain.Images;
using API.src.Domain.User;
using API.src.Domain.User.Application;
using API.src.Infra.Bucket;
using API.src.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.User
{
    public class UserImageRepository : IUserImageRepository
    {
        protected BuildContext context;
        protected BucketOperations bucketOperations;

        public UserImageRepository(BuildContext context, BucketOperations bucketOperations)
        {
            this.context = context;
            this.bucketOperations = bucketOperations;
        }

        public async Task<UsersImages> InsertSingle(ImageFile image, UserObject user)
        {
            var link = bucketOperations.UploadImage(image) ?? throw ImageNotUploaded.Default();

            image.data.pathToFile = link;
            var userImage = new UsersImages(image.data, user);

            var requestInsert = await context.UsersImages.AddAsync(userImage);

            if (requestInsert.State == EntityState.Added) return userImage;

            return null;
        }

        public async Task<AgentDocumentImage?> InsertAgentImage(ImageFile image, UserObject user)
        {
            var link = bucketOperations.UploadImage(image) ?? throw ImageNotUploaded.Default();

            image.data.pathToFile = link;
            var userImage = new AgentDocumentImage(image.data, user);

            var requestInsert = await context.AgentImages.AddAsync(userImage);

            if (requestInsert.State == EntityState.Added) return userImage;

            return null;
        }
    }
}
