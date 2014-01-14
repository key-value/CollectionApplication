using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace GaFan
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
        }

        public List<DishType> GetDishType()
        {
            var dishTypeList = new List<DishType>();
            var dishesTypePath = @"//*[@id='menu']/[@class='clearboth']";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishTypeNodeList = dishTypeHtmlNode.SelectNodes(dishesTypePath);
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                var dishTypeID = Guid.NewGuid();
                var dishTypeName = dishTypeNode.InnerText;
                var dishTypeInfo = new DishType
                {
                    PkID = dishTypeID,
                    DishName = dishTypeName
                };
                dishTypeList.Add(dishTypeInfo);
                var dishNode = dishTypeNode.NextSibling;
                int dishID = 1;
                while (dishNode != null)
                {
                    var dishInfoList = dishNode.SelectNodes("//li");
                    if (dishInfoList == null)
                    {
                        break;
                    }
                    foreach (var dishInfo in dishInfoList)
                    {
                        var dishNameNode = dishInfo.SelectSingleNode(".//p/strong");
                        if (dishNameNode != null)
                        {
                            var dishName = dishNameNode.Attributes["title"].Value;
                            var dishPriceNode = dishInfo.SelectSingleNode(".//p/span");
                            var dishImg = dishInfo.SelectSingleNode(".//p/img");
                            var dishPrice = dishPriceNode != null ? dishInfo.InnerText.Replace("￥", string.Empty).Replace("元", string.Empty).Trim() : string.Empty;

                        }
                    }
                    dishNode = dishNode.NextSibling;
                }
            }
            return dishTypeList;
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }

        protected override string DishesTypePath()
        {
            return string.Empty;
        }

        protected override string DishesPath()
        {
            return string.Empty;
        }

        protected override string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            return string.Empty;
        }

        protected override decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            return 0;
        }

        protected override string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
        {
            return string.Empty;
        }

        protected override HtmlNodeCollection GetSiteDishTypeList()
        {
            return new HtmlNodeCollection(null);
        }
    }
}
