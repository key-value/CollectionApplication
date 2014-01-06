using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISite;
using Maticsoft.BLL;
using SiteFactory;

namespace SiteLogic
{
    public class StoreLogic
    {
        public StoreLogic()
        {
        }
        private readonly IStore _storeSite = SiteAccess.CreateStoreSecretary();
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
    }
}
