namespace CollectionForm
{
    partial class DownPic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cbBoxProvinces = new System.Windows.Forms.ComboBox();
            this.cbBoxCity = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtStoreID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbBoxProvinces
            // 
            this.cbBoxProvinces.Font = new System.Drawing.Font("宋体", 11F);
            this.cbBoxProvinces.FormattingEnabled = true;
            this.cbBoxProvinces.Location = new System.Drawing.Point(38, 30);
            this.cbBoxProvinces.Name = "cbBoxProvinces";
            this.cbBoxProvinces.Size = new System.Drawing.Size(171, 23);
            this.cbBoxProvinces.TabIndex = 24;
            this.cbBoxProvinces.SelectedIndexChanged += new System.EventHandler(this.cbBoxProvinces_SelectedIndexChanged);
            // 
            // cbBoxCity
            // 
            this.cbBoxCity.Font = new System.Drawing.Font("宋体", 11F);
            this.cbBoxCity.FormattingEnabled = true;
            this.cbBoxCity.Location = new System.Drawing.Point(228, 30);
            this.cbBoxCity.Name = "cbBoxCity";
            this.cbBoxCity.Size = new System.Drawing.Size(171, 23);
            this.cbBoxCity.TabIndex = 25;
            this.cbBoxCity.SelectedIndexChanged += new System.EventHandler(this.cbBoxCity_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(773, 580);
            this.listBox1.TabIndex = 27;
            // 
            // txtStoreID
            // 
            this.txtStoreID.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStoreID.Location = new System.Drawing.Point(417, 29);
            this.txtStoreID.Name = "txtStoreID";
            this.txtStoreID.Size = new System.Drawing.Size(193, 24);
            this.txtStoreID.TabIndex = 28;
            // 
            // DownPic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 672);
            this.Controls.Add(this.txtStoreID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbBoxProvinces);
            this.Controls.Add(this.cbBoxCity);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DownPic";
            this.Text = "DownPic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbBoxProvinces;
        private System.Windows.Forms.ComboBox cbBoxCity;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtStoreID;
    }
}