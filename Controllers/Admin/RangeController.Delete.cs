using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Restriction.Core;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeController
    {
        [HttpDelete, Route(Route)]
        public async Task<ActionResult<BoolResult>> Delete([FromBody] DeleteRequest request)
        {
            if (request.IsAllowList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsAllow))
            {
                return Unauthorized();
            }

            if (!request.IsAllowList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsBlock))
            {
                return Unauthorized();
            }

            if (request.IsAllowList)
            {
                var list = new List<string>(_settingsManager.AdminRestrictionAllowList ?? new string[] { });
                list.Remove(request.Range);

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, list.ToArray(), _settingsManager.AdminRestrictionBlockList);
            }
            else
            {
                var list = new List<string>(_settingsManager.AdminRestrictionBlockList ?? new string[] { });
                list.Remove(request.Range);

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, _settingsManager.AdminRestrictionAllowList, list.ToArray());
            }

            return new BoolResult
            {
                Value = true
            };
        }
    }
}
