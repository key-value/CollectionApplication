using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ISite;
using Maticsoft.Model;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace Cyooy
{
    public class DishesSecretary : IDishes
    {
        private StorePicture storePictureBll = new StorePicture();
        Maticsoft.BLL.Dishes dishesBll = new Maticsoft.BLL.Dishes();
        public DishesSecretary()
        {
            DishList = new List<IDishSiteModel>();
            PageUrl = @"www.cyooy.com";
        }
        public string PageUrl { get; set; }

        public string PicType { get; set; }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {

            string regex = @"([\u4E00-\u9FA5]*)（([\u4E00-\u9FA5]*)）";
            var dishName = dishSiteModel.DishName;
            if (Regex.IsMatch(dishSiteModel.DishName, regex))
            {
                var matchCollection = Regex.Match(dishSiteModel.DishName, regex);
                dishName = matchCollection.Groups[1].Value.Trim();
                dishSiteModel.DishesUnit = string.IsNullOrEmpty(matchCollection.Groups[2].Value.Trim())
                    ? "份"
                    : matchCollection.Groups[2].Value.Trim();

            }
            if (string.IsNullOrEmpty(dishName))
            {
                return;
            }
            var dishes = new Maticsoft.Model.Dishes
            {
                DishesID = Guid.NewGuid().ToString(),
                DishesName = dishName,
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

        public List<IDishSiteModel> DishList { get; set; }
        bool IDishes.Conversion()
        {
            return false;
        }
        public List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            return dishesTyepList;
        }
    }
}
