using System.Collections.Generic;
using SSCMS.Restriction.Models;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class RangeController
    {
        public class ListRequest
        {
            public bool IsWhiteList { get; set; }
        }

        public class ListResult
        {
            public List<Range> Ranges { get; set; }
        }

        public class DeleteRequest
        {
            public bool IsWhiteList { get; set; }
            public int RangeId { get; set; }
        }
    }
}
