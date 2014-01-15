using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using BusPhotoAlbum = Maticsoft.Model.BusPhotoAlbum;
using StoreInfo = Maticsoft.Model.StoreInfo;
using StorePicture = Maticsoft.Model.StorePicture;

namespace GaFan
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {
        public PictureSecretary()
        {
            PageUrl = @"http://www.epinle.com/index.php?app=store&act={0}";
            StorePictureUrl = @"http://www.epinle.com/";
        }
        //public void DeletePicture(string storeId)&act=ip&ip=1
        //{
        //    var storePicturelist = storePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeId, PicturType));
        //    foreach (var storePicture in storePicturelist)
        //    {
        //        storePictureBll.Delete(storePicture.PID);
        //    }
        //    var storePicturesTableBll = new StorePicturesTable();
        //    var storePicturesTableList = storePicturesTableBll.GetModelList(string.Format("businessID = '{0}'", storeId));
        //    foreach (var storePicturesTable in storePicturesTableList)
        //    {
        //        storePicturesTableBll.Delete(storePicturesTable.StorePicturesID);
        //    }
        //}

        public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
            //var picturePath = @"//*[@id='menu']/[@class='clearboth']";
            //var baseCollectionSite = new BaseCollectionSite(PageUrl);
            //var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            //        var dishesPicturePath = pictureNode.Attributes["src"].Value;
            //        if (string.IsNullOrEmpty(dishesPicturePath) || dishesPicturePath.Contains("nopic"))
            //        {
            //            continue;
            //        }
            //        var storePicture = BuildStorePicture(storeInfo, dishesPicturePath);
            //        StorePictureBll.Add(storePicture);
        }
        //private Maticsoft.Model.BusPhotoAlbumTable BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo)
        //{
        //    var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
        //    busphotoAlbumTable.BusinessID = storeInfo.storeId;
        //    busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
        //    busphotoAlbumTable.IsDefault = true;
        //    var busPhotoAlbumTableBll = new Maticsoft.BLL.BusPhotoAlbumTable();
        //    busphotoAlbumTable.AlbumName = @"餐厅环境";
        //    busPhotoAlbumTableBll.Add(busphotoAlbumTable);
        //    return busphotoAlbumTable;
        //}


        //public override List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(Maticsoft.Model.StoreInfo storeInfo)
        //{
        //    return new List<Maticsoft.Model.BusPhotoAlbum>();
        //}

        public override string PicturePath(string albumType)
        {
            return string.Empty;
        }

        protected override List<string> GetTypeList()
        {
            return new List<string>() { "getXc", "getMenu" };
        }

        protected override List<StorePicture> PicturesBody(StoreInfo storeInfo, BusPhotoAlbum busphotoAlbumTable, string albumType, ref int pageNum)
        {
            var collectionPhone = new CollectionPhone();
            collectionPhone.PageUrl = GetPageUrl(storeInfo, albumType, pageNum);
            var sid = GetStoreSid(storeInfo.StorePictureHref);
            collectionPhone.dictionary.Add("s_id", sid);
            collectionPhone.dictionary.Add("id", sid);
            collectionPhone.dictionary.Add("page", pageNum.ToString());
            collectionPhone.dictionary.Add("keyword", string.Empty);

            try
            {
                //var location = collectionPhone.GetEpinLeResualt<List<PictureModel>>();
                //if (location == null || location.Count <= 0)
                //{
                //    pageNum = 500;
                return new List<StorePicture>();
                //}
                //return SavePicture(storeInfo, location, busphotoAlbumTable);
            }
            catch
            {
                pageNum = 500;
                return new List<StorePicture>();
            }
        }

        private string GetStoreSid(string storePictureHref)
        {
            string regex = @"\/store_(\d*)\/";
            if (!Regex.IsMatch(storePictureHref, regex))
            {
                return string.Empty;
            }
            var matchCollection = Regex.Match(storePictureHref, regex);
            return matchCollection.Groups[1].Value;
        }

        protected override string GetPageUrl(StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, albumType);
        }


    }
}
