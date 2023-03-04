using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ererenderingdering.Foundation.VariantJsx.DependencyInjection
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISitecoreContext, SitecoreContext>();
        }
    }
}