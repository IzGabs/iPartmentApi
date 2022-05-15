
using API.dependencyInjection.LayerInjectors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace API.dependencyInjection
{
    public class InjectorModule
    {
        private List<ILayerInjector> listInjectors = new List<ILayerInjector>();

        public InjectorModule()
        {
            listInjectors.Add(new RealStateInjector());
            listInjectors.Add(new LocationInjector());
            listInjectors.Add(new CondominiumInjector());
            listInjectors.Add(new MonetaryInjector());
            listInjectors.Add(new UserInjector());
            listInjectors.Add(new AnnouncementInjector());
            listInjectors.Add(new BucketInjector());
            
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
