﻿using Microsoft.Extensions.DependencyInjection;
using API.Application;
using API.src.Application.RealState;
using API.src.Domain.RealState.repository;
using API.src.Domain.RealState;

namespace API.dependencyInjection
{
    public class RealStateInjector : ILayerInjector
    {
        public RealStateInjector() { }

        public void Inject(IServiceCollection services)
        {
            services.AddTransient<IRealStateRepository, RealStateRepository>();
            services.AddTransient<IRealStateService, RealStateService>();
        }
    }
}