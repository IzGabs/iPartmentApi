
using API.Domain.User;
using API.Domain.Location;
using System.ComponentModel.DataAnnotations;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.src.Domain.RealState.Entities
{
    [Table("RealStates")]
    public class RealStateBase : RealStateValueObject
    {
        [Required]
        public Address Adress { get; set; }
        [Required]
        public RealStateMonetary Values { get; set; }
        public UserObject? CurrentResident { get; set; }

        public RealStateBase() { }
        public RealStateBase(
            int? iD,
            RealStateTypes tipo,
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

        public RealStateBase( Address adress, RealStateMonetary values, UserObject? currentResident = null)
        {
            this.CurrentResident = currentResident;
            this.Adress = adress;
            this.Values = values;
        }

        public bool isCondoRequired() => Type == RealStateTypes.APARTMENT;
    }
}