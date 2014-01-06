using System.Drawing;
using System.Threading.Tasks;
using Maticsoft.BLL;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using StorePicture = Maticsoft.BLL.StorePicture;

namespace CollectionForm
{
    public partial class DownPic : Form
    {
        private const string PicturePath = @"./imagefiles/{0}/"; //大图添加水印保存路径
        private const string PictureThumbnail = @"./imagefiles/Thumbnail/{0}/";
        public DownPic()
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var actionStoreInfoEntity = new Action<StoreInfoEntity>(store => listBox1.Items.Add(string.Format("{0}{1}", store.BizID, store.StoreName)));
            var storeCount = 0;
            try
            {
                CreatePath();
                var cityInfo = cbBoxCity.SelectedItem as Maticsoft.Model.City;
                if (cityInfo == null)
                {
                    return;
                }
                var storeInfoBll = new StoreInfoBll();
                var storeID = txtStoreID.Text;
                var whereStringBuilder = new StringBuilder();
                whereStringBuilder.Append(string.Format("CityID = '{0}'", cityInfo.CityID));
                if (!string.IsNullOrWhiteSpace(storeID))
                {
                    whereStringBuilder.Append(string.Format("and BizID = '{0}'", storeID));
                }
                var storeList = storeInfoBll.GetModelList(whereStringBuilder.ToString()) ?? new List<StoreInfoEntity>();
                storeCount = storeList.Count;
                var storePicture = new StorePicture();
                Action<List<StoreInfoEntity>> action = sList =>
                {
                    foreach (var storeInfoEntity in sList)
                    {
                        var storePictureList =
                            storePicture.GetModelList(string.Format("StoreId = '{0}'", storeInfoEntity.BizID)) ??
                            new List<Maticsoft.Model.StorePicture>();
                        //Parallel.ForEach(storePictureList, pictureInfo =>
                        if (string.IsNullOrEmpty(storeInfoEntity.ShortID))
                        {
                            storeInfoEntity.ShortID = storeInfoBll.GetMaxShortID();
                            storeInfoBll.Update(storeInfoEntity);
                        }
                        foreach (var pictureInfo in storePictureList)
                        {
                            if (pictureInfo.PicType == "Shop" && storeInfoEntity.StorePhoto != pictureInfo.PictureName)
                            {
                                storeInfoEntity.StorePhoto = pictureInfo.PictureName;
                                storeInfoBll.Update(storeInfoEntity);
                            }
                            var picPath = string.Format(PicturePath, pictureInfo.PicType);
                            var picThumbnail = string.Format(PictureThumbnail, pictureInfo.PicType);
                            try
                            {
                                db.DownFile(pictureInfo.PicturePath.Replace(@"/300_200/", "/").Replace("/320_0/", "/"),
                                    picPath + pictureInfo.PictureName);
                            }
                            catch (Exception exception)
                            {
                                try
                                {
                                    db.DownFile(
                                        pictureInfo.PicturePath.Replace(@"/300_200/", "/").Replace("/320_0/", "/"),
                                        picPath + pictureInfo.PictureName);
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            db.ZoomAuto(picPath + pictureInfo.PictureName, picThumbnail + pictureInfo.PictureName, 320,
                                240);
                            //生成缩略图
                            db.ZoomAuto(picPath + pictureInfo.PictureName,
                                picThumbnail + "640_480_" + pictureInfo.PictureName,
                                640, 480); //生成缩略图
                            db.ZoomAuto(picPath + pictureInfo.PictureName,
                                picThumbnail + "320_240_" + pictureInfo.PictureName,
                                320, 240); //生成缩略图
                            db.ZoomAuto(picPath + pictureInfo.PictureName,
                                picThumbnail + "160_120_" + pictureInfo.PictureName,
                                160, 120); //生成缩略图
                            //});
                        }
                        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                        qrCodeEncoder.QRCodeScale = 4;
                        qrCodeEncoder.QRCodeVersion = 8;
                        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                        Bitmap image;
                        String data = "http://www.51k7.com/wap/shop.aspx?sid=" + storeInfoEntity.ShortID;
                        image = qrCodeEncoder.Encode(data);
                        image.Save(@"./imagefiles/QrCode/" + storeInfoEntity.ShortID + ".png");
                        StoreInfoEntity entity = storeInfoEntity;
                        this.Invoke(actionStoreInfoEntity, entity);
                    }
                };
                Task task = new Task(() => action(storeList));
                task.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(string.Format("完成下载{0}家商家", storeCount));
        }

        private static void CreatePath()
        {
            var pictureTypeList = new List<string> { "Food", "PhotoAlbum", "Shop" };
            foreach (var pictureType in pictureTypeList)
            {
                var picPath = string.Format(PicturePath, pictureType);
                if (!Directory.Exists(picPath))
                {
                    Directory.CreateDirectory(picPath);
                }
                var picThumbnail = string.Format(PictureThumbnail, pictureType);
                if (!Directory.Exists(picThumbnail))
                {
                    Directory.CreateDirectory(picThumbnail);
                }
            }
            if (!Directory.Exists("./imagefiles/QrCode/"))
            {
                Directory.CreateDirectory("./imagefiles/QrCode/");
            }
        }
    }
}
