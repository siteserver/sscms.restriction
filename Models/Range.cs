using Datory;
using Datory.Annotations;

namespace SSCMS.Restriction.Models
{
    [DataTable("sscms_restriction_range")]
    public class Range : Entity
    {
        [DataColumn]
        public bool IsWhiteList { get; set; }

        [DataColumn]
        public string IpRange { get; set; }
    }
}
