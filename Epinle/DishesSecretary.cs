﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace Epinle
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
                storePicture.PicturePath = PageUrl + dishSiteModel.PictureName;
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

        public event IDelegate.CatalogueEventHandler CataloEventHandler;

        public event IDelegate.LabelEventHandler LabelEventHandler;
    }
}
