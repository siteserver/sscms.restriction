using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Restriction.Core;
using SSCMS.Utils;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class SettingsController
    {
        [HttpGet, Route(Route)]
        public async Task<ActionResult<GetResult>> Get()
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            var host = PageUtils.GetHost(Request);
            var settingsHost = _settingsManager.AdminRestrictionHost;
            var isHost = !string.IsNullOrEmpty(settingsHost);
            if (isHost)
            {
                host = settingsHost;
            }

            return new GetResult
            {
                IsHost = isHost,
                Host = host
            };
        }
    }
}
