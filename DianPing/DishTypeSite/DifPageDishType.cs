using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtility;
using HtmlAgilityPack;
using Maticsoft.BLL;

namespace DianPing.DishTypeSite
{
    public class DifPageDishType : IDishTypeChange
    {
        public string PageUrl
        {
            get { return @"http://www.dianping.com/shop/{0}/menu"; }
        }

        public string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            return CollectionNodeText.GetNodeInnerText(dishNode, @".//span[@class='name']");
        }

        public decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            var dishPriceNode = dishNode.SelectSingleNode(".//span[@class='price']");
            var dishPrice = dishPriceNode == null ? "0" : dishPriceNode.InnerText.Replace("¥", string.Empty).ClearSiteCode();
            decimal priceDecimal = 0;
            decimal.TryParse(dishPrice, out priceDecimal);
            return priceDecimal;
        }

        public string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
        {
            return string.Empty;
        }

        public string DishesTypePath()
        {
            return @".//div[@class='menus-main']/div[@class='menus-list']/ul[@class='menus-con']/li/div/div[@class='hd']/h6";
        }

        public string DishesPath()
        {
            return @"./../../div[@class='greens-name']/ul/li[@class='dish-item']";
        }

        public HtmlAgilityPack.HtmlNodeCollection GetDishInfoList(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            return new HtmlNodeCollection(null);
        }
    }
}
