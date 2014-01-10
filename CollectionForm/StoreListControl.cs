using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Maticsoft.BLL;
using Maticsoft.Model;
using StoreInfo = Maticsoft.Model.StoreInfo;

namespace CollectionForm
{
    public partial class StoreListControl : UserControl
    {
        public event Action<StoreInfoEntity> AfterChangeStoreEvent;

        private List<StoreInfoEntity> _storeList = new List<StoreInfoEntity>();
        private TextBox _txtBox;
        public StoreListControl(TextBox txtBox, string cityID)
        {
            InitializeComponent();
            _txtBox = txtBox;
            _storeList = GetDataList(cityID);
            
        }
        /// <summary>
        /// 构造数据源
        /// </summary>
        /// <returns></returns>
        private List<StoreInfoEntity> GetDataList(string cityID)
        {
            var storeInfoBll = new StoreInfoBll();
            return storeInfoBll.GetModelList(string.Format("CityID = '{0}' and StoreName != ''", cityID)).OrderBy(x => x.StoreName).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeys.Text))
            {
                return;
            }

            var resultList = _storeList.FindAll(store => store.StoreName.Contains(txtKeys.Text) || txtKeys.Text.Contains(store.StoreName));
            dgvStore.DataSource = resultList;
        }

        private void dgvStore_Click(object sender, EventArgs e)
        {
            if (dgvStore.RowCount > 0 && dgvStore.SelectedRows.Count > 0 && dgvStore.CurrentRow != null)
            {
                DataGridViewCell bizIDCell = dgvStore.CurrentRow.Cells["BizID"];

                string bizID = bizIDCell != null && bizIDCell.Value != null ? bizIDCell.Value.ToString() : "";
                if (string.IsNullOrWhiteSpace(bizID))
                {
                    return;
                }
                var storeInfo = _storeList.Find(x => x.BizID == bizID);
                if (storeInfo == null)
                {
                    return;
                }
                _txtBox.Text = storeInfo.StoreName;
                _txtBox.Tag = storeInfo;
                if (AfterChangeStoreEvent != null)
                {
                    AfterChangeStoreEvent(storeInfo);
                }
            }
        }

        private void StoreListControl_Load(object sender, EventArgs e)
        {
            dgvStore.DataSource = _storeList;
        }
    }
}
