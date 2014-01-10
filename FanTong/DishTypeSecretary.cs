using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using FanTong.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace FanTong
{
    public class DishTypeSecretary : IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl = @"http://sz.echiele.com/shop/{0}.html";

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
            get { return @"http://www.cyooy.com/"; }
            set { _pictureUrl = value; }
        }

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
