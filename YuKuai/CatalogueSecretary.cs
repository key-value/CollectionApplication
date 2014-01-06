using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;

namespace YuKuai
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.yukuai.com/";
            CataloguePath = @".//div[@class='res-content clearfix yk-grid-col2 mt10']/div[@class='yk-grid-main-res fl mr10']/div[@class='res-main']/div[@class='res-result mt10']/div[@class='list-content']/ul/li";
            PageNodePath =
               @".//div[@class='res-content clearfix yk-grid-col2 mt10']/div[@class='yk-grid-main-res fl mr10']/div[@class='res-main']/div[@class='ls-result-page clearfix mb20']/div[@class='fr yk-page mt20']/a";
            ImgNodePath = @".//div[@class='clearfix']/div[@class='fl ls-img']/a/img";
            NextPage = @"http://www.yukuai.com/chi/";
            BeforePage = @"http://www.yukuai.com/chi/";
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
            GetAddress(restaurant);
        }


        protected override Maticsoft.Model.StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            if (restaurant == null)
            {
                return new Maticsoft.Model.NullStoreInfo();
            }
            var storeInfo = new Maticsoft.Model.StoreInfo();
            storeInfo.StoreAddress = GetAddress(restaurant);
            storeInfo.StoreName = storeName;
            storeInfo.MaxPrice = MaxPrice(restaurant);
            storeInfo.StoreTag = GetStoreTag(restaurant);
            return storeInfo;
        }

        private string GetStoreTag(HtmlNode htmlNode)
        {
            var storeTagNodeList = htmlNode.SelectNodes(@".//div[@class='clearfix']/div[@class='fl ls-info']/div[@class='clearfix']/div[@class='fl clearfix']/div[@class='fl ls-detail']/div[@class='clearfix']/p/a[@class='mr5']");
            if (storeTagNodeList == null)
            {
                return string.Empty;
            }
            var storeTagSb = new StringBuilder();
            foreach (var storeTagNode in storeTagNodeList)
            {
                storeTagSb.Append(storeTagNode.InnerText);
            }
            return storeTagSb.ToString();
        }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='clearfix']/div[@class='fl ls-info']/div[@class='clearfix']/h4[@class='fl']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format(@"http://www.yukuai.com{0}", hrefString);
            const string regex = @"\/[\w]*\/(\d*).[\w]*";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            Title = fidNode.InnerText;
        }

        public string GetAddress(HtmlNode htmlNode)
        {
            var storeNode = htmlNode.SelectSingleNode(@".//div[@class='clearfix']/div[@class='fl ls-info']/div[@class='clearfix']/div[@class='fl clearfix']/div[@class='fl ls-detail']/div[@class='clearfix']/p/span[@class='gray mr5']");
            if (storeNode == null)
            {
                return string.Empty;
            }
            return storeNode.InnerText;
        }

        public int MaxPrice(HtmlNode htmlNode)
        {
            var priceNodeList = htmlNode.SelectNodes(@".//div[@class='clearfix']/div[@class='fl ls-info']/div[@class='clearfix']/div[@class='fl clearfix']/div[@class='fl ls-detail']/div[@class='clearfix']/p[last()]");
            if (priceNodeList == null)
            {
                return 0;
            }
            var priceText = string.Empty;
            foreach (var priceNode in priceNodeList)
            {
                if (priceNode.InnerText.Contains("￥"))
                {
                    priceText = priceNode.InnerText.Replace("¥", string.Empty).Replace("￥", string.Empty);
                }
            }
            decimal priceNum = 0;
            decimal.TryParse(priceText, out priceNum);
            return (int)priceNum;
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["src"].Value;
        }
        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"..//span[@class='current']");
            if (spanNode != null)
            {
                var intpageNum = 1;
                if (int.TryParse(spanNode.InnerText, out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
        }
    }
}
