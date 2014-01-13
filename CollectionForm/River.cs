using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using Maticsoft.BLL;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CollectionForm
{
    public partial class River : Form
    {
        private HtmlNode BaseHtmlNode = null;
        public River()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baseCollectionSite = new BaseCollectionSite(textBox4.Text);
            BaseHtmlNode = baseCollectionSite.BaseHtmlNodeByGBK;
            textBox1.Text = BaseHtmlNode.InnerHtml;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']";
            var basicIntroductionTextNode = BaseHtmlNode.SelectSingleNode(textBox3.Text.Trim());
            if (basicIntroductionTextNode == null)
            {
                textBox2.Text = string.Empty;
                return;
            }
            textBox2.Text = basicIntroductionTextNode.InnerHtml;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var htmlWeb = new HtmlWeb();
            htmlWeb.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; .NET4.0E";
            var htmlDoc = htmlWeb.Load(@"http://u.xmfish.com/album/32176");//, "10.0.1.200", 8888, "yinyazuolun", "zero452!");

            var a = new Cookie("Cookies", "24a79_winduser =UwQGDVMHVD8AAVdTVg9dBgcBVldSCgRSBgBUAwANVAkOBQdQAFIFWmg6HV9bTVBPEFdVQghsUwQ", "/", "u.xmfish.com");
            var _catalogueHtmlNode = htmlDoc.DocumentNode;
            textBox1.Text = _catalogueHtmlNode.InnerHtml;


            //var wc = new WebClient();
            //wc.BaseAddress = "http://u.xmfish.com/album/32176";
            //wc.Headers.Add("Cookie", "cna=YU9IC0AJp00CARubZ2P+U8IH");
            //wc.Encoding = Encoding.GetEncoding("gbk");
            //var doc = new HtmlDocument();
            //string html = wc.DownloadString("user/6971070.html");
            //doc.LoadHtml(html);
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://u.xmfish.com/album/32176");
            myReq.CookieContainer = new CookieContainer();
            myReq.CookieContainer.Add(a);
            HttpWebResponse resp = myReq.GetResponse() as HttpWebResponse;
            Stream s = resp.GetResponseStream();
            StreamReader sr = new StreamReader(s);

            String text = sr.ReadToEnd();
            sr.Close();
            s.Close();
        }
    }
}
