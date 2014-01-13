using System.Globalization;
using ISite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoBao.Model
{
    public class DishesTaoBao : IDishSiteModel
    {
        public int DishID { get; set; }

        public string DishName { get { return itemName; } set { itemName = value; } }

        public string DishesMoney { get { return itemPrice.ToString(CultureInfo.InvariantCulture); } set { itemPrice = int.Parse(value); } }

        public string DishesUnit { get; set; }

        public string DishesBrief { get; set; }

        public bool IsNull { get; set; }

        public int Popularity { get; set; }

        public string PictureName { get; set; }

        public string DishTypeID { get; set; }

        public int cid { get; set; }
        public string cname { get; set; }
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int itemPrice { get; set; }
        public int onPrice { get; set; }

    }
}
