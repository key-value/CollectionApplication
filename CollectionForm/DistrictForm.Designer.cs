namespace CollectionForm
{
    partial class DistrictForm
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
            this.cbBoxCity = new System.Windows.Forms.ComboBox();
            this.cbBoxProvinces = new System.Windows.Forms.ComboBox();
            this.btnDistrict = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbBoxCity
            // 
            this.cbBoxCity.FormattingEnabled = true;
            this.cbBoxCity.Location = new System.Drawing.Point(178, 59);
            this.cbBoxCity.Name = "cbBoxCity";
            this.cbBoxCity.Size = new System.Drawing.Size(121, 20);
            this.cbBoxCity.TabIndex = 21;
            // 
            // cbBoxProvinces
            // 
            this.cbBoxProvinces.FormattingEnabled = true;
            this.cbBoxProvinces.Location = new System.Drawing.Point(51, 59);
            this.cbBoxProvinces.Name = "cbBoxProvinces";
            this.cbBoxProvinces.Size = new System.Drawing.Size(121, 20);
            this.cbBoxProvinces.TabIndex = 20;
            this.cbBoxProvinces.SelectedIndexChanged += new System.EventHandler(this.cbBoxProvinces_SelectedIndexChanged);
            // 
            // btnDistrict
            // 
            this.btnDistrict.Location = new System.Drawing.Point(480, 42);
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.Size = new System.Drawing.Size(75, 23);
            this.btnDistrict.TabIndex = 23;
            this.btnDistrict.Text = "抓取";
            this.btnDistrict.UseVisualStyleBackColor = true;
            this.btnDistrict.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(534, 24);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "http://www.xiaomishu.com/shop/search-p50/";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 87);
            this.button1.TabIndex = 23;
            this.button1.Text = "抓取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 87);
            this.button2.TabIndex = 23;
            this.button2.Text = "抓取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(303, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 107);
            this.button3.TabIndex = 25;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DistrictForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 383);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDistrict);
            this.Controls.Add(this.cbBoxCity);
            this.Controls.Add(this.cbBoxProvinces);
            this.Name = "DistrictForm";
            this.Text = "DistrictForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBoxCity;
        private System.Windows.Forms.ComboBox cbBoxProvinces;
        private System.Windows.Forms.Button btnDistrict;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}