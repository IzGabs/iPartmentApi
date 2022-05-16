using API.Domain.User;
using API.src.Domain.Images;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.User
{
    public class UsersImages : ImageReference
    {
        [Required]
        public UserObject User { get; set; }

        protected UsersImages() { }
        public UsersImages(UserObject user)
        {
            User = user;
        }
    }
}
