using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;

namespace GaFan.Model
{
    public class GaFanDishModel : IDishSiteModel
    {
        public int click_count { get; set; }
        public decimal i_price { get; set; }
        public string c_desc { get; set; }
        public string i_dish_id { get; set; }
        public string i_pic_path { get; set; }
        public string c_unit { get; set; }
        public string dish_num { get; set; }
        public int favprices { get; set; }
        public string c_dish_name { get; set; }

        public int DishID { get; set; }

        public string DishName
        {
            get
            {
                return c_dish_name;
            }
            set
            {
                c_dish_name = value;
            }
        }

        public string DishesMoney
        {
            get
            {
                return i_price.ToString();
            }
            set
            {
                i_price = decimal.Parse(value);
            }
        }

        public string DishesUnit
        {
            get
            {
                return c_unit;
            }
            set
            {
                c_unit = value;
            }
        }

        public string DishesBrief
        {
            get
            {
                return c_desc;
            }
            set
            {
                c_desc = value;
            }
        }

        public bool IsNull { get; set; }

        public int Popularity { get; set; }

        public string PictureName { get; set; }

        public string DishTypeID { get; set; }
    }
}
