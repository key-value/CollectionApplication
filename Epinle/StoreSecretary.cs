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
    public class StoreSecretary : IStore
    {
        public string PageUrl { get; set; }
        public StoreInfo GetStoreInfo(Catalogue catalogue)
        {
            var storePath = @"//*[@id='container']";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            StoreInfoHtmlNode = baseCollectionSite.BaseHtmlNode;
            StoreInfoHtmlNode = StoreInfoHtmlNode.SelectSingleNode(storePath);
            if (StoreInfoHtmlNode == null)
            {
                return new NullStoreInfo();
            }
            int minPrice;
            int maxPrice;
            PeoplePrice(out minPrice, out maxPrice);
            var storeInfo = new StoreInfo();
            storeInfo.storeId = catalogue.StoreId;
            storeInfo.Fid = catalogue.FId;
            storeInfo.Facilities = GetFacilities();
            storeInfo.payCar = GetPayCar();
            storeInfo.BasicIntroduction = GetBasicIntroduction();
            storeInfo.subway = Subway();
            storeInfo.bus = GetBus();
            storeInfo.box = Getbox();
            storeInfo.MaxPrice = maxPrice;
            storeInfo.MinPrice = minPrice;
            storeInfo.StorePhone = GetPhoneNum();
            storeInfo.StoreHours = GetWorkTime();
            storeInfo.StoreTag = StoreTagText();
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.carPark = GetCarPark();
            return new NullStoreInfo();
        }
        public HtmlNode StoreInfoHtmlNode
        {
            get;
            set;
        }

        public string GetFacilities()
        {
            return string.Empty;
        }

        public string Subway()
        {
            return string.Empty;
        }

        public string GetCarPark()
        {
            return string.Empty;
        }

        public string GetBus()
        {
            return string.Empty;
        }

        public string StoreTagText()
        {
            return string.Empty;
        }

        public void PeoplePrice(out int minPrice, out int maxPrice)
        {
            minPrice = 0;
            maxPrice = 0;
            const string pricePath = @"//*[@id='goodsOrd']";
            var peoplePriceNode = StoreInfoHtmlNode.SelectSingleNode(pricePath);
            var priceText = peoplePriceNode.InnerText;
            string regex = @"(\d*)[\u4E00-\u9FA5]*";
            bool isMax = true;
            if (priceText.Contains('-'))
            {
                isMax = false;
                regex = @"(\d*)-(\d*)";
            }
            if (!Regex.IsMatch(priceText, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(priceText, regex);
            if (isMax)
            {
                maxPrice = int.Parse(string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                       ? string.Empty
                       : matchCollection.Groups[1].Value);
            }
            else
            {
                minPrice = int.Parse(string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                       ? string.Empty
                       : matchCollection.Groups[2].Value);
                maxPrice = int.Parse(string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                       ? string.Empty
                       : matchCollection.Groups[1].Value);
            }

        }

        public string GetAddress()
        {
            return string.Empty;
        }

        public string GetPhoneNum()
        {
            var xpath = @".//div[@class='content']/div[@class='restaurantInfo']/div[@class='left']/ul/li";
            var phoneNumNodeList = StoreInfoHtmlNode.SelectNodes(xpath) ?? new HtmlNodeCollection(null);
            if (phoneNumNodeList.Count <= 0)
            {
                return string.Empty;
            }
            foreach (var phoneNumNode in phoneNumNodeList)
            {
                if (phoneNumNode.InnerText.Contains(@"订座电话"))
                {
                    return phoneNumNode.InnerText.Replace("订座电话：", string.Empty);
                }
            }
            return string.Empty;
        }

        public string GetWorkTime()
        {
            var xpath = @".//div[@class='content']/div[@class='restaurantInfo']/div[@class='left']/ul/li";
            var phoneNumNodeList = StoreInfoHtmlNode.SelectNodes(xpath) ?? new HtmlNodeCollection(null);
            if (phoneNumNodeList.Count <= 0)
            {
                return string.Empty;
            }
            foreach (var phoneNumNode in phoneNumNodeList)
            {
                if (phoneNumNode.InnerText.Contains(@"营业时间"))
                {
                    return phoneNumNode.InnerText.Replace("营业时间：", string.Empty);
                }
            }
            return string.Empty;
        }

        public bool GetPayCar()
        {
            return false;
        }

        public string GetBasicIntroduction()
        {
            return string.Empty;
        }

        public bool Getbox()
        {
            return false;
        }

        public event IDelegate.CatalogueEventHandler CataloEventHandler;
    }
}
