using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using FanQieKuaiDianSite;
using HtmlAgilityPack;
using Maticsoft.BLL;
using Maticsoft.Model;
using CityLocalTag = Maticsoft.BLL.CityLocalTag;
using District = Maticsoft.BLL.District;
using DistrictTable = Maticsoft.BLL.DistrictTable;

namespace CollectionForm
{
    public partial class DistrictForm : Form
    {
        public DistrictForm()
        {
            InitializeComponent();

            var provinces = new Maticsoft.BLL.Provinces();
            var provincesList = provinces.GetModelList(string.Empty);
            cbBoxProvinces.DataSource = provincesList;
            cbBoxProvinces.ValueMember = "ProvincesName";

            var cityBll = new Maticsoft.BLL.City();
            var cityList = cityBll.GetModelList(string.Empty);
            cbBoxCity.DataSource = cityList;
            cbBoxCity.DisplayMember = "CityName";
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

        private void button1_Click(object sender, EventArgs e)
        {
            var pageUrl = textBox1.Text;
            var cityID = ((Maticsoft.Model.City)cbBoxCity.SelectedItem).CityID;
            if (string.IsNullOrWhiteSpace(pageUrl))
            {
                return;
            }
            var htmlWeb = new HtmlWeb();
            var htmlDoc = htmlWeb.Load(pageUrl);
            var nodeDetail =
                htmlDoc.DocumentNode.SelectSingleNode(
                    ".//div[@class='constr']/div[@class='constr_in']/div[@class='constr_bg mt10']/div[@class='pt30 pl30 pr30 pb28 lh22']");
            if (nodeDetail == null)
            {
                return;
            }

            var nodeNext = nodeDetail.SelectSingleNode("/div[@class='region']").NextSibling;
            var nodeList = nodeNext.SelectNodes(@".//a[class='g3']");

            var districtBll = new District();
            var districtList = new List<Maticsoft.Model.District>();
            foreach (var nodeInfo in nodeList)
            {
                var district = new Maticsoft.Model.District();
                district.DistrictID = Guid.NewGuid().ToString();
                district.DistrictName = nodeInfo.InnerText;
                district.CityID = cityID;
                districtBll.Add(district);
                districtList.Add(district);
            }
            var node = nodeDetail.SelectSingleNode("./div[@class='group']");
            while (true)
            {
                nodeNext = node.NextSibling;
                if (!string.IsNullOrEmpty(nodeNext.Id))
                {
                    break;
                }
                var nodeDistrict = nodeNext.SelectSingleNode("./strong[@class='w100 l']").InnerText;
                var district = districtList.Find(x => x.DistrictName == nodeDistrict);
                nodeList = nodeNext.SelectNodes(@".//a[class='g3']");

                var cityLocalTagBll = new CityLocalTagBll();
                foreach (var nodeInfo in nodeList)
                {
                    var cityLocalTagEntity = new Maticsoft.Model.CityLocalTagEntity();
                    cityLocalTagEntity.LocalTagID = Guid.NewGuid().ToString();
                    cityLocalTagEntity.TagName = nodeInfo.InnerText;
                    cityLocalTagEntity.DistrictID = district.DistrictID;
                    cityLocalTagEntity.CityID = cityID;
                    cityLocalTagEntity.TagGrade = 20;
                    cityLocalTagBll.Add(cityLocalTagEntity);
                }
            }

            node = nodeDetail.SelectSingleNode("./div[@class='position']");
            while (true)
            {
                nodeNext = node.NextSibling;
                if (!string.IsNullOrEmpty(nodeNext.Id))
                {
                    break;
                }
                var nodeDistrict = nodeNext.SelectSingleNode("./strong[@class='w100 l']").InnerText;
                var district = districtList.Find(x => x.DistrictName == nodeDistrict);
                nodeList = nodeNext.SelectNodes(@".//a[class='g3']");

                var cityLocalTagBll = new CityLocalTagBll();
                foreach (var nodeInfo in nodeList)
                {
                    var cityLocalTagEntity = new Maticsoft.Model.CityLocalTagEntity
                    {
                        LocalTagID = Guid.NewGuid().ToString(),
                        TagName = nodeInfo.InnerText,
                        DistrictID = district.DistrictID,
                        CityID = cityID,
                        TagGrade = 10
                    };
                    cityLocalTagBll.Add(cityLocalTagEntity);
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //http://www.fanqie.com/restaurant/circle

            var pageUrl = @"http://www.fanqie.com/restaurant/circle";
            var cityID = ((Maticsoft.Model.City)cbBoxCity.SelectedItem).CityID;
            if (string.IsNullOrWhiteSpace(pageUrl))
            {
                return;
            }
            try
            {
                var dictionary = new Dictionary<string, string>();

                var headDictionary = new Dictionary<string, string>();
                headDictionary.Add("city", "1");
                var jsonStr = PostHttpResponse.PostData(pageUrl, dictionary, headDictionary);

                if (jsonStr == null)
                {
                    return;
                }
                var anonymous = JsonHelper.JsonToObj<Anonymous>(jsonStr);

                var districtBll = new District();
                var cityLocalTagBll = new CityLocalTagBll();
                var districtTableBll = new DistrictTable();
                var cityLocalTagSampleBll = new CityLocalTag();
                var districtList = new List<Maticsoft.Model.District>();
                var districtOldList = districtBll.GetModelList(string.Format("cityID = '{0}'", cityID)) ?? new List<Maticsoft.Model.District>();
                var cityLocalTagList = cityLocalTagBll.GetModelList(string.Format("CityID='{0}'", cityID)) ?? new List<CityLocalTagEntity>();
                var districtTableList = districtTableBll.GetModelList(string.Format("CityID='{0}'", cityID)) ?? new List<Maticsoft.Model.DistrictTable>();
                var cityLocalTagSampleList = cityLocalTagSampleBll.GetModelList(string.Format("CityID='{0}'", cityID)) ?? new List<Maticsoft.Model.CityLocalTag>();
                foreach (var areaInfo in anonymous.Arealist)
                {
                    var olddistrict = districtOldList.Find(x => x.DistrictName.Trim() == areaInfo.AreaName.Trim());
                    if (olddistrict == null)
                    {
                        olddistrict = new Maticsoft.Model.District
                        {
                            DistrictID = Guid.NewGuid().ToString(),
                            DistrictName = areaInfo.AreaName,
                            CityID = cityID
                        };
                        districtBll.Add(olddistrict);
                    }
                    var districtTable = districtTableList.Find(x => x.DistrictName.Trim() == areaInfo.AreaName.Trim());
                    if (districtTable == null)
                    {
                        districtTable = new Maticsoft.Model.DistrictTable();
                        districtTable.CityID = cityID;
                        districtTable.DistrictID = olddistrict.DistrictID;
                        districtTable.SiteID = areaInfo.AreaId;
                        districtTable.DistrictName = areaInfo.AreaName;
                        districtTableBll.Add(districtTable);
                    }
                    districtList.Add(olddistrict);

                    foreach (var circle in areaInfo.CircleList)
                    {
                        var cityLocalTag = cityLocalTagList.Find(x => x.TagName.Trim() == circle.CircleName.Trim());
                        if (cityLocalTag == null)
                        {
                            cityLocalTag = new CityLocalTagEntity
                            {
                                LocalTagID =  Guid.NewGuid().ToString(),
                                TagName = circle.CircleName,
                                DistrictID = olddistrict.DistrictID,
                                CityID = cityID,
                                TagGrade = 10
                            };
                            cityLocalTagBll.Add(cityLocalTag);
                        }
                        var cityLocalTagSample = cityLocalTagSampleList.Find(x => x.TagName.Trim() == circle.CircleName.Trim());
                        if (cityLocalTagSample == null)
                        {
                            cityLocalTagSample = new Maticsoft.Model.CityLocalTag();
                            cityLocalTagSample.Circleid = circle.Circleid;
                            cityLocalTagSample.TagName = circle.CircleName;
                            cityLocalTagSample.CityID = cityID;
                            cityLocalTagSample.LocalTagID = cityLocalTag.LocalTagID;
                            cityLocalTagSampleBll.Add(cityLocalTagSample);
                        }
                    }
                }
                MessageBox.Show("OK");
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
