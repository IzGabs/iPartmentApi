using API.src.Domain.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Infra.Bucket
{
    public class BucketOperations
    {
        protected BucketClient bucket;

        private string bucketName;

        public BucketOperations(BucketClient bucket, string bucketName = "iapartment-bucket")
        {
            this.bucket = bucket;
            this.bucketName = bucketName;
        }

        public string UploadImage(ImageFile image) {

            try
            {
                string downloadLink;


                using (var imageBytes = new MemoryStream(image.bytes))
                {


                    var lala = bucket.Client.UploadObject(bucketName, image.data.name, image.data.type, imageBytes);

                    downloadLink = lala.MediaLink;
                }


                return downloadLink;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            return null;
        }
    }
}
