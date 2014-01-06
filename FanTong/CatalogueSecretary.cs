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

namespace FanTong
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.fantong.com/";
            CataloguePath = @".//div[@class='w-out clearfloat']/div[@class='left']/div[@class='listbox']/div[@class='result_item ']";
            PageNodePath =
               @".//div[@class='w-out clearfloat']/div[@class='left']/div[@class='listbox']/div[@class='pagination']/a";
            ImgNodePath = @".//div[@class='content']/dl/dt/a/img";
            NextPage = PageUrl;
            BeforePage = PageUrl;
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
            var storeTagNodeList = htmlNode.SelectNodes(@".//div[@class='content']/dl/dd/p[@class='cf']/span/a[@class='blue']");
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
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='content']/dl/dd/h2/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format(@"http://www.fantong.com{0}", hrefString);
            const string regex = @"\/[\w]*-(\d*)\/";
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
            var storeNodeList = htmlNode.SelectNodes(@".//div[@class='content']/dl/dd/p[@class='cf']/span[@class='s2']");
            if (storeNodeList == null)
            {
                return string.Empty;
            }
            var storeNode = storeNodeList.LastOrDefault();
            return storeNode != null ? storeNode.InnerText : string.Empty;
        }

        public int MaxPrice(HtmlNode htmlNode)
        {
            var priceNode = htmlNode.SelectSingleNode(@".//div[@class='content']/dl/dd/p/span[@class='per']");
            if (priceNode == null)
            {
                return 0;
            }
            var priceText = priceNode.InnerText.Replace("¥", string.Empty).Replace("￥", string.Empty);
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
            var spanNode = pageNode.SelectSingleNode(@"..//span");
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
