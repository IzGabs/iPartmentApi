using API.src.Infra.ML;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection.LayerInjectors.Infra
{
    public class MlPredictServiceInjector : ILayerInjector
    {
       

        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IMLPredictService, MLPredictService>();
        }
    }
}
