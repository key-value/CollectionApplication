using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace FanQieKuaiDianSite
{
    public class StoreSecretary : IStore
    {

        public StoreInfo GetStoreInfo(Catalogue catalogue)
        {
            return catalogue.StoreInfo;
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
            return;
        }

        public string GetAddress()
        {
            return string.Empty;
        }

        public string GetPhoneNum()
        {
            return string.Empty;
        }

        public string GetWorkTime()
        {
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

        public string PageUrl
        {
            get;
            set;
        }

        public event IDelegate.CatalogueEventHandler CataloEventHandler;


        public event IDelegate.LabelEventHandler LabelEventHandler;
    }
}
