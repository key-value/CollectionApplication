using System;
using System.Collections.Generic;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {
        public PictureSecretary()
        {
            PageUrl = @"http://www.xiaomishu.com/shop/new/ajax/picpull.aspx?resid={0}&t={1}&time={2}";
        }
        protected override List<string> GetTypeList()
        {
            return new List<string>() { "2", "3" };
        }

        protected override string GetPageUrl(StoreInfo storeInfo, string albumType, int pageNum)
        {
            return string.Format(PageUrl, storeInfo.Fid, albumType, pageNum);
        }

        public override string PicturePath(string albumType)
        {
            return @".//div[@class='bdc bgf0 p10']/a/img";
        }

        protected override bool FilterPicturePathName(string picturePathName)
        {
            if (base.FilterPicturePathName(picturePathName))
            {
                return !picturePathName.EndsWith("food_nopic.png");
            }
            return false;
        }


        public void GetPicture(StoreInfo storeInfo)
        {

        }
    }
}
