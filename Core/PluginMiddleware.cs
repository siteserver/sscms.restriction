using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SSCMS.Plugins;
using SSCMS.Restriction.Abstractions;
using SSCMS.Utils;

namespace SSCMS.Restriction.Core
{
    public class PluginMiddleware : IPluginMiddleware
    {
        private readonly IRestrictionManager _restrictionManager;
        public PluginMiddleware(IRestrictionManager restrictionManager)
        {
            _restrictionManager = restrictionManager;
        }

        public async Task UseAsync(RequestDelegate next, HttpContext context)
        {
            var isAllowed = true;
            if (StringUtils.StartsWithIgnoreCase(context.Request.Path.Value, "/ss-admin"))
            {
                isAllowed = await _restrictionManager.IsVisitAllowedAsync();
            }

            if (isAllowed)
            {
                await next(context);
            }
            else
            {
                await context.Response.WriteAsync("Access forbidden!");
            }
        }
    }
}
