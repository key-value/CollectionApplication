using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;

namespace Cyooy
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.cyooy.com/";
            NextPage = @"http://www.cyooy.com/list.php";
            BeforePage = @"http://www.cyooy.com/list.php";
            PageNum = 1;
            PageNodePath =
                @".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='restaurant']/div[@class='pageButton']/a";
            ImgNodePath = @".//p[@align='center']/img";
            CataloguePath =
                @".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='restaurant']/ul/li[@class='search']";


            BeforePageText = @"<>";
        }
        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }

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
        //        var shopPicturePath = @"http://www.cyooy.com" + imgNode.Attributes["src"].Value;
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
        //    var restaurantList = catalogueHtmlNode.SelectNodes(@".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='restaurant']/ul/li[@class='search']");
        //    if (restaurantList == null)
        //    {
        //        return catalogueList;
        //    }
        //    foreach (var restaurant in restaurantList)
        //    {
        //        GetFid(restaurant);
        //        //GetAddress(restaurant);
        //        if (string.IsNullOrEmpty(Fid))
        //        {
        //            continue;
        //        }
        //        var catalogue = new Catalogue
        //        {
        //            FId = Fid,
        //            title = Title,
        //            href = Href,
        //            LocalTagID = poIndex,
        //        };
        //        var storeId = Guid.NewGuid().ToString();
        //        //catalogue.IsRead = CheckStoreIsRead(catalogue.FId, ref storeId);
        //        catalogue.StoreId = storeId;
        //        catalogue.picName = SaveImageNode(restaurant, storeId);
        //        catalogueList.Add(catalogue);
        //    }

        //    var pageNodeList = catalogueHtmlNode.SelectNodes(@".//div[@align='center']/div[@id='container']/div[@id='content']/div[@id='restaurant']/div[@class='pageButton']/a");
        //    //if (pageNodeList != null)
        //    //{
        //    //    foreach (var pageNode in pageNodeList)
        //    //    {
        //    //        if (pageNode.InnerHtml.Contains("<>"))
        //    //        {
        //    //            BeforePage = @"http://www.cyooy.com/list.php" + pageNode.Attributes["href"].Value;
        //    //        }
        //    //        if (pageNode.InnerText.Contains("下一页"))
        //    //        {
        //    //            NextPage = @"http://www.cyooy.com/list.php" + pageNode.Attributes["href"].Value;
        //    //        }
        //    //    }
        //    //    var thisPageNode = pageNodeList.FirstOrDefault();
        //    //    if (thisPageNode != null)
        //    //    {
        //    //        var nodeInnerText = thisPageNode.ParentNode.InnerText;
        //    //        var strpageNum = nodeInnerText.IndexOf("当前第");
        //    //        if (strpageNum > 0)
        //    //        {
        //    //            var intpageNum = 1;
        //    //            if (int.TryParse(nodeInnerText.Substring(strpageNum + 3, 1), out intpageNum))
        //    //            {
        //    //                PageNum = intpageNum;
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    return catalogueList;
        //}
        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//p[@class='searchInfo']/a[@target='_blank']");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format("http://www.cyooy.com{0}", hrefString);
            const string regex = @"[\w]*\/(\d*).html";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            var titleNode = fidNode.SelectSingleNode(@".//strong");
            Title = titleNode != null ? titleNode.InnerText : string.Empty;
        }


        protected override void GetPage(HtmlNode pageNode)
        {
            var nodeInnerText = pageNode.ParentNode.InnerText;
            var strpageNum = nodeInnerText.IndexOf("当前第", System.StringComparison.Ordinal);
            if (strpageNum > 0)
            {
                var intpageNum = 1;
                if (int.TryParse(nodeInnerText.Substring(strpageNum + 3, 1), out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
            //var spanNode = pageNode.SelectSingleNode(@"../span[@class='page_on']");
            //if (spanNode != null)
            //{
            //    var intpageNum = 1;
            //    if (int.TryParse(spanNode.InnerText, out intpageNum))
            //    {
            //        PageNum = intpageNum;
            //    }
            //}
        }

        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return string.Format(@"http://www.cyooy.com{0}", htmlNode.GetPicturePath());
        }
    }
}
