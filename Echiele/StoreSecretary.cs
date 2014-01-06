using System;
using System.Text;
using AbstractSite;
using ISite;
using Maticsoft.Model;


namespace Echiele
{
    public class StoreSecretary : AbstractStore, IStore
    {
        public StoreSecretary()
        {
            StorePath = @".";
        }
        //public StoreInfo GetStoreInfo(Catalogue catalogue)
        //{
        //    //var storePath = @".//div[@class='dc_center']";
        //    var storePath = @".";
        //    var baseCollectionSite = new BaseCollectionSite(PageUrl);
        //    StoreInfoHtmlNode = baseCollectionSite.BaseHtmlNode;
        //    StoreInfoHtmlNode = StoreInfoHtmlNode.SelectSingleNode(storePath);
        //    if (StoreInfoHtmlNode == null)
        //    {
        //        return new NullStoreInfo();
        //    }
        //    var storeInfo = new StoreInfo();
        //    storeInfo.storeId = catalogue.StoreId;
        //    storeInfo.Fid = catalogue.FId;
        //    storeInfo.Facilities = GetFacilities();
        //    storeInfo.payCar = GetPayCar();
        //    storeInfo.BasicIntroduction = GetBasicIntroduction();
        //    storeInfo.subway = Subway();
        //    storeInfo.bus = GetBus();
        //    storeInfo.box = Getbox();
        //    storeInfo.StoreHours = GetWorkTime();
        //    storeInfo.StoreTag = StoreTagText();
        //    storeInfo.StoreName = catalogue.title;
        //    storeInfo.picName = catalogue.picName.Trim();
        //    storeInfo.carPark = GetCarPark();
        //    storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
        //    storeInfo.StorePhone = catalogue.StoreInfo.StorePhone;
        //    storeInfo.StoreName = catalogue.StoreInfo.StoreName;
        //    storeInfo.MinPrice = 0;
        //    storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
        //    return storeInfo;
        //}
        protected override StoreInfo ChangeStoreInfo(Catalogue catalogue, StoreInfo storeInfo)
        {
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = catalogue.StoreInfo.StoreAddress;
            storeInfo.StorePhone = catalogue.StoreInfo.StorePhone;
            storeInfo.StoreName = catalogue.StoreInfo.StoreName;
            storeInfo.MinPrice = 0;
            storeInfo.MaxPrice = catalogue.StoreInfo.MaxPrice;
            return storeInfo;
        }

        public override string GetFacilities()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div[@class='information disnone']/h3[@class='sh_fh']";
            var tagTitleNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (tagTitleNode == null)
            {
                return string.Empty;
            }
            var tagNode = tagTitleNode.NextSibling.NextSibling;
            if (tagNode == null)
            {
                return string.Empty;
            }
            var tagText =
                tagNode.InnerText.Trim()
                    .Replace("&nbsp", string.Empty)
                    .Replace(" ", string.Empty)
                    .Replace("　", string.Empty);
            return tagText.Replace("标签：", string.Empty);
        }

        public override string GetBus()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div[@class='information disnone']/p[1]";
            var busNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (busNode == null)
            {
                return string.Empty;
            }
            var busTextList = busNode.InnerHtml.Replace(@"<br>", "|").Split('|');
            foreach (var busText in busTextList)
            {
                if (busText.Contains(@"公交路线："))
                {
                    return busText.Replace("公交路线：", string.Empty).Trim();
                }
            }
            return string.Empty;
        }


        public override string GetPhoneNum()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div[@class='information disnone']/p[1]";
            var phoneNumNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (phoneNumNode == null)
            {
                return string.Empty;
            }
            var phoneTextList = phoneNumNode.InnerHtml.Replace(@"<br>", "|").Trim('|').Trim().Split('|');
            foreach (var phoneText in phoneTextList)
            {
                if (phoneText.Contains(@"预订电话："))
                {
                    return phoneText.Replace("预订电话：", string.Empty).Replace("（致电时，不妨告知由易吃易乐查到）：", string.Empty);
                }
            }
            return string.Empty;
        }

        public override string GetWorkTime()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div[@class='information disnone']/p[1]";
            var workTimeNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (workTimeNode == null)
            {
                return string.Empty;
            }
            var workTimeTextList = workTimeNode.InnerHtml.Replace("<br>", "|").Trim('|').Trim().Split('|');
            foreach (var workTimeText in workTimeTextList)
            {
                if (workTimeText.Contains(@"营业时间："))
                {
                    return workTimeText.Replace(@"营业时间：", string.Empty).Trim();
                }

            }
            return string.Empty;
        }

        public override string GetBasicIntroduction()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div/h3[@class='sh_jj']";
            var basicIntroductionTextNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            var stringBuilder = new StringBuilder();
            if (basicIntroductionTextNode == null)
            {
                return stringBuilder.ToString();
            }
            var basicIntroductionNode = basicIntroductionTextNode.NextSibling;
            while (basicIntroductionNode != null)
            {
                stringBuilder.Append(basicIntroductionNode.InnerText.Replace(@"&quot;", string.Empty).Replace(@"&nbsp;", string.Empty));
                basicIntroductionNode = basicIntroductionNode.NextSibling;
            }
            return stringBuilder.ToString();
        }

        public override string StoreTagText()
        {
            var xpath = @".//div[@class='dc_center']/div[@class='xq_ment']/div[@class='xq_ment_left ']/div[@class='information disnone']/p[1]";
            var tagTitleNode = StoreInfoHtmlNode.SelectSingleNode(xpath);
            if (tagTitleNode == null)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder();
            var tagTitleList = tagTitleNode.InnerHtml.Replace(@"<br>", "|").Trim().Trim('|').Trim().Split('|');
            foreach (var tagTitle in tagTitleList)
            {
                if (tagTitle.Contains(@"标　　签：") || tagTitle.Contains(@"适　　合："))
                {
                    stringBuilder.Append(tagTitle.Replace("标　　签：", string.Empty).Replace("适　　合：", string.Empty).Trim());
                }
            }
            return stringBuilder.ToString();
        }
    }
}
