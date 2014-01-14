using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Maticsoft.BLL
{
    public class CollectionNodeText
    {
        public static string GetNodeListInnerText(HtmlNode htmlNode, string xpath, char intervalStr = ' ')
        {
            var nodeList = htmlNode.SelectNodes(xpath);
            if (nodeList == null)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder();
            foreach (var node in nodeList)
            {
                if (string.IsNullOrWhiteSpace(node.InnerText))
                {
                    continue;
                }
                stringBuilder.Append(node.InnerText).Append(intervalStr);
            }
            return stringBuilder.ToString().Trim(intervalStr);
        }

        public static string GetNodeInnerText(HtmlNode htmlNode, string xpath)
        {
            var node = htmlNode.SelectSingleNode(xpath);
            if (node == null)
            {
                return string.Empty;
            }
            return node.InnerText;
        }
        public static HtmlNode GetNodeInner(HtmlNode htmlNode, string xpath)
        {
            var node = htmlNode.SelectSingleNode(xpath);
            if (node == null)
            {
                return new HtmlNode(HtmlNodeType.Text, null, 0);
            }
            return node;
        }
        public static string GetNodeListContainsInnerText(HtmlNode htmlNode, string xpath, string nodeName)
        {
            var containNode = GetNodeContainsInnerText(htmlNode, xpath, nodeName);
            if (containNode == null)
            {
                return string.Empty;
            }
            return containNode.InnerText.Replace(nodeName, string.Empty);
        }
        public static HtmlNode GetNodeContainsInnerText(HtmlNode htmlNode, string xpath, string nodeName)
        {
            var tagNodeList = htmlNode.SelectNodes(xpath);
            if (tagNodeList == null)
            {
                return null;
            }
            foreach (var tagNode in tagNodeList)
            {
                if (tagNode.InnerText.Contains(nodeName))
                {
                    return tagNode;
                }
            }
            return null;
        }
    }
}
