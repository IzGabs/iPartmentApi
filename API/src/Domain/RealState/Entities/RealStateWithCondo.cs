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
            this.Tipo = tipo;
            this.Tamanho = tamanho;
            this.NumeroSalas = numeroSalas;
            this.NumeroBanheiros = numeroBanheiros;
            this.Suites = suites;
            this.Mobiliado = mobiliado;
            this.AceitaPets = aceitaPets;
            this.MoradorAtual = moradorAtual;
            this.localizacao = localicazao;
            this.valores = valores;
            this.Condominio = condominium;
        }
    }
}
