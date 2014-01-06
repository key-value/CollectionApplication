using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;

namespace AbstractSite
{
    public abstract class AbstractPicture
    {
        protected AbstractPicture()
        {
            TypeList = new List<string>();
            StorePictureUrl = string.Empty;
        }
        protected StorePicture StorePictureBll = new StorePicture();
        protected StorePicturesTable StorePicturesTableBll = new StorePicturesTable();
        protected BusPhotoAlbumTable BusPhotoAlbumTableBll = new BusPhotoAlbumTable();

        public string PageUrl { get; set; }
        public string PicturType
        {
            get { return "PhotoAlbum"; }
        }
        public string PicturePath { get; set; }

        public string StorePictureUrl { get; set; }

        public virtual void DeletePicture(string storeId)
        {
            var storePicturelist = StorePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeId, PicturType));
            foreach (var storePicture in storePicturelist)
            {
                StorePictureBll.Delete(storePicture.PID);
            }
            var storePicturesTableBll = new StorePicturesTable();
            var storePicturesTableList = storePicturesTableBll.GetModelList(string.Format("businessID = '{0}'", storeId));
            foreach (var storePicturesTable in storePicturesTableList)
            {
                storePicturesTableBll.Delete(storePicturesTable.StorePicturesID);
            }
        }

        protected List<string> TypeList;
        public virtual void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
            DeletePicture(storeInfo.storeId);
            for (int i = 0; i < TypeList.Count; i++)
            {
                var busphotoAlbumTable = BuildBusPhotoAlbumTable(storeInfo, i);
                CollectionPicture(storeInfo, busphotoAlbumTable, TypeList[i]);
            }
        }
        protected virtual void CollectionPicture(Maticsoft.Model.StoreInfo storeInfo, Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        {
            var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid));
            var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
            var pictureNodeList = pictureHtmlNode.SelectNodes(PicturePath);
            SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
        }
        protected virtual void SavePicture(Maticsoft.Model.StoreInfo storeInfo, IEnumerable<HtmlNode> pictureNodeList, Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable)
        {
            foreach (var pictureNode in pictureNodeList)
            {
                var picturePathName = StorePictureUrl + pictureNode.Attributes["src"].Value;
                var storePicture = BuildStorePicture(storeInfo, picturePathName);
                StorePictureBll.Add(storePicture);
                StorePicturesTableBll.Add(BuildStorePicturesTable(busphotoAlbumTable, storePicture));

            }
        }
        protected virtual Maticsoft.Model.StorePicturesTable BuildStorePicturesTable(Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable, Maticsoft.Model.StorePicture storePicture)
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
        protected virtual Maticsoft.Model.BusPhotoAlbumTable BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo, int albumType)
        {
            var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
            busphotoAlbumTable.BusinessID = storeInfo.storeId;
            busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
            busphotoAlbumTable.IsDefault = true;
            busphotoAlbumTable.AlbumName = @"餐厅环境";
            if (albumType == 1)
            {
                busphotoAlbumTable.AlbumName = @"菜品图片";
            }
            BusPhotoAlbumTableBll.Add(busphotoAlbumTable);
            return busphotoAlbumTable;
        }
        protected virtual Maticsoft.Model.StorePicture BuildStorePicture(Maticsoft.Model.StoreInfo storeInfo, string picturePathName)
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
    }
}
