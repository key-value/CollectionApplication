namespace CollectionForm
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.htmllBox = new System.Windows.Forms.ListBox();
            this.ContentHtml = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.DishesTyep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // htmllBox
            // 
            this.htmllBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmllBox.ColumnWidth = 100;
            this.htmllBox.FormattingEnabled = true;
            this.htmllBox.ItemHeight = 12;
            this.htmllBox.Location = new System.Drawing.Point(22, 12);
            this.htmllBox.Name = "htmllBox";
            this.htmllBox.ScrollAlwaysVisible = true;
            this.htmllBox.Size = new System.Drawing.Size(814, 544);
            this.htmllBox.TabIndex = 17;
            this.htmllBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.htmllBox_MouseClick);
            // 
            // ContentHtml
            // 
            this.ContentHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentHtml.Location = new System.Drawing.Point(231, 571);
            this.ContentHtml.Multiline = true;
            this.ContentHtml.Name = "ContentHtml";
            this.ContentHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContentHtml.Size = new System.Drawing.Size(605, 51);
            this.ContentHtml.TabIndex = 16;
            // 
            // startBtn
            // 
            this.startBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startBtn.Location = new System.Drawing.Point(22, 562);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(95, 61);
            this.startBtn.TabIndex = 15;
            this.startBtn.Text = "开始";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // DishesTyep
            // 
            this.DishesTyep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DishesTyep.Location = new System.Drawing.Point(123, 562);
            this.DishesTyep.Name = "DishesTyep";
            this.DishesTyep.Size = new System.Drawing.Size(95, 61);
            this.DishesTyep.TabIndex = 15;
            this.DishesTyep.Text = "抓取详细";
            this.DishesTyep.UseVisualStyleBackColor = true;
            this.DishesTyep.Click += new System.EventHandler(this.DishesTyep_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 634);
            this.Controls.Add(this.htmllBox);
            this.Controls.Add(this.ContentHtml);
            this.Controls.Add(this.DishesTyep);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox htmllBox;
        private System.Windows.Forms.TextBox ContentHtml;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button DishesTyep;
    }
}

