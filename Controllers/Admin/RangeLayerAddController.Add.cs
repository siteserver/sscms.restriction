using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Restriction.Core;
using SSCMS.Utils;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeLayerAddController
    {
        [HttpPost, Route(Route)]
        public async Task<ActionResult<BoolResult>> Add([FromBody] AddRequest request)
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            if (request.IsAllowList)
            {
                var list = new List<string>(_settingsManager.AdminRestrictionAllowList ?? new string[] { });
                if (ListUtils.Contains(list, request.Range))
                {
                    return this.Error("添加失败，Ip 段已存在");
                }
                list.Add(request.Range);

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsSafeMode, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, list.ToArray(), _settingsManager.AdminRestrictionBlockList, _settingsManager.CorsIsOrigins, _settingsManager.CorsOrigins);
            }
            else
            {
                var list = new List<string>(_settingsManager.AdminRestrictionBlockList ?? new string[] { });
                if (ListUtils.Contains(list, request.Range))
                {
                    return this.Error("添加失败，Ip 段已存在");
                }
                list.Add(request.Range);

                _settingsManager.SaveSettings(_settingsManager.IsProtectData, _settingsManager.IsSafeMode, _settingsManager.IsDisablePlugins, _settingsManager.DatabaseType, _settingsManager.DatabaseConnectionString, _settingsManager.RedisConnectionString, _settingsManager.AdminRestrictionHost, _settingsManager.AdminRestrictionAllowList, list.ToArray(), _settingsManager.CorsIsOrigins, _settingsManager.CorsOrigins);
            }

            return new BoolResult
            {
                Value = true
            };
        }
    }
}
