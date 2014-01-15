using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;

namespace FanQieKuaiDianSite
{
    public class PictureSecretary : AbstractPhotoAlbum, IPicture
    {

        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(Maticsoft.Model.StoreInfo storeInfo)
        {
            return new List<Maticsoft.Model.BusPhotoAlbum>();
        }

        public string PicturePathName { get; set; }

        public override string PicturePath(string albumType)
        {
            return string.Empty;
        }

        protected override List<string> GetTypeList()
        {
            return new List<string>();
        }


        public void GetPicture(StoreInfo storeInfo)
        {
        }
    }
}
