using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace Cyooy
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {
        public PictureSecretary()
        {
            StorePictureUrl = @"http://www.cyooy.com/";
        }
        public string _pageUrl = @"http://www.cyooy.com/photoAlbum.php?id={0}&p={1}";

        public string PageUrl
        {
            get { return _pageUrl; }
            set { _pageUrl = value; }
        }


        //public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        //{
        //    DeletePicture(storeInfo.storeId);
        //    var busphotoAlbumTable = BuildBusPhotoAlbumTable(storeInfo);
        //    const string picturePath = @".//div[@align='center']/div[@id='container']/div[@id='photoAlbum']/li/a/img";
        //    for (int i = 1; i < 100; i++)
        //    {
        //        var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, i));
        //        var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
        //        var pictureNodeList = pictureHtmlNode.SelectNodes(picturePath);
        //        if (pictureNodeList == null)
        //        {
        //            break;
        //        }
        //        SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
        //    }
        //}
        //private void SavePicture(Maticsoft.Model.StoreInfo storeInfo, IEnumerable<HtmlNode> pictureNodeList, Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable)
        //{
        //    foreach (var pictureNode in pictureNodeList)
        //    {
        //        var picturePathName = @"http://www.cyooy.com/" + pictureNode.Attributes["src"].Value;
        //        var storePicture = BuildStorePicture(storeInfo, picturePathName);
        //        storePictureBll.Add(storePicture);
        //        StorePicturesTableBll.Add(BuildStorePicturesTable(busphotoAlbumTable, storePicture));

        //    }
        ////}
        //private Maticsoft.Model.StorePicture BuildStorePicture(Maticsoft.Model.StoreInfo storeInfo, string picturePathName)
        //{
        //    var storePicture = new Maticsoft.Model.StorePicture
        //    {
        //        PID = Guid.NewGuid().ToString(),
        //        PicType = PicturType,
        //        PicturePath = picturePathName,
        //        StoreId = storeInfo.storeId
        //    };
        //    storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
        //    return storePicture;
        //}
        //private static Maticsoft.Model.StorePicturesTable BuildStorePicturesTable(Maticsoft.Model.BusPhotoAlbumTable busphotoAlbumTable, Maticsoft.Model.StorePicture storePicture)
        //{
        //    var storePicturesTable = new Maticsoft.Model.StorePicturesTable
        //    {
        //        StorePicturesID = Guid.NewGuid().ToString(),
        //        BusPhotoAlbumID = busphotoAlbumTable.BusPhotoAlbumID,
        //        BusinessID = busphotoAlbumTable.BusinessID,
        //        PictureAddress = storePicture.PictureName,
        //        PicState = 2,
        //        UploadTime = DateTime.Now
        //    };
        //    return storePicturesTable;
        //}
        //private Maticsoft.Model.BusPhotoAlbumTable BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo)
        //{
        //    var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
        //    busphotoAlbumTable.BusinessID = storeInfo.storeId;
        //    busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
        //    busphotoAlbumTable.IsDefault = true;
        //    busphotoAlbumTable.AlbumName = @"餐厅环境";
        //    BusPhotoAlbumTableBll.Add(busphotoAlbumTable);
        //    return busphotoAlbumTable;
        //}


        public override string PicturePath(string albumType)
        {
            return @".//div[@align='center']/div[@id='container']/div[@id='photoAlbum']/li/a/img";
        }

        protected override List<string> GetTypeList()
        {
            return new List<string>() { "x" };
        }

        protected override string GetPageUrl(StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, storeInfo.Fid, pageNum);
        }


        public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
        }
    }
}
