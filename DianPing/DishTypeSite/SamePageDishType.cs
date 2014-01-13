using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Maticsoft.BLL;

namespace DianPing.DishTypeSite
{
    class SamePageDishType : IDishTypeChange
    {
        public string GetDishName(HtmlNode dishNode)
        {
            var dishNameNode = dishNode.SelectSingleNode("./div[@class='pic-name']/a");
            if (dishNameNode == null)
            {
                return string.Empty;
            }
            return dishNameNode.InnerText.Trim();
        }

        public decimal GetDishPrice(HtmlNode dishNode)
        {
            var dishPriceNode = dishNode.SelectSingleNode("./div[@class='pic-name']/span");
            var dishPrice = dishPriceNode == null ? "0" : dishPriceNode.InnerText.Replace("￥", string.Empty);
            decimal priceDecimal = 0;
            decimal.TryParse(dishPrice, out priceDecimal);
            return priceDecimal;
        }

        public string GetDishImg(HtmlNode dishNode)
        {
            var pictureHref = string.Empty;
            var dishImg = dishNode.SelectSingleNode(".//a/img");
            if (dishImg.Attributes.Contains("src"))
            {
                pictureHref = dishImg.Attributes["src"].Value;
            }
            else if (dishImg.Attributes.Contains("data-src"))
            {
                pictureHref = dishImg.Attributes["data-src"].Value;
            }
            return pictureHref;
        }


        public string DishesTypePath()
        {
            return @".//div[@class='shop-wrap']/div[@class='main']/div/div[@class='tabs']/ul/li/span[@class='active']/a[@class='ga-menu']";
        }

        public string DishesPath()
        {
            // return ".//li";/div[@class='shop-wrap']/div[@class='main']/div[@id='dish-tag']/div[@class='tab-container']
            return @"./../../../../..//div[@class='rec-dishes tab-item active']/div[@class='pic-list J_toggle']/ul/li";
        }

        public HtmlNodeCollection GetDishInfoList(HtmlNode dishTypeNode)
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishNodeList = dishTypeNode.SelectNodes(DishesPath());
            if (dishNodeList == null || dishNodeList.Count <= 0)
            {
                return new HtmlNodeCollection(null);
            }
            var scripNode = dishTypeNode.SelectSingleNode(@"./../../../../..//div[@class='rec-dishes tab-item active']/div[@class='pic-list J_toggle']/ul/script");
            if (scripNode != null && !string.IsNullOrWhiteSpace(scripNode.InnerText))
            {
                var liNodeList = baseCollectionSite.BaseHtmlNodeCollection(scripNode.InnerText);
                if (liNodeList != null)
                {
                    var dishLiList = liNodeList.SelectNodes(".//li");
                    if (dishLiList != null)
                    {
                        foreach (var dishLi in dishLiList)
                        {
                            dishNodeList.Add(dishLi);
                        }
                    }
                }
            }
            return dishNodeList;
        }

        public string PageUrl
        {
            get
            {
                return @"http://www.dianping.com/shop/{0}";
            }
        }
    }
}
