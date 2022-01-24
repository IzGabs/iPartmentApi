using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPIEntity.Models
{
    [Table("User")]
    public class User
    {

        public User(int? iD, string name, string email, string password, string phone)
        {
            ID = iD;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
