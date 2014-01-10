using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Maticsoft.Model;

namespace ISite
{
    public interface IDishType: IProgress
    {
        string PageUrl { get; set; }
        //DishType GetDishTypeEntity();
        List<DishType> GetDishType();

        List<IDishSiteModel> GetDishesList();

        string RestaurantId { get; set; }
        string PictureUrl { get; set; }
        StoreInfo StoreInfo { get; set; }

        List<DishesTyep> UpdateDishType();
    }
}
