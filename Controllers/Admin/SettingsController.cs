using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto;
using SSCMS.Restriction.Abstractions;
using SSCMS.Restriction.Core;
using SSCMS.Services;
using SSCMS.Utils;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = AuthTypes.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class SettingsController : ControllerBase
    {
        private const string Route = "restriction/settings";

        private readonly IAuthManager _authManager;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IRestrictionManager _restrictionManager;

        public SettingsController(IAuthManager authManager, ISettingsRepository settingsRepository, IRestrictionManager restrictionManager)
        {
            _authManager = authManager;
            _settingsRepository = settingsRepository;
            _restrictionManager = restrictionManager;
        }

        [HttpGet, Route(Route)]
        public async Task<ActionResult<GetResult>> GetConfig()
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            var settings = await _settingsRepository.GetAsync();
            var host = _restrictionManager.GetHost();

            return new GetResult
            {
                Settings = settings,
                Host = host
            };
        }

        [HttpPost, Route(Route)]
        public async Task<ActionResult<BoolResult>> SetConfig([FromBody] SubmitRequest request)
        {
            if (!await _authManager.HasAppPermissionsAsync(RestrictionManager.PermissionsSettings))
            {
                return Unauthorized();
            }

            var settings = await _settingsRepository.GetAsync();
            settings.RestrictionType = request.RestrictionType;
            settings.IsHostRestriction = request.IsHostRestriction;
            settings.Host = request.Host;
            await _settingsRepository.SetAsync(settings);

            return new BoolResult
            {
                Value = true
            };
        }
    }
}
