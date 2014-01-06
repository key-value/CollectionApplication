using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace SiteLogic
{
    public class PictureLogic
    {
        private readonly IPicture _pictureSite = SiteAccess.CreatePictureSecretary();
        public void GetDish(StoreInfo storeInfo)
        {
            try
            {
                _pictureSite.GetPicture(storeInfo);
            }
            catch
            {
                throw;
            }
        }

        public void SetPath(string pageUrl)
        {
            _pictureSite.PageUrl = pageUrl;
        }
    }
}
