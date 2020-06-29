using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Implements;
using SSCMS.Services;
using SSCMS.Utils;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = AuthTypes.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class RangeController : ControllerBase
    {
        private const string Route = "restriction/range";

        private readonly IAuthManager _authManager;
        private readonly IRangeRepository _rangeRepository;

        public RangeController(IAuthManager authManager, IRangeRepository rangeRepository)
        {
            _authManager = authManager;
            _rangeRepository = rangeRepository;
        }

        [HttpGet, Route(Route)]
        public async Task<ActionResult<ListResult>> GetList([FromQuery] ListRequest request)
        {
            if (request.IsWhiteList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsWhite))
            {
                return Unauthorized();
            }

            if (!request.IsWhiteList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsBlack))
            {
                return Unauthorized();
            }

            return new ListResult
            {
                Ranges = await _rangeRepository.GetAllAsync(request.IsWhiteList)
            };
        }

        [HttpDelete, Route(Route)]
        public async Task<ActionResult<ListResult>> Delete([FromBody] DeleteRequest request)
        {
            if (request.IsWhiteList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsWhite))
            {
                return Unauthorized();
            }

            if (!request.IsWhiteList && !await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsBlack))
            {
                return Unauthorized();
            }

            await _rangeRepository.DeleteAsync(request.IsWhiteList, request.RangeId);

            return new ListResult
            {
                Ranges = await _rangeRepository.GetAllAsync(request.IsWhiteList)
            };
        }
    }
}
