using API.Domain.User;
using API.src.Domain.Images;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.User
{
    [Table("AgentDocumentsImages")]
    public class AgentDocumentImage : ImageReference
    {
        public UserObject User { get; set; }

        public AgentDocumentImage() { }
        public AgentDocumentImage(ImageReference data, API.Domain.User.UserObject user) : base(data)
        {
            this.User = user;
        }
    }
}


