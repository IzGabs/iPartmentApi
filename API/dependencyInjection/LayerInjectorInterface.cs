using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection
{
    public interface ILayerInjector
    {
        void Inject(IServiceCollection services);
    }
}
