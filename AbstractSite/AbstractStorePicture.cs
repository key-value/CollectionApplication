using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace AbstractSite
{
    public abstract class AbstractStorePicture
    {
        protected AbstractStorePicture()
        {
        }
        protected string ImgNodePath;
        public string PicType
        {
            get { return "Shop"; }
        }
        protected Maticsoft.BLL.StorePicture StorePictureBll = new Maticsoft.BLL.StorePicture();
        #region image
        protected string SaveImageNode(HtmlNode htmlNode, string storeId)
        {
            var imageHref = GetImageHref(htmlNode, storeId);
            if (string.IsNullOrEmpty(imageHref))
            {
                return string.Empty;
            }
            return SavePictureName(storeId, imageHref);
        }
        protected virtual string SavePictureName(string storeId, string shopPicturePath)
        {
            var storePicture = new Maticsoft.Model.StorePicture()
            {
                PID = Guid.NewGuid().ToString()
            };
            storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
            storePicture.PicType = PicType;
            storePicture.PicturePath = shopPicturePath;
            storePicture.StoreId = storeId;
            StorePictureBll.Add(storePicture);
            return storePicture.PictureName;
        }

        protected virtual string GetshopPicturePath(HtmlNode htmlNode)
        {
            return string.Empty;
        }
        protected string GetImageHref(HtmlNode htmlNode, string storeId)
        {
            if (string.IsNullOrEmpty(ImgNodePath))
            {
                return string.Empty;
            }
            var imgNode = htmlNode.SelectSingleNode(ImgNodePath);
            if (imgNode != null)
            {
                var shopPicturePath = GetshopPicturePath(imgNode);
                if (string.IsNullOrEmpty(shopPicturePath))
                {
                    return string.Empty;
                }
                return shopPicturePath;
            }
            return string.Empty;
        }

        #endregion
    }
}
