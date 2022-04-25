using System;

namespace API.src.Core.Errors
{
    public class CouldNotCreateRealStateValues : Exception
    {
        public CouldNotCreateRealStateValues() { }
        public CouldNotCreateRealStateValues(string message) : base(message) { }
        public CouldNotCreateRealStateValues(string message, Exception inner) : base(message, inner) { }
        public static CouldNotCreateRealStateValues Default() => new CouldNotCreateRealStateValues("Não foi possível criar essa localização, verifique o objeto enviado!");
    }
}
