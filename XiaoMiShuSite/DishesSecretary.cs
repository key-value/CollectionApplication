using AbstractSite;
using ApplicationUtility;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;

namespace XiaoMiShuSite
{
    public class DishesSecretary : AbstractDishes, IDishes
    {
        protected override string GetDishesName(HtmlAgilityPack.HtmlNode dishesNode)
        {
            string xpath = ".//div[@class='fix']/div[@class='pct50 l']/a";
            return CollectionNodeText.GetNodeInnerText(dishesNode, xpath);
        }

        protected override decimal GetDishesMoney(HtmlAgilityPack.HtmlNode dishesNode)
        {
            string xpath = ".//div[@class='fix']/div[@class='pct10 l tc']";
            var dishesMoneyText = CollectionNodeText.GetNodeListContainsInnerText(dishesNode, xpath, @"¥");
            if (dishesMoneyText.Trim() == "时价")
            {
                return 0;
            }
            else if (dishesMoneyText.Trim() == "不详")
            {
                return 0;
            }
            decimal dishesMoney = 0;
            return decimal.TryParse(dishesMoneyText, out dishesMoney) ? dishesMoney : 0;
        }

        protected override string GetDishesBrief(HtmlAgilityPack.HtmlNode dishesNode)
        {
            return string.Empty;
        }

        protected override string GetPictureHref(HtmlAgilityPack.HtmlNode dishesNode)
        {
            var dishesPictureNode = dishesNode.SelectSingleNode(
                                  ".//div[@class='abs_out pt10']/div[@class='fix rel']/div[@class='pct50 l']/a[@class='g3']/img");
            if (dishesPictureNode != null)
            {
                return dishesPictureNode.GetPicturePath();
            }
            return string.Empty;
        }

        public override string DishPath()
        {
            return
                @".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/ul[@id='foodListUl']/li[@class='res_food_list']";
        }


        public void GetDish(IDishSiteModel dishSiteModel, string storeID)
        {
        }

        public override bool Conversion()
        {
            return true;
        }

        protected override string NextPageUrlPath()
        {
            return @".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/div[@class='mt20 p5 tr']/a[@class='page_able']";
        }

        protected override string NextPageUrl(HtmlNode pageUrlNode)
        {
            return @"http://www.xiaomishu.com" + pageUrlNode.GetPicturePath();
        }
    }
}
