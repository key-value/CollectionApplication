using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanQieKuaiDianSite
{
    public class Area
    {
        public Area()
        {
            CircleList = new List<Circle>();
        }
        public string AreaId;
        public string AreaName;
        public List<Circle> CircleList;
    }
}
