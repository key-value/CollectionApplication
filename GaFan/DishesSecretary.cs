using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AbstractSite;
using GaFan.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.Model.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace GaFan
{
    public class DishesSecretary : AbstractDishesJson, IDishes
    {
        public DishesSecretary()
        { DishList = new List<IDishSiteModel>(); }

        public override bool Conversion()
        {
            return true;
        }

        public override string GetDishUrl(DishesTyep dishType, ref int pageNum)
        {
            if (string.IsNullOrEmpty(dishType.DishHref))
            {
                return string.Empty;
            }
            return string.Format("{0}&pager.offset={1}", dishType.DishHref, pageNum * 10);
        }

        protected override decimal GetDishesMoney(IDishSiteModel dishesNode)
        {
            decimal dishesMoney = 0;
            decimal.TryParse(dishesNode.DishesMoney, out dishesMoney);
            return dishesMoney;
        }


        public string PicType { get; set; }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {

        }

        public List<IDishSiteModel> DishList { get; set; }

        protected override List<IDishSiteModel> GetDishList(string jsonText)
        {
            var dishResult = JsonHelper.JsonToObj<DishResult>(jsonText);
            if (dishResult == null || dishResult.data == null)
            {
                return new List<IDishSiteModel>();
            }
            return dishResult.data.Cast<IDishSiteModel>().ToList();
        }
    }
}
