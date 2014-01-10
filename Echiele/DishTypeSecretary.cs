using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Echiele.Model;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace Echiele
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
            var dishesTypePath =
                @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div/div[@class='dc_list']/ul/li";
            var baseCollectionSite = new BaseCollectionSite(PageUrl);
            var dishTypeHtmlNode = baseCollectionSite.BaseHtmlNode;
            var dishNodeList = dishTypeHtmlNode.SelectNodes(dishesTypePath);
            if (dishNodeList == null || dishNodeList.Count <= 0)
            {
                return dishTypeList;
            }
            int dishID = 1;
            var dishTypeID = Guid.NewGuid();
            var dishTypeName = @"推荐菜";
            var dishTypeInfo = new DishType
            {
                PkID = dishTypeID,
                DishName = dishTypeName,
                DishesList = new List<int>(),
            };
            foreach (var dishNode in dishNodeList)
            {
                var dishNameNode = dishNode.SelectSingleNode(".//h3/a");
                var dishPriceNode = dishNode.SelectSingleNode(".//h4/span[1]/font");
                var dishImg = dishNode.SelectSingleNode(".//div[@class='dc_l_img']/a/img");
                if (dishNameNode == null || dishPriceNode == null)
                {
                    continue;
                }
                var dishName = dishNameNode.InnerText;
                var dishPrice = dishPriceNode.InnerText.Replace("￥", string.Empty);
                var echieleDishes = new EchieleDishes();
                echieleDishes.DishID = dishID;
                echieleDishes.DishTypeID = dishTypeID.ToString();
                echieleDishes.DishName = dishName;
                echieleDishes.DishesMoney = dishPrice;
                if (dishImg != null)
                {
                    echieleDishes.PictureName = dishImg.Attributes["src"].Value;
                }
                _generalEntityList.Add(echieleDishes);
                dishTypeInfo.DishesList.Add(echieleDishes.DishID);
                dishID += 1;
            }
            dishTypeList.Add(dishTypeInfo);

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
