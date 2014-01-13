using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.Model;
using SiteFactory;

namespace CollectionLogic
{
    public class DishTypeLogic
    {
        private CollectionFactory _collectionFactory = null;
        public DishTypeLogic(string assemblyName)
        {
            _collectionFactory = new CollectionFactory(assemblyName);
            _dishTypeSite = _collectionFactory.CreateDishTypeSecretary();
        }

        private readonly IDishType _dishTypeSite;
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
        public void SetRestaurant(StoreInfo storeInfo)
        {
            _dishTypeSite.StoreInfo = storeInfo;
        }
        public void SetLabelEventHandler(IDelegate.LabelEventHandler labelEventHandler)
        {
            _dishTypeSite.LabelEventHandler += labelEventHandler;
        }
        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            try
            {
                return _dishTypeSite.UpdateDishType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
