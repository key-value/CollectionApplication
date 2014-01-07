using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ApplicationUtility
{
    public static class HtmlNodeUtility
    {
        public static string GetPicturePath(this HtmlNode htmlNode)
        {
            if (htmlNode == null)
            {
                return string.Empty;
            }
            if (htmlNode.Attributes.Contains("src"))
            {
                return htmlNode.Attributes["src"].Value;
            }
            if (htmlNode.Attributes.Contains("href"))
            {
                return htmlNode.Attributes["href"].Value;
            }
            return string.Empty;
        }
    }
}
