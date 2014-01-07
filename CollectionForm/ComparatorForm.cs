using System.Threading.Tasks;
using ApplicationUtility;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PopupTool;
using Catalogue = Maticsoft.Model.Catalogue;
using City = Maticsoft.Model.City;
using CookingStyles = Maticsoft.Model.CookingStyles;
using StoreInfo = Maticsoft.Model.StoreInfo;

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
            var regex = @"(http|ftp|https)?:\/\/[\w\-_]+(\.[\w\-_]+)(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
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
                    regex = string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*zonecode=(\d*)[\w\-\.,@?^=%&amp;:/~\+#]*[page=(\d*)]*[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "fantong":
                    _selectedItem = "FanTong";
                    regex =
                        string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "cyooy":
                    _selectedItem = "Cyooy";
                    regex =
                        string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]+=(\d*)-(\d*)-(\d*)-(\d*)-(\d*)-(\d*)-(\d*)", siteName);
                    break;
                case "yukuai":
                    _selectedItem = "YuKuai";
                    regex =
                       string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "scfood":
                    _selectedItem = "ScFood";
                    regex =
                       string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "duomifan":
                    _selectedItem = "DuoMiFan";
                    regex =
                        string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
                    break;
                case "dianping":
                    _selectedItem = "DianPing";
                    regex =
                       string.Format(@"(http|ftp|https)?:\/\/[\w\-_]+\.{0}[\w\-\.,@?^=%&amp;:/~\+#]*", siteName);
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
                var storeLogic = new CollectionLogic.StoreLogic(ySelectedItem) { PageUrl = x.href };
                var storeInfo = storeLogic.GetStoreInfo(x);
                if (storeInfo != null && !storeInfo.IsNull)
                {
                    _storeInfoList.Add(storeInfo);
                    BeginInvoke(new Action<StoreInfo>(ClearStoreText), storeInfo);
                }
                else
                {
                    Invoke(new Action(() => MessageBox.Show(@"网络异常")));
                }
            });

            taskGetcatalogueList.BeginInvoke(catalogueInfo, _selectedItem, null, null);
        }
        private void ClearStoreText(StoreInfo storeInfo)
        {
            txtStoreAddress.Text = storeInfo.StoreAddress;
            txtStoreHours.Text = string.IsNullOrWhiteSpace(storeInfo.StoreHours) ? "10:00-22:00" : storeInfo.StoreHours;
            txtBasic.Text = storeInfo.BasicIntroduction;
            txtFacilities.Text = storeInfo.Facilities;
            txtStoreName.Text = storeInfo.StoreName;
            txtStorePhone.Text = storeInfo.StorePhone;
            chbbox.Checked = storeInfo.box;
            txtBus.Text = storeInfo.bus;
            chbPayCar.Checked = storeInfo.payCar;
            txtStoreTag.Text = storeInfo.StoreTag;
            txtMaxPrice.Text = storeInfo.MaxPrice.ToString();
            txtMinPrice.Text = storeInfo.MinPrice.ToString();
            chbbox.Checked = false;
            chbPayCar.Checked = false;
            chbChildrenChair.Checked = false;
            chbCarPark.Checked = false;
            chbWIFI.Checked = false;
            chbNoSmoke.Checked = false;
            chbKCVIP.Checked = false;
            chbIsCoupon.Checked = false;
            chbIsSend.Checked = false;
            chbOnlineorder.Checked = false;
            chbIsCitySend.Checked = false;
            chbCod.Checked = false;
            chbOnlinePay.Checked = false;
        }
        private void ClearStoreEntityText(StoreInfoEntity storeInfoEntity)
        {
            txtStoreAddressSite.SetTextBoxText(storeInfoEntity.StoreAddress);
            txtStoreHoursSite.SetTextBoxText(string.IsNullOrWhiteSpace(storeInfoEntity.StoreHours) ? "10:00-22:00" : storeInfoEntity.StoreHours);
            txtBasicSite.SetTextBoxText(storeInfoEntity.BasicIntroduction);
            txtStoreNameSite.SetTextBoxText(storeInfoEntity.StoreName);
            txtStorePhoneSite.SetTextBoxText(storeInfoEntity.StorePhone);
            txtMaxPriceSite.SetTextBoxText(storeInfoEntity.MaxPrice.ToString());
            txtMinPriceSite.SetTextBoxText(storeInfoEntity.MinPrice.ToString());
            chbPayCar.UpdateCheckedState(storeInfoEntity.PayCar);
            chbbox.UpdateCheckedState(false);
            chbPayCar.UpdateCheckedState(false);
            chbChildrenChair.UpdateCheckedState(false);
            chbCarPark.UpdateCheckedState(false);
            chbWIFI.UpdateCheckedState(false);
            chbNoSmoke.UpdateCheckedState(false);
            chbKCVIP.UpdateCheckedState(false);
            chbIsCoupon.UpdateCheckedState(false);
            chbIsSend.UpdateCheckedState(false);
            chbOnlineorder.UpdateCheckedState(false);
            chbIsCitySend.UpdateCheckedState(false);
            chbCod.UpdateCheckedState(false);
            chbOnlinePay.UpdateCheckedState(false);
        }
        private void btnDish_Click(object sender, EventArgs e)
        {
            try
            {
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
                storeInfo.ChangeDishes = true;
                var siteTypeStr = _selectedItem;
                var foodAction = new Action<StoreInfo, string>(GetFoodAction);
                foodAction.Invoke(storeInfo, siteTypeStr);
                chbDish.Checked = true;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void GetFoodAction(StoreInfo store, string siteType)
        {
            var saveDishesEntity = new CollectionLogic.SaveDishesEntity(siteType);
            var dishTypeList = saveDishesEntity.UpdateDish(store);
            var dishTypeListCount = 0;
            if (dishTypeList != null)
            {
                store.DishTypeList = dishTypeList;
                dishTypeListCount = dishTypeList.Count;
            }
            Invoke(_showMessageBox, (string.Format("{0}菜品{1}道菜品下载完成", store.StoreName, dishTypeListCount)));
        }

        readonly Action<string> _showMessageBox = messageText => MessageBox.Show(messageText);
        private void GetPicAction(StoreInfo store, string siteType)
        {
            var pictureLogic = new CollectionLogic.PictureLogic(siteType);
            pictureLogic.GetPicture(store);
            Invoke(_showMessageBox, string.Format("{0}图片下载完成", store.StoreName));
        }
        private void btnpic_Click(object sender, EventArgs e)
        {
            try
            {
                chbPic.Checked = true;
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
                storeInfo.ChangePic = true;
                var siteTypeStr = _selectedItem;
                var picAction = new Action<StoreInfo, string>(GetPicAction);
                picAction.Invoke(storeInfo, siteTypeStr);
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
                    .Replace("）", string.Empty);
        }
    }
}
