﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.BLL.DishesTyep;
using DishesTyepTable = Maticsoft.BLL.DishesTyepTable;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace AbstractSite
{
    public abstract class AbstractDishType
    {
        protected DishesBll DishesBll = new DishesBll();
        protected DishesTyep DishTypeBll = new DishesTyep();
        protected StorePicture StorePictureBll = new StorePicture();
        public virtual string PageUrl { get; set; }

        public string RestaurantId { get; set; }

        public string PictureUrl { get; set; }

        public Maticsoft.Model.StoreInfo StoreInfo { get; set; }

        protected abstract string DishesTypePath();

        protected abstract string DishesPath();

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            var dishTypeList = new List<Maticsoft.Model.DishesTyep>();
            var dishTypeNodeList = GetSiteDishType();
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            var dishesTyepList = GetOlddDishType();
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                var dishTypeName = GetDishTypeName(dishTypeNode);
                if (string.IsNullOrWhiteSpace(dishTypeName))
                {
                    continue;
                }
                var dishesTypeInfo = dishesTyepList.Find(x => x.DishesTypeName == dishTypeName);
                if (dishesTypeInfo == null)
                {
                    dishesTypeInfo = new Maticsoft.Model.DishesTyep
                    {
                        DishesTypeID = Guid.NewGuid().ToString(),
                        DishesTypeName = dishTypeName,
                        BusinessID = StoreInfo.storeId,
                        CreateDate = DateTime.Now,
                    };
                    dishTypeList.Add(dishesTypeInfo);
                }
                var dishNodeList = GetDishInfoList(dishTypeNode);
                foreach (var dishNode in dishNodeList)
                {
                    var dishName = GetDishName(dishNode);
                    if (string.IsNullOrWhiteSpace(dishName))
                    {
                        continue;
                    }
                    var dishInfo = dishesTypeInfo.DishesList.Find(x => x.DishesName == dishName);
                    if (dishInfo == null)
                    {
                        dishInfo = new DishesEntity
                        {
                            BusinessID = StoreInfo.storeId,
                            DishesID = Guid.NewGuid().ToString(),
                            DishesTypeID = dishesTypeInfo.DishesTypeID
                        };
                        dishesTypeInfo.DishesList.Add(dishInfo);
                    }
                    dishInfo.DishesUnit = GetDishUnit(dishNode);
                    dishInfo.DishesMoney = GetDishPrice(dishNode);
                    dishInfo.PictureHref = GetDishImg(dishNode);
                }
            }
            return dishTypeList;
        }

        protected virtual string GetDishTypeName(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            if (dishTypeNode == null)
            {
                return string.Empty;
            }
            return dishTypeNode.InnerText;
        }

        protected virtual HtmlAgilityPack.HtmlNodeCollection GetSiteDishType()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishNodeList = dishTypeHtmlNode.SelectNodes(DishesTypePath());
            return dishNodeList;
        }

        protected virtual List<Maticsoft.Model.DishesTyep> GetOlddDishType()
        {
            var dishesTyepList = DishTypeBll.GetModelList(string.Format("StoreId = '{0}'", StoreInfo.storeId));
            foreach (var dishesTyep in dishesTyepList)
            {
                var dishesList = DishesBll.GetModelList(string.Format(@"DishesTypeID = '{0}'", dishesTyep.DishesTypeID));
                dishesTyep.DishesList.AddRange(dishesList);
            }
            return dishesTyepList;
        }

        protected virtual HtmlAgilityPack.HtmlNodeCollection GetDishInfoList(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            return dishTypeNode.SelectNodes(DishesPath());
        }

        protected abstract string GetDishName(HtmlAgilityPack.HtmlNode dishNode);
        protected abstract decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode);
        protected abstract string GetDishImg(HtmlAgilityPack.HtmlNode dishNode);

        protected virtual string GetDishUnit(HtmlAgilityPack.HtmlNode dishNode)
        {
            return "份";
        }
    }
}