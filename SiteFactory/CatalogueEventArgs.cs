using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractSite
{
    public class CatalogueEventArgs : EventArgs
    {
        private string _args = string.Empty;
        public CatalogueEventArgs()
        {
        }
        public CatalogueEventArgs(string args)
        {
            _args = args;
        }
        public CatalogueEventArgs(int maxPorgress, int progressNum)
        {
            ProgressNum = progressNum;
            MaxPorgress = maxPorgress;
        }
        public string Args
        {
            get { return _args; }
        }

        public int MaxPorgress { get; set; }
        public int ProgressNum { get; set; }
    }
}
