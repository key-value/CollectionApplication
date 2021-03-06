﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace Epinle
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {

        public CatalogueSecretary()
        {
            PageUrl = @"http://www.Epinle.com";
            CataloguePath =
                @".//div[@class='search_store_main']/div[@class='liebiaocont']/div[@class='liebiaocontl']/div[@class='liebiaolb']/div[@class='so_sp']/ul/li";
            ImgNodePath = @".//div[@class='so_spshang']/div/a/img";
            PageNodePath =
               @".//div[@class='search_store_main']/div[@class='liebiaocont']/div[@class='liebiaocontl']/div[@class='liebiaolb']/div[@class='so_sp']/div[@class='dp_tab01']/div[@id='pagelist']/ul/li/a";
            NextPage = PageUrl;
            BeforePage = PageUrl;
        }
        #region

        //public bool CheckStoreIsRead(string keyID, ref string storeId)
        //{
        //    var temStoreInfoList = _storeInfoBll.GetModelList(string.Format("Fid = '{0}'", keyID));
        //    if (temStoreInfoList != null && temStoreInfoList.Count > 0)
        //    {
        //        var temStoreInfo = temStoreInfoList.FirstOrDefault();
        //        if (temStoreInfo != null)
        //        {
        //            storeId = temStoreInfo.storeId;
        //            DeleteOldPicture(temStoreInfo);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public void DeleteOldPicture(Maticsoft.Model.StoreInfo temStoreInfo)
        //{
        //    var oldStorePicture =
        //       _storePictureBll.GetModelList(string.Format("PicType ='{1}' and StoreId = '{0}'",
        //           temStoreInfo.storeId, PicType));
        //    foreach (var storePicture in oldStorePicture)
        //    {
        //        _storePictureBll.Delete(storePicture.PID);
        //    }
        //}
        //private string SaveImageNode(HtmlNode htmlNode, string storeId)
        //{
        //    var imgNode = htmlNode.SelectSingleNode(".//p[@align='center']/img");
        //    if (imgNode != null)
        //    {
        //        var shopPicturePath = imgNode.Attributes["src"].Value;
        //        return SavePictureName(storeId, shopPicturePath);
        //    }
        //    return string.Empty;
        //}
        //public string SavePictureName(string storeId, string shopPicturePath)
        //{
        //    var storePicture = new Maticsoft.Model.StorePicture()
        //    {
        //        PID = Guid.NewGuid().ToString()
        //    };
        //    storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
        //    storePicture.PicType = PicType;
        //    storePicture.PicturePath = shopPicturePath;
        //    storePicture.StoreId = storeId;
        //    _storePictureBll.Add(storePicture);
        //    return storePicture.PictureName;
        //}
        //public List<Catalogue> GetPageCatalogue(int poIndex)
        //{
        //    var catalogueList = new List<Catalogue>();
        //    var baseCollectionSite = new BaseCollectionSite(PageUrl);
        //    var catalogueHtmlNode = baseCollectionSite.BaseHtmlNode;
        //    if (catalogueHtmlNode == null)
        //    {
        //        return catalogueList;
        //    }
        //    var restaurantList = catalogueHtmlNode.SelectNodes(@".//div[@class='search_store_main']/div[@class='liebiaocont']/div[@class='liebiaocontl']/div[@class='liebiaolb']/div[@class='so_sp']/ul/li");
        //    if (restaurantList == null)
        //    {
        //        return catalogueList;
        //    }
        //    foreach (var restaurant in restaurantList)
        //    {
        //        GetFid(restaurant);
        //        GetAddress(restaurant);
        //        if (string.IsNullOrEmpty(Fid))
        //        {
        //            continue;
        //        }
        //        var catalogue = new Catalogue
        //        {
        //            FId = Fid,
        //            title = Title,
        //            href = GetHref(restaurant),
        //            LocalTagID = poIndex,
        //        };
        //        var storeId = Guid.NewGuid().ToString();
        //        catalogue.IsRead = CheckStoreIsRead(catalogue.FId, ref storeId);
        //        catalogue.StoreId = storeId;
        //        catalogue.picName = SaveImageNode(restaurant, storeId);
        //        catalogueList.Add(catalogue);
        //    }

        //    return catalogueList;
        //}
        #endregion

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='so_spshang']/div[@class='so_sp_name']/table/tr/td/div[@class='yh_icon_n ']/div/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format(@"http://www.epinle.com{0}", hrefString);
            const string regex = @"\/store\/(\d*)\.html";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Title = fidNode.InnerText;
            Fid = matchCollection.Groups[1].Value;
        }

        //public string GetHref(HtmlNode htmlNode)
        //{
        //    var xpath = @".//li/div[@class='so_spshang']/div[@class='so_sp_icon']/a";
        //    var hrefNode = htmlNode.SelectSingleNode(xpath);
        //    if (hrefNode != null)
        //    {
        //        return hrefNode.Attributes["href"].Value;
        //    }
        //    return string.Empty;
        //}


        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"../../li[@class='current']");
            if (spanNode != null)
            {
                var intpageNum = 1;
                if (int.TryParse(spanNode.InnerText, out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
        }

        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
        }

        protected override StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            if (restaurant == null)
            {
                return new Maticsoft.Model.NullStoreInfo();
            }
            var storeInfo = new Maticsoft.Model.StoreInfo();
            storeInfo.StoreAddress = GetAddress(restaurant);
            storeInfo.StoreName = storeName;
            //storeInfo.MaxPrice = MaxPrice(restaurant);
            storeInfo.StoreTag = GetStoreTag(restaurant).Replace("&nbsp;&nbsp;", " ");
            //storeInfo.StorePhone = GetStorePhone(restaurant);
            //storeInfo.Facilities = GetFacilities(restaurant);
            return storeInfo;
        }

        private string GetStoreTag(HtmlNode restaurant)
        {
            var xpath = @".//div[@class='so_spshang']/div[@class='so_sp_name']/table/tr/td";
            return CollectionNodeText.GetNodeListContainsInnerText(restaurant, xpath, @"菜系：");
        }

        public string GetAddress(HtmlNode htmlNode)
        {
            var xpath = @".//div[@class='so_spshang']/div[@class='so_sp_name']/table/tr/td";
            return CollectionNodeText.GetNodeListContainsInnerText(htmlNode, xpath, @"地址：");
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.GetPicturePath();
        }
    }
}
