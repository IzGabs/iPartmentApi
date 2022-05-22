using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Monetary.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.src.Domain.RealState.Entities
{
    public class RealEstateCondo : RealEstateBase
    {
        [Required]
        public CondominiumObject Condominium { get; set; }

        public RealEstateCondo() { }

        public RealEstateCondo(
            int? iD, TypeRealEstate tipo, int tamanho,
            int numeroSalas, int numeroBanheiros, int suites,
            bool mobiliado, bool aceitaPets, bool garage,
            Address adress, AnnouncementSellMonetary values, CondominiumObject condominium, UserObject currentResident = null)
            : base(iD, tipo, tamanho, numeroSalas, numeroBanheiros, suites, mobiliado, aceitaPets, garage, adress)
        {
            CurrentResident = currentResident;
            Adress = adress;
            this.Condominium = condominium;
        }

        public RealEstateCondo(RealEstateBase realstate, CondominiumObject condo)
            : base(realstate.ID, realstate.Type, realstate.squareMeters,
                  realstate.Rooms, realstate.Bathrooms, realstate.RoomWithBathroom,
                  realstate.Furnished, realstate.AllowPets, realstate.Garage,
                  realstate.Adress)
        {
            this.Condominium = condo;
            this.Adress = realstate.Adress;
        }
    }
}
