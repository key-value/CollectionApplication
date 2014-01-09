using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FanQieKuaiDianSite.Model;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;

namespace FanQieKuaiDianSite
{
    public class CatalogueSecretary : ICatalogue
    {
        public List<Catalogue> GetCataloguePage(int poIndex)
        {
            throw new NotImplementedException();
        }
        private StoreInfo _storeInfoBll = new StoreInfo();
        private StorePicture _storePictureBll = new StorePicture();

        public CatalogueSecretary()
        {
            PicType = "Shop";
        }

        public string PageUrl { get; set; }

        public int PageNum { get; set; }

        public int PageCount { get; set; }

        public string PicType { get; private set; }

        public int IflastPage { get; set; }


        public bool CheckStoreIsRead(string keyID, ref string storeId)
        {
            var temStoreInfoList = _storeInfoBll.GetModelList(string.Format("Fid = '{0}'", keyID));
            if (temStoreInfoList != null && temStoreInfoList.Count > 0)
            {
                var temStoreInfo = temStoreInfoList.FirstOrDefault();
                if (temStoreInfo != null)
                {
                    //DeleteOldPicture(temStoreInfo);
                    return true;
                }
            }
            return false;
        }

        public void DeleteOldPicture(Maticsoft.Model.StoreInfo temStoreInfo)
        {
            var oldStorePicture =
               _storePictureBll.GetModelList(string.Format("PicType ='{1}' and StoreId = '{0}'",
                   temStoreInfo.storeId, PicType));
            foreach (var storePicture in oldStorePicture)
            {
                _storePictureBll.Delete(storePicture.PID);
            }
        }

        public string SavePictureName(string storeId, string shopPicturePath)
        {
            return string.Empty;
        }
        public List<Catalogue> GetPageCatalogue(int poIndex)
        {
            var catalogueList = new List<Catalogue>();
            var collectionPhone = new CollectionPhone();
            collectionPhone.headDictionary.Add("city", "1");
            collectionPhone.PageUrl = PageUrl;
            collectionPhone.dictionary.Add("pageno", PageNum.ToString());
            collectionPhone.dictionary.Add("circleid", CircleId.ToString());
            collectionPhone.dictionary.Add("City", "1");
            collectionPhone.dictionary.Add("pagesize", "20");
            var location = collectionPhone.GetResualt<Location>();
            if (location == null)
            {
                return catalogueList;
            }
            PageNum = location.PageNo;
            PageCount = location.TotalPage;
            IflastPage = location.IflastPage;
            foreach (var restaurantinfo in location.RestaurantinfoList)
            {
                var catalogue = new Catalogue
                {
                    FId = restaurantinfo.ID,
                    title = restaurantinfo.CtName,
                    href = string.Empty,
                    LocalTagID = poIndex,
                    StoreId = restaurantinfo.ID,
                    StoreInfo =
                        new Maticsoft.Model.StoreInfo
                        {
                            storeId = restaurantinfo.ID,
                            Fid = restaurantinfo.ID,
                            StoreAddress = restaurantinfo.Ctaddress,
                            StoreName = restaurantinfo.CtName,
                            StorePhone = restaurantinfo.Phone,
                            StoreTag = restaurantinfo.CategoryName,
                            MaxPrice = restaurantinfo.Price,
                            DishesNum = restaurantinfo.DishesNum,
                            MinPrice = 0
                        }
                };
                catalogue.IsRead = CheckStoreIsRead(restaurantinfo.ID, ref restaurantinfo.ID);
                catalogueList.Add(catalogue);
            }
            return catalogueList;
        }

        public int CircleId { get; set; }


        public string NextPage { get; set; }

        public string BeforePage { get; set; }


        public event IDelegate.CatalogueEventHandler CataloEventHandler;
    }
}
