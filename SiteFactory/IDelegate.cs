using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractSite;

namespace ISite
{
    public class IDelegate
    {
        public delegate void CatalogueEventHandler(object sender, CatalogueEventArgs e);
    }
}
