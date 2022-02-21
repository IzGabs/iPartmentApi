
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.dependencyInjection
{
    public class InjectorModule
    {
        private List<ILayerInjector> listInjectors = new List<ILayerInjector>();

        public InjectorModule()
        {
            listInjectors.Add(new RealStateInjector());
        }

        public void InjectModules(IServiceCollection services)
        {
            ILayerInjector _currentLayer;

            foreach (ILayerInjector index in listInjectors)
            {
                _currentLayer = index;
                try
                {
                    _currentLayer.Inject(services);
                }
                catch
                {
                    Console.WriteLine($"Error injecting layer {_currentLayer?.ToString()}");
                }
            }

        }
    }
}
