using API.Domain.User;
using API.src.Domain.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
