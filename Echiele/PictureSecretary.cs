using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;

namespace Echiele
{
    public class PictureSecretary : AbstractMainSite, IPicture
    {

        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(Maticsoft.Model.StoreInfo storeInfo)
        {
            return new List<Maticsoft.Model.BusPhotoAlbum>();
        }
        private StorePicture storePictureBll = new StorePicture();
        private StorePicturesTable StorePicturesTableBll = new StorePicturesTable();
        private BusPhotoAlbumTable BusPhotoAlbumTableBll = new BusPhotoAlbumTable();
        public string _pageUrl = @"http://sz.echiele.com/shop/{0}.html";

        public string PageUrl
        {
            get { return _pageUrl; }
            set { _pageUrl = value; }
        }

        public string PicturType
        {
            get { return "PhotoAlbum"; }
        }

        public void DeletePicture(string storeId)
        {
            var storePicturelist = storePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeId, PicturType));
            foreach (var storePicture in storePicturelist)
            {
                storePictureBll.Delete(storePicture.PID);
            }
            var storePicturesTableBll = new StorePicturesTable();
            var storePicturesTableList = storePicturesTableBll.GetModelList(string.Format("businessID = '{0}'", storeId));
            foreach (var storePicturesTable in storePicturesTableList)
            {
                storePicturesTableBll.Delete(storePicturesTable.StorePicturesID);
            }
        }

        public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
            DeletePicture(storeInfo.storeId);
            const string picturePath = @".//div[@class='dc_center']/div[@class='xq_top']/div[@class='xq_top_left']/div[@class='fangda']/div[@id='preview']/div[@id='spec-n5']/div[@id='spec-list']/ul[@class='list-h']/li/img";
            var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid));
            var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
            var pictureNodeList = pictureHtmlNode.SelectNodes(picturePath);

            var busphotoAlbumTable = BuildBusPhotoAlbumTable(storeInfo);
            SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);


        }
        private void SavePicture(Maticsoft.Model.StoreInfo storeInfo, IEnumerable<HtmlNode> pictureNodeList, Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable)
        {
            foreach (var pictureNode in pictureNodeList)
            {
                var picturePathName = pictureNode.Attributes["imsro"].Value;
                var storePicture = BuildStorePicture(storeInfo, picturePathName);
                storePictureBll.Add(storePicture);
                StorePicturesTableBll.Add(BuildStorePicturesTable(busphotoAlbumTable, storePicture));

            }
        }
        private Maticsoft.Model.StorePicture BuildStorePicture(Maticsoft.Model.StoreInfo storeInfo, string picturePathName)
        {
            var storePicture = new Maticsoft.Model.StorePicture
            {
                PID = Guid.NewGuid().ToString(),
                PicType = PicturType,
                PicturePath = picturePathName,
                StoreId = storeInfo.storeId
            };
            storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
            return storePicture;
        }
        private static Maticsoft.Model.StorePicturesTable BuildStorePicturesTable(Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable, Maticsoft.Model.StorePicture storePicture)
        {
            var storePicturesTable = new Maticsoft.Model.StorePicturesTable
            {
                StorePicturesID = Guid.NewGuid().ToString(),
                BusPhotoAlbumID = busphotoAlbumTable.BusPhotoAlbumID,
                BusinessID = busphotoAlbumTable.BusinessID,
                PictureAddress = storePicture.PictureName,
                PicState = 2,
                UploadTime = DateTime.Now
            };
            return storePicturesTable;
        }
        private Maticsoft.Model.BusPhotoAlbumTable BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo)
        {
            var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
            busphotoAlbumTable.BusinessID = storeInfo.storeId;
            busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
            busphotoAlbumTable.IsDefault = true;
            busphotoAlbumTable.AlbumName = @"餐厅环境";
            BusPhotoAlbumTableBll.Add(busphotoAlbumTable);
            return busphotoAlbumTable;
        }


    }
}
