using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SSCMS.Configuration;
using SSCMS.Restriction.Abstractions;
using SSCMS.Services;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class SettingsController : ControllerBase
    {
        private const string Route = "restriction/settings";

        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IAuthManager _authManager;
        private readonly ISettingsManager _settingsManager;
        private readonly IRestrictionManager _restrictionManager;

        public SettingsController(IHostApplicationLifetime hostApplicationLifetime, IAuthManager authManager, ISettingsManager settingsManager, IRestrictionManager restrictionManager)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _authManager = authManager;
            _settingsManager = settingsManager;
            _restrictionManager = restrictionManager;
        }

        public class GetResult
        {
            public bool IsHost { get; set; }
            public string Host { get; set; }
        }

        public class SubmitRequest
        {
            public bool IsHost { get; set; }
            public string Host { get; set; }
        }
    }
}
