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
namespace Maticsoft.Web.Catalogue
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string FId= Request.Params["id"];
					ShowInfo(FId);
				}
			}
		}
			
	private void ShowInfo(string FId)
	{
		Maticsoft.BLL.Catalogue bll=new Maticsoft.BLL.Catalogue();
		Maticsoft.Model.Catalogue model=bll.GetModel(FId);
		this.lblFId.Text=model.FId;
		this.txthref.Text=model.href;
		this.txttitle.Text=model.title;
		this.txtLocalTagID.Text=model.LocalTagID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txthref.Text.Trim().Length==0)
			{
				strErr+="href不能为空！\\n";	
			}
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtLocalTagID.Text))
			{
				strErr+="LocalTagID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string FId=this.lblFId.Text;
			string href=this.txthref.Text;
			string title=this.txttitle.Text;
			int LocalTagID=int.Parse(this.txtLocalTagID.Text);


			Maticsoft.Model.Catalogue model=new Maticsoft.Model.Catalogue();
			model.FId=FId;
			model.href=href;
			model.title=title;
			model.LocalTagID=LocalTagID;

			Maticsoft.BLL.Catalogue bll=new Maticsoft.BLL.Catalogue();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
