using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using Maticsoft.Model;

namespace CollectionLogic
{
    public class SaveStoreEntity : AbstractMainSite
    {
        public SaveStoreEntity()
        {
        }
        public void SaveStoreSpecialTag(StoreInfoEntity storeInfoEntity, List<SpecialTag> specialTagList)
        {
            var storeSpecialBll = new Maticsoft.BLL.StoreSpecialTag();
            storeSpecialBll.Remove(string.Format("bizid = '{0}'", storeInfoEntity.BizID));
            DoProgress();
            foreach (var specialTag in specialTagList)
            {
                if (specialTag != null)
                {
                    var storeSpecial = new Maticsoft.Model.StoreSpecialTag();
                    storeSpecial.BizID = storeInfoEntity.BizID;
                    storeSpecial.SpecialTagID = specialTag.SpecialTagID;
                    storeSpecial.TagName = specialTag.TagName;
                    storeSpecial.StoreSpecialTagID = Guid.NewGuid().ToString();
                    storeSpecialBll.Add(storeSpecial);
                }
            }
            DoProgress();
        }
        public void SaveCookingStyles(StoreInfoEntity storeInfoEntity, IEnumerable<CookingStyles> cookingStylesList)
        {
            var storeCookingStylesBll = new Maticsoft.BLL.StoreCookingStyles();
            storeCookingStylesBll.Remove(string.Format("bizid = '{0}'", storeInfoEntity.BizID));
            DoProgress(20);
            foreach (var specialTag in cookingStylesList)
            {
                if (specialTag != null)
                {
                    var storeCookingStyles = new Maticsoft.Model.StoreCookingStyles();
                    storeCookingStyles.BizID = storeInfoEntity.BizID;
                    storeCookingStyles.CookingStyleID = specialTag.CookingStyleID;
                    storeCookingStyles.CookingStyleName = specialTag.CookingStyleName;
                    storeCookingStyles.KeyID = Guid.NewGuid().ToString();
                    storeCookingStylesBll.Add(storeCookingStyles);
                }
            }
            DoProgress();
        }
        public void SaveCityLocalTagEntity(StoreInfoEntity storeInfoEntity, IEnumerable<CityLocalTagEntity> cityLocalTagEntityList)
        {
            var storeLocalTagBll = new Maticsoft.BLL.StoreLocalTag();
            storeLocalTagBll.Remove(string.Format("bizid = '{0}'", storeInfoEntity.BizID));
            DoProgress(30);
            foreach (var cityLocalTag in cityLocalTagEntityList)
            {
                var storeLocalTag = new Maticsoft.Model.StoreLocalTag();
                storeLocalTag.BizID = storeInfoEntity.BizID;
                storeLocalTag.BizType = 10;
                storeLocalTag.DistrictID = storeInfoEntity.DistrictID;
                storeLocalTag.KeyID = Guid.NewGuid().ToString();
                storeLocalTag.LocalTagID = cityLocalTag.LocalTagID;
                storeLocalTag.LocalTagName = cityLocalTag.TagName;
                storeLocalTagBll.Add(storeLocalTag);
            }
            DoProgress();
        }
        public void SaveDishes(StoreInfoEntity storeInfoEntity, StoreInfo siteStoreInfo)
        {
            var dishTypeBll = new Maticsoft.BLL.DishesTyep();
            var dishesEntityBll = new Maticsoft.BLL.DishesBll();
            var storePictureBll = new Maticsoft.BLL.StorePicture();
            DoProgress(30);
            dishesEntityBll.Remove(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
            dishTypeBll.Remove(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
            foreach (var dishType in siteStoreInfo.DishTypeList)
            {
                dishType.BusinessID = storeInfoEntity.BizID;
                dishTypeBll.Add(dishType);
                foreach (var dishesEntity in dishType.DishesList)
                {
                    dishesEntity.BusinessID = storeInfoEntity.BizID;
                    dishesEntityBll.Add(dishesEntity);
                    if (!string.IsNullOrEmpty(dishesEntity.PictureHref) && !string.IsNullOrWhiteSpace(dishesEntity.PictureHref))
                    {
                        var storePicture = new Maticsoft.Model.StorePicture();
                        storePicture.PID = Guid.NewGuid().ToString();
                        storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
                        storePicture.PicType = "Food";
                        storePicture.PicturePath = dishesEntity.PictureHref;
                        storePicture.StoreId = storeInfoEntity.BizID;
                        storePictureBll.Add(storePicture);
                    }
                }
            }
            DoProgress();
        }
        public void SaveStorePictures(StoreInfoEntity storeInfoEntity, StoreInfo siteStoreInfo)
        {
            var storePicturesBll = new Maticsoft.BLL.StorePictures();
            storePicturesBll.Remove(string.Format("BusinessID ='{0}'", storeInfoEntity.BizID));
            var busPhotoAlbumBll = new Maticsoft.BLL.BusPhotoAlbum();
            busPhotoAlbumBll.Remove(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
            var storePictureBll = new Maticsoft.BLL.StorePicture();
            DoProgress(30);
            foreach (var busPhotoAlbum in siteStoreInfo.BusPhotoAlbumTableList)
            {
                busPhotoAlbum.BusinessID = storeInfoEntity.BizID;
                busPhotoAlbumBll.Add(busPhotoAlbum);
                var pcituresList = busPhotoAlbum.StorePicturesList;
                foreach (var storePicture in pcituresList)
                {
                    storePicture.StoreId = storeInfoEntity.BizID;
                    storePictureBll.Add(storePicture);
                    var storePictures = new Maticsoft.Model.StorePictures
                    {
                        StorePicturesID = Guid.NewGuid().ToString(),
                        BusPhotoAlbumID = busPhotoAlbum.BusPhotoAlbumID,
                        BusinessID = busPhotoAlbum.BusinessID,
                        PictureAddress = storePicture.PictureName,
                        PicState = 2,
                        UploadTime = DateTime.Now
                    };
                    storePicturesBll.Add(storePictures);
                }
            }
            DoProgress();
        }
    }
}
