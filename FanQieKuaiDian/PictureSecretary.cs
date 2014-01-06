using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;

namespace FanQieKuaiDianSite
{
    public class PictureSecretary : IPicture
    {
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
