using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Maticsoft.BLL;

namespace AbstractSite
{
    public abstract class AbstractPhotoAlbum : AbstractMainSite
    {
        protected AbstractPhotoAlbum()
        {
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

        public abstract string PicturePath(string albumType);
        public string StorePictureUrl { get; set; }

        public virtual List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(Maticsoft.Model.StoreInfo storeInfo)
        {
            var busPhotoAlbumTableList = new List<Maticsoft.Model.BusPhotoAlbum>();
            var typeList = GetTypeList();
            for (int i = 0; i < typeList.Count; i++)
            {
                var busphotoAlbumTable = BuildBusPhotoAlbumTable(storeInfo, i);

                SaveIngPic(busphotoAlbumTable.AlbumName, string.Empty);

                busphotoAlbumTable.StorePicturesList.AddRange(CollectionPicture(storeInfo, busphotoAlbumTable, typeList[i]));
                busPhotoAlbumTableList.Add(busphotoAlbumTable);
            }
            FinishSaveDish();
            return busPhotoAlbumTableList;
        }

        protected virtual string GetPageUrl(Maticsoft.Model.StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, storeInfo.Fid);
        }

        protected abstract List<string> GetTypeList();
        protected virtual List<Maticsoft.Model.StorePicture> CollectionPicture(Maticsoft.Model.StoreInfo storeInfo, Maticsoft.Model.BusPhotoAlbum busphotoAlbumTable, string albumType)
        {
            var picturesList = new List<Maticsoft.Model.StorePicture>();
            for (int i = 1; i < 500; i++)
            {
                var storePic = PicturesBody(storeInfo, busphotoAlbumTable, albumType, ref i);
                picturesList.AddRange(storePic);
            }
            return picturesList;
        }


        protected virtual List<Maticsoft.Model.StorePicture> SavePicture(Maticsoft.Model.StoreInfo storeInfo, IEnumerable<HtmlNode> pictureNodeList, Maticsoft.Model.BusPhotoAlbum busphotoAlbumTable)
        {
            var storePicturesList = new List<Maticsoft.Model.StorePicture>();
            foreach (var pictureNode in pictureNodeList)
            {
                var picturePathName = StorePictureUrl + pictureNode.Attributes["src"].Value;
                if (FilterPicturePathName(picturePathName))
                {
                    SaveIngPic(busphotoAlbumTable.AlbumName, picturePathName);
                    storePicturesList.Add(BuildStorePicture(storeInfo, picturePathName));
                }
            }
            return storePicturesList;
        }

        protected virtual bool FilterPicturePathName(string picturePathName)
        {
            return !string.IsNullOrEmpty(picturePathName);
        }

        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(StoreInfo storeInfo)
        {
            return new List<Maticsoft.Model.BusPhotoAlbum>();
        }
        protected virtual Maticsoft.Model.BusPhotoAlbum BuildBusPhotoAlbumTable(Maticsoft.Model.StoreInfo storeInfo, int albumType)
        {
            var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbum();
            busphotoAlbumTable.BusinessID = storeInfo.storeId;
            busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
            busphotoAlbumTable.IsDefault = true;
            busphotoAlbumTable.AlbumName = @"餐厅环境";
            if (albumType == 1)
            {
                busphotoAlbumTable.AlbumName = @"菜品图片";
            }
            //BusPhotoAlbumTableBll.Add(busphotoAlbumTable);
            return busphotoAlbumTable;
        }
        protected virtual Maticsoft.Model.StorePicture BuildStorePicture(Maticsoft.Model.StoreInfo storeInfo, string picturePathName)
        {
            var storePicture = new Maticsoft.Model.StorePicture
            {
                PID = Guid.NewGuid().ToString(),
                PicType = PicturType,
                PicturePath = picturePathName,
                StoreId = storeInfo.storeId,
            };
            storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
            return storePicture;
        }
        protected virtual List<Maticsoft.Model.StorePicture> PicturesBody(Maticsoft.Model.StoreInfo storeInfo,
            Maticsoft.Model.BusPhotoAlbum busphotoAlbumTable, string albumType, ref int pageNum)
        {
            var baseCollectionSite = new BaseCollectionSite(GetPageUrl(storeInfo, albumType, pageNum));
            var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
            var pictureNodeList = pictureHtmlNode.SelectNodes(PicturePath(albumType));
            if (FilterPage(pictureNodeList, ref pageNum))
            {
                return new List<Maticsoft.Model.StorePicture>();
            }
            return SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
        }
        protected virtual bool FilterPage(HtmlNodeCollection pictureHtmlNode, ref int pageNum)
        {
            if (pictureHtmlNode == null)
            {
                pageNum = 500;
                return true;
            }
            return false;
        }

    }
}
