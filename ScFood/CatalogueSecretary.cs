using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbstractSite;
using HtmlAgilityPack;
using ISite;
using Maticsoft.BLL;
using Catalogue = Maticsoft.Model.Catalogue;

namespace ScFood
{
    public class CatalogueSecretary : AbstractCatalogue, ICatalogue
    {
        public CatalogueSecretary()
        {
            PageUrl = @"http://www.scfood.net";
            CataloguePath = @".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w766 fleft']/div[@id='lazyload_left']/div[@class='fleft w766 mtop12']/div[@class='fleft lb_766']/div[@class='lieb_list_w']";
            PageNodePath =
               @".//div[@class='w_100']/div[@class='w_100 fleft ']/div[@class='w980 center']/div[@class='w766 fleft']/div[@id='lazyload_left']/div[@class='fleft w766 mtop12']/div[@class='fleft w766 mtop8']/div[@class='sabrosus fright ']/a";
            ImgNodePath = @".//div[@class='w185 fleft']/a/img";
            NextPage = @"http://www.scfood.net";
            BeforePage = @"http://www.scfood.net";
        }

        public int PageCount { get; set; }

        public int CircleId { get; set; }

        public int IflastPage { get; set; }
        public override void InitRestaurant(HtmlNode restaurant)
        {
            GetFid(restaurant);
            //GetAddress(restaurant);
        }


        protected override Maticsoft.Model.StoreInfo GetStoreInfo(string storeName, HtmlNode restaurant)
        {
            if (restaurant == null)
            {
                return new Maticsoft.Model.NullStoreInfo();
            }
            var storeInfo = new Maticsoft.Model.StoreInfo();
            storeInfo.StoreAddress = GetAddress(restaurant);
            storeInfo.StoreName = storeName;
            storeInfo.MaxPrice = MaxPrice(restaurant);
            storeInfo.StoreTag = GetStoreTag(restaurant);
            storeInfo.StorePhone = GetStorePhone(restaurant);
            storeInfo.Facilities = GetFacilities(restaurant);
            return storeInfo;
        }

        private string GetStoreTag(HtmlNode htmlNode)
        {
            return CollectionNodeText.GetNodeListInnerText(htmlNode, @".//div[@class='w320 fleft keytitle']/ul/li/a");
        }


        private string GetFacilities(HtmlNode htmlNode)
        {
            return CollectionNodeText.GetNodeListInnerText(htmlNode, @".//div[@class='w320 fleft keytitle']/ul/li/span[@class='sslitxt']/a");
        }
        public void GetFid(HtmlNode htmlNode)
        {
            var fidNode = htmlNode.SelectSingleNode(@".//div[@class='w320 fleft keytitle']/ul/li/span[@class='fleft shopname']/a");
            if (fidNode == null)
            {
                return;
            }
            var hrefString = fidNode.Attributes["href"].Value;
            Href = string.Format(@"http://www.scfood.net{0}", hrefString);
            const string regex = @"[\w]*\/[\w]*-[\w]*-(\d*).[\w]*";//item/shops-id-70.html
            if (!Regex.IsMatch(hrefString, regex))
            {
                return;
            }
            var matchCollection = Regex.Match(htmlNode.InnerHtml, regex);
            Fid = string.IsNullOrEmpty(matchCollection.Groups[1].Value.Trim())
                   ? string.Empty
                   : matchCollection.Groups[1].Value;
            Title = fidNode.InnerText;
        }

        public string GetAddress(HtmlNode htmlNode)
        {
            return CollectionNodeText.GetNodeInnerText(htmlNode, @".//div[@class='w320 fleft keytitle']/ul/li[@class='con_mtop']/span[@class='sslitxt']");
        }

        public string GetStorePhone(HtmlNode htmlNode)
        {


            return CollectionNodeText.GetNodeListContainsInnerText(htmlNode, @".//div[@class='w320 fleft keytitle']/ul/li", "电话：");
        }

        public int MaxPrice(HtmlNode htmlNode)
        {
            var priceText = CollectionNodeText.GetNodeInnerText(htmlNode, @".//div[@class='fleft w98']/span[@class=' txtcenter price ']");
            decimal priceNum = 0;
            decimal.TryParse(priceText, out priceNum);
            return (int)priceNum;
        }

        protected override string GetshopPicturePath(HtmlNode htmlNode)
        {
            return @"http://www.scfood.net" + htmlNode.Attributes["src"].Value;
        }
        protected override void GetPage(HtmlNode pageNode)
        {
            var spanNode = pageNode.SelectSingleNode(@"..//span[@class='current']");
            if (spanNode != null)
            {
                var intpageNum = 1;
                if (int.TryParse(spanNode.InnerText, out intpageNum))
                {
                    PageNum = intpageNum;
                }
            }
        }
    }
}
