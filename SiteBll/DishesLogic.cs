using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace SiteLogic
{
    public class DishesLogic
    {
        private readonly IDishes _dishesSite = SiteAccess.CreateDishesSecretary();
        public void GetDish(IDishSiteModel dishSiteModel, string StoreID)
        {
            try
            {
                _dishesSite.GetDish(dishSiteModel, StoreID);
            }
            catch
            {
                throw;
            }
        }

        public void SetPath(string pageUrl)
        {
            _dishesSite.PageUrl = pageUrl;
        }

        public List<IDishSiteModel> DishList
        {
            get { return _dishesSite.DishList; }
            set { _dishesSite.DishList = value; }
        }
    }
}
