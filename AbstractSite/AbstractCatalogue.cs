using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace AbstractSite
{
    public abstract class AbstractCatalogue : AbstractStorePicture
    {
        protected AbstractCatalogue()
        {
            NextPage = string.Empty;
            BeforePage = string.Empty;
            PageNum = 1;
            BeforePageText = "上一页";
            NextPageText = "下一页";
        }
        protected Maticsoft.BLL.StoreInfo StoreInfoBll = new Maticsoft.BLL.StoreInfo();
        public string PageUrl { get; set; }
        public int PageNum { get; set; }
        protected string Title { get; set; }
        protected string Href { get; set; }
        protected string Fid { get; set; }
        protected string _nextPage;
        public string NextPage
        {
            get
            {
                return _nextPage;
            }
            set
            {
                _nextPage = value;
            }
        }
        protected string _beforePage;
        public string BeforePage
        {
            get
            {
                return _beforePage;
            }
            set
            {
                _beforePage = value;
            }
        }
        protected string NextPageText;
        protected string BeforePageText;
        protected string PageNodePath;
        protected string CataloguePath;

        #region CheckStoreIsRead

        public virtual bool CheckStoreIsRead(string keyID, string storeName, ref string storeId)
        {
            var temStoreInfoList = StoreInfoBll.GetModelList(string.Format("Fid = '{0}' and StoreName='{1}'", keyID, storeName.Replace("'", "''")));
            if (temStoreInfoList != null && temStoreInfoList.Count > 0)
            {
                var temStoreInfo = temStoreInfoList.FirstOrDefault();
                if (temStoreInfo != null)
                {
                    storeId = temStoreInfo.storeId;
                    //DeleteOldPicture(temStoreInfo);
                    return true;
                }
            }
            return false;
        }


        public virtual void DeleteOldPicture(StoreInfo temStoreInfo)
        {
            var oldStorePicture =
               StorePictureBll.GetModelList(string.Format("PicType ='{1}' and StoreId = '{0}'",
                   temStoreInfo.storeId, PicType));
            foreach (var storePicture in oldStorePicture)
            {
                StorePictureBll.Delete(storePicture.PID);
            }
        }
        #endregion
        #region 页面处理
        protected virtual void GetPageNum(HtmlNode catalogueHtmlNode)
        {
            var pageNodeList =
                catalogueHtmlNode.SelectNodes(PageNodePath);
            if (pageNodeList != null)
            {
                var beforeChange = false;
                var nextChange = false;
                foreach (var pageNode in pageNodeList)
                {
                    if (pageNode.InnerHtml.Contains(BeforePageText))
                    {
                        BeforePage += pageNode.Attributes["href"].Value;
                        beforeChange = true;
                    }
                    else if (pageNode.InnerText.Contains(NextPageText))
                    {
                        NextPage += pageNode.Attributes["href"].Value;
                        nextChange = true;
                    }
                    else
                    {
                        GetPage(pageNode);
                    }
                }
                if (!beforeChange)
                {
                    BeforePage = string.Empty;
                }
                if (!nextChange)
                {
                    NextPage = string.Empty;
                }
            }
        }

        protected abstract void GetPage(HtmlNode pageNode);
        #endregion
        #region 主流程函数
        public virtual List<Catalogue> GetPageCatalogue(int poIndex)
        {
            var catalogueList = new List<Catalogue>();
            var restaurantList = GetCatalogueList();
            foreach (var restaurant in restaurantList)
            {
                InitRestaurant(restaurant);
                var catalogue = CreateCatalogue(poIndex);
                if (catalogue.IsNull)
                {
                    continue;
                }
                var storeId = Guid.NewGuid().ToString();
                catalogue.IsRead = CheckStoreIsRead(catalogue.FId, catalogue.title, ref storeId);
                catalogue.StoreId = storeId;
                catalogue.picName = SaveImageNode(restaurant, storeId);
                var storeInfo = GetStoreInfo(catalogue.title, restaurant);
                if (!storeInfo.IsNull)
                {
                    catalogue.StoreInfo = storeInfo;
                }
                catalogueList.Add(catalogue);
            }
            return catalogueList;
        }

        private IEnumerable<HtmlNode> GetCatalogueList()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var catalogueHtmlNode = baseCollectionSite.BaseHtmlNode;
            if (catalogueHtmlNode == null)
            {
                return null;
            }
            GetPageNum(catalogueHtmlNode);
            var restaurantList = catalogueHtmlNode.SelectNodes(CataloguePath);
            return restaurantList;
        }

        public virtual List<Catalogue> GetCataloguePage(int poIndex)
        {
            var catalogueList = new List<Catalogue>();
            var restaurantList = GetCatalogueList();
            foreach (var restaurant in restaurantList)
            {
                InitRestaurant(restaurant);
                var catalogue = CreateCatalogue(poIndex);
                if (catalogue.IsNull)
                {
                    continue;
                }
                var storeId = Guid.NewGuid().ToString();
                catalogue.IsRead = CheckStoreIsRead(catalogue.FId, catalogue.title, ref storeId);
                catalogue.StoreId = storeId;
                catalogue.StorePictureHref = GetImageHref(restaurant, storeId);
                var storeInfo = GetStoreInfo(catalogue.title, restaurant);
                if (!storeInfo.IsNull)
                {
                    catalogue.StoreInfo = storeInfo;
                }
                catalogueList.Add(catalogue);
            }
            return catalogueList;
        }

        public abstract void InitRestaurant(HtmlNode restaurant);

        protected virtual StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            return new NullStoreInfo();
        }
        protected Catalogue CreateCatalogue(int poIndex)
        {
            if (string.IsNullOrEmpty(Fid) || string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Href))
            {
                return new NullCatalogue();
            }
            var catalogue = new Catalogue
            {
                FId = Fid,
                title = Title,
                href = Href,
                LocalTagID = poIndex,
            };
            Fid = string.Empty;
            Title = string.Empty;
            Href = string.Empty;
            return catalogue;
        }
        #endregion

        protected string StoreUrl { get; set; }

        protected virtual string GetStoreUrl()
        {
            if (!string.IsNullOrWhiteSpace(StoreUrl))
            {
                return StoreUrl; 
            }
            var regex = @"(http|ftp|https):\/\/([\w\-_]+\.[\w\-_]+\.[\w\-_]+)";
            if (!Regex.IsMatch(PageUrl, regex))
            {
                return string.Empty;
            }
            var matchCollection = Regex.Match(PageUrl, regex);
            var httpTop = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? @"http"
                   : matchCollection.Groups[1].Value;
            var urlMain = string.IsNullOrEmpty(matchCollection.Groups[2].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[2].Value;
            StoreUrl = string.Format("{0}://{1}", httpTop, urlMain);
            return StoreUrl;
        }
    }
}
