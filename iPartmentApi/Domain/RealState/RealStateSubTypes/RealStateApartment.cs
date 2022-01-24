using API.Domain.User;
using iPartmentApi.Domain.Location;

namespace iPartmentApi.Domain.RealState
{
    public sealed class RealStateApartment : RealState
    {
        public RealStateApartment(int iD, string tamanho, int numeroSalas, int numeroBanheiros, int suites, bool mobiliado, bool aceitaPets, User moradorAtual, Adress localicazao, double valor, bool garagem) 
            :
            base(iD: iD, tipo: RealStateTypes.APARTMENT, tamanho: tamanho, numeroSalas: numeroSalas, numeroBanheiros: numeroBanheiros, suites: suites, mobiliado: mobiliado,
               aceitaPets: aceitaPets, moradorAtual: moradorAtual, localicazao: localicazao, valor: valor)
        {
            Garagem = garagem;
        }


    }
}