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

namespace CollectionForm
{
    public partial class ShowDishListControl : UserControl
    {
        public ShowDishListControl()
        {
            InitializeComponent();
        }
        public ShowDishListControl(List<DishesEntity> dishesList)
        {
            InitializeComponent();
            if (dishesList != null)
            {
                dataGridView1.DataSource = dishesList;
            }
        }
        public ShowDishListControl(List<Maticsoft.Model.StorePicture> tlist)
        {
            InitializeComponent();
            if (tlist != null)
            {
                dataGridView1.DataSource = tlist;
            }
        }

        private void ShowDishListControl_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
