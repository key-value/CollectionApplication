using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using ISite;
using Maticsoft.Model;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace TaoBao
{
    public class DishesSecretary : AbstractDishes, IDishes
    {
        private StorePicture storePictureBll = new StorePicture();
        Maticsoft.BLL.Dishes dishesBll = new Maticsoft.BLL.Dishes();
        public DishesSecretary()
        {
            DishList = new List<IDishSiteModel>();
            PageUrl = @"http://sz.echiele.com";
        }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
            if (string.IsNullOrEmpty(dishSiteModel.DishName))
            {
                return;
            }
            var dishes = new Maticsoft.Model.Dishes
            {
                DishesID = Guid.NewGuid().ToString(),
                DishesName = dishSiteModel.DishName,
                DishesMoney = dishSiteModel.DishesMoney,
                dishTypeID = dishSiteModel.DishTypeID,
                StoreId = storeID,
                DishesUnit = string.IsNullOrEmpty(dishSiteModel.DishesUnit) ? "份" : dishSiteModel.DishesUnit
            };
            if (!string.IsNullOrEmpty(dishSiteModel.PictureName))
            {
                var storePicture = new Maticsoft.Model.StorePicture();
                storePicture.PID = Guid.NewGuid().ToString();
                storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
                storePicture.PicType = "Food";
                storePicture.PicturePath = dishSiteModel.PictureName;
                storePicture.StoreId = storeID;
                storePictureBll.Add(storePicture);
                dishes.PictureName = storePicture.PictureName;
            }
            dishesBll.Add(dishes);
        }

        public override List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            return dishesTyepList;
        }

        protected override string GetDishesName(HtmlAgilityPack.HtmlNode dishesNode)
        {
            return string.Empty;
        }

        protected override decimal GetDishesMoney(HtmlAgilityPack.HtmlNode dishesNode)
        {
            return 0;
        }

        protected override string GetDishesBrief(HtmlAgilityPack.HtmlNode dishesNode)
        {
            return string.Empty;
        }

        protected override string GetPictureHref(HtmlAgilityPack.HtmlNode dishesNode)
        {
            return string.Empty;
        }

        public override string DishPath()
        {
            return string.Empty;
        }
    }
}
