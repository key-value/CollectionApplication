using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;

namespace AbstractSite
{
    public class AbstractSite
    {
        public event IDelegate.CatalogueEventHandler CataloEventHandler;
        protected virtual void OnCatalogueGO(CatalogueEventArgs e)
        {
            if (CataloEventHandler != null)
            {
                CataloEventHandler(this, e);
            }
        }
        public void InitProgress(int count = 20)
        {
            //符合某一条件
            OnCatalogueGO(new CatalogueEventArgs() { MaxPorgress = count * 10, ProgressNum = 0 });
        }
        public void DoProgress(int progressNum = 10)
        {
            //符合某一条件
            OnCatalogueGO(new CatalogueEventArgs() { ProgressNum = progressNum });
        }
    }
}
