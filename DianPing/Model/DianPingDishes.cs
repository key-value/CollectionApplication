using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISite;

namespace DianPing.Model
{
    public class DianPingDishes : IDishSiteModel
    {
        public int DishID { get; set; }

        public string DishName { get; set; }

        public string DishesMoney { get; set; }

        public string DishesUnit { get; set; }

        public string DishesBrief { get; set; }

        public bool IsNull { get; set; }

        public int Popularity { get; set; }

        public string PictureName { get; set; }
        public string DishTypeID { get; set; }
    }
}
