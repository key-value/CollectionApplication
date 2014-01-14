using System.Collections;

namespace ApplicationUtility
{
    public static class StringUtility
    {
        public static string ClearSiteCode(this string strText)
        {
            if (string.IsNullOrEmpty(strText))
            {
                return string.Empty;
            }
            return strText.Replace(@"&nbsp;", string.Empty).Replace(@"&quot;", string.Empty).Replace(@"&raquo;", string.Empty).Replace(@"\r\n", string.Empty).Replace(@"\n", string.Empty).Replace(@"\t", string.Empty).Replace(@"&#x2193;", string.Empty).Replace(@"&mdash;", string.Empty).Trim();
        }
    }
}