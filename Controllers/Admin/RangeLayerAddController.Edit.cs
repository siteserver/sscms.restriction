using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Restriction.Core;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeLayerAddController
    {
        [HttpPut, Route(Route)]
        public async Task<ActionResult<BoolResult>> Edit([FromBody] EditRequest request)
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            if (request.IsAllowList)
            {
                var list = new List<string>(_settingsManager.AdminRestrictionBlockList ?? new string[] { });
                var index = list.IndexOf(request.OldRange);
                list[index] = request.NewRange;

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, list.ToArray(), _settingsManager.AdminRestrictionBlockList);
            }
            else
            {
                var list = new List<string>(_settingsManager.AdminRestrictionBlockList ?? new string[] { });
                var index = list.IndexOf(request.OldRange);
                list[index] = request.NewRange;

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, _settingsManager.AdminRestrictionAllowList, list.ToArray());
            }

            return new BoolResult
            {
                Value = true
            };
        }
    }
}
