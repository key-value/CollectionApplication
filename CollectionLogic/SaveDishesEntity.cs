using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyooy.Model;
using Maticsoft.Model;
using Dishes = Maticsoft.BLL.Dishes;
using DishesTyepTable = Maticsoft.BLL.DishesTyepTable;
using StorePicture = Maticsoft.BLL.StorePicture;


namespace CollectionLogic
{
    public class SaveDishesEntity
    {
        //private DishesTyepTable _dishesTyepTableBll = new DishesTyepTable();
        private Dishes _dishesBll = new Dishes();
        private StorePicture _storePictureBll = new StorePicture();
        private DishesTyepTable _dishTypeBll = new DishesTyepTable();
        string DishesType = "Food";

        public string AssemblyName;

        public SaveDishesEntity(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        public int SaveDish(StoreInfo storeInfo)
        {
            try
            {
                var dishTypeLogic = new DishTypeLogic(AssemblyName);
                dishTypeLogic.SetRestaurant(storeInfo);
                DeleteOldDish(storeInfo.storeId);
                var dishTypeList = dishTypeLogic.GetDishType();
                var dishList = dishTypeLogic.GetDishesList();

                var dishesLogic = new DishesLogic(AssemblyName) { DishList = dishList };
                dishesLogic.SetPath(dishTypeLogic.GetPicturePath());
                foreach (var dishType in dishTypeList)
                {
                    var dishesTyepTable = new Maticsoft.Model.DishesTyepTable
                    {
                        BusinessID = storeInfo.storeId,
                        CreateDate = DateTime.Now,
                        DishesTypeID = dishType.PkID.ToString(),
                        DishesTypeName = dishType.DishName
                    };
                    _dishTypeBll.Add(dishesTyepTable);
                    foreach (var dishesID in dishType.DishesList)
                    {
                        var dishEntity = dishList.Find(x => x.DishID == dishesID) ?? new CyooyDishes();
                        if (dishEntity.IsNull)
                        {
                            continue;
                        }
                        dishEntity.DishTypeID = dishesTyepTable.DishesTypeID;
                        dishesLogic.GetDish(dishEntity, storeInfo.storeId);
                    }
                }
                return dishList.Count;
            }
            catch (System.Exception ex)
            {

            }
            return 0;
        }

        public void DeleteOldDish(string storeId)
        {
            var oldDisheslist = _dishesBll.GetModelList(string.Format("StoreId = '{0}'", storeId));
            foreach (var dishese in oldDisheslist)
            {
                _dishesBll.Delete(dishese.DishesID);
            }
            var oldDishTypeList = _dishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", storeId));
            foreach (var dishesTyepTable in oldDishTypeList)
            {
                _dishTypeBll.Delete(dishesTyepTable.DishesTypeID);
            }

            var storePicturelist = _storePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeId, DishesType));
            foreach (var storePicture in storePicturelist)
            {
                _storePictureBll.Delete(storePicture.PID);
            }
        }
        public List<DishesTyep> UpdateDish(StoreInfo storeInfo)
        {
            var dishTypeLogic = new DishTypeLogic(AssemblyName);
            dishTypeLogic.SetRestaurant(storeInfo);
            var dishTypeList = dishTypeLogic.UpdateDishType();
            //var dishesLogic = new DishesLogic(AssemblyName);
            return dishTypeList;
        }
    }
}
