
using API.Domain.Location;
using API.Domain.User;
using API.src.Domain.RealState.Entities.ValueObject;
using API.src.Infra;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.RealState.Entities
{
    [Table("RealEstates")]
    public class RealEstateBase : RealEstateValueObject
    {
        [Required]
        public Address Adress { get; set; }

        [Required]
        [JsonConverter(typeof(ConverterTypeRealEstate))]
        public TypeRealEstate Type { get; set; }

        public UserObject? CurrentResident { get; set; }

        public RealEstateBase() { }

        public RealEstateBase(
            int? iD,
            TypeRealEstate tipo,
            int tamanho,
            int numeroSalas,
            int numeroBanheiros,
            int suites,
            bool mobiliado,
            bool aceitaPets,
            bool garage,
            Address localicazao,
            UserObject? moradorAtual = null
            )
        {
            this.ID = iD;
            this.Type = tipo;
            this.squareMeters = tamanho;
            this.Rooms = numeroSalas;
            this.Bathrooms = numeroBanheiros;
            this.RoomWithBathroom = suites;
            this.Furnished = mobiliado;
            this.AllowPets = aceitaPets;
            this.Garage = garage;
            this.CurrentResident = moradorAtual;
            this.Adress = localicazao;
        }

        public RealEstateBase(Address adress, TypeRealEstate Type, UserObject? currentResident = null)
        {
            this.CurrentResident = currentResident;
            this.Adress = adress;

            this.Type = Type;
        }

        public bool isCondoRequired() => Type == RealEstateTypesEnum.APARTMENT;
    }
}