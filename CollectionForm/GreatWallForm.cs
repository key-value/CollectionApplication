using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using FanQieKuaiDianSite;
using Maticsoft.BLL;
using Maticsoft.Model;
using SiteLogic;
using Catalogue = Maticsoft.Model.Catalogue;
using CookingStyles = Maticsoft.Model.CookingStyles;
using SpecialTag = Maticsoft.Model.SpecialTag;
using StoreInfo = Maticsoft.Model.StoreInfo;
using StorePictures = Maticsoft.BLL.StorePictures;
using StorePicturesTable = Maticsoft.BLL.StorePicturesTable;

namespace CollectionForm
{
    public partial class GreatWallForm : Form
    {

        private delegate void GoPathDelegate(string path, int pageIndex, List<Maticsoft.Model.Catalogue> catalogueList);

        private List<Maticsoft.Model.StoreInfo> storeInfoList = new List<Maticsoft.Model.StoreInfo>();

        public GreatWallForm()
        {
            InitializeComponent();

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

        private void webBtn_Click(object sender, EventArgs e)
        {
            catalogueListBox.DataBindings.Clear();
            this.catalogueListBox.ValueMember = "title";
            storeInfoList = new List<StoreInfo>();
            try
            {
                var path = @"http://www.fanqie.com/restaurant/location";
                var pageIndex = 1;

                Action<string, int> goPathDelegate = GoPath;
                goPathDelegate.Invoke(path, pageIndex);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoPath(string path, int pageIndex)
        {
            var catalogueLogic = new CatalogueLogic();
            catalogueLogic.SetPath(path);
            catalogueLogic.PageNum = pageIndex;
            var localTagID = ((CityLocalTagEntity)clbStoreTag.SelectedItem).LocalTagID;
            var cityLocalTagBll = new Maticsoft.BLL.CityLocalTag();
            var cityLocalTag = cityLocalTagBll.GetModel(localTagID);
            if (cityLocalTag != null)
            {
                catalogueLogic.CircleId = int.Parse(cityLocalTag.Circleid);
            }
            var catalogueList = catalogueLogic.GetStoreInfo(pageIndex);

            #region

            GoPathDelegate goPathDelegate = (s, index, cList) =>
            {
                catalogueListBox.Items.Clear();
                if (catalogueList != null)
                {
                    catalogueListBox.Items.AddRange(catalogueList.ToArray());
                }
                for (int i = 0; i < catalogueListBox.Items.Count; i++)
                {
                    catalogueListBox.SetItemChecked(i,
                        ((Maticsoft.Model.Catalogue)catalogueListBox.Items[i]).IsRead);
                }

                labPage.Text = catalogueLogic.PageNum.ToString(CultureInfo.InvariantCulture);
                btnNextPage.Enabled = catalogueLogic.IflastPage == 0;
            };

            #endregion

            this.Invoke(goPathDelegate, path, pageIndex, catalogueList);
        }

        private void catalogueListBox_MouseClick(object sender, MouseEventArgs e)
        {
            SetCatalogueListBox();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (catalogueListBox.SelectedIndex < 0)
                {
                    return;
                }
                var catalogueInfo = catalogueListBox.SelectedItem as Maticsoft.Model.Catalogue;
                if (catalogueInfo == null)
                {
                    return;
                }
                var storeInfoEntity = new Maticsoft.Model.StoreInfoEntity();
                var storeBll = new StoreInfoBll();
                storeInfoEntity.BizID = catalogueInfo.StoreId;
                storeInfoEntity.BasicIntroduction = txtBasic.Text.Trim();
                storeInfoEntity.StoreAddress = txtStoreAddress.Text.Trim();
                storeInfoEntity.StoreHours = txtStoreHours.Text.Trim();
                storeInfoEntity.StoreName = txtStoreName.Text.Trim();
                storeInfoEntity.Box = chbbox.Checked;
                storeInfoEntity.Bus = txtBus.Text.Trim();
                storeInfoEntity.CarPark = !string.IsNullOrEmpty(txtCarPark.Text.Trim());
                storeInfoEntity.PayCar = chbPayCar.Checked;
                storeInfoEntity.WIFI = chbWIFI.Checked;
                storeInfoEntity.KCVIP = chbKCVIP.Checked;
                storeInfoEntity.ChildrenChair = chbChildrenChair.Checked;
                storeInfoEntity.PayCar = chbPayCar.Checked;
                storeInfoEntity.NoSmoke = chbNoSmoke.Checked;
                storeInfoEntity.IsCoupon = chbIsCoupon.Checked;
                storeInfoEntity.IsCitySend = chbIsCitySend.Checked;
                storeInfoEntity.OnlinePay = chbOnlinePay.Checked;
                storeInfoEntity.IsSend = chbIsSend.Checked ? 1 : 0;
                storeInfoEntity.Cod = chbCod.Checked;
                storeInfoEntity.Onlineorder = chbOnlineorder.Checked ? 1 : 0;
                var maxPrice = 0;
                if (int.TryParse(txtMaxPrice.Text, out maxPrice))
                {
                    storeInfoEntity.MaxPrice = maxPrice;
                }
                var minPrice = 0;
                if (int.TryParse(txtMinPrice.Text, out minPrice))
                {
                    storeInfoEntity.MinPrice = minPrice;
                }
                storeInfoEntity.CityID = ((Maticsoft.Model.City)cbBoxCity.SelectedItem).CityID;
                storeInfoEntity.BusinessTypeID = "2";
                if (!string.IsNullOrEmpty(txtDoubleName.Text))
                {
                    storeInfoEntity.BranchName = txtDoubleName.Text.Trim();
                }
                storeInfoEntity.StorePhone = txtStorePhone.Text.Trim();
                storeInfoEntity.BusinessState = 40;
                storeInfoEntity.BusinessAddTime = DateTime.Now;
                if (!string.IsNullOrEmpty(txtImageName.Text.Trim()))
                {
                    storeInfoEntity.StorePhoto = txtImageName.Text;
                }
                storeInfoEntity.DistrictID = ((Maticsoft.Model.District)cbbDistrict.SelectedItem).DistrictID;
                var isExists = false;
                isExists = storeBll.Exists(storeInfoEntity.BizID);

                var storeSpecialBll = new Maticsoft.BLL.StoreSpecialTag();
                if (isExists)
                {
                    storeBll.Update(storeInfoEntity);
                }
                else
                {
                    var storeList = storeBll.GetModelList(string.Empty);
                    var maxShortID = storeList.Max(x =>
                    {
                        var shortId = string.IsNullOrEmpty(x.ShortID) ? "0" : x.ShortID;
                        return int.Parse(shortId);
                    });
                    storeInfoEntity.ShortID = (maxShortID + 1).ToString();
                    storeBll.Add(storeInfoEntity);
                }
                foreach (var checkedItem in chlBoxSpecialTag.CheckedItems)
                {
                    var specialTag = checkedItem as SpecialTag;
                    if (specialTag != null)
                    {
                        var storeSpecial = new Maticsoft.Model.StoreSpecialTag();
                        storeSpecial.BizID = storeInfoEntity.BizID;
                        storeSpecial.SpecialTagID = specialTag.SpecialTagID;
                        storeSpecial.TagName = specialTag.TagName;
                        storeSpecial.StoreSpecialTagID = Guid.NewGuid().ToString();
                        storeSpecialBll.Add(storeSpecial);
                    }
                }
                var storeCookingStylesBll = new Maticsoft.BLL.StoreCookingStyles();
                foreach (var checkedItem in chbCookingStyles.CheckedItems)
                {
                    var specialTag = checkedItem as Maticsoft.Model.CookingStyles;
                    if (specialTag != null)
                    {
                        var storeCookingStyles = new Maticsoft.Model.StoreCookingStyles();
                        storeCookingStyles.BizID = storeInfoEntity.BizID;
                        storeCookingStyles.CookingStyleID = specialTag.CookingStyleID;
                        storeCookingStyles.CookingStyleName = specialTag.CookingStyleName;
                        storeCookingStyles.KeyID = Guid.NewGuid().ToString();
                        storeCookingStylesBll.Add(storeCookingStyles);
                    }
                }
                var dishesBll = new Maticsoft.BLL.Dishes();
                if (chbDish.Checked)
                {
                    var dishList = dishesBll.GetModelList(string.Format("storeId = '{0}'", storeInfoEntity.BizID));
                    var dishesEntityBll = new Maticsoft.BLL.DishesBll();
                    var dishesEntityList = dishesEntityBll.GetModelList(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
                    foreach (var dishesEntity in dishesEntityList)
                    {
                        dishesEntityBll.Delete(dishesEntity.DishesID);
                    }
                    foreach (var dishese in dishList)
                    {
                        var dishesEntity = new DishesEntity();
                        dishesEntity.BusinessID = dishese.StoreId;
                        dishesEntity.DishesName = dishese.DishesName;
                        dishesEntity.CreateDate = DateTime.Now;
                        dishesEntity.DishesID = dishese.DishesID;
                        dishesEntity.ImageUrl = dishese.PictureName;
                        dishesEntity.State = 1;
                        dishesEntity.DishesTypeID = dishese.dishTypeID;
                        dishesEntity.DishesUnit = string.IsNullOrEmpty(dishese.DishesUnit) ? "份" : dishese.DishesUnit;
                        dishesEntity.DishesMoney = decimal.Parse(dishese.DishesMoney.Replace("￥", string.Empty));
                        dishesEntity.DishesBrief = dishese.DishesBrief;
                        dishesEntityBll.Add(dishesEntity);
                    }
                    var dishesTyepTableBll = new Maticsoft.BLL.DishesTyepTable();
                    var dishTypeBll = new Maticsoft.BLL.DishesTyep();
                    var dishTypeList = dishTypeBll.GetModelList(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
                    foreach (var dishesTyep in dishTypeList)
                    {
                        dishTypeBll.Delete(dishesTyep.DishesTypeID);
                    }
                    var dishesTypeTableList = dishesTyepTableBll.GetModelList(string.Format("BusinessID = '{0}'", storeInfoEntity.BizID));
                    foreach (var disheseTypeTable in dishesTypeTableList)
                    {
                        var dishesTyep = new Maticsoft.Model.DishesTyep();
                        dishesTyep.BusinessID = disheseTypeTable.BusinessID;
                        dishesTyep.CreateDate = DateTime.Now;
                        dishesTyep.DishesTypeName = disheseTypeTable.DishesTypeName;
                        dishesTyep.DishesTypeID = disheseTypeTable.DishesTypeID;
                        dishTypeBll.Add(dishesTyep);
                    }
                }
                var storeLocalTagBll = new Maticsoft.BLL.StoreLocalTag();
                foreach (var selectedItem in clbStoreTag.SelectedItems)
                {
                    var cityLocalTag = ((Maticsoft.Model.CityLocalTagEntity)selectedItem);
                    var storeLocalTag = new Maticsoft.Model.StoreLocalTag();
                    storeLocalTag.BizID = storeInfoEntity.BizID;
                    storeLocalTag.BizType = 10;
                    storeLocalTag.DistrictID = storeInfoEntity.DistrictID;
                    storeLocalTag.KeyID = Guid.NewGuid().ToString();
                    storeLocalTag.LocalTagID = cityLocalTag.LocalTagID;
                    storeLocalTag.LocalTagName = cityLocalTag.TagName;
                    storeLocalTagBll.Add(storeLocalTag);
                }

                var storeInfoBll = new Maticsoft.BLL.StoreInfo();
                var storeInfo = storeInfoList.Find(x => x.storeId == storeInfoEntity.BizID);
                if (storeInfo != null)
                {
                    if (isExists)
                    {
                        storeInfoBll.Update(storeInfo);
                    }
                    else
                    {
                        storeInfoBll.Add(storeInfo);
                    }
                }

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
                MessageBox.Show(string.Format(@"{0}保存成功", storeInfoEntity.StoreName));

                catalogueListBox.SetItemCheckState(catalogueListBox.SelectedIndex, CheckState.Checked);
                if (catalogueListBox.SelectedIndex < catalogueListBox.Items.Count - 1)
                {
                    catalogueListBox.SelectedIndex += 1;
                }
                SetCatalogueListBox();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbBoxProvinces_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cbBoxCity_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            storeInfoList = new List<StoreInfo>();
            var path = btnNextPage.Tag.ToString();
            var pageIndex = int.Parse(labPage.Text) + 1;
            GoPath(path, pageIndex);
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            storeInfoList = new List<StoreInfo>();
            var path = btnBeforePage.Tag.ToString();
            var pageIndex = int.Parse(labPage.Text) - 1;
            GoPath(path, pageIndex);
        }

        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            var districtList = cbbDistrict.DataSource as List<Maticsoft.Model.District>;
            if (districtList == null)
            {
                return;
            }
            var districtInfo = districtList[cbbDistrict.SelectedIndex];

            var cityLocalTagBll = new Maticsoft.BLL.CityLocalTagBll();
            clbStoreTag.DataSource =
                cityLocalTagBll.GetModelList(string.Format("CityID = '{0}' and DistrictID ='{1}'", districtInfo.CityID,
                    districtInfo.DistrictID)).OrderBy(x => x.TagName).ToList();
            clbStoreTag.DisplayMember = "TagName";
        }


        private void button2_Click(object sender, EventArgs e)
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
            chbbox.Checked = false;
            txtBus.Text = string.Empty;
            txtCarPark.Text = string.Empty;
            txtSubway.Text = string.Empty;
            chbPayCar.Checked = false;
            txtStoreTag.Text = string.Empty;
            txtMaxPrice.Text = string.Empty;
            txtMinPrice.Text = string.Empty;
            lblDishNum.Text = string.Empty;
        }

        private void SetCatalogueListBox()
        {
            //file = new OpenFileDialog();
            Action<StoreInfo> changceText = (Maticsoft.Model.StoreInfo storeInfo) =>
            {
                txtStoreAddress.Text = storeInfo.StoreAddress;
                txtStoreHours.Text = storeInfo.StoreHours;
                txtBasic.Text = storeInfo.BasicIntroduction;
                txtFacilities.Text = storeInfo.Facilities;
                txtStoreName.Text = storeInfo.StoreName;
                txtStorePhone.Text = storeInfo.StorePhone;
                chbbox.Checked = storeInfo.box;
                txtBus.Text = storeInfo.bus;
                txtCarPark.Text = storeInfo.carPark;
                txtSubway.Text = storeInfo.subway;
                chbPayCar.Checked = storeInfo.payCar;
                txtStoreTag.Text = storeInfo.StoreTag;
                txtMaxPrice.Text = storeInfo.MaxPrice.ToString();
                txtMinPrice.Text = storeInfo.MinPrice.ToString();
                txtImageName.Text = storeInfo.picName;
                txtDoubleName.Text = string.Empty;
                lblDishNum.Text = string.Format("共{0}道菜", storeInfo.DishesNum);
                chbDish.Checked = false;

            };
            if (catalogueListBox.SelectedIndex < 0)
            {
                return;
            }

            var catalogueInfo = catalogueListBox.SelectedItem as Maticsoft.Model.Catalogue;
            if (catalogueInfo == null)
            {
                return;
            }
            var taskGetcatalogueList = new Action<Catalogue>((x) =>
            {
                var storeLogic = new StoreLogic();
                var storeInfo = storeLogic.GetStoreInfo(x);
                if (storeInfo == null)
                {
                    return;
                }
                storeInfoList.Add(storeInfo);
                this.Invoke(changceText, storeInfo);
            });

            this.Invoke(taskGetcatalogueList, catalogueInfo);
        }

        private void btnDish_Click(object sender, EventArgs e)
        {
            try
            {
                chbDish.Checked = true;
                var showEnd = new Action<string, int>((storeName, resualt) => MessageBox.Show(string.Format("{0}菜品{1}下载完成", storeName, resualt)));
                var catalogueInfo = catalogueListBox.SelectedItem as Maticsoft.Model.Catalogue;
                if (catalogueInfo == null)
                {
                    return;
                }
                var storeInfo = storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
                if (storeInfo == null)
                {
                    return;
                }
                storeInfo.ChangeDishes = true;
                var getFood = new Task(((store) =>
                {
                    var saveDishesEntity = new SaveDishesEntity();
                    var dishNum = saveDishesEntity.SaveDish((StoreInfo)store);
                    this.Invoke(showEnd, ((StoreInfo)store).StoreName, dishNum);
                }), storeInfo);
                getFood.Start();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void btnpic_Click(object sender, EventArgs e)
        {
            var showEnd = new Action<object>((object storeName) =>
            {
                MessageBox.Show(string.Format("{0}图片下载完成", storeName));
            });
            var catalogueInfo = catalogueListBox.SelectedItem as Maticsoft.Model.Catalogue;
            if (catalogueInfo == null)
            {
                return;
            }
            var storeInfo = storeInfoList.Find(x => x.storeId == catalogueInfo.StoreId);
            if (storeInfo == null)
            {
                return;

            }
            storeInfo.ChangePic = true;
            var getPic = new Task(new Action<object>((store) =>
            {
                var filepath = string.Format("{0}\\imagefiles\\Food\\PhotoAlbum\\{1}\\", Application.StartupPath,
                    ((StoreInfo)store).StoreName);
                if (Directory.Exists(filepath))
                {
                    string[] files = System.IO.Directory.GetFiles(filepath
                                       , "*.*", System.IO.SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        //删除文件
                        System.IO.File.Delete(file);
                    }
                }
                var collection = new Collection();
                collection.GetPicture((StoreInfo)store);
                this.Invoke(showEnd, ((StoreInfo)store).StoreName);
            }), storeInfo);

            getPic.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var searchText = textBox1.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            var cookingStylesBll = new Maticsoft.BLL.CookingStyles();
            var cookingStylesList = cookingStylesBll.GetModelList(String.Empty).OrderBy(x => x.CookingStyleName).ToList();
            chbCookingStyles.DataSource = cookingStylesList.FindAll(x => x.CookingStyleName.Contains(searchText));
            chbCookingStyles.DisplayMember = "CookingStyleName";

        }

        private void GreatWallForm_Load(object sender, EventArgs e)
        {

        }

        private void btnNextPage_Click_1(object sender, EventArgs e)
        {
            storeInfoList = new List<StoreInfo>();
            var path = @"http://www.fanqie.com/restaurant/location";
            var pageIndex = int.Parse(labPage.Text) + 1;
            GoPath(path, pageIndex);
        }

        private void btnBeforePage_Click_1(object sender, EventArgs e)
        {
            storeInfoList = new List<StoreInfo>();
            var path = @"http://www.fanqie.com/restaurant/location";
            var pageIndex = int.Parse(labPage.Text) - 1;
            GoPath(path, pageIndex);
        }


    }
}

