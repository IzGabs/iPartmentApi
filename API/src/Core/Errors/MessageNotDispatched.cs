using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Core.Errors
{
    public class MessageNotDispatched : Exception
    {
        public MessageNotDispatched() { }
        public MessageNotDispatched(string message) : base(message) { }
        public MessageNotDispatched(string message, Exception inner) : base(message, inner) { }
        public static MessageNotDispatched Default() => new MessageNotDispatched("A mensagem nao foi enviada para o usuario");
    }
}
