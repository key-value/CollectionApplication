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
        public bool IsDish;
        public ShowDishListControl()
        {
            InitializeComponent();
        }
        public ShowDishListControl(List<DishesEntity> dishesList)
        {
            InitializeComponent();
            IsDish = true;
            if (dishesList != null)
            {
                dataGridView1.DataSource = dishesList;
            }
        }
        public ShowDishListControl(List<Maticsoft.Model.StorePicture> tlist)
        {
            InitializeComponent();
            IsDish = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsDish)
                {
                    var dishesList = dataGridView1.DataSource as List<Maticsoft.Model.DishesEntity>;
                    if (dishesList == null)
                    {
                        return;
                    }
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            var drv = selectedRow.DataBoundItem as Maticsoft.Model.DishesEntity;
                            dishesList.Remove(drv);
                        }

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dishesList;
                    }
                }
                else
                {
                    var dishesList = dataGridView1.DataSource as List<Maticsoft.Model.StorePicture>;
                    if (dishesList == null)
                    {
                        return;
                    }
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                        {
                            var drv = selectedRow.DataBoundItem as Maticsoft.Model.StorePicture;
                            dishesList.Remove(drv);
                        }

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dishesList;
                    }
                }
                this.dataGridView1.Invalidate();
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
