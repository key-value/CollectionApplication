using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using HtmlAgilityPack;
using ISite;
using Maticsoft.Model;

namespace XiaoMiShuSite
{
    public class StoreSecretary : IStore
    {
        //public StoreInfo GetStoreInfo(Catalogue catalogue)
        //{
        //    //try
        //    //{
        //    //    var nodeDetail = CatalogueHtmlNode.SelectSingleNode(((IStore)this).EntityXpath);
        //    //    if (nodeDetail == null)
        //    //    {
        //    //        return null;
        //    //    }
        //    //    int minPrice;
        //    //    int maxPrice;
        //    //    PeoplePrice(nodeDetail, out minPrice, out maxPrice);
        //    //    var nodePhone = nodeDetail.SelectNodes(".//p[@class='cell pl15']");
        //    //    if (nodePhone == null)
        //    //    {
        //    //        return null;
        //    //    }
        //    //    var phoneNum = string.Empty; //.Count > 1 ? nodePhone[1].FirstChild.InnerText.ToString().Replace(@"021-57575777&nbsp;&nbsp;我吃,我吃,我吃吃吃", string.Empty).Trim() : string.Empty;
        //    //    var workTime = string.Empty; //nodePhone.Count > 2 ? nodePhone[2].FirstChild.InnerText.ToString() : string.Empty;
        //    //    var facilities = GetFacilities(nodePhone);
        //    //    var cardListNode = string.Empty; //nodePhone.Count > 3 ? nodePhone[3].SelectSingleNode(".//a[@class='dib mr5 g3']") : null;
        //    //    bool payCar = cardListNode != null;
        //    //    //简介
        //    //    var basicIntroduction = nodePhone.Count > 4 ? nodePhone[4].InnerText : string.Empty;
        //    //    var box = nodeDetail.SelectSingleNode(".//a[@class='res_seat selSchSeat']") != null;
        //    //    var storeInfo = new StoreInfo();
        //    //    storeInfo.storeId = catalogue.StoreId;
        //    //    storeInfo.Fid = catalogue.FId;
        //    //    storeInfo.Facilities = facilities;
        //    //    storeInfo.payCar = payCar;
        //    //    storeInfo.BasicIntroduction = basicIntroduction;
        //    //    storeInfo.subway = Subway(nodeDetail);
        //    //    storeInfo.bus = GetBus(nodeDetail);
        //    //    storeInfo.box = box;
        //    //    storeInfo.MaxPrice = maxPrice;
        //    //    storeInfo.MinPrice = minPrice;
        //    //    storeInfo.StorePhone = phoneNum;
        //    //    storeInfo.StoreHours = workTime;
        //    //    storeInfo.StoreTag = StoreTagText(nodeDetail);
        //    //    storeInfo.StoreName = catalogue.title;
        //    //    storeInfo.picName = catalogue.picName.Trim();
        //    //    storeInfo.StoreAddress = GetAddress(nodeDetail);
        //    //    storeInfo.carPark = GetCarPark(nodeDetail);
        //    return new NullStoreInfo();

        //    //}
        //    //catch (Exception)
        //    //{
        //    //    throw;
        //    //}
        //}

        //protected string GetFacilities(HtmlNodeCollection nodePhone)
        //{
        //    var facilitieslist = nodePhone.Count > 3 ? nodePhone[3].SelectNodes(".//span") : null;
        //    var facilities = string.Empty;
        //    if (facilitieslist != null)
        //    {
        //        facilities = facilitieslist.Aggregate(facilities, (current, nodeInfo) => current + (nodeInfo.InnerText + '、'));
        //    }
        //    facilities = facilities.Trim('、');
        //    return facilities;
        //}

        //protected string Subway(HtmlNode nodeDetail)
        //{
        //    string subway = string.Empty;
        //    var subwayTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u01']");
        //    if (subwayTagNode == null)
        //    {
        //        return subway;
        //    }
        //    var subwayNode = subwayTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
        //    if (subwayNode == null)
        //    {
        //        return subway;
        //    }
        //    subway =
        //        subwayNode.InnerText.Replace("/r/n", string.Empty)
        //            .Replace(@"&nbsp;", string.Empty)
        //            .Replace("修改", string.Empty)
        //            .Trim();
        //    return subway;
        //}

        //protected string GetCarPark(HtmlNode nodeDetail)
        //{
        //    string carPark = string.Empty;
        //    var carParkTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u02']");
        //    if (carParkTagNode == null)
        //    {
        //        return carPark;
        //    }
        //    var carParkNode = carParkTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
        //    if (carParkNode == null)
        //    {
        //        return carPark;
        //    }
        //    carPark =
        //        carParkNode.InnerText.Replace("/r/n", string.Empty)
        //            .Replace(@"&nbsp;", string.Empty)
        //            .Replace("修改", string.Empty)
        //            .Trim();
        //    return carPark;
        //}

        //protected string GetBus(HtmlNode nodeDetail)
        //{
        //    string bus = String.Empty;
        //    var busTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u00']");
        //    if (busTagNode != null)
        //    {
        //        var busNode = busTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
        //        if (busNode != null)
        //        {
        //            bus =
        //                busNode.InnerText.Replace("/r/n", string.Empty)
        //                    .Replace(@"&nbsp;", string.Empty)
        //                    .Replace("修改", string.Empty)
        //                    .Trim();
        //        }
        //    }
        //    return bus;
        //}

        //protected string StoreTagText(HtmlNode nodeDetail)
        //{
        //    //var storeTagText = string.Empty;
        //    //var storeTagStrList = new List<string>();
        //    //var storeTagList = nodeDetail.SelectNodes(StoreTagXpath);
        //    //if (storeTagList != null)
        //    //{
        //    //    storeTagStrList.AddRange(storeTagList.ToList().ConvertAll(x => x.InnerText));
        //    //}
        //    //var storeTagStrNode =
        //    //    nodeDetail.SelectNodes(
        //    //        ".//div[@class='p20 mt5']/div[@class='mt10 f13']/div[@class='fix mb2']/p[@class='cell pl15']/a[@class='mr10']");
        //    //if (storeTagStrNode != null && storeTagStrNode.Count > 0)
        //    //{
        //    //    storeTagStrList.AddRange(storeTagStrNode.ToList().ConvertAll(x => x.InnerText));
        //    //}
        //    //storeTagText = storeTagText + string.Join(@"、", storeTagStrList);
        //    //return storeTagText;
        //    return string.Empty;
        //}

        //protected void PeoplePrice(HtmlNode nodeDetail, out int minPrice, out int maxPrice)
        //{
        //    minPrice = 0;
        //    maxPrice = 0;
        //    var peoplePriceNode = nodeDetail.SelectSingleNode(((IStore) this).PriceXpath);

        //    if (peoplePriceNode != null)
        //    {
        //        var peoplePriceList = peoplePriceNode.InnerText.Trim().Split('-');
        //        if (peoplePriceList.Count() == 2)
        //        {
        //            int.TryParse(peoplePriceList[0], out minPrice);
        //            int.TryParse(peoplePriceList[1], out maxPrice);
        //        }
        //    }
        //}

        //protected string GetAddress(HtmlNode nodeDetail)
        //{
        //    var nodeAddress = nodeDetail.SelectSingleNode(((IStore) this).AddressXpath);
        //    var addressName = string.Empty;
        //    if (nodeAddress == null)
        //    {
        //        return addressName;
        //    }
        //    var addressText = nodeAddress.FirstChild;
        //    if (addressText == null)
        //    {
        //        return addressName;
        //    }
        //    addressName = addressText.InnerText.Replace("/r/n", string.Empty).Trim();
        //    if (addressName.IndexOf("上海", System.StringComparison.Ordinal) == 0)
        //    {
        //        addressName = addressName.Substring(2);
        //    }
        //    return addressName;
        //}

        string GetFacilities()
        {
            throw new NotImplementedException();
        }


        public bool Getbox()
        {
            throw new NotImplementedException();
        }


        public string Subway()
        {
            throw new NotImplementedException();
        }

        public string GetCarPark()
        {
            throw new NotImplementedException();
        }

        public string GetBus()
        {
            throw new NotImplementedException();
        }

        public string StoreTagText()
        {
            throw new NotImplementedException();
        }

        public void PeoplePrice(out int minPrice, out int maxPrice)
        {
            throw new NotImplementedException();
        }

        public string GetAddress()
        {
            throw new NotImplementedException();
        }

        public string GetPhoneNum()
        {
            throw new NotImplementedException();
        }

        public string GetWorkTime()
        {
            throw new NotImplementedException();
        }

        public bool GetPayCar()
        {
            throw new NotImplementedException();
        }

        public string GetBasicIntroduction()
        {
            throw new NotImplementedException();
        }


        public HtmlNode NodeDetail
        {
            get;
            set;
        }

        public StoreInfo GetStoreInfo(Catalogue catalogue)
        {
            var nodePhone = NodeDetail.SelectNodes(".//p[@class='cell pl15']");
            if (nodePhone == null)
            {
                return null;
            }
            int minPrice;
            int maxPrice;
            PeoplePrice(out minPrice, out maxPrice);
            var storeInfo = new StoreInfo();
            storeInfo.storeId = catalogue.StoreId;
            storeInfo.Fid = catalogue.FId;
            storeInfo.Facilities = string.Empty;
            storeInfo.payCar = GetPayCar();
            storeInfo.BasicIntroduction = GetBasicIntroduction();
            storeInfo.subway = Subway();
            storeInfo.bus = GetBus();
            storeInfo.box = Getbox();
            storeInfo.MaxPrice = maxPrice;
            storeInfo.MinPrice = minPrice;
            storeInfo.StorePhone = GetPhoneNum();
            storeInfo.StoreHours = GetWorkTime();
            storeInfo.StoreTag = StoreTagText();
            storeInfo.StoreName = catalogue.title;
            storeInfo.picName = catalogue.picName.Trim();
            storeInfo.StoreAddress = GetAddress();
            storeInfo.carPark = GetCarPark();
            return storeInfo;
        }

        public string PageUrl
        {
            get;
            set;
        }
    }
}
