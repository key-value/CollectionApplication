using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace SiteLogic
{
    public class CatalogueLogic
    {
        
        public CatalogueLogic()
        {
            
        }
        private readonly ICatalogue _catalogueSite = SiteAccess.CreateCatalogueSecretary();

        public List<Catalogue> GetStoreInfo(int pageIndex)
        {
            return _catalogueSite.GetPageCatalogue(pageIndex);
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

    }
}
