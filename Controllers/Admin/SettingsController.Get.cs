using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Restriction.Core;

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

            var host = _restrictionManager.GetHost();

            return new GetResult
            {
                IsHost = !string.IsNullOrEmpty(host),
                Host = host
            };
        }
    }
}
