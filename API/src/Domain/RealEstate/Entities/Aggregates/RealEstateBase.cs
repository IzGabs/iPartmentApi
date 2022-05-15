
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using API.src.Infra;

namespace API.src.Domain.RealState.Entities
{
    [Table("RealEstates")]
    public class RealEstateBase : RealEstateValueObject
    {
        public UserObject? CurrentResident { get; set; }


        [Required]
        public Address Adress { get; set; }
        
        [Required]
        public RealStateMonetary Values { get; set; }

        [Required]
        [JsonConverter(typeof(ConverterTypeRealEstate))]
       // [ForeignKey()]
        public TypeRealEstate Type { get; set; }

        public RealEstateBase() { }
        public RealEstateBase(
            int? iD,
            TypeRealEstate tipo,
            string tamanho,
            int numeroSalas,
            int numeroBanheiros,
            int suites,
            bool mobiliado,
            bool aceitaPets,
            bool garage,
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
            this.Garage = garage;
            this.CurrentResident = moradorAtual;
            this.Adress = localicazao;
            this.Values = valores;
        }

        public RealEstateBase( Address adress, TypeRealEstate Type,  RealStateMonetary values, UserObject? currentResident = null)
        {
            this.CurrentResident = currentResident;
            this.Adress = adress;
            this.Values = values;
            this.Type = Type;
        }

        public bool isCondoRequired() => Type == RealEstateTypesEnum.APARTMENT;
    }
}