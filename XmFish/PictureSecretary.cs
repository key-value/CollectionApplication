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

namespace XmFish
{
    public class PictureSecretary : AbstractPicture, IPicture
    {

        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(StoreInfo storeInfo)
        {
            return new List<Maticsoft.Model.BusPhotoAlbum>();
        }
        public PictureSecretary()
        {
            PageUrl = @"http://www.yukuai.com/official/dishPicture?o.picType={2}&o.merchantId={0}&page.pageSize=20&page.currentPage={1}";
            PicturePath = @".//div[@class='yk-content gw_ztnr']/div[@class='yk-grid-col2']/div[@class='gw_ztk rel']/div[@class='yk-grid-main gw_ztright' and @id='mainContainer']/div[@class='gw_ztrnei']/a[@class='ml10']/img";
            TypeList = new List<string>() ;
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
