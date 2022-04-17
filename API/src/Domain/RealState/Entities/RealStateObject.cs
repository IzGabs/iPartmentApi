
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
            UserObject? moradorAtual = null
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
        }

        public bool isCondoRequired() => Type == RealStateTypes.APARTMENT;
    }
}