using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using BusPhotoAlbumTable = Maticsoft.Model.BusPhotoAlbumTable;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace DuoMiFan
{
    public class PictureSecretary : AbstractPicture, IPicture
    {
        public PictureSecretary()
        {
            PageUrl = @"http://www.134.cn/Hall/huanjing/id/{0}/type/{1}";
            PicturePath = @".//div[@id='productlist_container']/div[@id='waterfall']/div[@class='picList']/div[@class='picThumbnail']/a/img";
            TypeList = new List<string>() { "1", "2" };
        }


        protected override void CollectionPicture(StoreInfo storeInfo, BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        {
            var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, albumType));
            var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
            var pictureNodeList = pictureHtmlNode.SelectNodes(PicturePath);
            if (pictureNodeList == null)
            {
                return;
            }
            SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);

        }
    }
}
