using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using HtmlAgilityPack;
using Maticsoft.Model;

namespace ISite
{
    public interface ICatalogue
    {
        string PageUrl
        {
            get;
            set;
        }
        int PageNum
        {
            get;
            set;
        }
        int PageCount
        {
            get;
            set;
        }
        int CircleId { get; set; }

        string PicType { get; }
        int IflastPage { get; set; }
        //bool CheckStoreIsRead(string keyID, ref string storeId);

        //bool CheckStoreIsRead(string keyID, out string storeId)
        //{
        //    var temStoreInfoList = StoreInfoBll.GetModelList(string.Format("Fid = '{0}'", keyID));
        //    if (temStoreInfoList != null && temStoreInfoList.Count > 0)
        //    {
        //        var temStoreInfo = temStoreInfoList.FirstOrDefault();
        //        if (temStoreInfo != null)
        //        {
        //            storeId = temStoreInfo.storeId;
        //            DeleteOldPicture(temStoreInfo);
        //            return true;
        //        }
        //    }
        //    storeId = Guid.NewGuid().ToString();
        //    return false;
        //}

        //void DeleteOldPicture(StoreInfo temStoreInfo);
        //{
        //    var oldStorePicture =
        //        StorePictureBll.GetModelList(string.Format("PicType ='{1}' and StoreId = '{0}'",
        //            temStoreInfo.storeId, PicType));
        //    foreach (var storePicture in oldStorePicture)
        //    {
        //        StorePictureBll.Delete(storePicture.PID);
        //    }
        //}

        //string SavePictureName(string storeId, string shopPicturePath);
        //{
        //    var storePicture = new StorePicture
        //    {
        //        PID = Guid.NewGuid().ToString()
        //    };
        //    storePicture.PictureName = string.Format("{0}.jpg", storePicture.PID);
        //    storePicture.PicType = PicType;
        //    storePicture.PicturePath = shopPicturePath;
        //    storePicture.StoreId = storeId;
        //    StorePictureBll.Add(storePicture);
        //    return storePicture.PictureName;
        //}

        /// <summary>
        /// 页面目录
        /// </summary>
        /// <param name="poIndex"></param>
        /// <returns></returns>
        List<Catalogue> GetPageCatalogue(int poIndex);

        string NextPage { get; set; }
        string BeforePage { get; set; }

    }
}
