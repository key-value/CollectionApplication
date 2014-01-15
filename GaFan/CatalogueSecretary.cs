using System;
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

namespace GaFan
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {

        public CatalogueSecretary()
        {
            PageUrl = @"http://www.gafan.cn";
            CataloguePath =
                @".//div[@class='main']/div[@class='list_left']/div[@class='list_picList']/div[@id='tab_div_0']/div[@class='list_box']/ul/li";
            ImgNodePath = @".//div[@class='img']/a/img";
            PageNodePath =
               @".//div[@class='main']/div[@class='list_left']/div[@class='list_picList']/div[@id='tab_div_0']/div[@class='list_box']/div[@class='flickr']/a";

            NextPageText = @"list_next.gif";
            BeforePageText = @"list_prev.gif";
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
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='f_left']/div[@class='tit']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = hrefString;
            const string regex = @"\/restaurant\/(\d*)\.html";//http://www.gafan.cn:80/restaurant/25943.html
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Title = fidNode.InnerText;
            Fid = matchCollection.Groups[1].Value;
        }


        //protected override bool FilterPageText(HtmlNode htmlNode, string pageText)
        //{
        //    return htmlNode.OuterHtml.Contains(pageText);
        //}

        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"../span[@class='current']");
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
            //storeInfo.StoreAddress = GetAddress(restaurant);
            storeInfo.StoreName = storeName;
            //storeInfo.StoreTag = GetStoreTag(restaurant);
            storeInfo.MaxPrice = GetMaxPrice(restaurant);
            return storeInfo;
        }

        private int GetMaxPrice(HtmlNode restaurant)
        {
            var xpath = @".//div[@class='f_left']/div[@style='clear:both']/div[@class='dc']/b";
            var priceText = CollectionNodeText.GetNodeInnerText(restaurant, xpath);
            if (string.IsNullOrEmpty(priceText))
            {
                return 0;
            }
            int priceNum = 0;
            int.TryParse(priceText.Replace(@"人均：", string.Empty).Replace(@"元", string.Empty), out priceNum);
            return priceNum;
        }

        //private string GetStoreTag(HtmlNode restaurant)
        //{
        //    var xpath = @".//div[@class='f_left']/div[@style='clear:both']/div[@class='txt']/span";
        //    return CollectionNodeText.GetNodeListContainsInnerText(restaurant, xpath, @"菜系：");
        //}

        public string GetAddress(HtmlNode htmlNode)
        {
            var xpath = @".//div[@class='f_left']/div[@style='clear:both']/div[@class='txt']/span";
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
