using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPIEntity.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        public string phone2 { get; set; }
    }
}
