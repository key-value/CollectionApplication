using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using HtmlAgilityPack;
using ISite;

namespace Echiele
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://sz.echiele.com/";
            PageNodePath = @".//div[@class='list_center']/div[@class='list_left']/div[@class='feng_page']/span[@class='f_left']/a";
            CataloguePath =
                @".//div[@class='list_center']/div[@class='list_left']/div[@class='product_lists']/div[@class='product_list']";
            ImgNodePath = @".//div[@class='list_img']/a/img";
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        #region 注释

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
        //    var restaurantList = catalogueHtmlNode.SelectNodes(CataloguePath);
        //    if (restaurantList == null)
        //    {
        //        return catalogueList;
        //    }
        //    foreach (var restaurant in restaurantList)
        //    {
        //        GetFid(restaurant);
        //        GetAddress(restaurant);
        //        var catalogue = CreateCatalogue(poIndex);
        //        if (catalogue.IsNull)
        //        {
        //            continue;
        //        }
        //        var storeId = Guid.NewGuid().ToString();
        //        catalogue.IsRead = CheckStoreIsRead(catalogue.FId, ref storeId);
        //        catalogue.StoreId = storeId;
        //        catalogue.picName = SaveImageNode(restaurant, storeId);
        //        GetStoreInfo(catalogue.title, restaurant);
        //        catalogueList.Add(catalogue);
        //    }
        //    GetPageNum(catalogueHtmlNode);
        //    return catalogueList;
        //}
        #endregion
        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
            GetAddress(restaurant);
        }


        protected override Maticsoft.Model.StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            if (restaurant == null)
            {
                return new Maticsoft.Model.NullStoreInfo();
            }
            var storeInfo = new Maticsoft.Model.StoreInfo();
            storeInfo.StoreAddress = StoreAddress;
            storeInfo.StorePhone = StorePhone;
            storeInfo.StoreName = storeName;
            storeInfo.MaxPrice = MaxPrice(restaurant);
            return storeInfo;
        }


        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='list_img']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format("http://sz.echiele.com{0}", hrefString);
            const string regex = @"[\w]*\/(\d*).html";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            Title = fidNode.Attributes["title"].Value; ;
        }

        private string StoreAddress { get; set; }
        private string StorePhone { get; set; }

        public void GetAddress(HtmlNode htmlNode)
        {
            var storeNodeList = htmlNode.SelectNodes(@".//div[@class='list_mid']/span");
            if (storeNodeList == null)
            {
                return;
            }
            foreach (var storeNode in storeNodeList)
            {
                if (storeNode.InnerHtml.Contains("地址："))
                {
                    StoreAddress = storeNode.InnerText.Replace("地址：", string.Empty);
                }
                if (storeNode.InnerHtml.Contains("电话："))
                {
                    StorePhone = storeNode.InnerText.Replace("电话：", string.Empty);
                }
            }
        }

        public int MaxPrice(HtmlNode htmlNode)
        {
            var priceNode = htmlNode.SelectSingleNode(@".//div[@class='list_pl']/span[@class='sp1']/font");
            if (priceNode == null)
            {
                return 0;
            }
            var priceText = priceNode.InnerText.Replace("¥", string.Empty);
            decimal priceNum = 0;
            decimal.TryParse(priceText, out priceNum);
            return (int)priceNum;
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["data-original"].Value;
        }
        protected override void GetPage(HtmlNode pageNode)
        {
            var inPageNode = pageNode.Attributes["id"];
            if (inPageNode == null)
            {
                return;
            }
            if (pageNode.Attributes["id"].Value == "checked")
            {
                var intpageNum = 1;
                if (int.TryParse(pageNode.InnerText, out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
        }
    }
}
