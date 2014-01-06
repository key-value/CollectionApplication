﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;

namespace Epinle
{
    public class CatalogueSecretary : ICatalogue
    {
        private StoreInfo _storeInfoBll = new StoreInfo();
        private StorePicture _storePictureBll = new StorePicture();


        public CatalogueSecretary()
        {
            PicType = "Shop";
            PageUrl = @"http://www.cyooy.com/shop/";
        }

        public string PageUrl { get; set; }

        public int PageNum { get; set; }

        public int PageCount { get; set; }

        public string PicType { get; private set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }

        public bool CheckStoreIsRead(string keyID, ref string storeId)
        {
            var temStoreInfoList = _storeInfoBll.GetModelList(string.Format("Fid = '{0}'", keyID));
            if (temStoreInfoList != null && temStoreInfoList.Count > 0)
            {
                var temStoreInfo = temStoreInfoList.FirstOrDefault();
                if (temStoreInfo != null)
                {
                    storeId = temStoreInfo.storeId;
                    DeleteOldPicture(temStoreInfo);
                    return true;
                }
            }
            return false;
        }

        public void DeleteOldPicture(Maticsoft.Model.StoreInfo temStoreInfo)
        {
            var oldStorePicture =
               _storePictureBll.GetModelList(string.Format("PicType ='{1}' and StoreId = '{0}'",
                   temStoreInfo.storeId, PicType));
            foreach (var storePicture in oldStorePicture)
            {
                _storePictureBll.Delete(storePicture.PID);
            }
        }
        private string SaveImageNode(HtmlNode htmlNode, string storeId)
        {
            var imgNode = htmlNode.SelectSingleNode(".//p[@align='center']/img");
            if (imgNode != null)
            {
                var shopPicturePath = imgNode.Attributes["src"].Value;
                return SavePictureName(storeId, shopPicturePath);
            }
            return string.Empty;
        }
        public string SavePictureName(string storeId, string shopPicturePath)
        {
            var storePicture = new Maticsoft.Model.StorePicture()
            {
                PID = Guid.NewGuid().ToString()
            };
            storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
            storePicture.PicType = PicType;
            storePicture.PicturePath = shopPicturePath;
            storePicture.StoreId = storeId;
            _storePictureBll.Add(storePicture);
            return storePicture.PictureName;
        }
        public List<Catalogue> GetPageCatalogue(int poIndex)
        {
            var catalogueList = new List<Catalogue>();
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var catalogueHtmlNode = baseCollectionSite.BaseHtmlNode;
            if (catalogueHtmlNode == null)
            {
                return catalogueList;
            }
            var restaurantList = catalogueHtmlNode.SelectNodes(@".//div[@class='search_store_main']/div[@class='liebiaocont']/div[@class='liebiaocontl']/div[@class='liebiaolb']/div[@class='so_sp']/ul/li");
            if (restaurantList == null)
            {
                return catalogueList;
            }
            foreach (var restaurant in restaurantList)
            {
                GetFid(restaurant);
                GetAddress(restaurant);
                if (string.IsNullOrEmpty(Fid))
                {
                    continue;
                }
                var catalogue = new Catalogue
                {
                    FId = Fid,
                    title = Title,
                    href = GetHref(restaurant),
                    LocalTagID = poIndex,
                };
                var storeId = Guid.NewGuid().ToString();
                catalogue.IsRead = CheckStoreIsRead(catalogue.FId, ref storeId);
                catalogue.StoreId = storeId;
                catalogue.picName = SaveImageNode(restaurant, storeId);
                catalogueList.Add(catalogue);
            }

            return catalogueList;
        }

        private string Title { get; set; }

        private string Fid { get; set; }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.Attributes["id"];
            if (fidNode == null)
            {
                return;
            }
            //showListTipComment('外婆味道时尚菜馆(滇池店)',1087)
            //@"[\w\-_]+\.[\w\-_]+[\w\-\.,@?^=%&amp;:/~\+#]+shop\/search[\-po](\d*)[\-p](\d*)";

            const string regex = @"[\w]*\('([\u4E00-\u9FA5]*\(*[\u4E00-\u9FA5]*\)*)',(\d*)\)";
            if (!Regex.IsMatch(htmlNode.InnerHtml, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Title = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            Fid =
               string.IsNullOrEmpty(matchCollection.Groups[2].Value.Trim())
                    ? "1"
                    : matchCollection.Groups[2].Value;
        }

        public string GetHref(HtmlNode htmlNode)
        {
            var xpath = @".//li/div[@class='so_spshang']/div[@class='so_sp_icon']/a";
            var hrefNode = htmlNode.SelectSingleNode(xpath);
            if (hrefNode != null)
            {
                return hrefNode.Attributes["href"].Value;
            }
            return string.Empty;
        }

        private string StoreAddress
        {
            get;
            set;
        }
        private string StoreTag { get; set; }

        public void GetAddress(HtmlNode htmlNode)
        {
            var xpath = @".//li/div[@class='so_spshang']/div[@class='so_sp_name']/table/tbody/tr/td[@class='dn_name02']";
            var addressNode = htmlNode.SelectSingleNode(xpath);
            if (addressNode != null)
            {
                StoreAddress = addressNode.InnerText;
            }
        }

        public int DishesNum { get; set; }

        public string NextPage { get; set; }

        public string BeforePage { get; set; }
    }
}