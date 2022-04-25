using API.src.Core.Errors;
using API.src.Domain.Condominium.Application.Monetary;
using API.src.Domain.Condominium.Application.Values;
using API.src.Domain.Monetary.Entities;
using API.src.Infra.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.Application.Monetary.RealState
{
    public class RealStateMonetaryRepository : IMonetaryRepository<RealStateMonetary>
    {
        private readonly BuildContext context;

        public RealStateMonetaryRepository(BuildContext context)
        {
            this.context = context;
        }


        public async Task<RealStateMonetary> Create(RealStateMonetary obj)
        {
            try {
                var addObj = await context.RealStateMonetary.AddAsync(obj);

                if (addObj.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    await context.SaveChangesAsync();
                    return addObj.Entity;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw CouldNotCreateRealStateValues.Default();
            }

            return null;
        }
    }
}
