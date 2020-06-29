using Microsoft.AspNetCore.Mvc;

namespace SSCMS.Restriction.Controllers
{
    [Route("api/restriction/ping")]
    public class PingController : ControllerBase
    {
        private const string Route = "";

        [HttpGet, Route(Route)]
        public string Get()
        {
            return "pong";
        }
    }
}