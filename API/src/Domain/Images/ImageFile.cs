using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Images
{
    public class ImageFile
    {
        public ImageReference data { get; set; }
        public byte[] bytes;

        public ImageFile(ImageReference data, byte[] bytes)
        {
            this.data = data;
            this.bytes = bytes;
        }
    }
}
