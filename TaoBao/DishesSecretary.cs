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
    public class DishesSecretary : AbstractDishes, IDishes
    {
        public DishesSecretary()
        {
            DishList = new List<IDishSiteModel>();
            PageUrl = @"http://list.bendi.taobao.com/list.htm";
        }

        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
        }

        //protected override List<Maticsoft.Model.DishesTyep> GetSiteDishTypeList()
        //{
        //    var baseCollectionSite = new BaseCollectionSite(PageUrl);
        //    var dishTypeStr = baseCollectionSite.BaseHtmlNode.InnerText.Replace("jsonp78(", string.Empty).Trim(')');
        //    var mainResult = JsonHelper.JsonToObj<MainResult>(dishTypeStr) ?? new MainResult();
        //    var dishesTypeList = mainResult.category;
        //    foreach (var dishItem in mainResult.item)
        //    {
        //        var cat = dishesTypeList.Find(x => x.id == dishItem.cat.id);
        //        if (cat != null)
        //        {
        //            cat.DishesTaoBaos.Add(dishItem.item);
        //        }
        //    }
        //    return new List<Maticsoft.Model.DishesTyep>();
        //}

        protected override string GetDishesName(HtmlAgilityPack.HtmlNode dishesNode)
        {
            throw new NotImplementedException();
        }

        protected override decimal GetDishesMoney(HtmlAgilityPack.HtmlNode dishesNode)
        {
            throw new NotImplementedException();
        }

        protected override string GetDishesBrief(HtmlAgilityPack.HtmlNode dishesNode)
        {
            throw new NotImplementedException();
        }

        protected override string GetPictureHref(HtmlAgilityPack.HtmlNode dishesNode)
        {
            throw new NotImplementedException();
        }

        public override string DishPath()
        {
            throw new NotImplementedException();
        }
    }
}
