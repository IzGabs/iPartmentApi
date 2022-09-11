using API.src.Domain.Monetary;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium.Application.Values
{
    public interface IMonetaryService<T> where T : IMonetaryEntity
    {
        Task<T> Create(T obj);
    }
}
