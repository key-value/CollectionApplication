using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    class PictureSecretary : IPicture
    {
        //protected PictureSecretary(string pageUrl)
        //    : base(pageUrl)
        //{

        //}
        //public override void GetPicture(StoreInfo storeInfo)
        //{
        //    var picPullList = new List<PicPull>() { PicPull.Environmental, PicPull.Cake };

        //    DeleteStorePicture(storeInfo);
        //    DeleteStorePicturesTable(storeInfo);
        //    foreach (var picPull in picPullList)
        //    {
        //        var busphotoAlbumTable = BuildBusPhotoAlbumTable(storeInfo, picPull);
        //        BusPhotoAlbumTableBll.Add(busphotoAlbumTable);
        //        var pageIndex = 1;
        //        while (true)
        //        {
        //            //t=-1 2 3时有值
        //            var picturePath = @"{0}shop/new/ajax/picpull.aspx?resid={1}&t={2}&time={3}";

        //            picturePath = string.Format(picturePath, storeInfo.Fid, (int)picPull, pageIndex);
        //            pageIndex++;
        //            var htmlWeb = new HtmlWeb();

        //            var htmlDoc = htmlWeb.Load(picturePath);
        //            var pictureNodeList = htmlDoc.DocumentNode.SelectNodes(".//div[@class='bdc bgf0 p10']/a/img") ?? new HtmlNodeCollection(null);
        //            if (pictureNodeList.Count <= 0)
        //            {
        //                break;
        //            }
        //            SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
        //        }
        //    }
        //}

        //private void SavePicture(StoreInfo storeInfo, IEnumerable<HtmlNode> pictureNodeList, BusPhotoAlbumTable busphotoAlbumTable)
        //{
        //    foreach (var pictureNode in pictureNodeList)
        //    {
        //        var dishesPicturePath = pictureNode.Attributes["src"].Value;
        //        if (string.IsNullOrEmpty(dishesPicturePath) || dishesPicturePath.Contains("nopic"))
        //        {
        //            continue;
        //        }
        //        var storePicture = BuildStorePicture(storeInfo, dishesPicturePath);
        //        StorePictureBll.Add(storePicture);
        //        StorePicturesTableBll.Add(BuildStorePicturesTable(busphotoAlbumTable, storePicture));
        //    }
        //}

        //private static StorePicture BuildStorePicture(StoreInfo storeInfo, string dishesPicturePath)
        //{
        //    var storePicture = new StorePicture
        //    {
        //        PID = Guid.NewGuid().ToString(),
        //        PicType = PicturePathName,
        //        PicturePath = dishesPicturePath,
        //        StoreId = storeInfo.storeId
        //    };
        //    storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
        //    return storePicture;
        //}

        //private static StorePicturesTable BuildStorePicturesTable(BusPhotoAlbumTable busphotoAlbumTable,
        //    StorePicture storePicture)
        //{
        //    var storePicturesTable = new StorePicturesTable
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

        //private static BusPhotoAlbumTable BuildBusPhotoAlbumTable(StoreInfo storeInfo, PicPull picPull)
        //{
        //    var busphotoAlbumTable = new BusPhotoAlbumTable
        //    {
        //        BusinessID = storeInfo.storeId,
        //        BusPhotoAlbumID = Guid.NewGuid().ToString(),
        //        IsDefault = true
        //    };
        //    if (picPull == PicPull.Cake)
        //    {
        //        busphotoAlbumTable.AlbumName = @"菜品图片";
        //    }
        //    else
        //    {
        //        busphotoAlbumTable.AlbumName = @"餐厅环境";
        //    }
        //    return busphotoAlbumTable;
        //}

        //private void DeleteStorePicturesTable(StoreInfo storeInfo)
        //{
        //    var storePicturesTableList =
        //        StorePicturesTableBll.GetModelList(string.Format("businessID = '{0}'", storeInfo.storeId));
        //    foreach (var storePicturesTable in storePicturesTableList)
        //    {
        //        StorePicturesTableBll.Delete(storePicturesTable.StorePicturesID);
        //    }
        //}

        //private void DeleteStorePicture(StoreInfo storeInfo)
        //{
        //    var storePicturelist =
        //        StorePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeInfo.storeId,
        //            PicturePathName));
        //    foreach (var storePicture in storePicturelist)
        //    {
        //        StorePictureBll.Delete(storePicture.PID);
        //    }
        //}
        public string _pageUrl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PageUrl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PicturePathName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void GetPicture(StoreInfo storeInfo)
        {
            throw new NotImplementedException();
        }


        public string PicturType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
