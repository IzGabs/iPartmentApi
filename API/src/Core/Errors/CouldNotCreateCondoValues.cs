using System;

namespace API.src.Core.Errors
{
    public class CouldNotCreateCondoValues : Exception
    {
        public CouldNotCreateCondoValues() { }
        public CouldNotCreateCondoValues(string message) : base(message) { }
        public CouldNotCreateCondoValues(string message, Exception inner) : base(message, inner) { }
        public static CouldNotCreateCondoValues Default() => new CouldNotCreateCondoValues("Não foi possível criar essa localização, verifique o objeto enviado!");
    }
}
