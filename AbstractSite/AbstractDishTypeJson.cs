using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationUtility;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.BLL.DishesTyep;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace AbstractSite
{
    public abstract class AbstractDishTypeJson : AbstractMainSite
    {
        protected DishesBll DishesBll = new DishesBll();
        protected DishesTyep DishTypeBll = new DishesTyep();
        protected StorePicture StorePictureBll = new StorePicture();
        public virtual string PageUrl { get; set; }

        public string RestaurantId { get; set; }

        public string PictureUrl { get; set; }

        public Maticsoft.Model.StoreInfo StoreInfo { get; set; }

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            var dishTypeList = new List<Maticsoft.Model.DishesTyep>();
            var dishTypeNodeList = GetSiteDishTypeList();
            dishTypeList.AddRange(GetOlddDishType());
            if (dishTypeNodeList == null || dishTypeNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            foreach (var dishTypeNode in dishTypeNodeList)
            {
                var dishTypeName = dishTypeNode.DishesTypeName;
                if (string.IsNullOrWhiteSpace(dishTypeName))
                {
                    continue;
                }
                var dishesTypeInfo = dishTypeList.Find(x => x.DishesTypeName == dishTypeName);
                if (dishesTypeInfo == null)
                {
                    dishesTypeInfo = new Maticsoft.Model.DishesTyep
                    {
                        DishesTypeID = Guid.NewGuid().ToString(),
                        DishesTypeName = dishTypeName,
                        BusinessID = StoreInfo.OldStoreId,
                        CreateDate = DateTime.Now,
                        //DishHref = GetDishesHref(dishTypeNode),
                    };
                    dishTypeList.Add(dishesTypeInfo);
                }
                SaveIngDish(dishTypeName, string.Empty);
                var dishNodeList = dishTypeNode.DishesList;
                if (dishNodeList == null)
                {
                    continue;
                }
                foreach (var dishNode in dishNodeList)
                {
                    var dishName = dishNode.DishesName.ClearSiteCode();
                    if (string.IsNullOrWhiteSpace(dishName))
                    {
                        continue;
                    }

                    var dishInfo = dishesTypeInfo.DishesList.Find(x => x.DishesName == dishName);
                    if (dishInfo == null)
                    {
                        dishInfo = new DishesEntity
                        {
                            BusinessID = StoreInfo.storeId,
                            DishesID = Guid.NewGuid().ToString(),
                            DishesTypeID = dishesTypeInfo.DishesTypeID
                        };
                        dishesTypeInfo.DishesList.Add(dishInfo);
                    }
                    SaveIngDish(dishTypeName, dishName);
                }
            }
            FinishSaveDish();
            return dishTypeList;
        }

        protected virtual List<Maticsoft.Model.DishesTyep> GetOlddDishType()
        {
            var dishesTyepList = DishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", StoreInfo.OldStoreId)) ?? new List<Maticsoft.Model.DishesTyep>();
            foreach (var dishesTyep in dishesTyepList)
            {
                var dishesList = DishesBll.GetModelList(string.Format(@"DishesTypeID = '{0}'", dishesTyep.DishesTypeID));
                dishesTyep.DishesList.AddRange(dishesList);
            }
            return dishesTyepList;
        }

        protected virtual List<Maticsoft.Model.DishesTyep> GetSiteDishTypeList()
        {
            return new List<Maticsoft.Model.DishesTyep>();
        }

        public virtual bool Conversion()
        {
            return false;
        }

    }
}
