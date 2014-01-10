using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using DishesTyep = Maticsoft.Model.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace AbstractSite
{
    public abstract class AbstractDishes : AbstractMainSite
    {
        protected StorePicture StorePictureBll = new StorePicture();

        protected AbstractDishes()
        {
            DishList = new List<IDishSiteModel>();
            NextPageTextName = "下一页";
        }
        public string PageUrl { get; set; }

        public string PicType { get; set; }

        public virtual bool Conversion()
        {
            return false;
        }

        public virtual string GetDishUrl(DishesTyep dishType)
        {
            return dishType.DishHref;
        }

        public virtual List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            foreach (var dishType in dishesTyepList)
            {
                var nextPageUrl = GetDishUrl(dishType);
                while (!string.IsNullOrEmpty(nextPageUrl))
                {
                    var baseCollectionSite = new BaseCollectionSite(nextPageUrl);
                    var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
                    var dishesNodeList = dishTypeHtmlNode.SelectNodes(DishPath());
                    if (dishesNodeList == null)
                    {
                        continue;
                    }
                    SaveIngDish(dishType.DishesTypeName, string.Empty);
                    foreach (var dishesNode in dishesNodeList)
                    {
                        var dishes = GetDishes(dishType, dishesNode);
                        if (dishes.IsNull)
                        {
                            continue;
                        }
                        dishType.DishesList.Add(dishes);
                        SaveIngDish(dishType.DishesTypeName, dishes.DishesName);
                    }
                    nextPageUrl = GetNextPageUrl(dishTypeHtmlNode);
                }
            }
            FinishSaveDish();
            return dishesTyepList;
        }

        protected virtual string GetNextPageUrl(HtmlNode dishTypeHtmlNode)
        {
            var nextPageUrlPath = NextPageUrlPath();
            if (string.IsNullOrWhiteSpace(nextPageUrlPath))
            {
                return string.Empty;
            }
            var pageUrlNode = CollectionNodeText.GetNodeContainsInnerText(dishTypeHtmlNode, nextPageUrlPath, NextPageTextName);
            if (pageUrlNode == null)
            {
                return string.Empty;
            }
            return NextPageUrl(pageUrlNode);
        }
        protected virtual string NextPageUrl(HtmlNode pageUrlNode)
        {
            return pageUrlNode.GetPicturePath();
        }

        protected string NextPageTextName { get; set; }

        protected virtual string NextPageUrlPath()
        {
            return string.Empty;
        }

        public Maticsoft.Model.DishesEntity GetDishes(DishesTyep dishesTyep, HtmlNode dishesNode)
        {
            var dishes = new Maticsoft.Model.DishesEntity();
            dishes.DishesID = Guid.NewGuid().ToString();
            dishes.DishesName = GetDishesName(dishesNode);
            dishes.DishesTypeID = dishesTyep.DishesTypeID;
            dishes.PictureHref = GetPictureHref(dishesNode);
            dishes.DishesBrief = GetDishesBrief(dishesNode);
            dishes.DishesMoney = GetDishesMoney(dishesNode);
            dishes.DishesUnit = GetDishesUnit(dishesNode);
            if (string.IsNullOrWhiteSpace(dishes.DishesName))
            {
                dishes.IsNull = true;
            }
            if (dishes.DishesMoney == 0)
            {
                dishes.IsCurrentPrice = true;
            }
            return dishes;
        }

        protected virtual string GetDishesUnit(HtmlNode dishesNode)
        {
            return "份";
        }
        protected abstract string GetDishesName(HtmlNode dishesNode);
        protected abstract decimal GetDishesMoney(HtmlNode dishesNode);
        protected abstract string GetDishesBrief(HtmlNode dishesNode);
        protected abstract string GetPictureHref(HtmlNode dishesNode);

        public List<IDishSiteModel> DishList { get; set; }

        public abstract string DishPath();
    }
}
