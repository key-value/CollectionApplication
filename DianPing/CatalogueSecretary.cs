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

namespace DianPing
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.dianping.com/";
            CataloguePath = @".//div[@class='main page-asa Fix']/div[@class='section']/div[@class='section-inner']/div/dl/dt/dd";
            PageNodePath =
               @".//div[@class='main page-asa Fix']/div[@class='section']/div[@class='section-inner']/div[@class='box searchList searchResult searchList-v1009 listModeView']/div[@class='Pages']/a";
            NextPage = @"http://www.dianping.com";
            BeforePage = @"http://www.dianping.com";
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
            //storeInfo.StorePhone = GetStorePhone(restaurant);
            storeInfo.MaxPrice = GetMaxPrice(restaurant);
            return storeInfo;
        }

        private int GetMaxPrice(HtmlNode htmlNode)
        {
            var maxPriceText = CollectionNodeText.GetNodeListInnerText(htmlNode, @".//strong[@class='average']").Trim().Replace("¥", string.Empty).Replace("-", string.Empty);
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
            return CollectionNodeText.GetNodeListInnerText(htmlNode, @".//li[@class='tags']").Replace(@"&nbsp;", string.Empty).Replace(@" ", string.Empty);
        }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//li[@class='shopname']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;//shop/5630147
            Href = @"http://www.dianping.com" + hrefString;
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
            var spanNode = pageNode.SelectSingleNode(@"../span[@class='PageSel']");
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
