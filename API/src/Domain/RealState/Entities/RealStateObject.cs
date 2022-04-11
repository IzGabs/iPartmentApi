
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.src.Core.Swagger;
using API.Domain.RealState.Models;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.Monetary;

namespace API.src.Domain.RealState.Entities
{

    [Table("RealStates")]
    public class RealStateObject
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

        public UserObject? CurrentResident { get; set; }
        public CondominiumObject? Condominium { get; set; }

        [Required]
        public Address Adress { get; set; }

        [Required]
        public RealStateMonetary Values { get; set; }

        public RealStateObject() { }
        public RealStateObject(
            int? iD,
            RealStateTypes tipo,
            string tamanho,
            int numeroSalas,
            int numeroBanheiros,
            int suites,
            bool mobiliado,
            bool aceitaPets,
            Address localicazao,
            RealStateMonetary valores,
            UserObject? moradorAtual = null,
            CondominiumObject? condominium = null
            )
        {
            this.ID = iD;
            this.Type = tipo;
            this.Size = tamanho;
            this.Rooms = numeroSalas;
            this.Bathrooms = numeroBanheiros;
            this.RoomWithBathroom = suites;
            this.Furnished = mobiliado;
            this.AllowPets = aceitaPets;
            this.CurrentResident = moradorAtual;
            this.Adress = localicazao;
            this.Values = valores;
            this.Condominium = condominium;
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (!(obj is RealStateObject)) return false;

            var thisObj = obj as RealStateObject;

            if (ID == thisObj.ID) return true;

            return ID == thisObj.ID &&
                Type == thisObj.Type &&
                Size == thisObj.Size &&
                Rooms == thisObj.Rooms &&
                Bathrooms == thisObj.Bathrooms &&
                RoomWithBathroom == thisObj.RoomWithBathroom &&
                Furnished == thisObj.Furnished &&
                AllowPets == thisObj.AllowPets &&
                Garage == thisObj.Garage &&
                Adress == thisObj.Adress;
        }

        public bool isCondoRequired() => Type == RealStateTypes.APARTMENT;
    }
}