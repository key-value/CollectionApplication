using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using Maticsoft.Model;
using Catalogue = Maticsoft.BLL.Catalogue;
using CityLocalTag = Maticsoft.BLL.CityLocalTag;
using Dishes = Maticsoft.BLL.Dishes;
using StoreInfo = Maticsoft.BLL.StoreInfo;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace CollectionForm
{
    public partial class Form1 : Form
    {
        private string _pageUrl = @"http://www.xiaomishu.com/";

        string newPath = "./imagefiles/Food/{0}/{1}/{2}";//大图添加水印保存路径
        string newThumbnail = "./imagefiles/Thumbnail/Food/";//缩略图添加水印保存路径


        public Form1()
        {
            InitializeComponent();
            GetPicture();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            for (int poIndex = 1; poIndex < 20; poIndex++)
            {
                //http://www.xiaomishu.com/shop/search-po1/
                var startPageUrl = string.Format(@"{0}shop/search-po{1}/", _pageUrl, poIndex);
                if (!InsretCityLocalTag(startPageUrl, poIndex))
                {
                    continue;
                }
                for (int pageIndex = 1; pageIndex <= 10; pageIndex++)
                {
                    string indexPageUrl = string.Format(@"{0}-p{1}/", startPageUrl.Trim('/'), pageIndex);
                    if (!InsretPage(indexPageUrl, poIndex))
                    {
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// 商家列表页具体行获取
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="poIndex"></param>
        private bool InsretPage(string pageUrl, int poIndex)
        {
            #region 待用算法
            //var request = WebRequest.Create(PageUrl);
            //var response = request.GetResponse();
            //var resStream = response.GetResponseStream();
            //var htmlString = string.Empty;
            //if (resStream == null)
            //{
            //    return;
            //}
            //var sr = new StreamReader(resStream, System.Text.Encoding.UTF8);
            //htmlString = sr.ReadToEnd();
            //resStream.Close();
            //sr.Close();
            //ContentHtml.Text = htmlString;
            //var list = htmlDoc.DocumentNode.SelectNodes(".//div[@class='constr']/div/div[@class='res_hm_c']/div[@class='res_sch_res schResList']/div[@class='cell pl20']/div[@class='cell_bk']/div[@class='g9 l ell jsForSchTit res_sch_tit_w']");
            //var list = htmlDoc.DocumentNode.SelectNodes(".//img[@class='jsLazyImage']");
            #endregion

            var htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(pageUrl);
            var list =
                htmlDoc.DocumentNode.SelectNodes(
                    ".//div[@class='constr']/div/div[@class='res_hm_c']/div[@class='res_sch_res schResList']/div[@class='l']/a");


            if (list == null)
            {
                return false;
            }
            var catalogueBll = new Maticsoft.BLL.Catalogue();
            foreach (var htmlNode in list)
            {
                var href = htmlNode.Attributes["href"].Value;
                var title = htmlNode.SelectSingleNode(".//img").Attributes["title"].Value;
                var keyList = href.Trim('/').Split('/');
                var keyID = string.Empty;
                if (keyList.Count() == 2)
                {
                    keyID = keyList[1];
                    if (catalogueBll.Exists(keyID))
                    {
                        continue;
                    }
                }
                var catalogue = new Maticsoft.Model.Catalogue();
                catalogue.FId = keyID;
                catalogue.title = title;
                catalogue.href = href;
                catalogue.LocalTagID = poIndex;
                catalogueBll.Add(catalogue);
                htmllBox.Items.Add(string.Format("连接{0} --{1} -- {2}", href, title, keyID));
            }
            return true;
        }

        /// <summary>
        /// 商家详细商家列表页
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool InsretCityLocalTag(string pageUrl, int index)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void htmllBox_MouseClick(object sender, MouseEventArgs e)
        {
            ContentHtml.Text = htmllBox.Items[htmllBox.SelectedIndex].ToString();
        }

        /// <summary>
        /// 商店详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DishesTyep_Click(object sender, EventArgs e)
        {
            var catalogueBll = new Catalogue();
            var catalogueList = catalogueBll.GetModelList(string.Empty);
            foreach (var catalogue in catalogueList)
            {

                var pagePath = string.Format("{0}shop/{1}/", _pageUrl, catalogue.FId);

                //todo 修改路径测试

                pagePath = @"http://www.xiaomishu.com/shop/AESH10017472/";
                var htmlWeb = new HtmlWeb();

                var htmlDoc = htmlWeb.Load(pagePath);

                var nodeDetail =
                htmlDoc.DocumentNode.SelectSingleNode(
                    ".//div[@class='constr']/div[@class='constr_in pt15 pb30']/div[@class='l res_detail_con']");
                if (nodeDetail == null)
                {
                    return;
                }
                var nodeAddress = nodeDetail.SelectSingleNode(".//div[@class='res_hm_find']/div[@class='res_hm_find_in z']/div[@class='fix pb10']/div[@class='cell pl20']/div[@class='dash pb15 mr5']/div[@class='lh22']/div[@class='cell pl5']");
                var addressName = string.Empty;
                if (nodeAddress != null)
                {
                    var addressText = nodeAddress.FirstChild;
                    if (addressText == null)
                    {
                        return;
                    }
                    addressName = addressText.InnerText.Replace("/r/n", string.Empty).Trim();
                    if (string.IsNullOrEmpty(addressName))
                    {
                        return;
                    }
                }
                var nodePhone = nodeDetail.SelectNodes(".//p[@class='cell pl15']");
                if (nodePhone == null)
                {
                    return;
                }
                var phoneNum = nodePhone[1].FirstChild.InnerText.ToString().Replace(@"021-57575777&nbsp;&nbsp;我吃,我吃,我吃吃吃", string.Empty).Trim();
                var workTime = nodePhone[2].FirstChild.InnerText.ToString();
                var facilitieslist = nodePhone[3].SelectNodes(".//span[@class='dib mr5 ml5']");
                var facilities = string.Empty;
                if (facilitieslist != null)
                {
                    foreach (var nodeInfo in facilitieslist)
                    {
                        facilities += nodeInfo.InnerText + '、';
                    }
                }
                facilities = facilities.Trim('、');
                var cardListNode = nodePhone[3].SelectSingleNode(".//a[@class='dib mr5 g3']");
                bool payCar = cardListNode != null;
                //简介
                var basicIntroduction = nodePhone[4].InnerText.ToString();
                var subway = string.Empty;
                var carPark = string.Empty;
                var bus = string.Empty;
                if (nodePhone.Count > 8)
                {
                    subway = nodePhone[5].FirstChild.InnerText.ToString().Replace("/r/n", string.Empty).Trim();
                    if (nodePhone.Count > 6)
                    {
                        bus = nodePhone[6].FirstChild.InnerText.ToString().Replace("/r/n", string.Empty).Trim();
                    }
                    if (nodePhone.Count > 7)
                    {
                        carPark = nodePhone[7].FirstChild.InnerText.ToString().Replace("/r/n", string.Empty).Trim();
                    }
                }
                else
                {
                    bus = nodePhone[5].FirstChild.InnerText.ToString().Replace("/r/n", string.Empty).Trim();
                    if (nodePhone.Count > 6)
                    {
                        carPark = nodePhone[6].FirstChild.InnerText.ToString().Replace("/r/n", string.Empty).Trim();
                    }
                }
                var box = nodeDetail.SelectSingleNode(".//a[@class='res_seat selSchSeat']") != null;
                var storeInfoBll = new StoreInfo();
                var storeInfo = new Maticsoft.Model.StoreInfo();
                storeInfo.Fid = catalogue.FId;
                storeInfo.storeId = Guid.NewGuid().ToString();
                storeInfo.Facilities = facilities;
                storeInfo.payCar = payCar;
                storeInfo.BasicIntroduction = basicIntroduction;
                storeInfo.subway = subway;
                storeInfo.bus = bus;
                storeInfo.box = box;
                storeInfo.StorePhone = phoneNum;
                storeInfo.StoreHours = workTime;
                storeInfo.StoreName = catalogue.title;
                storeInfo.StoreAddress = addressName;
                storeInfo.carPark = carPark;
                storeInfoBll.Add(storeInfo);
            }
        }

        /// <summary>
        /// 获取菜品详细
        /// </summary>
        private void GetFood()
        {
            var dishesPath = "dishes";
            var storeInfoBll = new StoreInfo();
            var storeList = storeInfoBll.GetModelList(string.Empty);
            foreach (var storeInfo in storeList)
            {
                try
                {
                    string CreatePath = string.Format(newPath, storeInfo.StoreName, dishesPath, string.Empty);
                    if (!Directory.Exists(CreatePath))
                    {
                        Directory.CreateDirectory(CreatePath);
                    }
                }
                catch (Exception e)
                {
                }
                var pageIndex = 1;
                while (true)
                {

                    var dishPath = string.Format("{0}shop/{1}/dish/p{2}/", _pageUrl, storeInfo.Fid, pageIndex);
                    pageIndex++;
                    //dishPath = @"http://www.xiaomishu.com/shop/D22I15N56303/dish/";
                    var htmlWeb = new HtmlWeb();

                    var htmlDoc = htmlWeb.Load(dishPath);

                    var dishesNodeList =
                    htmlDoc.DocumentNode.SelectNodes(
                        ".//div[@class='constr']/div[@class='constr_in']/div[@class='cell pl10']/ul[@id='foodListUl']/li");
                    if (dishesNodeList == null || dishesNodeList.Count <= 1)
                    {
                        break;
                    }
                    var dishesBll = new Dishes();
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
                        dishes.DishesMoney = foodPrice.Trim();
                        dishes.popularity = popularity.Trim();
                        dishes.StoreId = storeInfo.storeId;
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
                                    db.DownFile(dishesPicturePath.Replace(@"/300_200/", "/"), string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName));
                                }
                                catch (Exception)
                                {
                                    db.DownFile(dishesPicturePath, string.Format(newPath, storeInfo.StoreName, dishes.PictureName));
                                }
                                db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName), newThumbnail + dishes.PictureName, 320, 240);//生成缩略图
                                db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName), newThumbnail + "640_480_" + dishes.PictureName, 640, 480);//生成缩略图
                                db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName), newThumbnail + "320_240_" + dishes.PictureName, 320, 240);//生成缩略图
                                db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, dishesPath, dishes.PictureName), newThumbnail + "160_120_" + dishes.PictureName, 160, 120);//生成缩略图
                                dishes.PictureName = dishesPicturePath;
                            }

                        }
                        dishesBll.Add(dishes);
                    }
                }
            }
        }

        /// <summary>
        /// 获取图片详细
        /// </summary>
        private void GetPicture()
        {
            var picturePathName = "picture";
            var picPullList = Enum.GetValues(typeof(PicPull));
            var storeInfoBll = new StoreInfo();
            var storeList = storeInfoBll.GetModelList(string.Empty);

            var storePictureBll = new StorePicture();
            foreach (var storeInfo in storeList)
            {
                try
                {
                    string CreatePath = string.Format(newPath, storeInfo.StoreName, picturePathName, string.Empty);
                    if (!Directory.Exists(CreatePath))
                    {
                        Directory.CreateDirectory(CreatePath);
                    }
                }
                catch (Exception e)
                {
                }
                var pageIndex = 1;
                foreach (var picPull in picPullList)
                {
                    while (true)
                    {
                        //t=-1 2 3时有值
                        var picturePath = @"{0}shop/new/ajax/picpull.aspx?resid={1}&t={2}&time={3}";

                        picturePath = string.Format(picturePath, _pageUrl, storeInfo.Fid, (int)picPull, pageIndex);
                        //picturePath =
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
                            if (string.IsNullOrEmpty(dishesPicturePath))
                            {
                                return;
                            }
                            var storePicture = new Maticsoft.Model.StorePicture();
                            storePicture.PID = Guid.NewGuid().ToString();
                            var pictureName = string.Format("{0}.jpg", storePicture.PID);
                            storePicture.PictureName = pictureName;
                            storePicture.StoreId = storeInfo.storeId;
                            //dishesPicturePath = @"http://f2.95171.cn/pic/D22I15N56303/3cfeefbe-cadd-49af-904b-a33a4b1d6c70.jpg";
                            dishesPicturePath = dishesPicturePath.Replace("/320_0/", "/");
                            try
                            {
                                db.DownFile(dishesPicturePath, string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName));
                            }
                            catch (Exception)
                            {
                                db.DownFile(dishesPicturePath, string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName));
                            }
                            db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName), newThumbnail + pictureName, 320, 240);//生成缩略图
                            db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName), newThumbnail + "640_480_" + pictureName, 640, 480);//生成缩略图
                            db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName), newThumbnail + "320_240_" + pictureName, 320, 240);//生成缩略图
                            db.ZoomAuto(string.Format(newPath, storeInfo.StoreName, picturePathName, pictureName), newThumbnail + "160_120_" + pictureName, 160, 120);//生成缩略图
                            storePictureBll.Add(storePicture);

                        }
                    }

                }
            }
        }
    }
}
