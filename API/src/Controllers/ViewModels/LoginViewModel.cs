using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Controllers.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        [Required]
        public String email { get; set; }
        [Required]
        public String password { get; set; }
    }
}
