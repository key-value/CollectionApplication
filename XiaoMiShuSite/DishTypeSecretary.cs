using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    class DishTypeSecretary : IDishType
    {
        //protected DishTypeSecretary(string pageUrl)
        //    : base(pageUrl)
        //{

        //}

        //protected override string ListPath
        //{
        //    get
        //    {
        //        return
        //            ".//div[@class='constr']/div[@class='constr_in']/div[@class='l float_four']/div[@class='bdc bgf0 pr10 pb10']/a[@class='res_food_ins_gra']";
        //    }
        //}

        //public override List<DishType> GetDishType(string pageUrl)
        //{
        //    var nodeDetail =
        //    CatalogueHtmlNode.SelectNodes(ListPath);
        //    if (nodeDetail == null || nodeDetail.Count <= 0)
        //    {
        //        return null;
        //    }

        //    return nodeDetail.Select(GetDishTypeEntity).ToList();
        //}

        //protected override DishType GetDishTypeEntity(HtmlNode nodeInfo)
        //{
        //    var href = nodeInfo.Attributes["href"].Value;
        //    var dishName = nodeInfo.InnerText;
        //    var dishNum = nodeInfo.FirstChild.InnerText;
        //    var dishType = new DishType()
        //    {
        //        PkID = Guid.NewGuid(),
        //        DishName = dishName,
        //        hrefString = href,
        //        dishNum = dishNum,
        //    };
        //    return dishType;
        //}
        public string PageUrl { get; set; }

        public List<DishType> GetDishType()
        {
            throw new NotImplementedException();
        }

        public List<IDishSiteModel> GetDishesList()
        {
            throw new NotImplementedException();
        }


        public string PictureUrl { get; set; }


        public string RestaurantId { get; set; }


        public StoreInfo StoreInfo { get; set; }

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            throw new NotImplementedException();
        }
    }
}
