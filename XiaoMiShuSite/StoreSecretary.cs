﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace XiaoMiShuSite
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='constr']/div[@class='constr_in pt15 pb30']/div[@class='l res_detail_con']";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.StorePictureHref = catalogue.StorePictureHref;
            storeInfo.payCar = storeInfo.Facilities.Contains(@"可以刷卡");
            storeInfo.ChildrenChair = storeInfo.Facilities.Contains(@"有宝宝椅");
            storeInfo.CarParks = storeInfo.Facilities.Contains(@"有停车位");
            storeInfo.WIFI = storeInfo.Facilities.Contains(@"无线上网");
            storeInfo.NoSmoke = storeInfo.Facilities.Contains(@"全场禁烟");

            return storeInfo;
        }

        public override string GetWorkTime()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"营业时间:").Trim().Replace(@"修改", string.Empty);
        }

        public override string GetAddress()
        {
            const string xpath = @".//div[@class='res_hm_find']/div[@class='res_hm_find_in z']/div[@class='fix pb10']/div[@class='cell pl20']/div[@class='dash pb15 mr5']/div[@class='lh22']";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"地址:").Trim().Replace(@"修改/报错", string.Empty).Replace(@"上海", string.Empty);
        }

        public override string GetPhoneNum()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"预订热线:").Replace("&nbsp;", string.Empty).Replace(@"021-57575777我吃,我吃,我吃吃吃", string.Empty).Trim().Replace(@"修改", string.Empty);
        }

        public override string StoreTagText()
        {
            string xpath = @".//div[@class='cell pl5']/a[@class='dib mr5']";
            var stringBuilder = new StringBuilder(CollectionNodeText.GetNodeListInnerText(StoreInfoHtmlNode, xpath).Trim());
            xpath = @".//div[@class='p20 mt5']/div[@class='mt10 f13']/div[@class='fix mb2']/p[@class='cell pl15']/a[@class='mr10']";
            stringBuilder.Append("、");
            stringBuilder.Append(CollectionNodeText.GetNodeListInnerText(StoreInfoHtmlNode, xpath).Trim());
            return stringBuilder.ToString();
        }

        public override void PeoplePrice(out int minPrice, out int maxPrice)
        {
            minPrice = 0;
            maxPrice = 0;
            const string xpath = @".//div[@class='res_hm_find']/div[@class='res_hm_find_in z']/div[@class='fix pb10']/div[@class='cell pl20']/div[@class='dash pb15 mr5']/div[@class='lh22']/strong[@class ='cr']";
            var peoplePriceText = CollectionNodeText.GetNodeListInnerText(StoreInfoHtmlNode, xpath).Trim();
            if (string.IsNullOrWhiteSpace(peoplePriceText))
            {
                return;
            }
            var peoplePriceList = peoplePriceText.Trim().Split('-');
            if (peoplePriceList.Count() == 2)
            {
                int.TryParse(peoplePriceList[0], out minPrice);
                int.TryParse(peoplePriceList[1], out maxPrice);
            }
        }

        public override string GetFacilities()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"设施服务:").Replace(@"<!-- 可以刷卡的列表 -->", string.Empty).Replace(@"       ", @" ").Replace(@"万事达(Master)", string.Empty).Replace(@"美国运通(AE)", string.Empty).Replace(@"JCB", string.Empty).Replace(@"VISA", string.Empty).Replace(@"   ", @" ");
        }

        public override string GetBasicIntroduction()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"餐厅简介:").Replace(@"。展开", @"。");
        }

        public override string GetBus()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"公交:").Replace(@"修改", string.Empty);
        }

        public override string GetCarPark()
        {
            const string xpath = @"./div[@class='p20 mt5']/div[@class='mt10 f13']/div";
            return CollectionNodeText.GetNodeListContainsInnerText(StoreInfoHtmlNode, xpath, @"停车:");
        }

        public override bool Getbox()
        {
            return StoreInfoHtmlNode.SelectSingleNode(".//a[@class='res_seat selSchSeat']") != null;
        }
    }
}
