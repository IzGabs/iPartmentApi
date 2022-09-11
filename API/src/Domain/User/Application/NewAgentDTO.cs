using API.src.Domain.Images;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.User.Application
{
    public class NewAgentDTO
    {
        [Required]
        public string CRECIID { get; set; }

        [Required]
        public ImageFile image { get; set; }

        [Required]
        public int userID { get; set; }

        public NewAgentDTO(string cRECIID, ImageFile image, int userID)
        {
            CRECIID = cRECIID;
            this.image = image;
            this.userID = userID;
        }
    }
}
