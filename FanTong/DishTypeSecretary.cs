using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using AbstractSite;
using FanTong.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.Model.DishesTyep;

namespace FanTong
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
            PictureUrl = @"http://www.cyooy.com/";
        }
        private string _pageUrl = @"http://sz.echiele.com/shop/{0}.html";

        public override string PageUrl
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


        public override List<Maticsoft.Model.DishesTyep> UpdateDishType()
        {
            return new List<DishesTyep>();
        }

        protected override string DishesTypePath()
        {
            throw new NotImplementedException();
        }

        protected override string DishesPath()
        {
            throw new NotImplementedException();
        }

        protected override string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }
    }
}
