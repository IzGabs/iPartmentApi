using API.Domain.RealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Domain.Condominium
{
    public interface ICondominiumService
    {
        Task<bool> Create(CondominiumObject obj);
        Task<CondominiumObject> Get(int id);
        Task<List<CondominiumObject>> GetAll();
        Task<List<RealStateObject>> realStatesFromCondominium(int id); 
    }
}
