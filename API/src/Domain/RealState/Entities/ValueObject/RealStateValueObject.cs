using API.Domain.Location;
using API.Domain.User;
using API.src.Core.Swagger;
using API.src.Domain.Monetary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Entities.ValueObject
{

    [Table("RealStates")]
    public abstract class RealStateValueObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        [Key]
        public int? ID { get; set; }

        [Required]
        public RealStateTypes Type { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        public int RoomWithBathroom { get; set; }
        [Required]
        public bool Furnished { get; set; }
        [Required]
        public bool AllowPets { get; set; }
        [Required]
        public bool Garage { get; set; }

        public RealStateValueObject() { }

        protected RealStateValueObject(int? iD, RealStateTypes type, string size, int rooms, int bathrooms, int roomWithBathroom, bool furnished, bool allowPets, bool garage)
        {
            ID = iD;
            Type = type;
            Size = size;
            Rooms = rooms;
            Bathrooms = bathrooms;
            RoomWithBathroom = roomWithBathroom;
            Furnished = furnished;
            AllowPets = allowPets;
            Garage = garage;
        }
    }
}
