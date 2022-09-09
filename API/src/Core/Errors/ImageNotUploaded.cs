using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Core.Errors
{
    public class ImageNotUploaded : Exception
    {
        public ImageNotUploaded() { }
        public ImageNotUploaded(string message) : base(message) { }
        public ImageNotUploaded(string message, Exception inner) : base(message, inner) { }
        public static ImageNotUploaded Default() => new ImageNotUploaded("A imagem não foi armazenada :(");
    }
}
