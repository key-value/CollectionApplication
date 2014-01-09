using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISite;
using Maticsoft.BLL;
using SiteFactory;

namespace CollectionLogic
{
    public class StoreLogic
    {
        private CollectionFactory _collectionFactory = null;
        private readonly IStore _storeSite = null;
        public StoreLogic(string assemblyName)
        {
            _collectionFactory = new CollectionFactory(assemblyName);
            _storeSite = _collectionFactory.CreateStoreSecretary();
        }
        public Maticsoft.Model.StoreInfo GetStoreInfo(Maticsoft.Model.Catalogue catalogue)
        {
            try
            {
                return _storeSite.GetStoreInfo(catalogue);
            }
            catch
            {
                throw;
            }
        }

        public string PageUrl
        {
            get { return _storeSite.PageUrl; }
            set { _storeSite.PageUrl = value; }
        }

        public void CataloEventHandler(IDelegate.CatalogueEventHandler cataloEventHandler)
        {
            _storeSite.CataloEventHandler += cataloEventHandler;
        }

    }
}
