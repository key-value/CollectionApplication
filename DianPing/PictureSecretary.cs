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
    public class PictureSecretary : AbstractPicture, IPicture
    {
        public PictureSecretary()
        {
            PageUrl = @"http://www.dianping.com/shop/{0}/photos/tag-{2}?pg={1}";
            PicturePath = @".//div[@class='main page-gallery Fix']/div[@class='gallery-list-wrapper page-block']/div[@class='gallery-photo-nav ']/div[@class='picture-square']/div[@class='picture-list']/ul/li[@class='J_list']/div[@class='img']/a/img";
            TypeList = new List<string>() { "环境", "菜" };
        }


        protected override void CollectionPicture(StoreInfo storeInfo, BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        {
            for (int i = 1; i < 500; i++)
            {
                var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, i, albumType));
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
