using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    public class CatalogueSecretary : ICatalogue
    {
    //    public CatalogueSecretary(string pageUrl)
    //    {
    //    }

    //    protected override string ListPath
    //    {
    //        get
    //        {
    //            return @".//div[@class='constr']/div/div[@class='res_hm_c']/div[@class='res_sch_res schResList']/div[@class='l']/a";
    //        }
    //    }

    //    /// <summary>
    //    /// 页面目录
    //    /// </summary>
    //    /// <param name="poIndex"></param>
    //    /// <returns></returns>
    //    public override List<Catalogue> GetPageCatalogue(int poIndex)
    //    {
    //        var catalogueNodeList = CatalogueHtmlNode.SelectNodes(ListPath);
    //        if (catalogueNodeList == null)
    //        {
    //            return _catalogueList;
    //        }
    //        foreach (var htmlNode in catalogueNodeList)
    //        {
    //            var catalogue = GetCatalogueNode(poIndex, htmlNode);
    //            if (catalogue != null)
    //            {
    //                _catalogueList.Add(catalogue);
    //            }
    //        }

    //        return _catalogueList.OrderBy(x => x != null && x.IsRead).ThenBy(x => x != null ? x.FId : string.Empty).ToList();
    //    }

    //    private Catalogue GetCatalogueNode(int poIndex, HtmlNode htmlNode)
    //    {
    //        var href = htmlNode.Attributes["href"].Value;
    //        var keyList = href.Trim('/').Split('/');
    //        if (keyList.Count() != 2)
    //        {
    //            return null;
    //        }
    //        var keyID = keyList[1];
    //        var catalogue = new Catalogue
    //        {
    //            FId = keyID,
    //            title = GetTitle(htmlNode),
    //            href = href,
    //            LocalTagID = poIndex
    //        };
    //        string storeId;
    //        catalogue.IsRead = CheckStoreIsRead(keyID, out storeId);
    //        catalogue.StoreId = storeId;
    //        catalogue.picName = SaveImageNode(htmlNode, storeId);
    //        return catalogue;

    //    }

    //    private string SaveImageNode(HtmlNode htmlNode, string storeId)
    //    {
    //        var imgNode = htmlNode.SelectSingleNode(".//img[@class='jsLazyImage']");
    //        if (imgNode != null)
    //        {
    //            var shopPicturePath = imgNode.Attributes["data-url"].Value;
    //            return SavePictureName(storeId, shopPicturePath);
    //        }
    //        return string.Empty;
    //    }

    //    protected override string SavePictureName(string storeId, string shopPicturePath)
    //    {
    //        if (!string.IsNullOrEmpty(shopPicturePath) && !shopPicturePath.EndsWith("food_nopic.png"))
    //        {
    //            return base.SavePictureName(storeId, shopPicturePath);
    //        }
    //        return string.Empty;
    //    }

    //    protected override string GetTitle(HtmlNode htmlNode)
    //    {
    //        return htmlNode.SelectSingleNode(".//img").Attributes["title"].Value;
    //    }
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

        public int PageNum
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

        public int PageCount
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
            get { throw new NotImplementedException(); }
        }

        public bool CheckStoreIsRead(string keyID, out string storeId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOldPicture(StoreInfo temStoreInfo)
        {
            throw new NotImplementedException();
        }

        public string SavePictureName(string storeId, string shopPicturePath)
        {
            throw new NotImplementedException();
        }

        public List<Catalogue> GetPageCatalogue(int poIndex)
        {
            throw new NotImplementedException();
        }

        string ICatalogue.PageUrl
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

        int ICatalogue.PageNum
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

        int ICatalogue.PageCount
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

        string ICatalogue.PicType
        {
            get { throw new NotImplementedException(); }
        }

        List<Catalogue> ICatalogue.GetPageCatalogue(int poIndex)
        {
            throw new NotImplementedException();
        }


        public int CircleId
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


        public int IflastPage
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


        public int DishesNum
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


        public string NextPage
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

        public string BeforePage
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
    }
}
