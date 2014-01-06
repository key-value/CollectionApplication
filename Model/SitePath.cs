using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    public class SitePath
    {
        public SitePath(string path, int pageIndex)
        {
            Path = path;
            PageIndex = pageIndex;
        }
        public String Path { get; set; }
        public int PageIndex { get; set; }

        public string SelectedSite { get; set; }
    }
}
