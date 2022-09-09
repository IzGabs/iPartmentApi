using API.src.Infra.Bucket;
using API.src.Infra.Firebase;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class FirebaseInjector : ILayerInjector
    {
        public void Inject(IServiceCollection services)
        {
            services.AddSingleton<FirebaseAdminClient, FirebaseAdminClient>();
            services.AddTransient<FirebaseMessageDispacher, FirebaseMessageDispacher>();
        }
    }
}
