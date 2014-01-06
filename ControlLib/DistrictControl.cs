using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLib
{
    public partial class DistrictControl : UserControl
    {
        public DistrictControl()
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
        }

        private void cbbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxCity_BindingContextChanged(object sender, EventArgs e)
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

        }
    }
}
