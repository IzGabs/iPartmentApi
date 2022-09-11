
using API.dependencyInjection.LayerInjectors;
using API.dependencyInjection.LayerInjectors.Infra;
using API.src.Infra.Firebase;
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
            listInjectors.Add(new ScheduledVisitisInjector());

            listInjectors.Add(new BucketInjector());
            listInjectors.Add(new GeolocatorInjector()); 
            listInjectors.Add(new FirebaseInjector());
            listInjectors.Add(new MlPredictServiceInjector());
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
