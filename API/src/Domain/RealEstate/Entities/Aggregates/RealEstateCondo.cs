using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Monetary.Entities;
using API.src.Domain.RealState.Entities.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.RealState.Entities
{
    public class RealEstateCondo : RealEstateBase
    {
        [Required]
        public CondominiumObject Condominium { get; set; }
       

        public RealEstateCondo() { }

        public RealEstateCondo(
            int? iD, TypeRealEstate tipo, string tamanho,
            int numeroSalas, int numeroBanheiros, int suites,
            bool mobiliado, bool aceitaPets, bool garage,
            Address adress, RealStateMonetary values, CondominiumObject condominium, UserObject currentResident = null)
            : base(iD, tipo, tamanho, numeroSalas, numeroBanheiros, suites, mobiliado, aceitaPets, garage, adress, values)
        {
            CurrentResident = currentResident;
            Adress = adress;
            Values = values;
            this.Condominium = condominium;
        }

        public RealEstateCondo(RealEstateBase realstate, CondominiumObject condo)
            : base(realstate.ID, realstate.Type, realstate.Size,
                  realstate.Rooms, realstate.Bathrooms, realstate.RoomWithBathroom,
                  realstate.Furnished, realstate.AllowPets, realstate.Garage, 
                  realstate.Adress, realstate.Values)
        {
            this.Condominium = condo;
            this.Adress = realstate.Adress;
            this.Values = realstate.Values;

        }
    }
}
