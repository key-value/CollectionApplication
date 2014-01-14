using System.Linq;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using TaoBao.Model;

namespace TaoBao
{
    public class DishTypeSecretary : AbstractDishTypeJson, IDishType
    {
        public DishTypeSecretary()
        {
            _pageUrl = @"http://dd.taobao.com/consumer/asynItemList.do?callback=jsonp78&localstoreId={0}&sellerId64=MzU5MzEzMDQxMg%3D%3D";

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
        protected override List<Maticsoft.Model.DishesTyep> GetSiteDishTypeList()
        {
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeStr = baseCollectionSite.BaseHtmlNodeByGBK.InnerText.Replace("jsonp78(", string.Empty).Replace(@")", string.Empty).Trim();
            var mainResult = JsonHelper.JsonToObj<MainResult>(dishTypeStr) ?? new MainResult();
            var dishesTypeList = new List<Maticsoft.Model.DishesTyep>();
            foreach (var dishItem in mainResult.List)
            {
                var dishesType = new Maticsoft.Model.DishesTyep();
                dishesType.BusinessID = StoreInfo.OldStoreId;
                dishesType.DishesTypeID = Guid.NewGuid().ToString();
                dishesType.DishesTypeName = dishItem.cat.Name;
                var dishesList = (
                                 from dishesTaoBao in dishItem.item
                                 select new DishesEntity()
                                 {
                                     DishesID = Guid.NewGuid().ToString(),
                                     DishesName = dishesTaoBao.DishName,
                                     DishesUnit = string.IsNullOrEmpty(dishesTaoBao.DishesUnit) ? "份" : dishesTaoBao.DishesUnit,
                                     DishesMoney = dishesTaoBao.itemPrice,
                                     BusinessID =  StoreInfo.OldStoreId,
                                     DishesTypeID = dishesType.DishesTypeID,
                                 }).ToList();
                dishesType.DishesList.AddRange(dishesList);
                dishesTypeList.Add(dishesType);
            }
            return dishesTypeList;
        }
    }
}
