namespace ControlLib
{
    partial class DistrictControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbbDistrict = new System.Windows.Forms.ComboBox();
            this.cbBoxProvinces = new System.Windows.Forms.ComboBox();
            this.cbBoxCity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbbDistrict
            // 
            this.cbbDistrict.FormattingEnabled = true;
            this.cbbDistrict.Location = new System.Drawing.Point(264, 12);
            this.cbbDistrict.Name = "cbbDistrict";
            this.cbbDistrict.Size = new System.Drawing.Size(121, 20);
            this.cbbDistrict.TabIndex = 26;
            this.cbbDistrict.SelectedIndexChanged += new System.EventHandler(this.cbbDistrict_SelectedIndexChanged);
            // 
            // cbBoxProvinces
            // 
            this.cbBoxProvinces.FormattingEnabled = true;
            this.cbBoxProvinces.Location = new System.Drawing.Point(10, 11);
            this.cbBoxProvinces.Name = "cbBoxProvinces";
            this.cbBoxProvinces.Size = new System.Drawing.Size(121, 20);
            this.cbBoxProvinces.TabIndex = 24;
            this.cbBoxProvinces.SelectedIndexChanged += new System.EventHandler(this.cbBoxProvinces_SelectedIndexChanged);
            // 
            // cbBoxCity
            // 
            this.cbBoxCity.FormattingEnabled = true;
            this.cbBoxCity.Location = new System.Drawing.Point(137, 11);
            this.cbBoxCity.Name = "cbBoxCity";
            this.cbBoxCity.Size = new System.Drawing.Size(121, 20);
            this.cbBoxCity.TabIndex = 25;
            this.cbBoxCity.SelectedIndexChanged += new System.EventHandler(this.cbBoxCity_SelectedIndexChanged);
            this.cbBoxCity.BindingContextChanged += new System.EventHandler(this.cbBoxCity_BindingContextChanged);
            // 
            // DistrictControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbDistrict);
            this.Controls.Add(this.cbBoxProvinces);
            this.Controls.Add(this.cbBoxCity);
            this.Name = "DistrictControl";
            this.Size = new System.Drawing.Size(400, 44);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbDistrict;
        private System.Windows.Forms.ComboBox cbBoxProvinces;
        private System.Windows.Forms.ComboBox cbBoxCity;
    }
}
