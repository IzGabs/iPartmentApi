using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Monetary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Entities
{
    public class RealStateCondo : RealStateObject
    {
        [Required]
        public CondominiumObject Condominium { get; set; }

        public RealStateCondo(){}

        public RealStateCondo(int? iD,
            RealStateTypes tipo, 
            string tamanho, 
            int numeroSalas, 
            int numeroBanheiros, 
            int suites, 
            bool mobiliado, 
            bool aceitaPets, 
            Address localicazao, 
            RealStateMonetary valores, 
            CondominiumObject condominium,
            UserObject moradorAtual = null) : base(iD, tipo, tamanho, numeroSalas, numeroBanheiros, suites, mobiliado, aceitaPets, localicazao, valores, moradorAtual)
        {
            this.Condominium = condominium;
        }

        public RealStateCondo(RealStateObject realstate, CondominiumObject condo) 
            : base(realstate.ID, realstate.Type, realstate.Size,
                  realstate.Rooms, realstate.Bathrooms, realstate.RoomWithBathroom, 
                  realstate.Furnished, realstate.AllowPets, realstate.Adress, realstate.Values, realstate.CurrentResident) 
        { this.Condominium = condo; }
    }
}
