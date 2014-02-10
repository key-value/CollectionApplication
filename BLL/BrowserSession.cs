using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace Maticsoft.BLL
{
    public class BrowserSession
    {
        static BrowserSession()
        {
            Cookies = new CookieCollection();
            Cookies.Add(new Cookie("TGSeenRecomDealTest", "b", "/", ".dianping.com"));
            Cookies.Add(new Cookie("TGReviewAB", "a", "/", ".dianping.com"));
            Cookies.Add(new Cookie("tc", "4", "/", ".dianping.com"));
            Cookies.Add(new Cookie("t_track", "D5116066:D5116066:T:D5158165:T:D2030113:D2030113:T", "/", ".dianping.com"));
            Cookies.Add(new Cookie("sid", "gwbp5jb4xdbkalzxxvskke55", "/", ".dianping.com"));
            Cookies.Add(new Cookie("s_ViewType", "1", "/", ".dianping.com"));
            Cookies.Add(new Cookie("RecentDealGroupIds", "2030113|5158165|5116066", "/", ".dianping.com"));
            Cookies.Add(new Cookie("PHOENIX_ID", "0a01677b-1441994edf8-c93d64", "/", ".dianping.com"));


            Cookies.Add(new Cookie("lb.dp", "167837962.20480.0000", "/", ".dianping.com"));
            Cookies.Add(new Cookie("JSESSIONID", "075910FEA7B1E03DC68BF5EDA251DB8A", "/", ".dianping.com"));
            Cookies.Add(new Cookie("is", "782612742637", "/", ".dianping.com"));
            Cookies.Add(new Cookie("ipbh", "1387468800000", "/", ".dianping.com"));
            Cookies.Add(new Cookie("d_p_w", "1391757237622", "/", ".dianping.com"));
            Cookies.Add(new Cookie("d_p_m", "1391757237622", "/", ".dianping.com"));
            Cookies.Add(new Cookie("cye", "guangzhou", "/", ".dianping.com"));
            Cookies.Add(new Cookie("cy", "4", "/", ".dianping.com"));
            Cookies.Add(new Cookie("ano", "hKzddZUmzwEkAAAAYjhiMmJjNjQtZTNmYS00M2Y5LWFhN2UtYzhjMjZkNjU5Zjg1jIjEjJ8aCy1OxZrlBgJo1je0n3A1", "/", ".dianping.com"));
            Cookies.Add(new Cookie("aburl", "1", "/", ".dianping.com"));
            Cookies.Add(new Cookie("abtest", "\"36,92\\|37,94\"", "/", ".dianping.com"));
            Cookies.Add(new Cookie("_tr.u", "Ui3WxGt4CKAGBEpR", "/", ".dianping.com"));
            Cookies.Add(new Cookie("_hc.v", "\"\\\"13fbe2f8-258e-4a7f-8202-3acd74ae0418.1389575918\\\"\"", "/", ".dianping.com"));
            Cookies.Add(new Cookie("__zpspc", "99.2.1389696352.1389696352.1%234%7C%7C%7C%7C%7C", "/", ".dianping.com"));
            Cookies.Add(new Cookie("__utmz", "1.1391756850.1.1.utmcsr=locoy.com|utmccn=(referral)|utmcmd=referral|utmcct=/show.php", "/", ".dianping.com"));


        }
        private bool _isPost;
        private bool _isDownload;
        private HtmlDocument _htmlDoc;
        private string _download;

        /// <summary>
        /// System.Net.CookieCollection. Provides a collection container for instances of Cookie class 
        /// </summary>
        public static CookieCollection Cookies { get; set; }

        /// <summary>
        /// Provide a key-value-pair collection of form elements 
        /// </summary>
        public FormElementCollection FormElements { get; set; }

        /// <summary>
        /// Makes a HTTP GET request to the given URL
        /// </summary>
        public string Get(string url)
        {
            _isPost = false;
            CreateWebRequestObject().Load(url);
            return _htmlDoc.DocumentNode.InnerHtml;
        }
        /// <summary>
        /// Makes a HTTP GET request to the given URL
        /// </summary>
        public HtmlDocument GetHtmlDocument(string url)
        {
            _isPost = false;
            CreateWebRequestObject().Load(url);
            return _htmlDoc;
        }

        /// <summary>
        /// Makes a HTTP POST request to the given URL
        /// </summary>
        public string Post(string url)
        {
            _isPost = true;
            CreateWebRequestObject().Load(url, "POST");
            return _htmlDoc.DocumentNode.InnerHtml;
        }

        public string GetDownload(string url)
        {
            _isPost = false;
            _isDownload = true;
            CreateWebRequestObject().Load(url);
            return _download;
        }

        /// <summary>
        /// Creates the HtmlWeb object and initializes all event handlers. 
        /// </summary>
        private HtmlWeb CreateWebRequestObject()
        {
            HtmlWeb web = new HtmlWeb();
            web.UseCookies = true;
            web.PreRequest = new HtmlWeb.PreRequestHandler(OnPreRequest);
            web.PostResponse = new HtmlWeb.PostResponseHandler(OnAfterResponse);
            web.PreHandleDocument = new HtmlWeb.PreHandleDocumentHandler(OnPreHandleDocument);
            return web;
        }

        /// <summary>
        /// Event handler for HtmlWeb.PreRequestHandler. Occurs before an HTTP request is executed.
        /// </summary>
        protected bool OnPreRequest(HttpWebRequest request)
        {
            request.AllowAutoRedirect = false;

            AddCookiesTo(request);               // Add cookies that were saved from previous requests
            if (_isPost) AddPostDataTo(request); // We only need to add post data on a POST request
            return true;
        }

        /// <summary>
        /// Event handler for HtmlWeb.PostResponseHandler. Occurs after a HTTP response is received
        /// </summary>
        protected void OnAfterResponse(HttpWebRequest request, HttpWebResponse response)
        {
            SaveCookiesFrom(request, response); // Save cookies for subsequent requests

            if (response != null && _isDownload)
            {
                Stream remoteStream = response.GetResponseStream();
                var sr = new StreamReader(remoteStream);
                _download = sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Event handler for HtmlWeb.PreHandleDocumentHandler. Occurs before a HTML document is handled
        /// </summary>
        protected void OnPreHandleDocument(HtmlDocument document)
        {
            SaveHtmlDocument(document);
        }

        /// <summary>
        /// Assembles the Post data and attaches to the request object
        /// </summary>
        private void AddPostDataTo(HttpWebRequest request)
        {
            string payload = FormElements.AssemblePostPayload();
            byte[] buff = Encoding.UTF8.GetBytes(payload.ToCharArray());
            request.ContentLength = buff.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            System.IO.Stream reqStream = request.GetRequestStream();
            reqStream.Write(buff, 0, buff.Length);
        }

        /// <summary>
        /// Add cookies to the request object
        /// </summary>
        private void AddCookiesTo(HttpWebRequest request)
        {
            if (Cookies != null && Cookies.Count > 0)
            {
                request.CookieContainer.Add(Cookies);
            }
        }

        /// <summary>
        /// Saves cookies from the response object to the local CookieCollection object
        /// </summary>
        private void SaveCookiesFrom(HttpWebRequest request, HttpWebResponse response)
        {
            //save the cookies ;)
            if (request.CookieContainer.Count > 0 || response.Cookies.Count > 0)
            {
                if (Cookies == null)
                {
                    Cookies = new CookieCollection();
                }

                Cookies.Add(request.CookieContainer.GetCookies(request.RequestUri));
                Cookies.Add(response.Cookies);
            }
        }

        /// <summary>
        /// Saves the form elements collection by parsing the HTML document
        /// </summary>
        private void SaveHtmlDocument(HtmlDocument document)
        {
            _htmlDoc = document;
            FormElements = new FormElementCollection(_htmlDoc);
        }
    }

    /// <summary>
    /// Represents a combined list and collection of Form Elements.
    /// </summary>
    public class FormElementCollection : Dictionary<string, string>
    {
        /// <summary>
        /// Constructor. Parses the HtmlDocument to get all form input elements. 
        /// </summary>
        public FormElementCollection(HtmlDocument htmlDoc)
        {
            var inputs = htmlDoc.DocumentNode.Descendants("input");
            foreach (var element in inputs)
            {
                string name = element.GetAttributeValue("name", "undefined");
                string value = element.GetAttributeValue("value", "");

                if (!this.ContainsKey(name))
                {
                    if (!name.Equals("undefined"))
                    {
                        Add(name, value);
                    }
                }
            }
        }

        /// <summary>
        /// Assembles all form elements and values to POST. Also html encodes the values.  
        /// </summary>
        public string AssemblePostPayload()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in this)
            {
                string value = System.Web.HttpUtility.UrlEncode(element.Value);
                sb.Append("&" + element.Key + "=" + value);
            }
            return sb.ToString().Substring(1);
        }
    }
}
