using Datory;
using Datory.Annotations;

namespace SSCMS.Restriction.Models
{
    [DataTable("sscms_restriction_settings")]
    public class Settings : Entity
    {
        [DataColumn]
        public RestrictionType RestrictionType { get; set; }

        [DataColumn]
        public bool IsHostRestriction { get; set; }

        [DataColumn]
        public string Host { get; set; }
    }
}