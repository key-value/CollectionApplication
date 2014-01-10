using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;

namespace FanQieKuaiDianSite
{
    public class PictureSecretary : AbstractMainSite, IPicture
    {

        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(Maticsoft.Model.StoreInfo storeInfo)
        {
            return new List<Maticsoft.Model.BusPhotoAlbum>();
        }
        public string _pageUrl { get; set; }

        public string PageUrl { get; set; }

        public string PicturePathName { get; set; }

        public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
            throw new NotImplementedException();
        }


        public string PicturType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
