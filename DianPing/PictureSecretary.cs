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

namespace DianPing
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {

        public PictureSecretary()
        {
            PageUrl = @"http://www.dianping.com/shop/{0}/photos/tag-{2}?pg={1}";
        }


        //protected override void CollectionPicture(StoreInfo storeInfo, BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        //{
        //    for (int i = 1; i < 500; i++)
        //    {
        //        var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, i, albumType));
        //        var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
        //        var pictureNodeList = pictureHtmlNode.SelectNodes(PicturePath);
        //        if (pictureNodeList == null)
        //        {
        //            break;
        //        }
        //        SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
        //    }
        //}

        public override string PicturePath()
        {
            return @".//div[@class='main page-gallery Fix']/div[@class='gallery-list-wrapper page-block']/div[@class='gallery-photo-nav ']/div[@class='picture-square']/div[@class='picture-list']/ul/li[@class='J_list']/div[@class='img']/a/img";
        }

        protected override List<string> GetTypeList()
        {
            return new List<string>() { "环境", "菜" };
        }


        public void GetPicture(StoreInfo storeInfo)
        {
        }
        protected override string GetPageUrl(StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, storeInfo.Fid, pageNum, albumType);
        }
    }
}
