using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _pageUrl = @"http://www.xiaomishu.com/shop/{0}";
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
            return
                @".//div[@class='constr']/div[@class='constr_in']/div[@class='l float_four']/div[@class='bdc bgf0 pr10 pb10']/a[@class='res_food_ins_gra']";
        }

        protected override string DishesPath()
        {
            return string.Empty;
        }

        protected override string GetDishName(HtmlNode dishNode)
        {
            return string.Empty;
        }

        protected override decimal GetDishPrice(HtmlNode dishNode)
        {
            return 0;
        }

        protected override string GetDishImg(HtmlNode dishNode)
        {
            return string.Empty;
        }


        public List<DishType> GetDishType()
        {
            return new List<DishType>();
        }

        public List<IDishSiteModel> GetDishesList()
        {
            return new List<IDishSiteModel>();
        }
    }
}
