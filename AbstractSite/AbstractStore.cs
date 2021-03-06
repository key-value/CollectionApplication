﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using Catalogue = Maticsoft.Model.Catalogue;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace AbstractSite
{
    public abstract class AbstractStore : AbstractStorePicture
    {
        protected AbstractStore()
        {
            StorePath = @".";
        }
        public string PageUrl { get; set; }
        protected HtmlNode StoreInfoHtmlNode { get; set; }

        protected string StorePath { get; set; }

        public Maticsoft.Model.StoreInfo GetStoreInfo(Maticsoft.Model.Catalogue catalogue)
        {
            InitProgress();
            DoProgress(50);
            BuildBaseStore();
            DoProgress(50);
            if (StoreInfoHtmlNode == null)
            {
                return new NullStoreInfo();
            }
            int minPrice;
            int maxPrice;
            PeoplePrice(out minPrice, out maxPrice);
            var storeInfo = new StoreInfo();
            storeInfo.storeId = catalogue.StoreId;
            DoProgress(20);
            storeInfo.Fid = catalogue.FId;
            storeInfo.Facilities = GetFacilities().ClearSiteCode().Trim();
            storeInfo.payCar = GetPayCar();
            storeInfo.BasicIntroduction = GetBasicIntroduction().ClearSiteCode().Trim();
            DoProgress(30);
            storeInfo.subway = Subway().ClearSiteCode().Trim();
            storeInfo.bus = GetBus().ClearSiteCode().Trim();
            DoProgress(20);
            storeInfo.box = Getbox();
            storeInfo.StoreHours = GetWorkTime().ClearSiteCode().Trim();
            storeInfo.StoreTag = StoreTagText().ClearSiteCode().Trim();
            storeInfo.carPark = GetCarPark().ClearSiteCode().Trim();
            storeInfo.StoreAddress = GetAddress().ClearSiteCode().Trim();
            storeInfo.StorePhone = GetPhoneNum().ClearSiteCode().Trim();
            DoProgress(20);
            storeInfo.MinPrice = minPrice;
            storeInfo.MaxPrice = maxPrice;
            storeInfo = ChangeStoreInfo(catalogue, storeInfo);
            DoProgress();
            return storeInfo;
        }

        protected virtual void BuildBaseStore()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            StoreInfoHtmlNode = baseCollectionSite.BaseHtmlNode.SelectSingleNode(StorePath);
        }

        protected virtual StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            return storeInfo;
        }

        public virtual string GetFacilities()
        {
            return string.Empty;
        }

        public virtual string Subway()
        {
            return string.Empty;
        }

        public virtual string GetCarPark()
        {
            return string.Empty;
        }

        public virtual string GetBus()
        {
            return string.Empty;
        }

        public virtual string StoreTagText()
        {
            return string.Empty;
        }

        public virtual void PeoplePrice(out int minPrice, out int maxPrice)
        {
            minPrice = 0;
            maxPrice = 0;
            return;
        }

        public virtual string GetAddress()
        {
            return string.Empty;
        }

        public virtual string GetPhoneNum()
        {
            return string.Empty;
        }

        public virtual string GetWorkTime()
        {
            return string.Empty;
        }

        public virtual bool GetPayCar()
        {
            return false;
        }

        public virtual string GetBasicIntroduction()
        {
            return string.Empty;
        }

        public virtual bool Getbox()
        {
            return false;
        }
    }
}
