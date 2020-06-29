using Datory.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SSCMS.Restriction.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestrictionType
    {
        [DataEnum(DisplayName = "无访问限制")] None,
        [DataEnum(DisplayName = "启用白名单，允许白名单中的IP进行访问，其余禁止访问")] BlackList,
        [DataEnum(DisplayName = "启用黑名单，禁止黑名单中的IP进行访问，其余允许访问")] WhiteList,
    }
}
