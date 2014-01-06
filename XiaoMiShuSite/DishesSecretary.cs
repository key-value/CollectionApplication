using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    public class DishesSecretary : IDishes
    {

        //public DishesSecretary(string pageUrl)
        //    : base(pageUrl)
        //{

        //}

        //protected override string PictureXpath
        //{
        //    get
        //    {
        //        return @".//div[@class='abs_out pt10']/div[@class='fix rel']/div[@class='pct50 l']/a[@class='g3']/img";
        //    }
        //}

        //public override void GetDish(StoreInfo storeInfo)
        //{
        //    try
        //    {
        //        DeleteDishes(storeInfo.storeId);
        //        DeleteDishType(storeInfo.storeId);
        //        DeleteStorePicture(storeInfo);
        //        //var dishTypePath = string.Format("{0}shop/{1}/dish/", _pageUrl, storeInfo.Fid);

        //        var dishTypeNodeList =
        //            CatalogueHtmlNode.SelectNodes(ListPath) ?? new HtmlNodeCollection(null);
        //        if (dishTypeNodeList.Count <= 0)
        //        {
        //            return;
        //        }
        //        foreach (var dishTypeNode in dishTypeNodeList)
        //        {
        //            SaveDishTypeNode(storeInfo, dishTypeNode);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //    }

        //}

        //private void SaveDishTypeNode(StoreInfo storeInfo, HtmlNode dishTypeNode)
        //{
        //    var dishType = GetDishesTypeTable(storeInfo, dishTypeNode);
        //    DishTypeBll.Add(dishType);

        //    var pageIndex = 1;
        //    var htmlWeb = new HtmlWeb();
        //    while (true)
        //    {
        //        var dishUrl = dishTypeNode.Attributes["href"].Value;
        //        var dishPath = string.Format("{0}{1}p{2}/", PageUrl, dishUrl, pageIndex);
        //        pageIndex++;
        //        var htmlDoc = htmlWeb.Load(dishPath);
        //        var dishesNodeList =
        //            htmlDoc.DocumentNode.SelectNodes(
        //                ".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/ul[@id='foodListUl']/li[@class='res_food_list']") ??
        //            new HtmlNodeCollection(null);
        //        if (dishesNodeList.Count <= 1)
        //        {
        //            break;
        //        }
        //        foreach (var dishNode in dishesNodeList)
        //        {
        //            var dishes = GetDishes(storeInfo, dishNode, dishType);
        //            if (dishes.IsNull)
        //            {
        //                continue;
        //            }
        //            DishesBll.Add(dishes);
        //        }
        //    }
        //}

        //private void DeleteStorePicture(StoreInfo storeInfo)
        //{
        //    var storePicturelist =
        //        StorePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeInfo.storeId,
        //            PicType));
        //    foreach (var storePicture in storePicturelist)
        //    {
        //        StorePictureBll.Delete(storePicture.PID);
        //    }
        //}

        //private Dishes GetDishes(StoreInfo storeInfo, HtmlNode dishNode, DishesTyepTable dishType)
        //{
        //    var dishes = new Dishes();
        //    var foodList = dishNode.SelectSingleNode(".//div[@class='fix']");
        //    if (foodList == null)
        //    {
        //        return new NullDishes();
        //    }
        //    var foodChildList = foodList.ChildNodes;
        //    var foodName = foodList.ChildNodes.Count > 1
        //        ? foodChildList[1].InnerText ?? string.Empty
        //        : string.Empty;
        //    var popularity = foodList.ChildNodes.Count > 5
        //        ? foodChildList[5].InnerText ?? string.Empty
        //        : string.Empty;
        //    dishes.DishesID = Guid.NewGuid().ToString();
        //    dishes.DishesName = foodName.Trim();
        //    dishes.dishTypeID = dishType.DishesTypeID;
        //    var isCurrentPrice = false;
        //    dishes.DishesMoney = GetFoodPrice(foodList, ref isCurrentPrice);
        //    dishes.IsCurrentPrice = isCurrentPrice;
        //    dishes.popularity = popularity.Trim();
        //    dishes.StoreId = storeInfo.storeId;
        //    dishes.PictureName = SavePicture(storeInfo.storeId, dishNode);
        //    return dishes;
        //}

        //private DishesTyepTable GetDishesTypeTable(StoreInfo storeInfo, HtmlNode dishTypeNode)
        //{
        //    var dishType = new DishesTyepTable
        //    {
        //        BusinessID = storeInfo.storeId,
        //        CreateDate = DateTime.Now,
        //        DishesTypeID = Guid.NewGuid().ToString(),
        //        DishesTypeName = GetDishTypeName(dishTypeNode)
        //    };
        //    return dishType;
        //}

        //private string GetFoodPrice(HtmlNode htmlNode, ref bool IsCurrentPrice)
        //{
        //    var dishesMoney = "0";
        //    var foodPrice = htmlNode.InnerText ?? string.Empty;
        //    foodPrice = foodPrice.Trim().Replace("￥", string.Empty).Replace("¥", string.Empty);
        //    if (foodPrice.Trim() == "时价")
        //    {
        //        dishesMoney = "0";
        //        IsCurrentPrice = true;
        //    }
        //    else if (foodPrice.Trim() == "不详")
        //    {
        //        dishesMoney = "0";
        //    }
        //    else
        //    {
        //        dishesMoney = foodPrice;
        //    }
        //    return dishesMoney;
        //}

        //private string SavePicture(string StoreId, HtmlNode dishNode)
        //{
        //    var dishesPictureNode = dishNode.SelectSingleNode(
        //        PictureXpath);
        //    if (dishesPictureNode != null)
        //    {
        //        var dishesPicturePath = dishesPictureNode.Attributes["src"].Value;
        //        if (!string.IsNullOrEmpty(dishesPicturePath) &&
        //            !dishesPicturePath.Contains("nopic"))
        //        {
        //            var storePicture = new StorePicture();
        //            storePicture.PID = Guid.NewGuid().ToString();
        //            storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
        //            storePicture.PicType = PicType;
        //            storePicture.PicturePath = dishesPicturePath;
        //            storePicture.StoreId = StoreId;
        //            StorePictureBll.Add(storePicture);

        //            return storePicture.PictureName;
        //        }
        //    }
        //    return string.Empty;
        //}

        //private string GetDishTypeName(HtmlNode dishTypeNode)
        //{
        //    var dishlength = dishTypeNode.InnerText.IndexOf('(');
        //    if (dishlength > 0)
        //    {
        //        return dishTypeNode.InnerText.Substring(0, dishlength);
        //    }
        //    return dishTypeNode.InnerText;
        //}

        //private void DeleteDishType(string storeId)
        //{
        //    var dishTypeList = DishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", storeId));
        //    foreach (var dishesTyepTable in dishTypeList)
        //    {
        //        DishTypeBll.Delete(dishesTyepTable.DishesTypeID);
        //    }
        //}

        //private void DeleteDishes(string storeId)
        //{
        //    var disheslist = DishesBll.GetModelList(string.Format("StoreId = '{0}'", storeId));
        //    foreach (var dishese in disheslist)
        //    {
        //        DishesBll.Delete(dishese.DishesID);
        //    }
        //}
        public string PageUrl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PicType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void GetDish(StoreInfo storeInfo)
        {
            throw new NotImplementedException();
        }

        public List<IDishSiteModel> DishList
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
            throw new NotImplementedException();
        }
        bool IDishes.Conversion()
        {
            return true;
        }
    }
}
