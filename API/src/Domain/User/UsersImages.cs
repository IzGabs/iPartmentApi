using API.Domain.User;
using API.src.Domain.Images;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.User
{
    [Table("UserImages")]
    public class UsersImages : ImageReference
    {
        [Required]
        public UserObject User { get; set; }

        public UsersImages() { }
        public UsersImages(UserObject user)
        {
            User = user;
        }

        public UsersImages(ImageReference imgR, UserObject User) : base(imgR) { this.User = User; }
    }
}
