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

namespace FanTong
{
    public class PictureSecretary : AbstractPicture, IPicture
    {

        public List<BusPhotoAlbumTable> SaveAlbumTables(StoreInfo storeInfo)
        {
            return new List<BusPhotoAlbumTable>();
        }
        public PictureSecretary()
        {
            PageUrl = @"http://www.fantong.com/biz-{0}/pic/?page={1}";
            PicturePath = @".//div[@class='warp']/div/div[@class='restaurant_samplesimg']/div[@class='foodimg']/ul[@id='allPicList']/li/a[@class='picborder']/img";
            TypeList = new List<string>() { "1" };
        }


        protected override void CollectionPicture(StoreInfo storeInfo, BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        {
            for (int i = 1; i < 100; i++)
            {
                var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, i));
                var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
                var pictureNodeList = pictureHtmlNode.SelectNodes(PicturePath);
                if (pictureNodeList == null)
                {
                    break;
                }
                SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
            }
        }
    }
}
