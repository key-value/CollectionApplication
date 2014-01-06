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

namespace XmFish
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://food.xmfish.com/";
            CataloguePath = @".//div[@class='grid-content']/div[@class='section']/div[@class='grid-wrap']/div[@class='grid-c38 biz-list']/div[@class='item fn-clear']";
            PageNodePath =
               @".//div[@class='grid-content']/div[@class='section']/div[@class='grid-wrap']/div[@class='grid-c38 biz-list']/div[@class='pagination']/ul/li[@class='active']/a";
            NextPage = @"http://food.xmfish.com/";
            BeforePage = @"http://food.xmfish.com/";
            BeforePageText = @"«";
            NextPage = @"»";
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
            storeInfo.StoreTag = GetStoreTag(restaurant);
            storeInfo.StorePhone = GetStorePhone(restaurant);
            return storeInfo;
        }

        private string GetStorePhone(HtmlNode htmlNode)
        {
            var storePhoneNodeList = htmlNode.SelectNodes(@".//div[@class='content']/p");
            if (storePhoneNodeList == null)
            {
                return string.Empty;
            }
            foreach (var storePhoneNode in storePhoneNodeList)
            {
                if (storePhoneNode.InnerText.Contains("电话:"))
                {
                    return storePhoneNode.InnerText.Replace("电话:", string.Empty).Trim();
                }
            }
            return string.Empty;
        }

        private string GetStoreTag(HtmlNode htmlNode)
        {
            var storeTagNodeList = htmlNode.SelectNodes(@".//div[@class='content']/p");
            if (storeTagNodeList == null)
            {
                return string.Empty;
            }
            foreach (var storeTagNode in storeTagNodeList)
            {
                if (storeTagNode.InnerText.Contains("特色:"))
                {
                    return storeTagNode.InnerText.Replace("特色:", string.Empty).Trim();
                }
            }
            return string.Empty;
        }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='content']/h4/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = hrefString;
            const string regex = @"(http):\/\/u.xmfish.com\/biz\/(\d*)";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[2].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[2].Value;
            Title = fidNode.InnerText;
        }

        public string GetAddress(HtmlNode htmlNode)
        {
            var storeNodeList = htmlNode.SelectNodes(@".//div[@class='content']/p");
            if (storeNodeList == null)
            {
                return string.Empty;
            }
            foreach (var storeNode in storeNodeList)
            {
                if (storeNode.InnerText.Contains("地址:"))
                {
                    return storeNode.InnerText.Replace("地址:", string.Empty).Trim();
                }
            }
            return string.Empty;
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["src"].Value;
        }
        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"../..//li[@class='active']/a");
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
