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
        public string itemId { get; set; }
        public string itemName { get; set; }
        public decimal itemPrice { get; set; }
        public decimal oriPrice { get; set; }
        public int soldCount { get; set; }
        public int cateIds { get; set; }
        public int isRecommend { get; set; }
        public int isSetFood { get; set; }
        public int isDiscount { get; set; }
        public int isNew { get; set; }
        public int isTakeout { get; set; }
        public string useTime { get; set; }
        public int quantity { get; set; }

    }
}
