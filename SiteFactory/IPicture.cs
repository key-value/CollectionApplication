using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlAgilityPack;
using Maticsoft.BLL;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace ISite
{
    public interface IPicture
    {
        string PageUrl { get; set; }
        //PhotoAlbum
        string PicturType { get; }
        void GetPicture(StoreInfo storeInfo);
    }
}
