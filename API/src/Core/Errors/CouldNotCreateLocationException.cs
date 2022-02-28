using System;

namespace API.src.Core.Errors
{
    public class CouldNotCreateLocationException : Exception
    {
        public CouldNotCreateLocationException() { }
        public CouldNotCreateLocationException(string message)  : base(message) { }
        public CouldNotCreateLocationException(string message, Exception inner) : base(message, inner){}
    }
}
