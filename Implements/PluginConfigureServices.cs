using Microsoft.Extensions.DependencyInjection;
using SSCMS.Plugins;
using SSCMS.Restriction.Abstractions;

namespace SSCMS.Restriction.Implements
{
    public class PluginConfigureServices : IPluginConfigureServices
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IRangeRepository, RangeRepository>();
            services.AddScoped<IRestrictionManager, RestrictionManager>();
        }
    }
}
