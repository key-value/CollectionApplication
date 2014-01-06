using AbstractSite;
using DianPing.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using DishesTyepTable = Maticsoft.Model.DishesTyepTable;

namespace DianPing
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _pageUrl = @"http://www.dianping.com/shop/{0}";
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl;

        public override string PageUrl
        {
            get
            {
                return string.Format(_pageUrl, StoreInfo.Fid);
            }
            set
            {
                _pageUrl = value;
            }
        }

        public List<DishType> GetDishType()
        {
            var dishTypeList = new List<DishType>();
            var dishesTypePath =
                @".//div[@class='shop-wrap']/div[@class='main']/div[@id='dish-tag']/div[@class='tab-container']/div[@class='rec-dishes tab-item active']/div/ul/li";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishNodeList = dishTypeHtmlNode.SelectNodes(dishesTypePath);
            if (dishNodeList == null || dishNodeList.Count <= 0)
            {
                return dishTypeList;
            }

            var scripNode = baseCollectionSite.BaseHtmlNode.SelectSingleNode(@".//div[@class='shop-wrap']/div[@class='main']/div[@id='dish-tag']/div[@class='tab-container']/div[@class='rec-dishes tab-item active']/div[@class='pic-list J_toggle']/ul/script");
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
            int dishID = 1;
            var dishTypeID = Guid.NewGuid();
            const string dishTypeName = @"推荐菜";
            var dishTypeInfo = new DishType
            {
                PkID = dishTypeID,
                DishName = dishTypeName,
                DishesList = new List<int>(),
            };

            foreach (var dishNode in dishNodeList)
            {
                var dishNameNode = dishNode.SelectSingleNode("./div[@class='pic-name']/a");
                var dishPriceNode = dishNode.SelectSingleNode("./div[@class='pic-name']/span");
                var dishImg = dishNode.SelectSingleNode(".//a/img");
                if (dishNameNode == null)
                {
                    continue;
                }
                var dishName = dishNameNode.InnerText;
                var dishPrice = dishPriceNode == null ? "0" : dishPriceNode.InnerText.Replace("￥", string.Empty);
                var dianPingDishes = new DianPingDishes();
                dianPingDishes.DishID = dishID;
                dianPingDishes.DishTypeID = dishTypeID.ToString();
                if (string.IsNullOrWhiteSpace(dishName))
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(dishPrice))
                {
                    dishPrice = "0";
                }
                dianPingDishes.DishName = dishName;
                dianPingDishes.DishesMoney = dishPrice;
                if (dishImg != null)
                {
                    if (dishImg.Attributes.Contains("src"))
                    {
                        dianPingDishes.PictureName = dishImg.Attributes["src"].Value;
                    }
                    else if (dishImg.Attributes.Contains("data-src"))
                    {
                        dianPingDishes.PictureName = dishImg.Attributes["data-src"].Value;
                    }
                }
                _generalEntityList.Add(dianPingDishes);
                dishTypeInfo.DishesList.Add(dianPingDishes.DishID);
                dishID += 1;
            }

            dishTypeList.Add(dishTypeInfo);

            return dishTypeList;
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }
        protected override string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            var dishNameNode = dishNode.SelectSingleNode("./div[@class='pic-name']/a");
            if (dishNameNode == null)
            {
                return string.Empty;
            }
            return dishNameNode.InnerText;
        }

        protected override decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            var dishPriceNode = dishNode.SelectSingleNode("./div[@class='pic-name']/span");
            var dishPrice = dishPriceNode == null ? "0" : dishPriceNode.InnerText.Replace("￥", string.Empty);
            decimal priceDecimal = 0;
            decimal.TryParse(dishPrice, out priceDecimal);
            return priceDecimal;
        }

        protected override string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
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


        protected override string DishesTypePath()
        {
            return @".//div[@class='shop-wrap']/div[@class='main']/div[@id='dish-tag']/div[@class='tab-container']/div[@class='rec-dishes tab-item active']/div/ul/li";
        }

        protected override string DishesPath()
        {
            return ".//li";
        }
    }
}
