using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;

namespace Epinle
{
    public class PictureSecretary : IPicture
    {
        private StorePicture storePictureBll = new StorePicture();
        public string _pageUrl { get; set; }

        public string PageUrl { get; set; }

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
            var picturePath = @"//*[@id='menu']/[@class='clearboth']";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            //        var dishesPicturePath = pictureNode.Attributes["src"].Value;
            //        if (string.IsNullOrEmpty(dishesPicturePath) || dishesPicturePath.Contains("nopic"))
            //        {
            //            continue;
            //        }
            //        var storePicture = BuildStorePicture(storeInfo, dishesPicturePath);
            //        StorePictureBll.Add(storePicture);
            //        StorePicturesTableBll.Add(BuildStorePicturesTable(busphotoAlbumTable, storePicture));


        }
        private Maticsoft.Model.BusPhotoAlbumTable BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo)
        {
            var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
            busphotoAlbumTable.BusinessID = storeInfo.storeId;
            busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
            busphotoAlbumTable.IsDefault = true;
            var busPhotoAlbumTableBll = new Maticsoft.BLL.BusPhotoAlbumTable();
            busphotoAlbumTable.AlbumName = @"餐厅环境";
            busPhotoAlbumTableBll.Add(busphotoAlbumTable);
            return busphotoAlbumTable;
        }
    }
}
