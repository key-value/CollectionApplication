using AbstractSite;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System.Linq;
using System.Text.RegularExpressions;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace GaFan
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='main']/div[@class='list_left']";
        }
        #region

        //public string PageUrl { get; set; }
        //public StoreInfo GetStoreInfo(Catalogue catalogue)
        //{
        //    var storePath = @"//*[@id='container']";
        //    var baseCollectionSite = new BaseCollectionSite(PageUrl);
        //    StoreInfoHtmlNode = baseCollectionSite.BaseHtmlNode;
        //    StoreInfoHtmlNode = StoreInfoHtmlNode.SelectSingleNode(storePath);
        //    if (StoreInfoHtmlNode == null)
        //    {
        //        return new NullStoreInfo();
        //    }
        //    int minPrice;
        //    int maxPrice;
        //    PeoplePrice(out minPrice, out maxPrice);
        //    var storeInfo = new StoreInfo();
        //    storeInfo.storeId = catalogue.StoreId;
        //    storeInfo.Fid = catalogue.FId;
        //    storeInfo.Facilities = GetFacilities();
        //    storeInfo.payCar = GetPayCar();
        //    storeInfo.BasicIntroduction = GetBasicIntroduction();
        //    storeInfo.subway = Subway();
        //    storeInfo.bus = GetBus();
        //    storeInfo.box = Getbox();
        //    storeInfo.MaxPrice = maxPrice;
        //    storeInfo.MinPrice = minPrice;
        //    storeInfo.StorePhone = GetPhoneNum();
        //    storeInfo.StoreHours = GetWorkTime();
        //    storeInfo.StoreTag = StoreTagText();
        //    storeInfo.StoreName = catalogue.title;
        //    storeInfo.picName = catalogue.picName.Trim();
        //    storeInfo.carPark = GetCarPark();
        //    return new NullStoreInfo();
        //}
        //public HtmlNode StoreInfoHtmlNode
        //{
        //    get;
        //    set;
        //}

        //public string GetFacilities()
        //{
        //    return string.Empty;
        //}

        //public string Subway()
        //{
        //    return string.Empty;
        //}

        //public string GetCarPark()
        //{
        //    return string.Empty;
        //}

        //public string GetBus()
        //{
        //    return string.Empty;
        //}

        //public string StoreTagText()
        //{
        //    return string.Empty;
        //}
        #endregion


        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.StorePictureHref = catalogue.StorePictureHref;
            //storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            //storeInfo.StoreTag = catalogue.StoreInfo.StoreTag;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            return storeInfo;
        }

        public override string GetBus()
        {
            return BaseGetText("公交：").Replace(@"<br>", string.Empty).ClearSiteCode();
        }

        public override string GetWorkTime()
        {
            return BaseGetText("营业时间：").Replace("<div class=\"cl\"></div>", string.Empty).ClearSiteCode();
        }

        public override string GetFacilities()
        {
            return (BaseGetText("设施：").Replace(@"<br>", string.Empty.ClearSiteCode()) + BaseGetText("停车：")).Replace("<div class=\"blank5\"></div><div class=\"itemt_bottom\"></div><div class=\"blank5\"></div>", string.Empty);
        }

        public override string GetAddress()
        {
            return BaseGetText("地址：");
        }

        public override string StoreTagText()
        {
            return BaseGetText("菜系：").Replace("<div class=\"blank5\"></div><div class=\"itemt_bottom\"></div><div class=\"blank5\"></div>", string.Empty).ClearSiteCode();
        }

        public override string GetPhoneNum()
        {
            return BaseGetText("咨询热线：");
        }

        public string BaseGetText(string containsText)
        {
            var xpath = @".//div[@class='show_border']/div[@class='show_A']/div[@class='show_A_righ']/div[@class='show_A_txt']";
            var node = CollectionNodeText.GetNodeInner(StoreInfoHtmlNode, xpath);
            var strList = node.InnerHtml.Replace("<em>", "|").Split('|');
            foreach (var stringText in strList)
            {
                if (stringText.Contains(containsText))
                {
                    return stringText.Replace(containsText, string.Empty).Replace(@"</em>", string.Empty).ClearSiteCode();
                }
            }
            return string.Empty;
        }
    }
}
