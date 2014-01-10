using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;
using AbstractSite;

namespace XiaoMiShuSite
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            //.//div[7]/div/div[2]/div[3]/div[2]/div/div/h4/a
            PageUrl = @"http://www.xiaomishu.com/";
            CataloguePath = @".//div[@class='constr']/div/div[@class='res_hm_c']/div[@class='res_sch_res schResList']";
            ImgNodePath = @".//div[@class='l']/a[@target='_blank']/img";
            PageNodePath =
               @".//div[@class='constr']/div[@class='constr_in pt15 pb30']/div[@class='res_hm_c']/div[@class='tr pt30 pb2 btc mt-1 fix']/div[@class='r pt5 pb1']/a";
            NextPage = @"http://www.xiaomishu.com/";
            BeforePage = @"http://www.xiaomishu.com/";

        }

        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"../span[@class='page_on']");
            if (spanNode != null)
            {
                var intpageNum = 1;
                if (int.TryParse(spanNode.InnerText, out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
        }

        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
        }

        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='cell pl20']/div/div/h4[@class='f14 di mr5']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.GetPicturePath();//shop/F20I05W49127/
            Href = GetStoreUrl() + hrefString;
            const string regex = @"\/shop\/(\w*)?\/";
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(hrefString, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            Title = fidNode.InnerText;
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return htmlNode.Attributes["data-url"].Value;
        }
    }
}
