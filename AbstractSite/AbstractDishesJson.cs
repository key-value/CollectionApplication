using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.BLL;
using DishesTyep = Maticsoft.Model.DishesTyep;

namespace AbstractSite
{
    public abstract class AbstractDishesJson : AbstractMainSite
    {
        public string PageUrl { get; set; }
        public virtual bool Conversion()
        {
            return false;
        }

        public virtual string GetDishUrl(DishesTyep dishType, ref int pageNum)
        {
            return dishType.DishHref;
        }

        public virtual List<DishesTyep> GetDish(List<DishesTyep> dishesTyepList)
        {
            foreach (var dishType in dishesTyepList)
            {
                for (int i = 0; i < 500; i++)
                {
                    var nextPageUrl = GetDishUrl(dishType, ref i);
                    var baseCollection = PostHttpResponse.PostData(nextPageUrl, new Dictionary<string, string>(), new Dictionary<string, string>()); //new BaseCollectionSite(nextPageUrl);
                    //var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
                    var dishesNodeList = GetDishList(baseCollection);
                    if (dishesNodeList == null || !dishesNodeList.Any())
                    {
                        break;
                    }
                    SaveIngDish(dishType.DishesTypeName, string.Empty);
                    foreach (var dishesNode in dishesNodeList)
                    {
                        var dishes = GetDishes(dishType, dishesNode);
                        if (dishes.IsNull)
                        {
                            continue;
                        }
                        dishType.DishesList.Add(dishes);
                        SaveIngDish(dishType.DishesTypeName, dishes.DishesName);
                    }
                }
            }
            FinishSaveDish();
            return dishesTyepList;
        }

        protected abstract decimal GetDishesMoney(IDishSiteModel dishesNode);
        public Maticsoft.Model.DishesEntity GetDishes(DishesTyep dishesTyep, IDishSiteModel dishSiteModel)
        {
            var dishes = new Maticsoft.Model.DishesEntity();
            dishes.DishesID = Guid.NewGuid().ToString();
            dishes.DishesName = dishSiteModel.DishName;
            dishes.DishesTypeID = dishesTyep.DishesTypeID;
            dishes.DishesBrief = dishSiteModel.DishesBrief;
            dishes.DishesMoney = GetDishesMoney(dishSiteModel);
            dishes.DishesUnit = dishSiteModel.DishesUnit;
            if (string.IsNullOrWhiteSpace(dishes.DishesName))
            {
                dishes.IsNull = true;
            }
            if (dishes.DishesMoney == 0)
            {
                dishes.IsCurrentPrice = true;
            }
            return dishes;
        }

        protected virtual List<IDishSiteModel> GetDishList(string jsonText)
        {
            return new List<IDishSiteModel>();
        }
    }

}
