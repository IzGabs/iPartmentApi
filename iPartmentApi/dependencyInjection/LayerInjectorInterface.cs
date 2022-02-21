using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection
{
    public interface ILayerInjector
    {


        void Inject(IServiceCollection services);
    }
}
