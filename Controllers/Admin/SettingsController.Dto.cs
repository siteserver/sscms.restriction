using System;
using System.Collections.Generic;
using System.Text;
using SSCMS.Restriction.Models;

namespace SSCMS.Restriction.Controllers.Admin
{
    public partial class SettingsController
    {
        public class GetResult
        {
            public Settings Settings { get; set; }
            public string Host { get; set; }
        }

        public class SubmitRequest
        {
            public RestrictionType RestrictionType { get; set; }

            public bool IsHostRestriction { get; set; }

            public string Host { get; set; }
        }
    }
}
