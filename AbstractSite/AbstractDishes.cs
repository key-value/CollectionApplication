using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using DishesTyep = Maticsoft.Model.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace AbstractSite
{
    public abstract class AbstractDishes
    {
        protected StorePicture StorePictureBll = new StorePicture();
        public AbstractDishes()
        {
            DishList = new List<IDishSiteModel>();
        }
        public string PageUrl { get; set; }

        public string PicType { get; set; }

        public virtual bool Conversion()
        {
            return false;
        }

        public List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            foreach (var dishType in dishesTyepList)
            {
                var baseCollectionSite = new BaseCollectionSite(PageUrl);
                var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
                var dishesNodeList = dishTypeHtmlNode.SelectNodes(dishType.DishHref);
                if (dishesNodeList == null)
                {
                    continue;
                }

                foreach (var dishesNode in dishesNodeList)
                {
                    var dishes = GetDishes(dishType, dishesNode);
                    if (dishes.IsNull)
                    {
                        continue;
                    }
                    dishType.DishesList.Add(dishes);
                }
            }
            return dishesTyepList;
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
            if (string.IsNullOrWhiteSpace(dishes.DishesName))
            {
                dishes.IsNull = true;
            }
            return dishes;
        }

        protected abstract string GetDishesName(HtmlNode dishesNode);
        protected abstract decimal GetDishesMoney(HtmlNode dishesNode);
        protected abstract string GetDishesBrief(HtmlNode dishesNode);
        protected abstract string GetPictureHref(HtmlNode dishesNode);

        public List<IDishSiteModel> DishList { get; set; }

        public abstract string DishPath();
    }
}
