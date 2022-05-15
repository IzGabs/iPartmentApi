using API.src.Infra.Bucket;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection.LayerInjectors
{
    public class BucketInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddSingleton<BucketClient, BucketClient>();
            services.AddTransient<BucketOperations, BucketOperations>();
            
        }
    }
}
