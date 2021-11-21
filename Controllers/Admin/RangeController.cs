using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Configuration;
using SSCMS.Services;

namespace SSCMS.Restriction.Controllers.Admin
{
    [Authorize(Roles = Types.Roles.Administrator)]
    [Route(Constants.ApiAdminPrefix)]
    public partial class RangeController : ControllerBase
    {
        private const string Route = "restriction/range";
        private const string RouteDelete = "restriction/range/actions/delete";

        private readonly IAuthManager _authManager;
        private readonly ISettingsManager _settingsManager;

        public RangeController(IAuthManager authManager, ISettingsManager settingsManager)
        {
            _authManager = authManager;
            _settingsManager = settingsManager;
        }

        public class ListRequest
        {
            public bool IsAllowList { get; set; }
        }

        public class ListResult
        {
            public string[] Ranges { get; set; }
        }

        public class DeleteRequest
        {
            public bool IsAllowList { get; set; }
            public string Range { get; set; }
        }
    }
}
