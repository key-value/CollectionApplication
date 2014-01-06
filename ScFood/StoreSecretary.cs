using System;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;


namespace ScFood
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w980 fleft']";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            storeInfo.Facilities += catalogue.StoreInfo.Facilities;
            storeInfo.StorePhone = catalogue.StoreInfo.StorePhone;
            return storeInfo;
        }


        public override string GetBus()
        {
            var xpath =
                @".//div[@class='shopmid']/div[@class='shopw']/div[@class='shopmidw']/div[@class='wid_left']/div[@class='w718 fleft']/div[@class='w470 fleft']/div[@class='w470  fleft']/div[@class='dplist3  fleft w470']/div[@class='text fleft w470']/div[@class='w718 fleft mtop8']/div[@class='desc-list']/dl";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"公交信息:").Trim();
        }

        public override string GetWorkTime()
        {
            var xpath =
                @".//div[@class='shopmid']/div[@class='shopw']/div[@class='shopmidw']/div[@class='wid_left']/div[@class='w718 fleft']/div[@class='w470 fleft']/div[@class='w470  fleft']/div[@class='dplist3  fleft w470']/div[@class='text fleft w470']/div[@class='w718 fleft mtop8']/div[@class='desc-list']/dl";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"营业时间:").Trim().Replace("修改", string.Empty).Trim();

        }

        public override string GetBasicIntroduction()
        {
            var xpath =
                @".//div[@class='shopmid']/div[@class='shopw']/div[@class='shopmidw']/div[@class='wid_left']/div[@class='w718 fleft']/div[@class='w470 fleft']/div[@class='w470  fleft']/div[@class='dplist3  fleft w470']/div[@class='text fleft w470']/div[@class='w718 fleft mtop8']/div[@class='desc-list']/dl/dd/span[@id='content_x']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);
        }
    }
}
