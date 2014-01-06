using System;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;


namespace DuoMiFan
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            storeInfo.MinPrice = catalogue.StoreInfo.MinPrice;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            return storeInfo;
        }


        public override string GetBus()
        {
            var xpath =
                @".//div[@id='res_show_xiangxi']/div[@id='res_show_xxbk']/div[@id='res_show_xx_jbxx']/div[@id='res_show_xx_jbxxL']/div[@id='res_show_xx_jbxxL02']/div[@id='res_show_xx_jbxxL_gj']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Replace("公交：", string.Empty).Trim();
        }

        public override string GetWorkTime()
        {
            var xpath =
                @".//div[@id='res_show_xiangxi']/div[@id='res_show_xxbk']/div[@id='res_show_xx_jbxx']/div[@id='res_show_xx_jbxxL']/div[@id='res_show_xx_jbxxL01']/div[@id='res_show_xx_jbxxL01R']/div[@id='res_show_xx_jbxxL01Rsj']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);

        }

        public override string GetBasicIntroduction()
        {
            var xpath =
                @".//div[@id='res_pagebody4']/div[@id='res_show_jbxx']/div[@id='res_show_jbxxR']/div[@id='res_show_jbxxR_jjxx']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Replace("推荐理由：", string.Empty).Replace("&nbsp;", string.Empty).Replace(@"◆", string.Empty).Replace(@"全部", string.Empty).Replace(@"展开", string.Empty).Replace(@"收起", string.Empty).Replace(@"简介", string.Empty).Trim();
        }

        public override string GetFacilities()
        {
            var xpath =
                @".//div[@id='res_show_xiangxi']/div[@id='res_show_xxbk']/div[@id='res_show_xx_jbxx']/div[@id='res_show_xx_jbxxL']/div[@id='res_show_xx_jbxxL_ytss']/div[@id='res_show_xx_jbxxL_fw']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath).Replace("服务：", string.Empty).Trim();
        }

        public override string StoreTagText()
        {
            var xpath =
                @".//div[@id='res_show_xiangxi']/div[@id='res_show_xxbk']/div[@id='res_show_xx_jbxx']/div[@id='res_show_xx_jbxxL']/div[@id='res_show_xx_jbxxL_ytss']/div[@id='res_show_xx_jbxxL_yt']";
            return CollectionNodeText.GetNodeInnerText(StoreInfoHtmlNode, xpath);
        }
    }
}
