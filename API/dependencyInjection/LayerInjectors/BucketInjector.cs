using API.src.Infra.Bucket;
using Microsoft.Extensions.DependencyInjection;

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
