using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApplicationUtility
{
    public class CustomTabpage
    {
        public CustomTabpage()
        {
            //添加webBrowser 相关的响应事件
            //WebBrowser = new System.Windows.Forms.WebBrowser();
            //WebBrowser.ScriptErrorsSuppressed = true;

        }
        public System.Windows.Forms.WebBrowser WebBrowser;
        private string _Navigate;
        //***********************************************//
        //                                               //
        // 把WebBrowser的Navigate方法转变为TabPage类     //
        // 的Navigate属性                                //
        //                                               //
        //***********************************************//
        public string Navigate
        {
            get { return _Navigate; }
            set
            {
                _Navigate = value;
                if (WebBrowser != null)
                {
                    if (String.IsNullOrEmpty(_Navigate)) return;
                    if (_Navigate.Equals("about:blank")) return;
                    if (!_Navigate.StartsWith("http://")) _Navigate = "http://" + _Navigate;
                    try
                    {
                        WebBrowser.Navigate(new Uri(_Navigate));
                    }
                    catch (System.UriFormatException)
                    {
                        return;
                    }

                }
            }
        }

        public HtmlDocument HdHtmlDocument;
        //***********************************************//
        //                                               //
        //                  加载中事件                   //
        //                                               //
        //***********************************************//
        void webBrowser_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e)
        {
            ////当点击网页跳转时,使地址栏重新获得跳转后的地址           
            string strurl = this.WebBrowser.Document.ActiveElement.GetAttribute("href");
            //string strurl = webBrowser.StatusText;
            if (!strurl.Contains("http://"))
            {
                strurl = "http://" + strurl;
            }
            //this.Text = strurl;
            //this.pParentWin.Text = strurl;
        }

    }
}
