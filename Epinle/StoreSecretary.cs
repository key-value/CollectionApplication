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

namespace Epinle
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='wrapper']/div[@class='part2']/div[@class='r11 box pad1']";
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


        public override void PeoplePrice(out int minPrice, out int maxPrice)
        {
            minPrice = 0;
            maxPrice = 0;
            const string pricePath = @".//div[@class='c4 dotline']/div[@class='c2']/ul/li";
            //var peoplePriceNode = StoreInfoHtmlNode.SelectSingleNode(pricePath);
            var priceText = CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, pricePath, @"人均消费：");
            //var priceText = peoplePriceNode.InnerText;
            string regex = @"(\d*)-(\d*)";
            if (!Regex.IsMatch(priceText, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(priceText, regex);
            maxPrice = int.Parse(string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[2].Value);
            minPrice = int.Parse(string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                  ? string.Empty
                  : matchCollection.Groups[1].Value);
        }

        public override string GetPhoneNum()
        {
            var xpath = @".//div[@class='c4 dotline']/div[@class='c2']/ul/li";
            //var phoneNumNodeList = StoreInfoHtmlNode.SelectNodes(xpath) ?? new HtmlNodeCollection(null);
            //if (phoneNumNodeList.Count <= 0)
            //{
            //    return string.Empty;
            //}
            //foreach (var phoneNumNode in phoneNumNodeList)
            //{
            //    if (phoneNumNode.InnerText.Contains(@"订座电话"))
            //    {
            //        return phoneNumNode.InnerText.Replace("订座电话：", string.Empty);
            //    }
            //}
            //return string.Empty;
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"电话预定：").Replace(@"(电话连接到e品乐订餐平台)", string.Empty);
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.StorePictureHref = catalogue.StorePictureHref;
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.StoreTag = catalogue.StoreInfo.StoreTag;
            storeInfo.StoreTag += CarPark().ClearSiteCode();
            storeInfo.box = storeInfo.StoreTag.Contains(@"有包间");
            storeInfo.ChildrenChair = storeInfo.StoreTag.Contains(@"儿童座椅");
            storeInfo.CarParks = storeInfo.StoreTag.Contains(@"有停车位");
            return storeInfo;
        }

        private string CarPark()
        {
            var xpath = @".//div[@class='dotline c4']/div/div[@class='tc_info']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);
        }

        public override string GetWorkTime()
        {
            var xpath = @".//div[@class='c4 dotline']/div[@class='c2']/ul/li";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"营业时间：");
            //var phoneNumNodeList = StoreInfoHtmlNode.SelectNodes(xpath) ?? new HtmlNodeCollection(null);
            //if (phoneNumNodeList.Count <= 0)
            //{
            //    return string.Empty;
            //}
            //foreach (var phoneNumNode in phoneNumNodeList)
            //{
            //    if (phoneNumNode.InnerText.Contains(@"营业时间"))
            //    {
            //        return phoneNumNode.InnerText.Replace("营业时间：", string.Empty);
            //    }
            //}
            //return string.Empty;
        }

        public override string GetBus()
        {
            var xpath = @".//div[@class='dotline c4']/div/div[@class='gj_info']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);
        }

        public override string GetFacilities()
        {
            var xpath = @".//div[@class='c4 dotline']/div[@class='c3']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Replace(@"服务与设施", string.Empty).Replace(@"	", string.Empty);
        }

        public override string GetBasicIntroduction()
        {
            var xpath = @".//div[@class='c4 jianjie']/div[@id='description']/p";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);
        }

    }
}
