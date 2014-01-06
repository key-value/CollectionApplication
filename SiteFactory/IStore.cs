using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Maticsoft;
using Maticsoft.Model;

namespace ISite
{
    public interface IStore
    {
        string PageUrl
        {
            get;
            set;
        }
        StoreInfo GetStoreInfo(Catalogue catalogue);
    }
}
