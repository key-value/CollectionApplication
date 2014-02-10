using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using ApplicationUtility;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Maticsoft.BLL
{
    public class BaseCollectionSite
    {
        static BaseCollectionSite()
        {
            htmlWeb = new HtmlWeb();
            htmlWeb.UseCookies = true;
            htmlWeb.UserAgent = @"Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.95 Safari/537.36 SE 2.X MetaSr 1.0";
            cookieContainer = new CookieContainer();
            cookieContainer.Add(new CookieCollection() { new Cookie("JSESSIONID", "A0F155532E73C78CAB609C7E21379447", "/", ".dianping.com") });
        }
        public bool OnPreRequest2(HttpWebRequest request)
        {
            request.CookieContainer = cookieContainer;
            return true;
        }
        protected void OnAfterResponse2(HttpWebRequest request, HttpWebResponse response)
        {
            SaveCookiesFrom(response);
            //do nothing
        }
        private void SaveCookiesFrom(HttpWebResponse response)
        {
            if ((response.Cookies.Count > 0))
            {
                var cookies = new CookieCollection { response.Cookies };
                cookieContainer.Add(cookies);
            }
        }
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

        public static CookieContainer cookieContainer;

        public static HtmlWeb htmlWeb;
        public HtmlNode BaseHtmlNode
        {
            get
            {
                if (_catalogueHtmlNode == null)
                {

                    //WebClient _client = new WebClient();
                    //_client.BaseAddress = PageUrl;
                    //_client.OpenWrite(new Uri(PageUrl));
                    /*HttpWebRequest req;
                    req = WebRequest.Create(new Uri(PageUrl)) as HttpWebRequest;
                    req.Method = "GET";
                    req.UseDefaultCredentials = true;
                    //req.Referer = @"Accept-Encoding: gzip,deflate,sdch";
                    req.PreAuthenticate = true;
                    req.Accept = @"*/
                    /*";
   req.ContentType = "application/x-www-form-urlencoded";
   req.Headers.Add("Accept-Encoding: gzip, deflate");
   req.Headers.Add("Accept-Language: zh-Hans-CN,zh-Hans;q=0.8,en-US;q=0.5,en;q=0.3");
   req.UserAgent = @"User-Agent: Mozilla/5.0 (MSIE 11.0; Windows NT 6.2; WOW64; Trident/7.0; rv:11.0; SE 2.X MetaSr 1.0) like Gecko";
   req.CookieContainer = new CookieContainer(10);*/
                    //req.CookieContainer.Add();

                    //Encoding encoding = Encoding.GetEncoding("GB2312");

                    /*WebResponse rs = req.GetResponse();
                    Stream rss = rs.GetResponseStream();
                    if (rss != null && req.CookieContainer != null)
                    {
                        cookieContainer = req.CookieContainer;
                    }
                    HtmlDocument doc = new HtmlDocument();
                    doc.Load(rss, Encoding.GetEncoding("GBK"));
                    var a = doc;*/

                    var browserSession = new BrowserSession();
                    _catalogueHtmlNode = browserSession.GetHtmlDocument(PageUrl).DocumentNode;

                    //htmlWeb.PreRequest = new HtmlWeb.PreRequestHandler(OnPreRequest2);
                    //htmlWeb.PostResponse = new HtmlWeb.PostResponseHandler(OnAfterResponse2);

                    ////var htmlWeb = new HtmlWeb();
                    ////Encoding encoding = Encoding.GetEncoding("GBK");
                    ////htmlWeb.OverrideEncoding = encoding;
                    ////htmlWeb.UseCookies = true;

                    //var htmlDoc = htmlWeb.Load(PageUrl);
                    //_catalogueHtmlNode = htmlDoc.DocumentNode;
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

        public HtmlNode BaseHtmlNodeMethod(string method = "post")
        {
            var htmlWeb = new HtmlWeb();
            htmlWeb.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0";
            var htmlDoc = htmlWeb.Load(PageUrl, method);
            return htmlDoc.DocumentNode;
        }
    }
}
