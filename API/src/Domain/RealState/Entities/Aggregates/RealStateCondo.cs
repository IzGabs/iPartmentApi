using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.RealState.Entities
{
    public class RealStateCondo : RealStateValueObject
    {
        [Required]
        public CondominiumObject Condominium { get; set; }
        [Required]
        public Address Adress { get; set; }
        [Required]
        public RealStateMonetary Values { get; set; }
        public UserObject? CurrentResident { get; set; }

        public RealStateCondo() { }

        public RealStateCondo(
            int? iD, RealStateTypes tipo, string tamanho,
            int numeroSalas, int numeroBanheiros, int suites,
            bool mobiliado, bool aceitaPets, bool garage,
            Address adress, RealStateMonetary values, CondominiumObject condominium, UserObject currentResident = null)
            : base(iD, tipo, tamanho, numeroSalas, numeroBanheiros, suites, mobiliado, aceitaPets, garage)
        {
            CurrentResident = currentResident;
            Adress = adress;
            Values = values;
            this.Condominium = condominium;
        }

        public RealStateCondo(RealStateBase realstate, CondominiumObject condo)
            : base(realstate.ID, realstate.Type, realstate.Size,
                  realstate.Rooms, realstate.Bathrooms, realstate.RoomWithBathroom,
                  realstate.Furnished, realstate.AllowPets, realstate.Garage)
        { this.Condominium = condo; }
    }
}
