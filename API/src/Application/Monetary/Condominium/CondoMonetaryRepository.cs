using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Values;
using API.src.Infra.EntityFramework;
using System.Threading.Tasks;

namespace API.src.Application.Condominium.Monetary
{
    public class CondoMonetaryRepository : IMonetaryRepository<CondominiumMonetary>
    {
        private readonly BuildContext context;

        public CondoMonetaryRepository(BuildContext context)
        {
            this.context = context;
        }

        public async Task<CondominiumMonetary> Create(CondominiumMonetary obj)
        {
            var request = context.CondominiumValues.Add(obj);
            await context.SaveChangesAsync();
            return request.Entity;
        }
    }
}
