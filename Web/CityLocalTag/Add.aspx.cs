using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.CityLocalTag
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtLocalTagID.Text))
			{
				strErr+="LocalTagID格式错误！\\n";	
			}
			if(this.txtTagName.Text.Trim().Length==0)
			{
				strErr+="TagName不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int LocalTagID=int.Parse(this.txtLocalTagID.Text);
			string TagName=this.txtTagName.Text;

			Maticsoft.Model.CityLocalTag model=new Maticsoft.Model.CityLocalTag();
			model.LocalTagID=LocalTagID;
			model.TagName=TagName;

			Maticsoft.BLL.CityLocalTag bll=new Maticsoft.BLL.CityLocalTag();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
