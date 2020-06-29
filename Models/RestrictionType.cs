using Datory.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SSCMS.Restriction.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestrictionType
    {
        [DataEnum(DisplayName = "�޷�������")] None,
        [DataEnum(DisplayName = "���ð�����������������е�IP���з��ʣ������ֹ����")] BlackList,
        [DataEnum(DisplayName = "���ú���������ֹ�������е�IP���з��ʣ������������")] WhiteList,
    }
}
