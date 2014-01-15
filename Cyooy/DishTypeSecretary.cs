using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using AbstractSite;
using Cyooy.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.Model.DishesTyep;

namespace Cyooy
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl = @"http://www.cyooy.com/shop/{0}.html";

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
            var dishesTypePath = @".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='menu']/h3[@class='clearboth']";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishTypeNodeList = dishTypeHtmlNode.SelectNodes(dishesTypePath);
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            int dishID = 1;
            var dishTypeID = Guid.NewGuid();
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                dishTypeID = Guid.NewGuid();
                var dishTypeName = dishTypeNode.InnerText;
                var dishTypeInfo = new DishType
                {
                    PkID = dishTypeID,
                    DishName = dishTypeName,
                    DishesList = new List<int>(),
                };
                var dishNode = dishTypeNode.NextSibling;
                while (dishNode != null)
                {
                    if (dishNode.InnerHtml.Contains("返回顶部"))
                    {
                        break;
                    }
                    var dishInfoList = dishNode.SelectNodes(".//li");
                    dishNode = dishNode.NextSibling;
                    if (dishInfoList == null)
                    {
                        continue;
                    }
                    foreach (var dishInfo in dishInfoList)
                    {
                        var dishNameNode = dishInfo.SelectSingleNode(".//p/strong");
                        if (dishNameNode != null)
                        {
                            var dishName = dishNameNode.Attributes["title"].Value;
                            if (string.IsNullOrEmpty(dishName))
                            {
                                continue;
                            }
                            var dishPriceNode = dishInfo.SelectSingleNode(".//p/span");
                            var dishImg = dishInfo.SelectSingleNode("./img");
                            var dishPrice = dishPriceNode != null ? dishPriceNode.InnerText.Replace("￥", string.Empty).Replace("元", string.Empty).Replace("&nbsp;", string.Empty).Trim() : string.Empty;
                            var cyooyDishes = new CyooyDishes();
                            cyooyDishes.DishID = dishID;
                            cyooyDishes.DishTypeID = dishTypeID.ToString();
                            cyooyDishes.DishName = dishName;
                            cyooyDishes.DishesMoney = dishPrice;
                            cyooyDishes.DishesUnit = "份";
                            if (dishImg != null)
                            {
                                cyooyDishes.PictureName = @"http://www.cyooy.com" + dishImg.Attributes["src"].Value;
                            }
                            _generalEntityList.Add(cyooyDishes);
                            dishTypeInfo.DishesList.Add(cyooyDishes.DishID);
                            dishID += 1;
                            continue;
                        }
                        dishNameNode = dishInfo.SelectSingleNode(".//div[@class='foodName']");
                        if (dishNameNode != null)
                        {
                            var dishName = dishNameNode.Attributes["title"].Value;
                            var dishPriceNode = dishInfo.SelectSingleNode(".//div[@class='price']");
                            var dishPrice = dishPriceNode != null ? dishPriceNode.InnerText.Replace("￥", string.Empty).Replace("元", string.Empty).Trim() : string.Empty;
                            var cyooyDishes = new CyooyDishes();
                            cyooyDishes.DishID = dishID;
                            cyooyDishes.DishTypeID = dishTypeID.ToString();
                            cyooyDishes.DishName = dishName;
                            cyooyDishes.DishesMoney = dishPrice;
                            cyooyDishes.DishesUnit = "份";

                            _generalEntityList.Add(cyooyDishes);
                            dishTypeInfo.DishesList.Add(cyooyDishes.DishID);
                            dishID += 1;
                        }
                    }
                }
                dishTypeList.Add(dishTypeInfo);
            }
            return dishTypeList;
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }

        private string _pictureUrl;
        public string PictureUrl
        {
            get { return @"http://www.cyooy.com/"; }
            set { _pictureUrl = value; }
        }

        protected override string DishesTypePath()
        {
            return @".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='menu']/h3[@class='clearboth']";
        }

        protected override string DishesPath()
        {
            throw new NotImplementedException();
        }

        protected override string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        public override List<DishesTyep> UpdateDishType()
        {
            var dishTypeList = new List<DishesTyep>();
            var dishTypeNodeList = GetSiteDishTypeList();
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                Guid dishTypeID = Guid.NewGuid();
                var dishTypeName = GetDishTypeName(dishTypeNode);
                var dishTypeInfo = new DishesTyep
                {
                    DishesTypeID = Guid.NewGuid().ToString(),
                    DishesTypeName = dishTypeName,
                    BusinessID = StoreInfo.OldStoreId,
                    CreateDate = DateTime.Now,
                };
                var dishNode = dishTypeNode.NextSibling;
                while (dishNode != null)
                {
                    if (dishNode.InnerHtml.Contains("返回顶部"))
                    {
                        break;
                    }
                    var dishInfoList = dishNode.SelectNodes(".//li");
                    dishNode = dishNode.NextSibling;
                    if (dishInfoList == null)
                    {
                        continue;
                    }
                    foreach (var dishInfo in dishInfoList)
                    {
                        var dishNameNode = dishInfo.SelectSingleNode(".//p/strong");
                        if (dishNameNode != null)
                        {
                            var dishName = dishNameNode.Attributes["title"].Value;
                            if (string.IsNullOrEmpty(dishName))
                            {
                                continue;
                            }
                            var dishPriceNode = dishInfo.SelectSingleNode(".//p/span");
                            var dishImg = dishInfo.SelectSingleNode("./img");
                            var dishPriceText = dishPriceNode != null ? dishPriceNode.InnerText.Replace("￥", string.Empty).Replace("元", string.Empty).Replace("&nbsp;", string.Empty).Trim() : string.Empty;
                            var cyooyDishes = new DishesEntity();
                            decimal dishPrice = 0;
                            decimal.TryParse(dishPriceText, out dishPrice);
                            cyooyDishes.DishesTypeID = dishTypeID.ToString();
                            cyooyDishes.DishesName = dishName;
                            cyooyDishes.DishesMoney = dishPrice;
                            cyooyDishes.DishesID = Guid.NewGuid().ToString();
                            cyooyDishes.DishesUnit = "份";
                            if (cyooyDishes.DishesMoney <= 0)
                            {
                                cyooyDishes.IsCurrentPrice = true;
                            }
                            if (dishImg != null)
                            {
                                cyooyDishes.PictureHref = @"http://www.cyooy.com" + dishImg.Attributes["src"].Value;
                            }
                            dishTypeInfo.DishesList.Add(cyooyDishes);
                            continue;
                        }
                        dishNameNode = dishInfo.SelectSingleNode(".//div[@class='foodName']");
                        if (dishNameNode != null)
                        {
                            var dishName = dishNameNode.Attributes["title"].Value;
                            var dishPriceNode = dishInfo.SelectSingleNode(".//div[@class='price']");
                            var dishPriceText = dishPriceNode != null ? dishPriceNode.InnerText.Replace("￥", string.Empty).Replace("元", string.Empty).Trim() : string.Empty;
                            var cyooyDishes = new DishesEntity();
                            decimal dishPrice = 0;
                            decimal.TryParse(dishPriceText, out dishPrice);
                            cyooyDishes.DishesTypeID = dishTypeID.ToString();
                            cyooyDishes.DishesName = dishName;
                            cyooyDishes.DishesMoney = dishPrice;
                            cyooyDishes.DishesID = Guid.NewGuid().ToString();
                            cyooyDishes.DishesUnit = "份";
                            if (cyooyDishes.DishesMoney <= 0)
                            {
                                cyooyDishes.IsCurrentPrice = true;
                            }
                            dishTypeInfo.DishesList.Add(cyooyDishes);
                        }
                    }
                }
                dishTypeList.Add(dishTypeInfo);
            }
            return dishTypeList;
        }
    }
}
