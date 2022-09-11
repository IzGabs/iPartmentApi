using API.src.Domain.Images;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Helpers
{
    public class FormFileImageConverter
    {

        public ImageReference reference { get; set; }

        public FormFileImageConverter(ImageReference reference)
        {
            this.reference = reference;
        }

        public List<ImageFile> fromList(List<IFormFile> files)
        {
            var imageFiles = new List<ImageFile>();

            foreach (var file in files)
            {
                imageFiles.Add(transformSingle(file));
            }

            return imageFiles;
        }

        public ImageFile transformSingle(IFormFile file)
        {
            var imageReference = reference.fromType(file.ContentType);
            var openStream = file.OpenReadStream();
            byte[] imageBytes = new byte[openStream.Length];

            using (var memoryStream = new MemoryStream())
            {
                openStream.CopyTo(memoryStream);

                openStream.Close();
                openStream.Dispose();

                var meusBytes = memoryStream.ToArray();


                return new ImageFile(imageReference, meusBytes);
            }
        }
    }
}
