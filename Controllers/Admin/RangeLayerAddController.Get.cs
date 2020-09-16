using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Restriction.Core;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeLayerAddController
    {
        [HttpGet, Route(Route)]
        public async Task<ActionResult<StringResult>> Get()
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            return new StringResult
            {
                Value = _restrictionManager.GetIpAddress()
            };
        }
    }
}
