using System;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;


namespace TaoBao
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='page']/div[@class='content']/div[@class='shop-intro']";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            return storeInfo;
        }


        public override string GetPhoneNum()
        {
            const string xpath = @"./div[@class='shop-other']/span[@class='shop-tel']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Trim();
        }

        protected override void BuildBaseStore()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            StoreInfoHtmlNode = baseCollectionSite.BaseHtmlNodeByGBK.SelectSingleNode(StorePath);
        }
    }
}
