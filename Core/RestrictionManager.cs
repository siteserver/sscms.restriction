namespace SSCMS.Restriction.Core
{
	public static class RestrictionManager
    {
        public const string PermissionsSettings = "restriction_settings";
        public const string PermissionsAllow = "restriction_allow";
        public const string PermissionsBlock = "restriction_block";

        //private readonly ISettingsManager _settingsManager;
        //private readonly IHttpContextAccessor _accessor;

        //public RestrictionManager(ISettingsManager settingsManager, IHttpContextAccessor accessor)
        //{
        //    _settingsManager = settingsManager;
        //    _accessor = accessor;
        //}

        //private bool Contains(string text, string inner)
        //{
        //    return text?.IndexOf(inner, StringComparison.Ordinal) >= 0;
        //}

        //private int GetCount(string innerText, string content)
        //{
        //    if (innerText == null || content == null)
        //    {
        //        return 0;
        //    }
        //    var count = 0;
        //    for (var index = content.IndexOf(innerText, StringComparison.Ordinal); index != -1; index = content.IndexOf(innerText, index + innerText.Length, StringComparison.Ordinal))
        //    {
        //        count++;
        //    }
        //    return count;
        //}

        //private bool IsIpAddress(string ip)
        //{
        //    return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        //}

        //public string GetIpAddress()
        //{
        //    var result = string.Empty;

        //    try
        //    {
        //        var request = _accessor.HttpContext.Request;

        //        result = request.Headers["HTTP_X_FORWARDED_FOR"];
        //        if (!string.IsNullOrEmpty(result))
        //        {
        //            if (result.IndexOf(".", StringComparison.Ordinal) == -1)
        //                result = null;
        //            else
        //            {
        //                if (result.IndexOf(",", StringComparison.Ordinal) != -1)
        //                {
        //                    result = result.Replace("  ", "").Replace("'", "");
        //                    var temporary = result.Split(",;".ToCharArray());
        //                    foreach (var t in temporary)
        //                    {
        //                        if (IsIpAddress(t) && t.Substring(0, 3) != "10." && t.Substring(0, 7) != "192.168" && t.Substring(0, 7) != "172.16.")
        //                        {
        //                            result = t;
        //                        }
        //                    }
        //                    var str = result.Split(',');
        //                    if (str.Length > 0)
        //                        result = str[0].Trim();
        //                }
        //                else if (IsIpAddress(result))
        //                    return result;
        //            }
        //        }

        //        if (string.IsNullOrEmpty(result))
        //        {
        //            result = request.Headers["REMOTE_ADDR"];
        //        }

        //        if (string.IsNullOrEmpty(result))
        //        {
        //            result = request.HttpContext.Connection.RemoteIpAddress.ToString();
        //        }

        //        if (string.IsNullOrEmpty(result) || result == "::1")
        //        {
        //            result = "127.0.0.1";
        //        }
        //    }
        //    catch
        //    {
        //        // ignored
        //    }

        //    return result;
        //}

        //public bool IsVisitAllowed()
        //{
        //    var isAllowed = true;

        //    if (!string.IsNullOrEmpty(_settingsManager.AdminRestrictionHost))
        //    {
        //        var currentHost = RemoveProtocolFromUrl(GetHost());
        //        if (!StartsWithIgnoreCase(currentHost, RemoveProtocolFromUrl(_settingsManager.AdminRestrictionHost)))
        //        {
        //            isAllowed = false;
        //        }
        //    }

        //    if (isAllowed)
        //    {
        //        var userIp = GetIpAddress();

        //        if (_settingsManager.AdminRestrictionBlockList != null && _settingsManager.AdminRestrictionBlockList.Length > 0)
        //        {
        //            var list = new IpList();
        //            foreach (var restriction in _settingsManager.AdminRestrictionBlockList)
        //            {
        //                AddRestrictionToIpList(list, restriction);
        //            }
        //            if (list.CheckNumber(userIp))
        //            {
        //                isAllowed = false;
        //            }
        //        }
        //        else if (_settingsManager.AdminRestrictionAllowList != null && _settingsManager.AdminRestrictionAllowList.Length > 0)
        //        {
        //            isAllowed = false;
        //            var list = new IpList();
        //            foreach (var restriction in _settingsManager.AdminRestrictionAllowList)
        //            {
        //                AddRestrictionToIpList(list, restriction);
        //            }
        //            if (list.CheckNumber(userIp))
        //            {
        //                isAllowed = true;
        //            }
        //        }
        //    }

        //    return isAllowed;
        //}

        //private bool StartsWithIgnoreCase(string text, string startString)
        //{
        //    if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(startString)) return false;
        //    return text.Trim().ToLower().StartsWith(startString.Trim().ToLower()) || string.Equals(text.Trim(), startString.Trim(), StringComparison.CurrentCultureIgnoreCase);
        //}

        //private string RemoveProtocolFromUrl(string url)
        //{
        //    if (string.IsNullOrEmpty(url)) return string.Empty;

        //    url = url.Trim();
        //    return IsProtocolUrl(url) ? url.Substring(url.IndexOf("://", StringComparison.Ordinal) + 3) : url;
        //}

        //private bool IsProtocolUrl(string url)
        //{
        //    if (string.IsNullOrEmpty(url)) return false;

        //    url = url.Trim();
        //    return url.IndexOf("://", StringComparison.Ordinal) != -1 || url.StartsWith("javascript:");
        //}

        //public string GetHost()
        //{
        //    var request = _accessor.HttpContext.Request;

        //    var host = string.Empty;
        //    if (request == null) return string.IsNullOrEmpty(host) ? string.Empty : host.Trim().ToLower();
        //    host = request.Headers["HOST"];
        //    if (string.IsNullOrEmpty(host))
        //    {
        //        host = request.Host.Host;
        //    }

        //    return string.IsNullOrEmpty(host) ? string.Empty : host.Trim().ToLower();
        //}

        //private void AddRestrictionToIpList(IpList list, string restriction)
        //{
        //    if (string.IsNullOrEmpty(restriction)) return;

        //    if (Contains(restriction, "-"))
        //    {
        //        restriction = restriction.Trim(' ', '-');
        //        var arr = restriction.Split('-');
        //        list.AddRange(arr[0].Trim(), arr[1].Trim());
        //    }
        //    else if (Contains(restriction, "*"))
        //    {
        //        var ipPrefix = restriction.Substring(0, restriction.IndexOf('*'));
        //        ipPrefix = ipPrefix.Trim(' ', '.');
        //        var dotNum = GetCount(".", ipPrefix);

        //        string ipNumber;
        //        string mask;
        //        if (dotNum == 0)
        //        {
        //            ipNumber = ipPrefix + ".0.0.0";
        //            mask = "255.0.0.0";
        //        }
        //        else if (dotNum == 1)
        //        {
        //            ipNumber = ipPrefix + ".0.0";
        //            mask = "255.255.0.0";
        //        }
        //        else
        //        {
        //            ipNumber = ipPrefix + ".0";
        //            mask = "255.255.255.0";
        //        }
        //        list.Add(ipNumber, mask);
        //    }
        //    else
        //    {
        //        list.Add(restriction);
        //    }
        //}
	}
}
