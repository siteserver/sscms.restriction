using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Restriction.Core;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeController
    {
        [HttpGet, Route(Route)]
        public async Task<ActionResult<ListResult>> Get([FromQuery] ListRequest request)
        {
            if (request.IsAllowList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsAllow))
            {
                return Unauthorized();
            }

            if (!request.IsAllowList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsBlock))
            {
                return Unauthorized();
            }

            return new ListResult
            {
                Ranges = request.IsAllowList
                    ? _settingsManager.AdminRestrictionAllowList
                    : _settingsManager.AdminRestrictionBlockList
            };
        }
    }
}
