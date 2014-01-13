using System;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;


namespace DianPing
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='shop-wrap']/div[@class='main']/div[@class='shop-info shakeable']/div[@class='shop-info-con']/div[@class='pic-txt']/div[@class='txt']/div[@class='shop-info-location']";
            ImgNodePath = @"./../../div[@class='pic']/div[@class='thumb-switch']/ul/li/a/img";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            storeInfo.picName = GetImageHref(StoreInfoHtmlNode, storeInfo.storeId);
            storeInfo.WIFI = storeInfo.Facilities.Contains(@"无线上网");
            storeInfo.payCar = storeInfo.Facilities.Contains(@"可以刷卡");
            storeInfo.DishTypeSite = GetDishTypeSite();
            return storeInfo;
        }

        public bool GetDishTypeSite()
        {
            const string xpath = @"./../../../../../../../div[@class='shop-wrap']/div[@class='main']/div/div[@class='tabs']/ul/li/a[@class='ga-menu J_menu_tag']";
            return CollectionNodeText.GetNodeContainsInnerText(StoreInfoHtmlNode, xpath, @"菜单") != null;
        }

        public override string GetWorkTime()
        {
            const string xpath = @"./div[@class='desc-info']/div[@class='desc-list Hide']/ul/li/span[@class='J_full-cont']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Trim();
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["src"].Value;
        }

        public override string GetAddress()
        {
            const string xpath = @"./div[@class='shop-location']/ul/li";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Replace(@"地址：", string.Empty).Trim();
        }

        public override string GetPhoneNum()
        {
            const string xpath = @".//div[@class='shop-location']//ul/li/span[@class='call']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Trim();
        }

        public override string StoreTagText()
        {
            const string xpath = @".//div[@class='desc-info']/div[@class='desc-list Hide']/ul/li[@class='J_tags-fold-wrap J_toggle J_tags-biaoqian']/div/span/a";
            return CollectionNodeText.GetNodeListInnerText(StoreInfoHtmlNode, xpath).Trim();
        }
    }
}
