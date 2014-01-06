using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Maticsoft.BLL
{
    public class BaseCollectionSite
    {
        private readonly string _pageUrl;

        private HtmlNode _catalogueHtmlNode;
        public BaseCollectionSite(string pageUrl)
        {
            _pageUrl = pageUrl;
        }
        public string PageUrl
        {
            get { return _pageUrl; }
        }
        public HtmlNode BaseHtmlNode
        {
            get
            {
                if (_catalogueHtmlNode == null)
                {
                    var htmlWeb = new HtmlWeb();
                    htmlWeb.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0";
                    var htmlDoc = htmlWeb.Load(PageUrl);
                    _catalogueHtmlNode = htmlDoc.DocumentNode;
                }
                return _catalogueHtmlNode;
            }
        }

        public HtmlNode BaseHtmlNodeCollection(string htmlText)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlText);
            return htmlDocument.DocumentNode;
        }
    }
}
