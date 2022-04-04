using API.Domain.Location;
using API.Domain.RealState.Models;
using API.Domain.User;
using API.src.Domain.Monetary.Entities;

namespace API.src.Domain.RealState.Entities
{
    public class RealStateWithCondo : RealStateObject
    {
        public CondominiumObject Condominio { get; set; }

        public RealStateWithCondo() { }
        public RealStateWithCondo(
            int? iD,
            RealStateTypes tipo,
            string tamanho,
            int numeroSalas,
            int numeroBanheiros,
            int suites,
            bool mobiliado,
            bool aceitaPets,
            UserObject? moradorAtual,
            CondominiumObject condominium,
            Address localicazao,
            RealStateMonetary valores)
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
            this.Condominio = condominium;
        }
    }
}
