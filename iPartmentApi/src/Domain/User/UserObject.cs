
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.User
{
    [Table("Usuarios")]
    public class UserObject
    {

        public UserObject(int? iD, string name, string email, string password, string phone)
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


        public UserResponsesEnum? IsEqual(UserObject other)
        {

            if (other == null) return null;
            if (Email == other.Email) return UserResponsesEnum.SAME_EMAIL;
            if (Phone == other.Phone) return UserResponsesEnum.SAME_PHONE_NUMBER;

            return null;
        }
    }
}
