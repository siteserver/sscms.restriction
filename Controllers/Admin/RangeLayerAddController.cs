using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Configuration;
using SSCMS.Services;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class RangeLayerAddController : ControllerBase
    {
        private const string Route = "restriction/rangeLayerAdd";

        private readonly IAuthManager _authManager;
        private readonly ISettingsManager _settingsManager;

        public RangeLayerAddController(IAuthManager authManager, ISettingsManager settingsManager)
        {
            _authManager = authManager;
            _settingsManager = settingsManager;
        }

        public class AddRequest
        {
            public bool IsAllowList { get; set; }
            public string Range { get; set; }
        }

        public class EditRequest
        {
            public bool IsAllowList { get; set; }
            public string OldRange { get; set; }
            public string NewRange { get; set; }
        }
    }
}
