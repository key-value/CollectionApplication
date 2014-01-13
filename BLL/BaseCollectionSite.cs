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
            if (pageUrl.Contains(@"http://"))
            {
                _pageUrl = pageUrl;
            }
            else
            {
                _pageUrl = @"http://" + pageUrl;
            }
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
                    //Encoding encoding = Encoding.GetEncoding("GBK");
                    //htmlWeb.OverrideEncoding = encoding;
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
        public HtmlNode BaseHtmlNodeByGBK
        {
            get
            {
                if (_catalogueHtmlNode == null)
                {
                    var htmlWeb = new HtmlWeb();
                    Encoding encoding = Encoding.GetEncoding("GBK");
                    htmlWeb.OverrideEncoding = encoding;
                    htmlWeb.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0";
                    var htmlDoc = htmlWeb.Load(PageUrl);
                    _catalogueHtmlNode = htmlDoc.DocumentNode;
                }
                return _catalogueHtmlNode;
            }
        }

    }
}
