
using API.src.Domain.RealState.Entities;
using API.src.Controllers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.src.Domain.RealState.Application
{
    public interface IRealEstateService
    {
        Task<bool> Update(RealEstateBase body);
        Task<bool> Delete(RealEstateBase body);
        Task<RealEstateBase> Create(RealEstateBase body);

        Task<RealEstateBase> GetByID(int id);
        Task<List<RealEstateBase>> GetList();
        Task<List<RealEstateBase>> GetListPagineted(string city, int page, int pageSize = 0);
    }

    public interface IRealEstateCondoService
    {
        Task<RealEstateCondo> Create(RealEstateBase body, int condoId);
        Task<RealEstateCondo> GetByID(int id);
    }
}
