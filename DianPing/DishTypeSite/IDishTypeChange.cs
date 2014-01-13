using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace DianPing.DishTypeSite
{
    public interface IDishTypeChange
    {
        string PageUrl { get;  }
        string GetDishName(HtmlNode dishNode);

        decimal GetDishPrice(HtmlNode dishNode);

        string GetDishImg(HtmlNode dishNode);

        string DishesTypePath();
        string DishesPath();
        HtmlNodeCollection GetDishInfoList(HtmlNode dishTypeNode);

    }
}
