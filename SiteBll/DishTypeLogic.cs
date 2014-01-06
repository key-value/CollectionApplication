using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using SiteFactory;

namespace SiteLogic
{
    public class DishTypeLogic
    {
        private readonly IDishType _dishTypeSite = SiteAccess.CreateDishTypeSecretary();
        public List<Maticsoft.Model.DishType> GetDishType()
        {
            try
            {
                return _dishTypeSite.GetDishType();
            }
            catch
            {
                throw;
            }
        }

        public void SetPath(string pageUrl)
        {
            _dishTypeSite.PageUrl = pageUrl;
        }
        public void SetRestaurantId(string restaurantId)
        {
            _dishTypeSite.RestaurantId = restaurantId;
        }

        public List<IDishSiteModel> GetDishesList()
        {
            return _dishTypeSite.GetDishesList();
        }

        public string GetPicturePath()
        {
            return _dishTypeSite.PictureUrl;
        }
    }
}
