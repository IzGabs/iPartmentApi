using System;

namespace API.src.Core.Errors
{
    public class TypeNotFound : Exception
    {
        public TypeNotFound() { }
        public TypeNotFound(string message) : base(message) { }
        public TypeNotFound(string message, Exception inner) : base(message, inner) { }
        public static TypeNotFound Default() => new TypeNotFound(" não encontrado!!");
    }
}
