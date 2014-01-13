using AbstractSite;
using DianPing.DishTypeSite;
using DianPing.Model;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;

namespace DianPing
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public IDishTypeChange DishTypeChange = null;
        public DishTypeSecretary()
        {
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
            const string dishesTypePath = @".//div[@class='shop-wrap']/div[@class='main']/div[@id='dish-tag']/div[@class='tab-container']/div[@class='rec-dishes tab-item active']/div/ul/li";
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

        protected override string GetDishName(HtmlNode dishNode)
        {
            return DishTypeChange.GetDishName(dishNode);
        }

        protected override decimal GetDishPrice(HtmlNode dishNode)
        {
            return DishTypeChange.GetDishPrice(dishNode);
        }

        protected override string GetDishImg(HtmlNode dishNode)
        {
            return DishTypeChange.GetDishImg(dishNode);
        }


        protected override string DishesTypePath()
        {
            return DishTypeChange.DishesTypePath();
        }

        protected override string DishesPath()
        {
            return DishTypeChange.DishesPath();
        }

        protected override HtmlNodeCollection GetDishInfoList(HtmlNode dishTypeNode)
        {
            if (StoreInfo.DishTypeSite)
            {
                return base.GetDishInfoList(dishTypeNode);
            }
            else
            {
                return DishTypeChange.GetDishInfoList(dishTypeNode);
            }
        }

        protected override HtmlNodeCollection GetSiteDishTypeList()
        {
            if (StoreInfo.DishTypeSite)
            {
                DishTypeChange = new DifPageDishType();
                _pageUrl = DishTypeChange.PageUrl;
            }
            else
            {
                DishTypeChange = new SamePageDishType();
                _pageUrl = DishTypeChange.PageUrl;
            }
            return base.GetSiteDishTypeList();
        }
    }
}
