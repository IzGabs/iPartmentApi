using API.src.Domain.Monetary;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium.Application.Monetary
{
    public interface IMonetaryRepository<T> where T : IMonetaryEntity
    {
        Task<T> Create(T obj);
    }
}
