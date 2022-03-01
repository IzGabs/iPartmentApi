using API.src.Domain.Monetary;
using API.src.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium.Application.Values
{
    public interface IMonetaryService<T> where T : IMonetaryEntity
    {
        Task<T> Create(T obj);
    }
}
