using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace CollectionLogic
{
    public class PictureLogic
    {
        private CollectionFactory _collectionFactory = null;
        public PictureLogic(string assemblyName)
        {
            _collectionFactory = new CollectionFactory(assemblyName);
            _pictureSite = _collectionFactory.CreatePictureSecretary();
        }

        private readonly IPicture _pictureSite;
        public void GetPicture(StoreInfo storeInfo)
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
        public List<Maticsoft.Model.BusPhotoAlbum> SaveAlbumTables(StoreInfo storeInfo)
        {
            try
            {
                return _pictureSite.SaveAlbumTables(storeInfo);
            }
            catch
            {
                throw;
            }
        }
        public void SetLabelEventHandler(IDelegate.LabelEventHandler labelEventHandler)
        {
            _pictureSite.LabelEventHandler += labelEventHandler;
        }
    }
}
