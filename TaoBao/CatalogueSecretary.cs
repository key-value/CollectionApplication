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

namespace TaoBao
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://list.bendi.taobao.com/chengdu";
            CataloguePath = @".//div[@class='main-wrap']/div[@class='col-main']/div[@class='mod']/div[@class='items']/div[@class='list']/ul/li[@class='clearfix place-item']/div[@class='item-inner clearfix']/div[@class='info']";
            PageNodePath =
               @".//div[@class='main-wrap']/div[@class='col-main']/div[@class='mod']/div[@class='k2-pagination clearfix']/div[@class='option']/a";
            NextPage = PageUrl;
            BeforePage = PageUrl;
            ImgNodePath =
                @".//div[@class='main-wrap']/div[@class='col-main']/div[@class='mod']/div[@class='items']/div[@class='list']/ul/li[@class='clearfix place-item']/div[@class='item-inner clearfix']/div[@class='photo']/a/span/img";
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
        }


        protected override Maticsoft.Model.StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            if (restaurant == null)
            {
                return new Maticsoft.Model.NullStoreInfo();
            }
            var storeInfo = new Maticsoft.Model.StoreInfo();
            storeInfo.StoreName = storeName;
            storeInfo.StoreTag = GetStoreTag(restaurant);
            storeInfo.MaxPrice = GetMaxPrice(restaurant);
            return storeInfo;
        }

        private int GetMaxPrice(HtmlNode htmlNode)
        {
            var maxPriceText = CollectionNodeText.GetNodeListInnerText(htmlNode, @".//div[@class='more-info clearfix']/div[@class='price']/span[@class='g_price g_price-highlight']/strong").Trim().Replace("¥", string.Empty).Replace("-", string.Empty);
            if (string.IsNullOrWhiteSpace(maxPriceText))
            {
                return 0;
            }
            var maxPrice = 1;
            if (int.TryParse(maxPriceText, out maxPrice))
            {
                return maxPrice;
            }
            return 0;
        }

        private string GetStoreTag(HtmlNode htmlNode)
        {
            return CollectionNodeText.GetNodeListInnerText(htmlNode, @".//div[@class='more-info clearfix']/div[@class='place-tag']/div[@class='tags']/p/a").Replace(@"&nbsp;", string.Empty).Replace(@" ", string.Empty);
        }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='clearfix']/a[@class='name']");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;//shop/5630147
            Href = hrefString;
            const string regex = @"\/shop\/(\d*)";
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

        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"../span[@class='current']");
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
