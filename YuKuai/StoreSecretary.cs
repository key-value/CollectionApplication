using System;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;


namespace YuKuai
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".//div[@class='yk-content']";
        }

        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.StorePictureHref = catalogue.StorePictureHref;
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            return storeInfo;
        }

        public override string GetFacilities()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li/p[@class='dmcl']";
            var tagNodeList = StoreInfoHtmlNode.SelectNodes(xpath);
            if (tagNodeList == null)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder();
            foreach (var tagNode in tagNodeList)
            {
                if (tagNode.InnerText.Contains("设施服务："))
                {
                    stringBuilder.Append(tagNode.InnerText.Replace("适合类型：", string.Empty).Replace("设施服务：", string.Empty));
                }
            }
            return stringBuilder.ToString();
        }

        public override string GetBus()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li[@class='d-height']/p/a[@id='gongjiaoErr']/../span";
            var busNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (busNode == null)
            {
                return string.Empty;
            }
            return busNode.InnerText.Replace("公交：", string.Empty);
        }


        public override string GetPhoneNum()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li[@class='d-height']/p/a[@id='telephoneErr']/../span";
            var phoneNumNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (phoneNumNode == null)
            {
                return string.Empty;
            }
            var phoneText = phoneNumNode.InnerText.Replace(@"&nbsp;", string.Empty);
            var subNum = phoneText.IndexOf("）", System.StringComparison.Ordinal);
            if (subNum++ > 0)
            {
                phoneText = phoneText.Substring(subNum, phoneText.Length - subNum);
            }
            return phoneText.Replace(@"4009191777", string.Empty).Replace(@"4009191777-3537", string.Empty).Trim();

        }

        public override string GetWorkTime()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li[@class='d-height']/p/a[@id='businessTimeErr']/../span";
            var workTimeNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (workTimeNode == null)
            {
                return string.Empty;
            }
            return workTimeNode.InnerText.Replace("营业时间：", string.Empty);

        }

        public override string GetBasicIntroduction()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li/p[@class='down-up']";
            var basicIntroductionTextNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (basicIntroductionTextNode == null)
            {
                return string.Empty;
            }
            return basicIntroductionTextNode.InnerText;
        }

        public override string StoreTagText()
        {
            var xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-block res-detail mt10']/ul[@class='detail mlr25']/li/p[@class='dmcl']";
            var tagNodeList = StoreInfoHtmlNode.SelectNodes(xpath);
            if (tagNodeList == null)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder();
            foreach (var tagNode in tagNodeList)
            {
                if (tagNode.InnerText.Contains("适合类型："))
                {
                    stringBuilder.Append(tagNode.InnerText.Replace("适合类型：", string.Empty).Replace("设施服务：", string.Empty));
                }
            }
            xpath =
                @".//div[@class='yk-grid-col2 type-mx clearfix mt10']/div[@class='yk-grid-main']/div[@class='res-business-information']/div[@class='res_busInformation']/div[@class='res-stylefood']/span/a";
            tagNodeList = StoreInfoHtmlNode.SelectNodes(xpath);
            if (tagNodeList == null)
            {
                return stringBuilder.ToString();
            }
            foreach (var tagNode in tagNodeList)
            {
                stringBuilder.Append(tagNode.InnerText);
            }
            return stringBuilder.ToString();
        }
    }
}
