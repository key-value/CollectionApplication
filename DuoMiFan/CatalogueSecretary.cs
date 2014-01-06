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

namespace DuoMiFan
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.scfood.net";
            CataloguePath = @".//li[@class='res_list_Rlist_li02']";
            PageNodePath =
               @".//div[@id='res_pagebody_zct']/div[@id='res_list_Rbk']/div[@class='res_list_tab']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@class='res_list_Rlist']/div[@id='res_pagefy']/a";
            ImgNodePath = @"../.././/ul/li[@class='res_list_Rlist_li01']/a/img";
            NextPage = @"http://www.134.cn";
            BeforePage = @"http://www.134.cn";
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
            //GetAddress(restaurant);
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
            int minPrice;
            int maxPrice;
            PeoplePrice(restaurant, out minPrice, out maxPrice);
            storeInfo.MaxPrice = maxPrice;
            storeInfo.MinPrice = minPrice;
            storeInfo.StoreTag = GetStoreTag(restaurant);
            return storeInfo;
        }

        private string GetStoreTag(HtmlNode htmlNode)
        {
            return CollectionNodeText.GetNodeListContainsInnerText(htmlNode, @".//ul", "菜系：");
        }


        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='res_list_Rlist_name overhide']/span[@class='res_list_Rlist_name_span01']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format(@"http://www.134.cn{0}", hrefString);
            const string regex = @"\/[\w]*\/[\w]*\/[\w]*\/(\d*)";//Index/hall/id/450
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
            return CollectionNodeText.GetNodeListContainsInnerText(htmlNode, @".//ul", "地址：");
        }

        public void PeoplePrice(HtmlNode htmlNode, out int minPrice, out int maxPrice)
        {
            minPrice = 0;
            maxPrice = 0;
            var priceText = CollectionNodeText.GetNodeInnerText(htmlNode, @".//ul/li[@class='res_list_Rlist_jbxx02 f_shui bb']");
            var priceList = priceText.Replace("&nbsp;", string.Empty).Replace("￥", string.Empty).Split('-');
            if (priceList.Count() != 2)
            {
                return;
            }
            decimal minPriceNum = 0;
            decimal.TryParse(priceList[0], out minPriceNum);
            minPrice = (int)minPriceNum;
            decimal maxPriceNum = 0;
            decimal.TryParse(priceList[1], out maxPriceNum);
            maxPrice = (int)maxPriceNum;
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
