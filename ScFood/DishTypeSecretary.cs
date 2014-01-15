using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using DishesTyep = Maticsoft.Model.DishesTyep;

namespace ScFood
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl = string.Empty;

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

        public List<Maticsoft.Model.DishesTyep> UpdateDishType()
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
