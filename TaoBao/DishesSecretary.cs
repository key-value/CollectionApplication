using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using ISite;
using Maticsoft.BLL;
using TaoBao.Model;
using DishesTyep = Maticsoft.Model.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace TaoBao
{
    public class DishesSecretary : AbstractDishTypeJson, IDishes
    {
        public DishesSecretary()
        {
            DishList = new List<IDishSiteModel>();
            PageUrl = @"http://list.bendi.taobao.com/list.htm";
        }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
        }


        public string PicType { get; set; }


        public List<IDishSiteModel> DishList { get; set; }

        public List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            throw new NotImplementedException();
        }

        protected override List<Maticsoft.Model.DishesTyep> GetSiteDishTypeList()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeStr = baseCollectionSite.BaseHtmlNode.InnerText.Replace("jsonp78(", string.Empty).Trim(')');
            var mainResult = JsonHelper.JsonToObj<MainResult>(dishTypeStr) ?? new MainResult();
            var dishesTypeList = mainResult.category;
            foreach (var dishItem in mainResult.item)
            {
                var cat = dishesTypeList.Find(x => x.id == dishItem.cat.id);
                if (cat != null)
                {
                    cat.DishesTaoBaos.Add(dishItem.item);
                }
            }
            return new List<Maticsoft.Model.DishesTyep>();
        }

        public override bool Conversion()
        {
            return true;
        }
    }
}
