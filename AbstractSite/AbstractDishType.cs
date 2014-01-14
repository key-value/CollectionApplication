using System;
using System.Collections.Generic;
using ApplicationUtility;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.BLL.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace AbstractSite
{
    public abstract class AbstractDishType : AbstractMainSite
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

        public virtual List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            var dishTypeList = new List<Maticsoft.Model.DishesTyep>();
            BeginSaveDish();
            var dishTypeNodeList = GetSiteDishTypeList();
            dishTypeList.AddRange(GetOlddDishType());
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                var dishTypeName = GetDishTypeName(dishTypeNode);
                if (string.IsNullOrWhiteSpace(dishTypeName))
                {
                    continue;
                }
                var dishesTypeInfo = dishTypeList.Find(x => x.DishesTypeName == dishTypeName);
                if (dishesTypeInfo == null)
                {
                    dishesTypeInfo = new Maticsoft.Model.DishesTyep
                    {
                        DishesTypeID = Guid.NewGuid().ToString(),
                        DishesTypeName = dishTypeName,
                        BusinessID = StoreInfo.OldStoreId,
                        CreateDate = DateTime.Now,
                        DishHref = GetDishesHref(dishTypeNode),
                    };
                    dishTypeList.Add(dishesTypeInfo);
                }
                SaveIngDish(dishTypeName, string.Empty);
                var dishNodeList = GetDishInfoList(dishTypeNode);
                if (dishNodeList == null)
                {
                    continue;
                }
                foreach (var dishNode in dishNodeList)
                {
                    var dishName = GetDishName(dishNode).ClearSiteCode();
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
                    dishInfo.DishesName = dishName;
                    if (dishInfo.DishesMoney == 0)
                    {
                        dishInfo.IsCurrentPrice = true;
                    }
                    SaveIngDish(dishTypeName, dishName);
                }
            }
            FinishSaveDish();
            return dishTypeList;
        }

        protected virtual string GetDishesHref(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            return dishTypeNode.GetPicturePath();
        }

        protected virtual string GetDishTypeName(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            if (dishTypeNode == null)
            {
                return string.Empty;
            }
            return dishTypeNode.InnerText.ClearSiteCode();
        }

        protected virtual HtmlAgilityPack.HtmlNodeCollection GetSiteDishTypeList()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishNodeList = dishTypeHtmlNode.SelectNodes(DishesTypePath());
            return dishNodeList;
        }

        protected virtual List<Maticsoft.Model.DishesTyep> GetOlddDishType()
        {
            var dishesTyepList = DishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", StoreInfo.OldStoreId)) ?? new List<Maticsoft.Model.DishesTyep>();
            foreach (var dishesTyep in dishesTyepList)
            {
                var dishesList = DishesBll.GetModelList(string.Format(@"DishesTypeID = '{0}'", dishesTyep.DishesTypeID));
                dishesTyep.DishesList.AddRange(dishesList);
            }
            return dishesTyepList;
        }

        protected virtual HtmlAgilityPack.HtmlNodeCollection GetDishInfoList(HtmlAgilityPack.HtmlNode dishTypeNode)
        {
            var dishesPath = DishesPath();
            if (string.IsNullOrEmpty(dishesPath))
            {
                return null;
            }
            return dishTypeNode.SelectNodes(dishesPath);
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
