using System;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;


namespace FanTong
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".";
        }
        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            storeInfo.StoreTag += catalogue.StoreInfo.StoreTag;
            return storeInfo;
        }

        public override string GetFacilities()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dt/i[@class='icon_fw']";
            var tagTitleNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (tagTitleNode == null)
            {
                return string.Empty;
            }
            var tagNode = tagTitleNode.ParentNode.ParentNode;
            if (tagNode == null)
            {
                return string.Empty;
            }
            var tagText =
                tagNode.InnerText.Trim()
                    .Replace("&nbsp", string.Empty)
                    .Replace(" ", string.Empty)
                    .Replace("　", string.Empty);
            return tagText.Replace("服务：", string.Empty);
        }

        public override string GetBus()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dd";
            var busNode = StoreInfoHtmlNode.SelectNodes(xpath);
            if (busNode == null)
            {
                return string.Empty;
            }
            foreach (var busText in busNode)
            {
                if (busText.InnerText.Contains(@"公交路线："))
                {
                    return busText.InnerText.Replace("公交路线：", string.Empty);
                }
            }
            return string.Empty;
        }


        public override string GetPhoneNum()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dd";
            var phoneNumNode = StoreInfoHtmlNode.SelectNodes(xpath);
            if (phoneNumNode == null)
            {
                return string.Empty;
            }
            foreach (var phoneTextNode in phoneNumNode)
            {
                if (phoneTextNode.InnerText.Contains(@"预订电话："))
                {
                    return phoneTextNode.InnerText.Replace("预订电话：", string.Empty).Replace("（致电时，不妨告知由饭统网查到） ", string.Empty).Trim();
                }
            }
            return string.Empty;
        }

        public override string GetWorkTime()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dd";
            var workTimeNode = StoreInfoHtmlNode.SelectNodes(xpath);
            if (workTimeNode == null)
            {
                return string.Empty;
            }
            foreach (var workTimeText in workTimeNode)
            {
                if (workTimeText.InnerText.Contains(@"营业时间："))
                {
                    return workTimeText.InnerText.Replace("营业时间：", string.Empty);
                }
            }
            return string.Empty;
        }

        public override string GetBasicIntroduction()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dt/i[@class='icon_jj']/../../dd[@class='txt-short']";
            var basicIntroductionTextNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            var stringBuilder = new StringBuilder();
            if (basicIntroductionTextNode == null)
            {
                return stringBuilder.ToString();
            }
            return basicIntroductionTextNode.InnerText;
        }

        public override string StoreTagText()
        {
            var xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='hotel_reservation mt10']/dl/dd";
            var stringBuilder = new StringBuilder();
            var tagTitleNode = StoreInfoHtmlNode.SelectNodes(xpath);
            if (tagTitleNode == null)
            {
                return string.Empty;
            }
            foreach (var tagTitle in tagTitleNode)
            {
                if (tagTitle.InnerText.Contains(@"适　　合："))
                {
                    stringBuilder.Append(tagTitle.InnerText.Replace("适　　合：", string.Empty));
                }
            }
            xpath = @".//div[@class='warp']/div[@class='main']/div[@class='lefts_left']/div[@class='res_introduction']/dl/dd";
            tagTitleNode = StoreInfoHtmlNode.SelectNodes(xpath);
            if (tagTitleNode == null)
            {
                return stringBuilder.ToString();
            }
            foreach (var tagTitle in tagTitleNode)
            {
                if (tagTitle.InnerText.Contains(@"标签："))
                {
                    stringBuilder.Append(tagTitle.InnerText.Replace("标签：", string.Empty));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
