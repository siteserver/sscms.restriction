using Microsoft.Extensions.DependencyInjection;
using SSCMS.Plugins;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Core;

namespace SSCMS.Restriction
{
    public class Startup : IPluginConfigureServices
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRestrictionManager, RestrictionManager>();
        }
    }
}
