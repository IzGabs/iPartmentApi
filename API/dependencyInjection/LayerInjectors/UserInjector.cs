using API.src.Application.User;
using API.src.Domain.User.Application;
using Microsoft.Extensions.DependencyInjection;

namespace API.dependencyInjection.LayerInjectors
{
    public class UserInjector : ILayerInjector
    {
        public UserInjector() { }
        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
