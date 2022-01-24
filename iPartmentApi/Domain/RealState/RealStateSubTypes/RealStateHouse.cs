using iPartmentApi.Domain.Location;
using API.Domain.User;

namespace iPartmentApi.Domain.RealState.RealStateSubTypes
{
    public class RealStateHouse : RealState
    {

        public RealStateHouse(int iD,string tamanho, int numeroSalas, int numeroBanheiros, int suites, bool mobiliado, bool aceitaPets, User moradorAtual, Adress localicazao, double valor, bool garagem)
            : 
            base(iD: iD, tipo: RealStateTypes.HOUSE, tamanho: tamanho, numeroSalas: numeroSalas, numeroBanheiros: numeroBanheiros, suites: suites, mobiliado: mobiliado,
                aceitaPets: aceitaPets,  moradorAtual: moradorAtual, localicazao: localicazao, valor: valor) {
            Garagem = garagem;
        }

    }
}