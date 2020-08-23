using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Configuration;
using SSCMS.Dto;
using SSCMS.Extensions;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Core;
using SSCMS.Restriction.Models;
using SSCMS.Services;
using SSCMS.Utils;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class RangeLayerAddController : ControllerBase
    {
        private const string Route = "restriction/rangeLayerAdd";

        private readonly IAuthManager _authManager;
        private readonly IRangeRepository _rangeRepository;
        private readonly IRestrictionManager _restrictionManager;

        public RangeLayerAddController(IAuthManager authManager, IRangeRepository rangeRepository, IRestrictionManager restrictionManager)
        {
            _authManager = authManager;
            _rangeRepository = rangeRepository;
            _restrictionManager = restrictionManager;
        }

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

        [HttpPost, Route(Route)]
        public async Task<ActionResult<BoolResult>> Add([FromBody] AddRequest request)
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            if (await _rangeRepository.ExistsAsync(request.IsWhiteList, request.IpRange))
            {
                return this.Error("添加失败，Ip 段已存在");
            }

            await _rangeRepository.InsertAsync(new Range
            {
                IsWhiteList = request.IsWhiteList,
                IpRange = request.IpRange
            });

            return new BoolResult
            {
                Value = true
            };
        }

        [HttpPut, Route(Route)]
        public async Task<ActionResult<BoolResult>> Edit([FromBody] EditRequest request)
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            await _rangeRepository.UpdateAsync(request.IsWhiteList, request.RangeId, request.IpRange);

            return new BoolResult
            {
                Value = true
            };
        }
    }
}
