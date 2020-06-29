using SSCMS.Restriction.Models;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeLayerAddController
    {

        public class AddRequest
        {
            public bool IsWhiteList { get; set; }
            public string IpRange { get; set; }
        }

        public class EditRequest
        {
            public bool IsWhiteList { get; set; }
            public int RangeId { get; set; }
            public string IpRange { get; set; }
        }
    }
}
