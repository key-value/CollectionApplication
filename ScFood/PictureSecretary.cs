using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using BusPhotoAlbum = Maticsoft.Model.BusPhotoAlbum;
using BusPhotoAlbumTable = Maticsoft.Model.BusPhotoAlbumTable;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace ScFood
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {
        public PictureSecretary()
        {
            PageUrl = @"http://www.scfood.net/item/shops-ac-{1}pic-id-{0}-page-{2}.html";
            //PicturePath = string.Empty;
            //TypeList = new List<string>() { "h", "c" };
            StorePictureUrl = @"http://www.scfood.net";
        }


        protected void CollectionPicture(StoreInfo storeInfo, BusPhotoAlbumTable busphotoAlbumTable, string albumType)
        {
            var picPath = ".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w980 fleft']/div[@class='shopmid']/div[@class='shopw']/div[@id='pic_list']/div[@class='item_box']/div[@class='item masonry_brick']/div[@class='item_t']/div[@class='img']/a/img";
            if (albumType == "h")
            {
                picPath = ".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w980 fleft']/div[@class='shopmid']/div[@class='shopw']/div[@class='pic_huanj']/ul/li/div[@class='hjtp_box']/div[@class='hjtpw center']/div[@class='hjtpw fleft']/a/img";
            }
            for (int i = 1; i < 500; i++)
            {
                var baseCollectionSite = new BaseCollectionSite(string.Format(PageUrl, storeInfo.Fid, albumType, i));
                var pictureHtmlNode = baseCollectionSite.BaseHtmlNode;
                var pictureNodeList = pictureHtmlNode.SelectNodes(picPath);
                if (pictureNodeList == null)
                {
                    break;
                }
                if (pictureNodeList.Count <= 1)
                {
                    var picNode = pictureNodeList.FirstOrDefault();
                    if (picNode == null)
                    {
                        break;
                    }
                    var picturePathName = picNode.Attributes["src"].Value;
                    if (picturePathName.Contains("bctp_28.gif"))
                    {
                        break;
                    }
                }
                //SavePicture(storeInfo, pictureNodeList, busphotoAlbumTable);
            }
        }
        protected override string GetPageUrl(StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, storeInfo.Fid, albumType, pageNum);
        }

        protected override bool FilterPage(HtmlNodeCollection pictureHtmlNode, ref int pageNum)
        {
            if (base.FilterPage(pictureHtmlNode, ref pageNum))
            {
                return true;
            }
            if (pictureHtmlNode.Count() <= 1)
            {
                var picNode = pictureHtmlNode.FirstOrDefault();
                if (picNode == null)
                {
                    pageNum = 500;
                    return true;
                }
                var picturePathName = picNode.Attributes["src"].Value;
                if (picturePathName.Contains("bctp_28.gif"))
                {
                    pageNum = 500;
                    return true;
                }
            }
            return false;
        }

        public override string PicturePath(string albumType)
        {

            if (albumType == "h")
            {
                return @".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w980 fleft']/div[@class='shopmid']/div[@class='shopw']/div[@class='pic_huanj']/ul/li/div[@class='hjtp_box']/div[@class='hjtpw center']/div[@class='hjtpw fleft']/a/img";
            }
            else
            {
                return @".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w980 fleft']/div[@class='shopmid']/div[@class='shopw']/div[@id='pic_list']/div[@class='item_box']/div[@class='item masonry_brick']/div[@class='item_t']/div[@class='img']/a/img";
            }
        }

        protected override List<string> GetTypeList()
        {
            return new List<string>() { "h", "c" };
        }


        public void GetPicture(StoreInfo storeInfo)
        {
        }
    }
}
