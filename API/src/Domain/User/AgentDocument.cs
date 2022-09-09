using API.Domain.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.User
{

    [Table("AgentDocuments")]
    public class AgentDocument
    {
        public UserObject User { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string CRECIID { get; set; }

        [Required]
        public AgentDocumentImage image { get; set; }

        protected AgentDocument() { }

        public AgentDocument(string creciID, AgentDocumentImage image)
        {
            CRECIID = creciID;
            this.image = image;
        }

        public AgentDocument(string creciID, AgentDocumentImage image, UserObject user)
        {
            this.CRECIID = creciID;
            this.image = image;
            this.User = user;
        }
    }
}
