using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBao.Model
{
    public class MainResult
    {
        public MainResult()
        {
            category = new List<cat>();
            List = new List<DishItem>();
        }
        public List<cat> category;
        public int code;
        public int curCate;
        public string freshen;
        public int view;

        public List<DishItem> List;
    }
}
