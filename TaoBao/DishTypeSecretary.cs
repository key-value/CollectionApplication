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
            _pageUrl = @"http://dd.taobao.com/consumer/asynItemList.do?callback=jsonp78&localstoreId='{0}'&sellerId64=MzU5MzEzMDQxMg%3D%3D";

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


        public List<DishType> GetDishType()
        {
            throw new NotImplementedException();
        }

        public List<IDishSiteModel> GetDishesList()
        {
            throw new NotImplementedException();
        }
    }
}
