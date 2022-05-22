using System;

namespace API.src.Core.Errors
{
    public class CondoNotFoundException : Exception
    {
        public CondoNotFoundException() { }
        public CondoNotFoundException(string message) : base(message) { }
        public CondoNotFoundException(string message, Exception inner) : base(message, inner) { }
        public static CondoNotFoundException Default() => new CondoNotFoundException("Condomínio não encontrado!!");
    }
}
