using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISite
{
    public interface IProgress
    {
        event IDelegate.CatalogueEventHandler CataloEventHandler;
        event IDelegate.LabelEventHandler LabelEventHandler;
    }
}
