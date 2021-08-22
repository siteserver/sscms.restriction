using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Configuration;
using SSCMS.Services;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class SettingsController : ControllerBase
    {
        private const string Route = "restriction/settings";

        private readonly IAuthManager _authManager;
        private readonly ISettingsManager _settingsManager;

        public SettingsController(IAuthManager authManager, ISettingsManager settingsManager)
        {
            _authManager = authManager;
            _settingsManager = settingsManager;
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
