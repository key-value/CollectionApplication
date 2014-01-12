using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;

namespace TaoBao
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _pageUrl = @"http://www.dianping.com/shop/{0}";
            _generalEntityList = new List<IDishSiteModel>();
        }
        private string _pageUrl;

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

        protected override string DishesTypePath()
        {
            throw new NotImplementedException();
        }

        protected override string DishesPath()
        {
            throw new NotImplementedException();
        }

        protected override string GetDishName(HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override decimal GetDishPrice(HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }

        protected override string GetDishImg(HtmlNode dishNode)
        {
            throw new NotImplementedException();
        }
    }
}
