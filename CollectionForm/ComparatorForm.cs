using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AbstractSite;
using ApplicationUtility;
using CollectionLogic;
using ISite;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PopupTool;
using BusPhotoAlbum = Maticsoft.Model.BusPhotoAlbum;
using Catalogue = Maticsoft.Model.Catalogue;
using City = Maticsoft.Model.City;
using CookingStyles = Maticsoft.Model.CookingStyles;
using DishesTyep = Maticsoft.Model.DishesTyep;
using SpecialTag = Maticsoft.Model.SpecialTag;
using StoreInfo = Maticsoft.Model.StoreInfo;
using StorePictures = Maticsoft.BLL.StorePictures;

namespace CollectionForm
{
    public partial class ComparatorForm : Form
    {
        private List<StoreInfo> _storeInfoList = new List<StoreInfo>();

        private string _selectedItem;

        public ComparatorForm()
        {
            InitializeComponent();

            InitializeCheckBox();

            InitializeClb();

            InitializeButton();
        }

        private void InitializeButton()
        {
            btnNextPage.Enabled = false;
            btnBeforePage.Enabled = false;
        }
        private void InitializeClb()
        {
            var specialTagBll = new Maticsoft.BLL.SpecialTag();
            chlBoxSpecialTag.DataSource = specialTagBll.GetModelList(string.Empty);
            chlBoxSpecialTag.DisplayMember = "TagName";

            var cookingStylesBll = new Maticsoft.BLL.CookingStyles();
            chbCookingStyles.DataSource =
                cookingStylesBll.GetModelList(String.Empty).OrderBy(x => x.CookingStyleName).ToList();
            chbCookingStyles.DisplayMember = "CookingStyleName";

            var cityLocalTagBll = new Maticsoft.BLL.CityLocalTagBll();
            clbStoreTag.DataSource = cityLocalTagBll.GetModelList(string.Empty).OrderBy(x => x.TagName).ToList();
            clbStoreTag.DisplayMember = "TagName";
        }
        private void InitializeCheckBox()
        {
            var provinces = new Maticsoft.BLL.Provinces();
            var provincesList = provinces.GetModelList(string.Empty);
            cbBoxProvinces.DataSource = provincesList;
            cbBoxProvinces.ValueMember = "ProvincesName";
            var provincesInfo = provincesList.FirstOrDefault();
            var cityBll = new Maticsoft.BLL.City();
            var cityList = cityBll.GetModelList(string.Empty);
            cityList = cityList.FindAll(x => provincesInfo != null && x.ProvincesID == provincesInfo.ProvincesID);
            cbBoxCity.DataSource = cityList;
            cbBoxCity.DisplayMember = "CityName";
            var cityInfo = cityList.FirstOrDefault();
            var districtBll = new Maticsoft.BLL.District();
            var districtList = districtBll.GetModelList(String.Empty);
            cbbDistrict.DataSource = districtList.FindAll(x => cityInfo != null && x.CityID == cityInfo.CityID);
            cbbDistrict.DisplayMember = "DistrictName";
        }
        private string InitializeRegex(string path)
        {
            //var regex = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            var regex = @"(http|ftp|https)?[:\/\/]?[\w\-_]+(\.[\w\-_]+)(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            if (!Regex.IsMatch(path, regex))
            {
                return string.Empty;
            }
            Match matchCollection = Regex.Match(path, regex);
            var siteName = matchCollection.Groups[2].Value.Replace(".", string.Empty).ToLower();
            switch (siteName)
            {
                case "echiele":
                    _selectedItem = "Echiele";
                    regex = string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*zonecode=(\d*)[\w\-\.,@?^=%&amp;:/~\+#]*[page=(\d*)]*[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "fantong":
                    _selectedItem = "FanTong";
                    regex =
                        string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "cyooy":
                    _selectedItem = "Cyooy";
                    regex =
                        string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]+=(\d*)-(\d*)-(\d*)-(\d*)-(\d*)-(\d*)-(\d*)", siteName);
                    break;
                case "yukuai":
                    _selectedItem = "YuKuai";
                    regex =
                       string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "scfood":
                    _selectedItem = "ScFood";
                    regex =
                       string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "duomifan":
                    _selectedItem = "DuoMiFan";
                    regex =
                        string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "dianping":
                    _selectedItem = "DianPing";
                    regex =
                       string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "xiaomishu":
                    _selectedItem = "XiaoMiShuSite";
                    regex =
                       string.Format(@"(http|ftp|https)?[:\/\/]?[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                default:
                    regex = string.Empty;
                    break;
            }
            return regex;
        }

        private void webBtn_Click(object sender, EventArgs e)
        {
            catalogueListBox.DataBindings.Clear();
            catalogueListBox.ValueMember = "title";
            _storeInfoList = new List<StoreInfo>();
            try
            {
                var path = textBox1.Text.Trim();
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show(@"请输入网址");
                    return;
                }
                var regex = InitializeRegex(path);
                int pageIndex;
                if (string.IsNullOrEmpty(regex) || !Regex.IsMatch(path, regex))
                {
                    MessageBox.Show(@"请输入正确的网址");
                    return;
                }
                Match matchCollection = Regex.Match(path, regex);
                pageIndex =
                    int.Parse(string.IsNullOrEmpty(matchCollection.Groups[3].Value.Trim())
                        ? "1"
                        : matchCollection.Groups[3].Value);
                var sitePath = new SitePath(path, pageIndex) { SelectedSite = _selectedItem };
                Action<SitePath> goPathDelegate = GoPath;
                goPathDelegate.BeginInvoke(sitePath, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GoPath(SitePath sitePath)
        {
            Action<string, string, int, List<Catalogue>> goPathDelegate = (nextPage, beforePage, pageNum, cList) =>
            {
                try
                {
                    catalogueListBox.Items.Clear();
                    if (cList != null)
                    {
                        // ReSharper disable once CoVariantArrayConversion
                        catalogueListBox.Items.AddRange(cList.ToArray());
                    }
                    for (int i = 0; i < catalogueListBox.Items.Count; i++)
                    {
                        catalogueListBox.SetItemChecked(i,
                            ((Catalogue)catalogueListBox.Items[i]).IsRead);
                    }

                    labPage.Text = pageNum.ToString(CultureInfo.InvariantCulture);

                    btnNextPage.Enabled = !string.IsNullOrEmpty(nextPage);
                    btnNextPage.Tag = nextPage;

                    btnBeforePage.Enabled = !string.IsNullOrEmpty(beforePage);
                    btnBeforePage.Tag = beforePage;
                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            };
            try
            {
                var catalogueLogic = new CollectionLogic.CatalogueLogic(sitePath.SelectedSite);
                catalogueLogic.SetPath(sitePath.Path);
                catalogueLogic.PageNum = sitePath.PageIndex;
                progressBar1.SetValue(0);
                catalogueLogic.CataloEventHandler(UpdateIncrement);
                var catalogueList = catalogueLogic.GetCataloguePage(sitePath.PageIndex);
                BeginInvoke(goPathDelegate, catalogueLogic.NextPage, catalogueLogic.BeforePage, catalogueLogic.PageNum, catalogueList);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void ShowException(Exception ex)
        {
            Invoke(new Action<Exception>(x => MessageBox.Show(x.Message)), ex);
        }

        private void catalogueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetCatalogueListBox();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }
        private void SetCatalogueListBox()
        {
            if (catalogueListBox.SelectedIndex < 0)
            {
                return;
            }
            var catalogueInfo = catalogueListBox.SelectedItem as Catalogue;
            if (catalogueInfo == null)
            {
                return;
            }
            var taskGetcatalogueList = new Action<Catalogue, string>((x, ySelectedItem) =>
            {
                var storeLogic = new StoreLogic(ySelectedItem) { PageUrl = x.href };
                storeLogic.CataloEventHandler(UpdateIncrement);
                var storeInfo = storeLogic.GetStoreInfo(x);
                if (storeInfo != null && !storeInfo.IsNull)
                {
                    _storeInfoList.Add(storeInfo);
                    BeginInvoke(new Action<StoreInfo>(ClearStoreText), storeInfo);
                }
                else
                {
                    Invoke(_showMessageBox, @"网络异常");
                }
            });

            taskGetcatalogueList.BeginInvoke(catalogueInfo, _selectedItem, null, null);
        }
        private void ClearStoreText(StoreInfo storeInfo)
        {
            textBox4.ClearTag();
            chbCarPark.UpdateCheckedState(false);
            chbChildrenChair.UpdateCheckedState(false);
            chbCod.UpdateCheckedState(false);
            chbIsCitySend.UpdateCheckedState(false);
            chbIsCoupon.UpdateCheckedState(false);
            chbIsSend.UpdateCheckedState(false);
            chbKCVIP.UpdateCheckedState(false);
            chbNoSmoke.UpdateCheckedState(false);
            chbOnlinePay.UpdateCheckedState(false);
            chbOnlineorder.UpdateCheckedState(false);
            chbPayCar.UpdateCheckedState(false);
            chbPayCar.UpdateCheckedState(storeInfo.payCar);
            chbWIFI.UpdateCheckedState(false);
            chbbox.UpdateCheckedState(false);
            chbDish.UpdateCheckedState(false);
            chbPic.UpdateCheckedState(false);
            lblDish.SetTextBoxText(string.Empty);
            lblPic.SetTextBoxText(string.Empty);
            chbCarPark.UpdateCheckedState(storeInfo.CarParks);
            chbChildrenChair.UpdateCheckedState(storeInfo.ChildrenChair);
            chbPayCar.UpdateCheckedState(storeInfo.payCar);
            chbWIFI.UpdateCheckedState(storeInfo.WIFI);
            chbbox.UpdateCheckedState(storeInfo.box);
            chbNoSmoke.UpdateCheckedState(storeInfo.NoSmoke);
            txtBasic.SetTextBoxText(storeInfo.BasicIntroduction);
            txtBus.SetTextBoxText(storeInfo.bus);
            txtFacilities.SetTextBoxText(storeInfo.Facilities);
            txtMaxPrice.SetTextBoxText(storeInfo.MaxPrice.ToString());
            txtMinPrice.SetTextBoxText(storeInfo.MinPrice.ToString());
            txtStoreAddress.SetTextBoxText(storeInfo.StoreAddress);
            txtStoreHours.SetTextBoxText(string.IsNullOrWhiteSpace(storeInfo.StoreHours) ? "10:00-22:00" : storeInfo.StoreHours);
            txtStoreName.SetTextBoxText(storeInfo.StoreName);
            txtStorePhone.SetTextBoxText(storeInfo.StorePhone);
            txtStoreTag.SetTextBoxText(storeInfo.StoreTag);
            txtDoubleName.SetTextBoxText(string.Empty);

            txtBasicSite.SetTextBoxText(storeInfo.BasicIntroduction);
            txtBusSite.SetTextBoxText(storeInfo.bus);
            txtMaxPriceSite.SetTextBoxText(storeInfo.MaxPrice.ToString());
            txtMinPriceSite.SetTextBoxText(storeInfo.MinPrice.ToString());
            txtStoreAddressSite.SetTextBoxText(storeInfo.StoreAddress);
            txtStoreHoursSite.SetTextBoxText(string.IsNullOrWhiteSpace(storeInfo.StoreHours) ? "10:00-22:00" : storeInfo.StoreHours);
            txtStoreNameSite.SetTextBoxText(storeInfo.StoreName);
            txtStorePhoneSite.SetTextBoxText(storeInfo.StorePhone);
        }
        private void ClearStoreEntityText(StoreInfoEntity storeInfoEntity)
        {
            chbCarPark.UpdateCheckedState(storeInfoEntity.CarPark);
            chbChildrenChair.UpdateCheckedState(storeInfoEntity.ChildrenChair);
            chbCod.UpdateCheckedState(storeInfoEntity.Cod);
            chbIsCitySend.UpdateCheckedState(storeInfoEntity.IsCitySend);
            chbIsCoupon.UpdateCheckedState(storeInfoEntity.IsCoupon);
            chbIsSend.UpdateCheckedState(storeInfoEntity.IsSend != 0);
            chbKCVIP.UpdateCheckedState(storeInfoEntity.KCVIP);
            chbNoSmoke.UpdateCheckedState(storeInfoEntity.NoSmoke);
            chbOnlinePay.UpdateCheckedState(storeInfoEntity.OnlinePay);
            chbOnlineorder.UpdateCheckedState(storeInfoEntity.Onlineorder != 0);
            chbPayCar.UpdateCheckedState(storeInfoEntity.PayCar);
            chbPayCar.UpdateCheckedState(storeInfoEntity.PayCar);
            chbWIFI.UpdateCheckedState(storeInfoEntity.WIFI);
            chbbox.UpdateCheckedState(storeInfoEntity.Box);
            txtBasicSite.SetTextBoxText(storeInfoEntity.BasicIntroduction);
            txtDoubleName.SetTextBoxText(storeInfoEntity.BranchName);
            txtBusSite.SetTextBoxText(storeInfoEntity.Bus);
            txtMaxPriceSite.SetTextBoxText(storeInfoEntity.MaxPrice.ToString());
            txtMinPriceSite.SetTextBoxText(storeInfoEntity.MinPrice.ToString());
            txtStoreAddressSite.SetTextBoxText(storeInfoEntity.StoreAddress);
            txtStoreHoursSite.SetTextBoxText(string.IsNullOrWhiteSpace(storeInfoEntity.StoreHours) ? "10:00-22:00" : storeInfoEntity.StoreHours);
            txtStoreNameSite.SetTextBoxText(storeInfoEntity.StoreName);
            txtStorePhoneSite.SetTextBoxText(storeInfoEntity.StorePhone);
        }
        private void btnDish_Click(object sender, EventArgs e)
        {
            try
            {
                lblDish.SetTextBoxText(string.Empty);
                lboxDish.ClearText();
                var catalogueInfo = catalogueListBox.SelectedItem as Catalogue;
                if (catalogueInfo == null)
                {
                    return;
                }
                var storeInfo = _storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
                if (storeInfo == null)
                {
                    return;
                }
                var oldStoreInfo = textBox4.Tag as StoreInfoEntity;
                if (oldStoreInfo == null)
                {
                    storeInfo.OldStoreId = storeInfo.storeId;
                }
                else
                {
                    storeInfo.OldStoreId = oldStoreInfo.BizID;
                }
                storeInfo.ChangeDishes = true;
                var siteTypeStr = _selectedItem;
                var foodAction = new Action<StoreInfo, string>(GetFoodAction);
                foodAction.BeginInvoke(storeInfo, siteTypeStr, null, null);
                chbDish.Checked = true;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void GetFoodAction(StoreInfo store, string siteType)
        {
            var saveDishesEntity = new SaveDishesEntity(siteType);

            var dishTypeList = saveDishesEntity.UpdateDish(store, UpdateLabelText);
            var dishTypeListCount = 0;
            var dishCount = 0;
            if (dishTypeList != null)
            {
                store.DishTypeList = new List<DishesTyep>();
                store.DishTypeList = dishTypeList;
                dishTypeListCount = dishTypeList.Count;
                dishCount = dishTypeList.Sum(x => x.DishesList.Count);
                store.DishTypeList = dishTypeList;
            }
            else
            {
                store.DishTypeList.Clear();
            }
            lblDish.SetTextBoxText(string.Format("{0}菜品{1}种菜系{2}道菜品下载完成", store.StoreName, dishTypeListCount, dishCount));
            //Invoke(_showMessageBox, (string.Format("{0}菜品{1}种菜系{2}道菜品下载完成", store.StoreName, dishTypeListCount, dishCount)));
        }

        private void UpdateLabelText(object sender, LabelEventArgs labelEventArgs)
        {
            if (labelEventArgs.UpdateType == 1)
            {
                //labelDishText.SetTextBoxText(labelEventArgs.LabelText);
                lboxDish.AddText(labelEventArgs.LabelText);
            }
            else
            {
                //labelPicText.SetTextBoxText(labelEventArgs.LabelText);
                lboxPic.AddText(labelEventArgs.LabelText);
            }
        }

        private void GetPicAction(StoreInfo store, string siteType)
        {
            var pictureLogic = new PictureLogic(siteType);
            pictureLogic.SetLabelEventHandler(UpdateLabelText);
            var albumTablesList = pictureLogic.SaveAlbumTables(store);
            var albumCount = 0;
            var picturesCount = 0;
            if (albumTablesList != null)
            {
                albumCount = albumTablesList.Count;
                picturesCount = albumTablesList.Sum(x => x.StorePicturesList.Count);
                store.BusPhotoAlbumTableList = albumTablesList;
            }
            else
            {
                store.BusPhotoAlbumTableList.Clear();
            }
            lblPic.SetTextBoxText(string.Format("{0}{1}个相册{2}张图片下载完成", store.StoreName, albumCount, picturesCount));
            //Invoke(_showMessageBox, string.Format("{0}{1}个相册{2}张图片下载完成", store.StoreName, albumCount, picturesCount));
        }
        private void btnpic_Click(object sender, EventArgs e)
        {
            try
            {
                lblPic.SetTextBoxText(string.Empty);
                lboxPic.ClearText();
                var catalogueInfo = catalogueListBox.SelectedItem as Catalogue;
                if (catalogueInfo == null)
                {
                    return;
                }
                var storeInfo = _storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
                if (storeInfo == null)
                {
                    return;
                }
                var oldStoreInfo = textBox4.Tag as StoreInfoEntity;
                if (oldStoreInfo == null)
                {
                    storeInfo.OldStoreId = storeInfo.storeId;
                }
                else
                {
                    storeInfo.OldStoreId = oldStoreInfo.BizID;
                }
                storeInfo.ChangePic = true;
                var siteTypeStr = _selectedItem;
                var picAction = new Action<StoreInfo, string>(GetPicAction);
                picAction.BeginInvoke(storeInfo, siteTypeStr, null, null);
                chbPic.Checked = true;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                _storeInfoList = new List<StoreInfo>();
                if (btnNextPage.Tag == null)
                {
                    return;
                }
                var path = btnNextPage.Tag.ToString();
                var pageIndex = int.Parse(labPage.Text) + 1;
                textBox1.Text = path;
                var sitePath = new SitePath(path, pageIndex) { SelectedSite = _selectedItem };
                Action<SitePath> goPathDelegate = GoPath;
                goPathDelegate.BeginInvoke(sitePath, null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            try
            {
                _storeInfoList = new List<StoreInfo>();
                if (btnBeforePage.Tag == null)
                {
                    return;
                }
                var path = btnBeforePage.Tag.ToString();
                var pageIndex = int.Parse(labPage.Text) - 1;
                textBox1.Text = path;
                var sitePath = new SitePath(path, pageIndex) { SelectedSite = _selectedItem };
                Action<SitePath> goPathDelegate = GoPath;
                goPathDelegate.BeginInvoke(sitePath, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            var cityInfo = cbBoxCity.SelectedItem as City;
            if (cityInfo == null)
            {
                return;
            }
            var cityID = cityInfo.CityID;

            var storeListControl = new StoreListControl(textBox4, cityID);
            storeListControl.AfterChangeStoreEvent += ClearStoreEntityText;
            var pop = new Popup(storeListControl);
            pop.Show(textBox4, false);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var cookingStylesBll = new Maticsoft.BLL.CookingStyles();
            var cookingStylesList = cookingStylesBll.GetModelList(String.Empty).OrderBy(x => x.CookingStyleName).ToList();
            chbCookingStyles.DataSource = cookingStylesList;
            chbCookingStyles.DisplayMember = "CookingStyleName";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var searchText = textBox3.Text;
                if (cbbDistrict.SelectedIndex < 0)
                {
                    return;
                }
                var districtList = cbbDistrict.DataSource as List<Maticsoft.Model.District>;
                if (districtList == null)
                {
                    return;
                }
                var districtInfo = districtList[cbbDistrict.SelectedIndex];
                var cityLocalTagBll = new CityLocalTagBll();
                var resualtList = clbStoreTag.CheckedItems.Cast<CityLocalTagEntity>().ToList();
                foreach (var selectedIndex in clbStoreTag.CheckedIndices)
                {
                    clbStoreTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                var citylocalList =
                    cityLocalTagBll.GetModelList(string.Format("CityID = '{0}' and DistrictID ='{1}'", districtInfo.CityID,
                        districtInfo.DistrictID)).FindAll(x => x.TagName.Contains(searchText) && !string.IsNullOrEmpty(searchText) && !resualtList.Exists(y => x.LocalTagID == y.LocalTagID)).OrderBy(x => x.TagName).ToList();
                citylocalList.AddRange(resualtList);
                clbStoreTag.DataSource = citylocalList;
                clbStoreTag.DisplayMember = "TagName";

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var searchText = textBox2.Text;

            var cookingStylesBll = new Maticsoft.BLL.CookingStyles();
            //var cookingStylesList = cookingStylesBll.GetModelList(String.Empty).OrderBy(x => x.CookingStyleName).ToList();
            var ckeckItemList = chbCookingStyles.CheckedItems;
            var resualtList = ckeckItemList.Cast<CookingStyles>().ToList();
            var cookingStylesList = cookingStylesBll.GetModelList(String.Empty);
            if (cookingStylesList != null)
            {
                resualtList.AddRange(cookingStylesList.FindAll(x => (x.CookingStyleName.Contains(searchText) && !string.IsNullOrEmpty(searchText)) && !resualtList.Exists(y => x.CookingStyleID == y.CookingStyleID)));
            }
            chbCookingStyles.DataSource = resualtList;
            chbCookingStyles.DisplayMember = "CookingStyleName";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var districtList = cbbDistrict.DataSource as List<Maticsoft.Model.District>;
                if (districtList == null)
                {
                    return;
                }
                if (cbbDistrict.SelectedIndex < 0)
                {
                    return;
                }
                var districtInfo = districtList[cbbDistrict.SelectedIndex];
                var cityLocalTagBll = new CityLocalTagBll();
                foreach (var selectedIndex in clbStoreTag.CheckedIndices)
                {
                    clbStoreTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                clbStoreTag.DataSource =
                    cityLocalTagBll.GetModelList(string.Format("CityID = '{0}' and DistrictID ='{1}'", districtInfo.CityID,
                        districtInfo.DistrictID)).OrderBy(x => x.TagName).ToList();
                clbStoreTag.DisplayMember = "TagName";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var doubleName = txtDoubleName.Text;
            if (string.IsNullOrWhiteSpace(doubleName))
            {
                return;
            }
            txtDoubleName.Text =
                doubleName.Replace("(", string.Empty)
                    .Replace(")", string.Empty)
                    .Replace("（", string.Empty)
                    .Replace("）", string.Empty).Trim();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (catalogueListBox.SelectedIndex < 0)
            {
                return;
            }
            var catalogueInfo = catalogueListBox.SelectedItem as Catalogue;
            if (catalogueInfo == null)
            {
                return;
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var siteStoreInfo = _storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
            var oldStoreInfo = textBox4.Tag as StoreInfoEntity;
            var storeInfoEntity = GetStoreInfoEntity(catalogueInfo, oldStoreInfo, siteStoreInfo);
            var storeBll = new StoreInfoBll();
            var storeInfoBll = new Maticsoft.BLL.StoreInfo();
            var storePictureBll = new Maticsoft.BLL.StorePicture();
            var storePicture = new Maticsoft.Model.StorePicture();
            storePicture.PID = Guid.NewGuid().ToString();
            storePicture.PictureName = string.Format("{0}.jpg", storeInfoEntity.BizID);
            storePicture.PicType = "Shop";
            storePicture.PicturePath = siteStoreInfo.StorePictureHref;
            storePicture.StoreId = storeInfoEntity.BizID;
            if (storeBll.Exists(storeInfoEntity.BizID))
            {
                storeBll.Update(storeInfoEntity);
                storeInfoBll.Update(siteStoreInfo);
            }
            else
            {
                storeInfoEntity.ShortID = storeBll.GetMaxShortID();
                storeInfoBll.Add(siteStoreInfo);
                storeBll.Add(storeInfoEntity);
            }
            if (!string.IsNullOrEmpty(storePicture.PicturePath))
            {
                storePictureBll.Remove(string.Format("PicType = 'Shop' and StoreId = '{0}'", storeInfoEntity.BizID));
                storePictureBll.Add(storePicture);
            }
            var saveStoreEntity = new SaveStoreEntity();
            saveStoreEntity.CataloEventHandler += UpdateIncrement;
            saveStoreEntity.InitProgress();
            var specialTagList = chlBoxSpecialTag.CheckedItems.Cast<SpecialTag>().ToList();
            Action<StoreInfoEntity, List<SpecialTag>> storeSpecialTagDelegate = saveStoreEntity.SaveStoreSpecialTag;
            storeSpecialTagDelegate.BeginInvoke(storeInfoEntity, specialTagList, null, null);

            var cookingStylesList = chbCookingStyles.CheckedItems.Cast<CookingStyles>().ToList();
            Action<StoreInfoEntity, IEnumerable<CookingStyles>> cookingStylesDelegate = saveStoreEntity.SaveCookingStyles;
            cookingStylesDelegate.BeginInvoke(storeInfoEntity, cookingStylesList, null, null);

            var cityLocalTagEntityList = clbStoreTag.CheckedItems.Cast<CityLocalTagEntity>().ToList();
            Action<StoreInfoEntity, IEnumerable<CityLocalTagEntity>> cityLocalTagEntityDelegate = saveStoreEntity.SaveCityLocalTagEntity;
            cityLocalTagEntityDelegate.BeginInvoke(storeInfoEntity, cityLocalTagEntityList, null, null);

            if (chbDish.Checked)
            {
                Action<StoreInfoEntity, StoreInfo> dishesDelegate = saveStoreEntity.SaveDishes;
                dishesDelegate.BeginInvoke(storeInfoEntity, siteStoreInfo, null, null);
            }
            if (chbPic.Checked)
            {
                Action<StoreInfoEntity, StoreInfo> storePicturesDelegate = saveStoreEntity.SaveStorePictures;
                storePicturesDelegate.BeginInvoke(storeInfoEntity, siteStoreInfo, null, null);
            }

            saveStoreEntity.DoProgress();
            foreach (var selectedIndex in clbStoreTag.CheckedIndices)
            {
                clbStoreTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
            }
            saveStoreEntity.DoProgress();
            foreach (var selectedIndex in chlBoxSpecialTag.CheckedIndices)
            {
                chlBoxSpecialTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
            }
            saveStoreEntity.DoProgress();
            foreach (var selectedIndex in chbCookingStyles.CheckedIndices)
            {
                chbCookingStyles.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
            }
            saveStoreEntity.DoProgress();
            stopwatch.Stop();
            Invoke(_showMessageBox, string.Format(@"{0}保存成功,耗时{1}毫秒", storeInfoEntity.StoreName, stopwatch.ElapsedMilliseconds));
            catalogueListBox.SetItemCheckState(catalogueListBox.SelectedIndex, CheckState.Checked);
            if (catalogueListBox.SelectedIndex < catalogueListBox.Items.Count - 1)
            {
                catalogueListBox.SelectedIndex += 1;
            }
            SetCatalogueListBox();
        }






        private StoreInfoEntity GetStoreInfoEntity(Catalogue catalogueInfo, StoreInfoEntity oldStoreInfo, StoreInfo siteStoreInfo)
        {
            if (oldStoreInfo == null)
            {
                oldStoreInfo = new Maticsoft.Model.StoreInfoEntity();
                oldStoreInfo.BizID = catalogueInfo.StoreId;
            }
            if (siteStoreInfo == null)
            {
                return null;
            }
            oldStoreInfo.Box = chbbox.Checked;
            oldStoreInfo.StoreName = txtStoreNameSite.Text.Trim();
            oldStoreInfo.Bus = txtBusSite.Text.Trim();
            oldStoreInfo.BusinessAddTime = DateTime.Now;
            oldStoreInfo.BasicIntroduction = txtBasicSite.Text.Trim();
            oldStoreInfo.BusinessState = 40;
            oldStoreInfo.BusinessTypeID = "2";
            oldStoreInfo.CarPark = chbCarPark.Checked;
            oldStoreInfo.ChildrenChair = chbChildrenChair.Checked;
            oldStoreInfo.CityID = ((Maticsoft.Model.City)cbBoxCity.SelectedItem).CityID;
            oldStoreInfo.Cod = chbCod.Checked;
            oldStoreInfo.DistrictID = ((Maticsoft.Model.District)cbbDistrict.SelectedItem).DistrictID;
            oldStoreInfo.IsCitySend = chbIsCitySend.Checked;
            oldStoreInfo.IsCoupon = chbIsCoupon.Checked;
            oldStoreInfo.IsSend = chbIsSend.Checked ? 1 : 0;
            oldStoreInfo.KCVIP = chbKCVIP.Checked;
            oldStoreInfo.NoSmoke = chbNoSmoke.Checked;
            oldStoreInfo.OnlinePay = chbOnlinePay.Checked;
            oldStoreInfo.Onlineorder = chbOnlineorder.Checked ? 1 : 0;
            oldStoreInfo.PayCar = chbPayCar.Checked;
            oldStoreInfo.PayCar = chbPayCar.Checked;
            oldStoreInfo.StoreAddress = txtStoreAddressSite.Text.Trim();
            oldStoreInfo.StoreHours = txtStoreHoursSite.Text.Trim();
            oldStoreInfo.StoreName = txtStoreNameSite.Text.Trim();
            oldStoreInfo.StorePhone = txtStorePhoneSite.Text.Trim();
            oldStoreInfo.WIFI = chbWIFI.Checked;
            decimal maxPrice = 0;
            if (decimal.TryParse(txtMaxPriceSite.Text, out maxPrice))
            {
                oldStoreInfo.MaxPrice = maxPrice;
            }
            decimal minPrice = 0;
            if (decimal.TryParse(txtMinPriceSite.Text, out minPrice))
            {
                oldStoreInfo.MinPrice = minPrice;
            }
            oldStoreInfo.BranchName = txtDoubleName.Text.Trim();
            oldStoreInfo.StorePhoto = string.Format("{0}.jpg", oldStoreInfo.BizID);
            return oldStoreInfo;
        }

        private void cbBoxProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var provincesList = cbBoxProvinces.DataSource as List<Maticsoft.Model.Provinces>;
                if (provincesList == null)
                {
                    return;
                }
                var provincesInfo = provincesList[cbBoxProvinces.SelectedIndex];

                var cityBll = new Maticsoft.BLL.City();
                var cityList = cityBll.GetModelList(string.Empty);
                cbBoxCity.DataSource = cityList.FindAll(x => x.ProvincesID == provincesInfo.ProvincesID);
                cbBoxCity.ValueMember = "CityName";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cityList = cbBoxCity.DataSource as List<Maticsoft.Model.City>;
                if (cityList == null)
                {
                    return;
                }
                var cityInfo = cityList[cbBoxCity.SelectedIndex];

                var districtBll = new Maticsoft.BLL.District();
                var districtList = districtBll.GetModelList(String.Empty);
                cbbDistrict.DataSource = districtList.FindAll(x => x.CityID == cityInfo.CityID);

                cbbDistrict.DisplayMember = "DistrictName";
                cbbDistrict.ValueMember = "DistrictID";


                var cookingStylesBll = new Maticsoft.BLL.CookingStyles();
                chbCookingStyles.DataSource =
                    cookingStylesBll.GetModelList(string.Empty)
                        .OrderBy(x => x.CookingStyleName)
                        .ToList();
                chbCookingStyles.DisplayMember = "CookingStyleName";


                var cityLocalTagBll = new Maticsoft.BLL.CityLocalTagBll();
                clbStoreTag.DataSource =
                    cityLocalTagBll.GetModelList(string.Format("CityID = '{0}'", cityInfo.CityID))
                        .OrderBy(x => x.TagName)
                        .ToList();
                clbStoreTag.DisplayMember = "TagName";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var districtList = cbbDistrict.DataSource as List<Maticsoft.Model.District>;
                if (districtList == null)
                {
                    return;
                }
                var districtInfo = districtList[cbbDistrict.SelectedIndex];
                var cityLocalTagBll = new Maticsoft.BLL.CityLocalTagBll();
                foreach (var selectedIndex in clbStoreTag.CheckedIndices)
                {
                    clbStoreTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                clbStoreTag.DataSource =
                    cityLocalTagBll.GetModelList(string.Format("CityID = '{0}' and DistrictID ='{1}'", districtInfo.CityID,
                        districtInfo.DistrictID)).OrderBy(x => x.TagName).ToList();
                clbStoreTag.DisplayMember = "TagName";

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (var selectedIndex in clbStoreTag.CheckedIndices)
                {
                    clbStoreTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                foreach (var selectedIndex in chlBoxSpecialTag.CheckedIndices)
                {
                    chlBoxSpecialTag.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                foreach (var selectedIndex in chbCookingStyles.CheckedIndices)
                {
                    chbCookingStyles.SetItemCheckState((int)selectedIndex, CheckState.Unchecked);
                }
                txtStoreAddress.Text = string.Empty;
                txtStoreHours.Text = string.Empty;
                txtBasic.Text = string.Empty;
                txtFacilities.Text = string.Empty;
                txtStoreName.Text = string.Empty;
                txtStorePhone.Text = string.Empty;
                chbbox.UpdateCheckedState(false);
                txtBus.Text = string.Empty;
                chbPayCar.UpdateCheckedState(false);
                txtStoreTag.Text = string.Empty;
                txtMaxPrice.Text = string.Empty;
                txtMinPrice.Text = string.Empty;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        readonly Action<string> _showMessageBox = messageText => MessageBox.Show(messageText);

        public void UpdateIncrement(object sender, CatalogueEventArgs catalogueEventArgs)
        {
            if (catalogueEventArgs.MaxPorgress > 0)
            {
                progressBar1.SetMaximum(catalogueEventArgs.MaxPorgress);
                progressBar1.SetValue(0);
            }
            else
            {
                progressBar1.UpdateIncrement(catalogueEventArgs.ProgressNum);
            }
        }

        private void ComparatorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShowMessage_Click(object sender, EventArgs e)
        {
            if (catalogueListBox.SelectedIndex < 0)
            {
                return;
            }
            var catalogueInfo = catalogueListBox.SelectedItem as Catalogue;
            if (catalogueInfo == null)
            {
                return;
            }
            var siteStoreInfo = _storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
            if (siteStoreInfo == null)
            {
                return;
            }
            chbShowDishType.DataSource = siteStoreInfo.DishTypeList;
            chbShowDishType.DisplayMember = "DishesTypeName";
            chbShowPicBox.DataSource = siteStoreInfo.BusPhotoAlbumTableList;
            chbShowPicBox.DisplayMember = "AlbumName";
        }

        private void btnShowDish_Click(object sender, EventArgs e)
        {
            var dishesTyep = chbShowDishType.SelectedItem as DishesTyep;
            if (dishesTyep == null)
            {
                return;
            }

            var showDishListControl = new ShowDishListControl(dishesTyep.DishesList);
            var pop = new Popup(showDishListControl);
            pop.Show(btnShowDish, false);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var busPhotoAlbum = chbShowPicBox.SelectedItem as BusPhotoAlbum;
            if (busPhotoAlbum == null)
            {
                return;
            }

            var showDishListControl = new ShowDishListControl(busPhotoAlbum.StorePicturesList);
            var pop = new Popup(showDishListControl);
            pop.Show(btnShowDish, false);
        }
    }
}
