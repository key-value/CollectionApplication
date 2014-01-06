using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace DuoMiFan
{
    public class DishTypeSecretary : IDishType
    {

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            throw new NotImplementedException();
        }
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl = string.Empty;

        public string PageUrl
        {
            get
            {
                return string.Format(_pageUrl, StoreInfo.Fid);
            }
            set
            {
                _pageUrl = value;
            }
        }


        public List<DishType> GetDishType()
        {
            var dishTypeList = new List<DishType>();
            return dishTypeList;
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }

        private string _pictureUrl;
        public string PictureUrl
        {
            get { return _pictureUrl; }
            set { _pictureUrl = value; }
        }

        public string RestaurantId { get; set; }

        public Maticsoft.Model.StoreInfo StoreInfo { get; set; }
    }
}
