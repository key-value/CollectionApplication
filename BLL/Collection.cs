using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Maticsoft.Model;

namespace Maticsoft.BLL
{
    public class Collection
    {
        string newPath = "./imagefiles/Food/{1}/{0}/{2}";//大图添加水印保存路径
        string newThumbnail = "./imagefiles/Thumbnail/{0}/{1}/";//缩略图添加水印保存路径
        string newPathThu = "./imagefiles/Foodbak/{0}/";

        private string _pageUrl = @"http://www.xiaomishu.com/";
        public Collection()
        {

        }

        /// <summary>
        /// 录入商圈
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool InsretCityLocalTag(string pageUrl, int index)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load(pageUrl);
            var list =
                htmlDoc.DocumentNode.SelectNodes(
                    ".//div[@class='constr pt10']/div[@class='constr_in']/a[@class='g3']");

            var cityLocalTagBll = new CityLocalTag();
            if (list == null)
            {
                return false;
            };
            var htmlNode = list.First();
            if (htmlNode == null)
            {
                return false;
            }
            if (cityLocalTagBll.Exists(index.ToString()))
            {
                return false;
            }
            var cityLocalTag = new Maticsoft.Model.CityLocalTag
            {
                TagName = htmlNode.InnerText,
                LocalTagID = index.ToString()
            };

            cityLocalTagBll.Add(cityLocalTag);
            return true;
        }
        /// <summary>
        /// 商家列表页获取
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="poIndex"></param>
        public List<Model.Catalogue> InsretPage(string pageUrl, int poIndex)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load(pageUrl);
            var list =
                htmlDoc.DocumentNode.SelectNodes(
                    ".//div[@class='constr']/div/div[@class='res_hm_c']/div[@class='res_sch_res schResList']/div[@class='l']/a");

            if (list == null)
            {
                return null;
            }
            var catalogueList = new List<Model.Catalogue>();
            foreach (var htmlNode in list)
            //Parallel.ForEach(list, htmlNode =>
            {
                var title = htmlNode.SelectSingleNode(".//img").Attributes["title"].Value;
                var href = htmlNode.Attributes["href"].Value;
                var keyList = href.Trim('/').Split('/');
                var keyID = string.Empty;
                var catalogue = new Maticsoft.Model.Catalogue();
                if (keyList.Count() == 2)
                {
                    keyID = keyList[1];
                    catalogue.FId = keyID;
                    catalogue.title = title;
                    catalogue.href = href;
                    catalogue.LocalTagID = poIndex;
                    catalogue.StoreId = Guid.NewGuid().ToString();
                    var storeInfoBll = new Maticsoft.BLL.StoreInfo();
                    var temStoreInfoList = storeInfoBll.GetModelList(string.Format("Fid = '{0}'", keyID));
                    var storePictureBll = new StorePicture();
                    if (temStoreInfoList != null && temStoreInfoList.Count > 0)
                    {
                        catalogue.IsRead = true;
                        var temStoreInfo = temStoreInfoList.FirstOrDefault();
                        if (temStoreInfo != null)
                        {
                            catalogue.StoreId = temStoreInfo.storeId;
                        }
                        var oldStorePicture =
                            storePictureBll.GetModelList(string.Format("PicType ='Shop' and StoreId = '{0}'",
                                catalogue.StoreId));
                        foreach (var storePicture in oldStorePicture)
                        {
                            storePictureBll.Delete(storePicture.PID);
                        }
                        //Parallel.ForEach(oldStorePicture, storePicture => storePictureBll.Delete(storePicture.PID));
                    }
                    else
                    {
                        catalogue.IsRead = false;
                    }
                    var imgNode = htmlNode.SelectSingleNode(".//img[@class='jsLazyImage']");
                    if (imgNode != null)
                    {
                        var shopPicturePath = imgNode.Attributes["data-url"].Value;
                        if (!string.IsNullOrEmpty(shopPicturePath) && !shopPicturePath.EndsWith("food_nopic.png"))
                        {
                            var storePicture = new Maticsoft.Model.StorePicture();
                            storePicture.PID = Guid.NewGuid().ToString();
                            var pictureName = string.Format("{0}.jpg", storePicture.PID);
                            storePicture.PictureName = pictureName;
                            storePicture.PicType = "Shop";
                            storePicture.PicturePath = shopPicturePath;
                            storePicture.StoreId = catalogue.StoreId;
                            storePictureBll.Add(storePicture);
                            catalogue.picName = storePicture.PictureName;
                        }

                    }
                    catalogueList.Add(catalogue);
                }
                //catalogueBll.Add(catalogue);
            }

            return catalogueList.OrderBy(x => x != null && x.IsRead).ThenBy(x => x != null ? x.FId : string.Empty).ToList();
        }

        /// <summary>
        /// 收集某一家商店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Model.StoreInfo CollectionStore(string pageUrl, Model.Catalogue catalogue)
        {
            var htmlWeb = new HtmlWeb();
            try
            {

                var htmlDoc = htmlWeb.Load(string.Format("{0}{1}", _pageUrl, pageUrl));
                var nodeDetail =
                htmlDoc.DocumentNode.SelectSingleNode(
                    ".//div[@class='constr']/div[@class='constr_in pt15 pb30']/div[@class='l res_detail_con']");
                if (nodeDetail == null)
                {
                    return null;
                }
                var nodeAddress = nodeDetail.SelectSingleNode(".//div[@class='res_hm_find']/div[@class='res_hm_find_in z']/div[@class='fix pb10']/div[@class='cell pl20']/div[@class='dash pb15 mr5']/div[@class='lh22']/div[@class='cell pl5']");
                var addressName = string.Empty;
                if (nodeAddress != null)
                {
                    var addressText = nodeAddress.FirstChild;
                    if (addressText == null)
                    {
                        return null;
                    }
                    addressName = addressText.InnerText.Replace("/r/n", string.Empty).Trim();
                    if (string.IsNullOrEmpty(addressName))
                    {
                        return null;
                    }
                }

                var minPrice = 0;
                var maxPrice = 0;
                var peoplePriceNode = nodeDetail.SelectSingleNode(".//div[@class='res_hm_find']/div[@class='res_hm_find_in z']/div[@class='fix pb10']/div[@class='cell pl20']/div[@class='dash pb15 mr5']/div[@class='lh22']/strong[@class ='cr']");

                if (peoplePriceNode != null)
                {
                    var peoplePriceList = peoplePriceNode.InnerText.Trim().Split('-');
                    if (peoplePriceList.Count() == 2)
                    {
                        int.TryParse(peoplePriceList[0], out minPrice);
                        int.TryParse(peoplePriceList[1], out maxPrice);
                    }
                }
                var storeTagList = nodeDetail.SelectNodes(".//div[@class='cell pl5']/a[@class='dib mr5']");
                var storeTagText = string.Empty;
                var storeTagStrList = new List<string>();
                if (storeTagList != null)
                {
                    storeTagStrList.AddRange(storeTagList.ToList().ConvertAll(x => x.InnerText));
                }
                var storeTagStrNode = nodeDetail.SelectNodes(".//div[@class='p20 mt5']/div[@class='mt10 f13']/div[@class='fix mb2']/p[@class='cell pl15']/a[@class='mr10']");
                if (storeTagStrNode != null && storeTagStrNode.Count > 0)
                {
                    storeTagStrList.AddRange(storeTagStrNode.ToList().ConvertAll(x => x.InnerText));
                }
                storeTagText = storeTagText + string.Join(@"、", storeTagStrList);
                var nodePhone = nodeDetail.SelectNodes(".//p[@class='cell pl15']");
                if (nodePhone == null)
                {
                    return null;
                }
                var phoneNum = nodePhone.Count > 1 ? nodePhone[1].FirstChild.InnerText.ToString().Replace(@"021-57575777&nbsp;&nbsp;我吃,我吃,我吃吃吃", string.Empty).Trim() : string.Empty;
                var workTime = nodePhone.Count > 2 ? nodePhone[2].FirstChild.InnerText.ToString() : string.Empty;
                var facilitieslist = nodePhone.Count > 3 ? nodePhone[3].SelectNodes(".//span") : null;
                var facilities = string.Empty;
                if (facilitieslist != null)
                {
                    foreach (var nodeInfo in facilitieslist)
                    {
                        facilities += nodeInfo.InnerText + '、';
                    }
                }
                facilities = facilities.Trim('、');
                var cardListNode = nodePhone.Count > 3 ? nodePhone[3].SelectSingleNode(".//a[@class='dib mr5 g3']") : null;
                bool payCar = cardListNode != null;
                //简介
                var basicIntroduction = nodePhone.Count > 4 ? nodePhone[4].InnerText : string.Empty;
                var subway = string.Empty;
                var carPark = string.Empty;
                var bus = string.Empty;
                var busTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u00']");
                if (busTagNode != null)
                {
                    var busNode = busTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
                    if (busNode != null)
                    {
                        bus = busNode.InnerText.Replace("/r/n", string.Empty).Replace(@"&nbsp;", string.Empty).Replace("修改", string.Empty).Trim();
                    }
                }


                var carParkTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u02']");
                if (carParkTagNode != null)
                {
                    var carParkNode = carParkTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
                    if (carParkNode != null)
                    {
                        carPark = carParkNode.InnerText.Replace("/r/n", string.Empty).Replace(@"&nbsp;", string.Empty).Replace("修改", string.Empty).Trim();
                    }
                }


                var subwayTagNode = nodeDetail.SelectSingleNode(".//u[@class='res_u_info u u01']");
                if (subwayTagNode != null)
                {
                    var subwayNode = subwayTagNode.ParentNode.ParentNode.SelectSingleNode(".//p[@class='cell pl15']");
                    if (subwayNode != null)
                    {
                        subway = subwayNode.InnerText.Replace("/r/n", string.Empty).Replace(@"&nbsp;", string.Empty).Replace("修改", string.Empty).Trim();
                    }
                }

                var box = nodeDetail.SelectSingleNode(".//a[@class='res_seat selSchSeat']") != null;
                var storeInfo = new Maticsoft.Model.StoreInfo();
                storeInfo.storeId = catalogue.StoreId;
                storeInfo.Fid = catalogue.FId;
                storeInfo.Facilities = facilities;
                storeInfo.payCar = payCar;
                storeInfo.BasicIntroduction = basicIntroduction;
                storeInfo.subway = subway;
                storeInfo.bus = bus;
                storeInfo.box = box;
                storeInfo.MaxPrice = maxPrice;
                storeInfo.MinPrice = minPrice;
                storeInfo.StorePhone = phoneNum;
                storeInfo.StoreHours = workTime;
                storeInfo.StoreTag = storeTagText;
                storeInfo.StoreName = catalogue.title;
                storeInfo.picName = catalogue.picName.Trim();
                storeInfo.storeTagList.AddRange(storeTagStrList);
                if (addressName.IndexOf("上海", System.StringComparison.Ordinal) == 0)
                {
                    addressName = addressName.Substring(2);
                }
                storeInfo.StoreAddress = addressName;
                storeInfo.carPark = carPark;
                //var storeList = storeInfoBll.GetModelList(string.Format("Fid like '%{0}%'", catalogue.FId));
                //if (storeList.Count <= 0)
                //{
                //    storeInfoBll.Add(storeInfo);
                //}
                return storeInfo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DishType> GetDishType(string pageUrl)
        {
            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(string.Format("{0}{1}/dish/", _pageUrl, pageUrl));

            var nodeDetail =
            htmlDoc.DocumentNode.SelectNodes(
                ".//div[@class='constr']/div[@class='constr_in']/div[@class='l float_four']/div[@class='bdc bgf0 pr10 pb10']/a[@class='res_food_ins_gra']");
            if (nodeDetail == null || nodeDetail.Count <= 0)
            {
                return null;
            }

            var dishTypeList = new List<DishType>();
            foreach (var nodeInfo in nodeDetail)
            {
                var href = nodeInfo.Attributes["href"].Value;
                var dishName = nodeInfo.InnerText;
                var dishNum = nodeInfo.FirstChild.InnerText;
                dishTypeList.Add(new DishType()
                {
                    PkID = Guid.NewGuid(),
                    DishName = dishName,
                    hrefString = href,
                    dishNum = dishNum,
                })
                ;
            }
            return dishTypeList;
        }

        /// <summary>
        /// 获取菜品详细--取消使用
        /// </summary>
        public List<Model.Dishes> GetDish(string UrlPath, string StoreName, string StoreId)
        {
            const string dishesPath = "Food";
            var foodThumbnail = string.Format(newThumbnail, dishesPath, StoreName);
            try
            {
                string CreatePath = string.Format(newPath, StoreName, dishesPath, string.Empty);
                if (!Directory.Exists(CreatePath))
                {
                    Directory.CreateDirectory(CreatePath);
                }
                if (!Directory.Exists(foodThumbnail))
                {
                    Directory.CreateDirectory(foodThumbnail);
                }

            }
            catch (Exception e)
            {
                return null;
            }
            var dishPath = string.Format("{0}{1}", _pageUrl, UrlPath);
            //dishPath = @"http://www.xiaomishu.com/shop/D22I15N56303/dish/";
            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(dishPath);

            var dishesList = new List<Model.Dishes>();
            var dishesNodeList =
            htmlDoc.DocumentNode.SelectNodes(
                ".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/ul[@id='foodListUl']/li");
            if (dishesNodeList == null || dishesNodeList.Count <= 1)
            {
                return dishesList;
            }
            foreach (var dishNode in dishesNodeList)
            {
                var dishes = new Maticsoft.Model.Dishes();
                var foodList = dishNode.SelectSingleNode(".//div[@class='fix']");
                if (foodList == null)
                {
                    continue;
                }
                var foodChildList = foodList.ChildNodes;
                var foodName = foodList.ChildNodes.Count > 1 ? foodChildList[1].InnerText ?? string.Empty : string.Empty;
                var foodPrice = foodList.ChildNodes.Count > 3 ? foodChildList[3].InnerText ?? string.Empty : string.Empty;
                var popularity = foodList.ChildNodes.Count > 5 ? foodChildList[5].InnerText ?? string.Empty : string.Empty;
                dishes.StoreId = StoreId;
                dishes.DishesID = Guid.NewGuid().ToString();
                dishes.DishesName = foodName.Trim();
                dishes.DishesMoney = foodPrice.Replace("¥", String.Empty).Trim();
                dishes.popularity = popularity.Trim();
                //dishes.StoreId = storeInfo.storeId;
                var dishesPictureNode = dishNode.SelectSingleNode(
                    ".//div[@class='abs_out pt10']/div[@class='fix rel']/div[@class='pct50 l']/a[@class='g3']/img");
                if (dishesPictureNode != null)
                {
                    dishes.PictureName = string.Format("{0}.jpg", Guid.NewGuid().ToString());
                    var dishesPicturePath = dishesPictureNode.Attributes["src"].Value;
                    if (!string.IsNullOrEmpty(dishesPicturePath))
                    {
                        try
                        {
                            try
                            {
                                db.DownFile(dishesPicturePath.Replace(@"/300_200/", "/"), string.Format(newPath, StoreName, dishesPath, dishes.PictureName));
                            }
                            catch (Exception)
                            {
                                db.DownFile(dishesPicturePath, string.Format(newPath, StoreName, dishes.PictureName));
                            }
                            //db.ZoomAuto(string.Format(newPath, StoreName, dishesPath, dishes.PictureName), newThumbnail + dishes.PictureName, 320, 240);//生成缩略图
                            var dishPicPath = string.Format(newPath, StoreName, dishesPath, dishes.PictureName);
                            db.ZoomAuto(dishPicPath, foodThumbnail + "640_480_" + dishes.PictureName, 640, 480);//生成缩略图
                            db.ZoomAuto(dishPicPath, foodThumbnail + "320_240_" + dishes.PictureName, 320, 240);//生成缩略图
                            db.ZoomAuto(dishPicPath, foodThumbnail + "160_120_" + dishes.PictureName, 160, 120);//生成缩略图
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }

                }
                dishesList.Add(dishes);

            }
            return dishesList;
        }

        public bool GetNextHref(string pageUrl, ref string href, bool BeginOrEnd = true)
        {
            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(pageUrl);

            var nodeDetail =
            htmlDoc.DocumentNode.SelectNodes(
                ".//a[@class='page_able']");
            if (nodeDetail == null || nodeDetail.Count <= 0)
            {
                return false;
            }
            HtmlNode lastNode;
            lastNode = BeginOrEnd ? nodeDetail.LastOrDefault() : nodeDetail.FirstOrDefault();
            if (lastNode != null)
            {
                href = lastNode.Attributes["href"].Value;
                if (string.IsNullOrEmpty(href))
                {
                    return false;
                }
                href = _pageUrl.Trim('/') + href;
                if (href != pageUrl)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void GetFood(Maticsoft.Model.StoreInfo storeInfo)
        {
            var dishesPath = "Food";
            try
            {
                //string CreatePath = string.Format(newPath, storeInfo.StoreName, dishesPath, string.Empty);
                //if (!Directory.Exists(CreatePath))
                //{
                //    Directory.CreateDirectory(CreatePath);
                //}

                //var foodThumbnail = string.Format(newThumbnail, dishesPath, storeInfo.StoreName);
                //if (!Directory.Exists(foodThumbnail))
                //{
                //    Directory.CreateDirectory(foodThumbnail);
                //}

                //var newPathThumb = string.Format(newPathThu, dishesPath);
                //if (!Directory.Exists(newPathThumb))
                //{
                //    Directory.CreateDirectory(newPathThumb);
                //}

                var dishesBll = new Maticsoft.BLL.Dishes();
                var disheslist = dishesBll.GetModelList(string.Format("StoreId = '{0}'", storeInfo.storeId));
                foreach (var dishese in disheslist)
                {
                    dishesBll.Delete(dishese.DishesID);
                }
                var dishTypeBll = new Maticsoft.BLL.DishesTyepTable();
                var dishTypeList = dishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", storeInfo.storeId));
                foreach (var dishesTyepTable in dishTypeList)
                {
                    dishTypeBll.Delete(dishesTyepTable.DishesTypeID);
                }
                var dishTypePath = string.Format("{0}shop/{1}/dish/", _pageUrl, storeInfo.Fid);

                var storePictureBll = new StorePicture();

                var storePicturelist = storePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeInfo.storeId, dishesPath));
                foreach (var storePicture in storePicturelist)
                {
                    storePictureBll.Delete(storePicture.PID);
                }

                //dishPath = @"http://www.xiaomishu.com/shop/D22I15N56303/dish/";
                var htmlWeb = new HtmlWeb();

                var htmlDoc = htmlWeb.Load(dishTypePath);
                var dishTypeNodeList = htmlDoc.DocumentNode.SelectNodes(".//div[@class='constr']/div[@class='constr_in']/div[@class='l float_four']/div[@class='bdc bgf0 pr10 pb10']/a[@class='res_food_ins_gra']");
                if (dishTypeNodeList == null)
                {
                    return;
                }
                foreach (var dishTypeNode in dishTypeNodeList)
                {
                    var dishType = new Maticsoft.Model.DishesTyepTable();
                    dishType.BusinessID = storeInfo.storeId;
                    dishType.CreateDate = DateTime.Now;
                    dishType.DishesTypeID = Guid.NewGuid().ToString();
                    var dishName = dishTypeNode.InnerText;
                    var dishlength = dishName.IndexOf('(');
                    dishType.DishesTypeName = dishTypeNode.InnerText.Substring(0, dishlength);
                    dishTypeBll.Add(dishType);

                    var pageIndex = 1;
                    while (true)
                    {
                        var dishUrl = dishTypeNode.Attributes["href"].Value;

                        var dishPath = string.Format("{0}{1}p{2}/", _pageUrl, dishUrl, pageIndex);

                        pageIndex++;
                        htmlDoc = htmlWeb.Load(dishPath);
                        var dishesNodeList =
                        htmlDoc.DocumentNode.SelectNodes(
                            ".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/ul[@id='foodListUl']/li[@class='res_food_list']");
                        if (dishesNodeList == null || dishesNodeList.Count <= 1)
                        {
                            break;
                        }
                        foreach (var dishNode in dishesNodeList)
                        {
                            var dishes = new Maticsoft.Model.Dishes();
                            var foodList = dishNode.SelectSingleNode(".//div[@class='fix']");
                            if (foodList == null)
                            {
                                continue;
                            }
                            var foodChildList = foodList.ChildNodes;
                            var foodName = foodList.ChildNodes.Count > 1 ? foodChildList[1].InnerText ?? string.Empty : string.Empty;
                            var foodPrice = foodList.ChildNodes.Count > 3 ? foodChildList[3].InnerText ?? string.Empty : string.Empty;
                            var popularity = foodList.ChildNodes.Count > 5 ? foodChildList[5].InnerText ?? string.Empty : string.Empty;
                            dishes.DishesID = Guid.NewGuid().ToString();
                            dishes.DishesName = foodName.Trim();
                            foodPrice = foodPrice.Trim().Replace("￥", string.Empty).Replace("¥", string.Empty);
                            dishes.dishTypeID = dishType.DishesTypeID;
                            if (foodPrice.Trim() == "时价")
                            {
                                dishes.DishesMoney = "0";
                                dishes.IsCurrentPrice = true;
                            }
                            else if (foodPrice.Trim() == "不详")
                            {
                                dishes.DishesMoney = "0";
                            }
                            else
                            {
                                dishes.DishesMoney = foodPrice;
                            }

                            dishes.popularity = popularity.Trim();
                            dishes.StoreId = storeInfo.storeId;
                            var dishesPictureNode = dishNode.SelectSingleNode(
                                ".//div[@class='abs_out pt10']/div[@class='fix rel']/div[@class='pct50 l']/a[@class='g3']/img");
                            if (dishesPictureNode != null)
                            {
                                var dishesPicturePath = dishesPictureNode.Attributes["src"].Value;
                                if (!string.IsNullOrEmpty(dishesPicturePath) && !dishesPicturePath.EndsWith("food_nopic.png"))
                                {
                                    var storePicture = new Maticsoft.Model.StorePicture();
                                    storePicture.PID = Guid.NewGuid().ToString();
                                    var pictureName = string.Format("{0}.jpg", storePicture.PID);
                                    storePicture.PictureName = pictureName;
                                    storePicture.PicType = dishesPath;
                                    storePicture.PicturePath = dishesPicturePath;
                                    storePicture.StoreId = storeInfo.storeId;
                                    storePictureBll.Add(storePicture);

                                    dishes.PictureName = pictureName;
                                    //try
                                    //{
                                    //    db.DownFile(dishesPicturePath.Replace(@"/300_200/", "/").Replace("/320_0/", "/"), string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName));
                                    //}
                                    //catch (Exception)
                                    //{
                                    //}
                                    //try
                                    //{
                                    //    db.DownFile(dishesPicturePath, newPathThumb + dishes.PictureName);
                                    //}
                                    //catch (Exception)
                                    //{

                                    //    throw;
                                    //}
                                    //var storeInfopath = string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName);
                                    //db.ZoomAuto(newPathThumb + dishes.PictureName, foodThumbnail + dishes.PictureName, 320, 240);//生成缩略图
                                    //db.ZoomAuto(newPathThumb + dishes.PictureName, foodThumbnail + "640_480_" + dishes.PictureName, 640, 480);//生成缩略图
                                    //db.ZoomAuto(newPathThumb + dishes.PictureName, foodThumbnail + "320_240_" + dishes.PictureName, 320, 240);//生成缩略图
                                    //db.ZoomAuto(newPathThumb + dishes.PictureName, foodThumbnail + "160_120_" + dishes.PictureName, 160, 120);//生成缩略图

                                }
                            }
                            dishesBll.Add(dishes);
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }

        }


        /// <summary>
        /// 获取图片详细
        /// </summary>
        public void GetPicture(Maticsoft.Model.StoreInfo storeInfo)
        {
            var picturePathName = "PhotoAlbum";
            var picPullList = new List<PicPull>() { PicPull.Environmental, PicPull.Cake };
            //var picThumbnail = string.Format(newThumbnail, picturePathName, storeInfo.StoreName);
            //var newPathThumb = string.Format(newPathThu, picturePathName);
            //try
            //{
            //    string CreatePath = string.Format(newPath, storeInfo.StoreName, picturePathName, string.Empty);
            //    if (!Directory.Exists(CreatePath))
            //    {
            //        Directory.CreateDirectory(CreatePath);
            //    }
            //    if (!Directory.Exists(picThumbnail))
            //    {
            //        Directory.CreateDirectory(picThumbnail);
            //    }
            //    if (!Directory.Exists(newPathThumb))
            //    {
            //        Directory.CreateDirectory(newPathThumb);
            //    }

            //}
            //catch (Exception e)
            //{
            //}

            var storePictureBll = new StorePicture();

            var storePicturelist = storePictureBll.GetModelList(string.Format("StoreID = '{0}' and picType ='{1}'", storeInfo.storeId, picturePathName));
            foreach (var storePicture in storePicturelist)
            {
                storePictureBll.Delete(storePicture.PID);
            }
            var storePicturesTableBll = new StorePicturesTable();
            var storePicturesTableList = storePicturesTableBll.GetModelList(string.Format("businessID = '{0}'", storeInfo.storeId));
            foreach (var storePicturesTable in storePicturesTableList)
            {
                storePicturesTableBll.Delete(storePicturesTable.StorePicturesID);
            }
            foreach (var picPull in picPullList)
            {
                var busphotoAlbumTable = new Maticsoft.Model.BusPhotoAlbumTable();
                busphotoAlbumTable.BusinessID = storeInfo.storeId;
                if (picPull == PicPull.Cake)
                {
                    busphotoAlbumTable.AlbumName = @"菜品图片";
                }
                else
                {
                    busphotoAlbumTable.AlbumName = @"餐厅环境";
                }
                busphotoAlbumTable.BusPhotoAlbumID = Guid.NewGuid().ToString();
                busphotoAlbumTable.IsDefault = true;
                var busPhotoAlbumTableBll = new Maticsoft.BLL.BusPhotoAlbumTable();
                busPhotoAlbumTableBll.Add(busphotoAlbumTable);


                var pageIndex = 1;
                while (true)
                {
                    //t=-1 2 3时有值
                    var picturePath = @"{0}shop/new/ajax/picpull.aspx?resid={1}&t={2}&time={3}";

                    picturePath = string.Format(picturePath, _pageUrl, storeInfo.Fid, (int)picPull, pageIndex);
                    //picturePath = @"http://www.xiaomishu.com/shop/new/ajax/picpull.aspx?resid=C21C09K22533&time=6";
                    pageIndex++;
                    var htmlWeb = new HtmlWeb();

                    var htmlDoc = htmlWeb.Load(picturePath);
                    var pictureNodeList = htmlDoc.DocumentNode.SelectNodes(".//div[@class='bdc bgf0 p10']/a/img");
                    if (pictureNodeList == null)
                    {
                        break;
                    }
                    foreach (var pictureNode in pictureNodeList)
                    {
                        var dishesPicturePath = pictureNode.Attributes["src"].Value;
                        if (string.IsNullOrEmpty(dishesPicturePath) || dishesPicturePath.EndsWith("food_nopic.png"))
                        {
                            return;
                        }
                        var storePicture = new Maticsoft.Model.StorePicture();
                        storePicture.PID = Guid.NewGuid().ToString();
                        var pictureName = string.Format("{0}.jpg", storePicture.PID);
                        storePicture.PictureName = pictureName;
                        storePicture.PicType = picturePathName;
                        storePicture.PicturePath = dishesPicturePath;
                        storePicture.StoreId = storeInfo.storeId;
                        //dishesPicturePath = @"http://f2.95171.cn/pic/D22I15N56303/3cfeefbe-cadd-49af-904b-a33a4b1d6c70.jpg";
                        //try
                        //{
                        //    db.DownFile(dishesPicturePath.Replace("/320_0/", "/").Replace(@"/300_200/", "/"), string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName));
                        //}
                        //catch (Exception)
                        //{
                        //}
                        //try
                        //{
                        //    db.DownFile(dishesPicturePath, newPathThumb + pictureName);
                        //}
                        //catch (Exception)
                        //{
                        //    throw;
                        //}
                        //var storePath = string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName);

                        //db.ZoomAuto(newPathThumb + pictureName, picThumbnail + pictureName, 320, 240);//生成缩略图
                        //db.ZoomAuto(newPathThumb + pictureName, picThumbnail + "640_480_" + pictureName, 640, 480);//生成缩略图
                        //db.ZoomAuto(newPathThumb + pictureName, picThumbnail + "320_240_" + pictureName, 320, 240);//生成缩略图
                        //db.ZoomAuto(newPathThumb + pictureName, picThumbnail
                        //     + "160_120_" + pictureName, 160, 120);//生成缩略图
                        storePictureBll.Add(storePicture);

                        var storePicturesTable = new Maticsoft.Model.StorePicturesTable();
                        storePicturesTable.StorePicturesID = Guid.NewGuid().ToString();
                        storePicturesTable.BusPhotoAlbumID = busphotoAlbumTable.BusPhotoAlbumID;
                        storePicturesTable.BusinessID = busphotoAlbumTable.BusinessID;
                        storePicturesTable.PictureAddress = pictureName;
                        storePicturesTable.PicState = 2;
                        //storePicturesTable.PicName = dishesPicturePath;
                        storePicturesTable.UploadTime = DateTime.Now;
                        storePicturesTableBll.Add(storePicturesTable);
                    }
                }
            }
        }
    }
}
