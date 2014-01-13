using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace CollectionLogic
{
    public class CatalogueLogic
    {
        private readonly ICatalogue _catalogueSite = null;
        public CatalogueLogic(string assemblyName)
        {
            var collectionFactory = new CollectionFactory(assemblyName);
            _catalogueSite = collectionFactory.CreateCatalogueSecretary();
        }

        public List<Catalogue> GetStoreInfo(int pageIndex)
        {
            return _catalogueSite.GetPageCatalogue(pageIndex);
        }


        public List<Catalogue> GetCataloguePage(int pageIndex)
        {
            try
            {
                return _catalogueSite.GetCataloguePage(pageIndex);
            }
            catch (System.Exception ex)
            {

            }
            return new List<Catalogue>();
        }

        public void SetPath(string pageUrl)
        {
            _catalogueSite.PageUrl = pageUrl;
        }

        public int PageNum
        {
            get { return _catalogueSite.PageNum; }
            set { _catalogueSite.PageNum = value; }
        }
        public int PageCount
        {
            get { return _catalogueSite.PageCount; }
            set { _catalogueSite.PageCount = value; }
        }
        public int CircleId
        {
            get { return _catalogueSite.CircleId; }
            set { _catalogueSite.CircleId = value; }
        }
        public int IflastPage
        {
            get { return _catalogueSite.IflastPage; }
            set { _catalogueSite.IflastPage = value; }
        }
        public string NextPage
        {
            get { return _catalogueSite.NextPage; }
            set { _catalogueSite.NextPage = value; }
        }
        public string BeforePage
        {
            get { return _catalogueSite.BeforePage; }
            set { _catalogueSite.BeforePage = value; }
        }

        public void CataloEventHandler(IDelegate.CatalogueEventHandler cataloEventHandler)
        {
            _catalogueSite.CataloEventHandler += cataloEventHandler;
        }
    }
}
