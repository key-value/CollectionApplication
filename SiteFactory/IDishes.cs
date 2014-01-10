using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Maticsoft.Model;

namespace ISite
{
    public interface IDishes : IProgress
    {
        string PageUrl { get; set; }
        //Food
        string PicType { get; set; }

        bool Conversion();

        void GetDish(IDishSiteModel dishSiteModel, string storeID);
        List<IDishSiteModel> DishList { get; set; }

        List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList);
    }
}
