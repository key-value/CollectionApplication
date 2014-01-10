using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FanQieKuaiDianSite.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace FanQieKuaiDianSite
{
    public class DishTypeSecretary : IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
            PageUrl = @"http://www.fanqie.com/dishes/fulldata";
        }
        private string _pageUrl;

        public string PageUrl
        {
            get
            {
                return _pageUrl;
            }
            set
            {
                _pageUrl = value;
            }
        }

        public DishType GetDishTypeEntity(DishTypeEntity dishTypeEntity)
        {
            var dishType = new DishType { PkID = Guid.NewGuid(), DishName = dishTypeEntity.C, dishNum = dishTypeEntity.D };
            dishType.DishesList.AddRange(dishTypeEntity.E);
            return dishType;
        }


        public List<DishType> GetDishType()
        {
            var collectionPhone = new CollectionPhone();
            collectionPhone.headDictionary.Add("city", "1");
            collectionPhone.dictionary.Add("restaurant", RestaurantId);
            collectionPhone.dictionary.Add("template", "0");
            collectionPhone.PageUrl = PageUrl;
            var dishFullData = collectionPhone.GetResualt<DishFullData>() ?? new NullDishFullData();
            PictureUrl = dishFullData.I;
            _generalEntityList.AddRange(dishFullData.B);
            var dishTypeTable = dishFullData.C.Find(x => x.A == 0) ?? new NullDishTypeTable();
            var dishTypeInfo = dishTypeTable.D.Find(x => x.B == "01") ?? new NullDishTypeInfo();
            return dishTypeInfo.D.Select(GetDishTypeEntity).ToList();
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }


        public string PictureUrl { get; set; }

        public string RestaurantId { get; set; }


        public Maticsoft.Model.StoreInfo StoreInfo { get; set; }

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            throw new NotImplementedException();
        }

        public event IDelegate.CatalogueEventHandler CataloEventHandler;

        public event IDelegate.LabelEventHandler LabelEventHandler;
    }
}
