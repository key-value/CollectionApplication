using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;

namespace GaFan
{
    public class DishTypeSecretary : AbstractDishType, IDishType
    {
        public DishTypeSecretary()
        {
            _generalEntityList = new List<IDishSiteModel>();
            _pageUrl = @"http://www.gafan.cn/restaurant/{0}.html";
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
            return new List<DishType>();
        }
        private List<IDishSiteModel> _generalEntityList;
        public List<IDishSiteModel> GetDishesList()
        {
            return _generalEntityList;
        }

        protected override string DishesTypePath()
        {
            return @".//div[@class='main']/div[@class='list_left']/div[@id='tab_div_0']/div[@id='container']/div[@class='sidebox']/ul[@class='foodcon']/li";
        }

        protected override string DishesPath()
        {
            return string.Empty;
        }

        protected override string GetDishName(HtmlAgilityPack.HtmlNode dishNode)
        {
            return string.Empty;
        }

        protected override decimal GetDishPrice(HtmlAgilityPack.HtmlNode dishNode)
        {
            return 0;
        }

        protected override string GetDishImg(HtmlAgilityPack.HtmlNode dishNode)
        {
            return string.Empty;
        }

        protected override string GetDishesHref(HtmlNode dishTypeNode)
        {
            var funName = dishTypeNode.GetAttributes("onclick");
            if (string.IsNullOrEmpty(funName))
            {
                return string.Empty;
            }
            const string regex = @"ajaxDish\(this,'(\d*)','(\d*)'\)";
            if (!Regex.IsMatch(funName, regex))
            {
                return string.Empty;
            }
            var matchCollection = Regex.Match(funName, regex);
            var resId = matchCollection.Groups[1].Value;
            var preId = matchCollection.Groups[2].Value;
            if (string.IsNullOrEmpty(preId) || string.IsNullOrEmpty(preId))
            {
                return string.Empty;
            }
            return
                string.Format(
                    @"http://www.gafan.cn/orderAction!ajaxDish.do?resId={0}&preId={1}&page.size=10", resId, preId);
        }
    }
}
