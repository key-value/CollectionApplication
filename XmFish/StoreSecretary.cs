using System;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;


namespace XmFish
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@id='body-wrap']/div[@class='grid-c3s6e6']";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.StorePhone = catalogue.StoreInfo.StorePhone;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            return storeInfo;
        }

        public override string GetWorkTime()
        {
            var xpath =
                @".//div[@class='col-main']/div[@class='main-wrap mc-wifi']/div[@class='group-profile']/div[@class='address']/p";
            var workTimeNodeList = StoreInfoHtmlNode.SelectNodes(xpath);
            if (workTimeNodeList == null)
            {
                return string.Empty;
            }
            foreach (var workTimeNode in workTimeNodeList)
            {
                var indexNum = workTimeNode.InnerText.IndexOf("营业时间：", System.StringComparison.Ordinal);
                if (indexNum > 0)
                {
                    return workTimeNode.InnerText.Substring(indexNum + 5, workTimeNode.InnerText.Length - indexNum - 5);
                }
            }
            return string.Empty;

        }

        public override string StoreTagText()
        {
            var xpath =
                @".//div[@class='col-main']/div[@class='main-wrap mc-wifi']/div[@class='group-profile']/div[@class='name']/p/a[@class='alittle']";
            var tagNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (tagNode == null)
            {
                return string.Empty;
            }
            return tagNode.InnerText;
        }
    }
}
