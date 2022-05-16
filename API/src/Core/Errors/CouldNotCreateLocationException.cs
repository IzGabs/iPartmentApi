using System;

namespace API.src.Core.Errors
{
    public class CouldNotCreateLocationException : Exception
    {
        public CouldNotCreateLocationException() { }
        public CouldNotCreateLocationException(string message) : base(message) { }
        public CouldNotCreateLocationException(string message, Exception inner) : base(message, inner) { }

        public static CouldNotCreateLocationException Default() => new CouldNotCreateLocationException("Não foi possível criar essa localização, verifique o objeto enviado!");
    }
}
