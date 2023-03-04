﻿using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ererenderingdering.DependencyInjection
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISitecoreContext, SitecoreContext>();
        }
    }
}