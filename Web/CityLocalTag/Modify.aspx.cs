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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int LocalTagID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(LocalTagID);
				}
			}
		}
			
	private void ShowInfo(int LocalTagID)
	{
		Maticsoft.BLL.CityLocalTag bll=new Maticsoft.BLL.CityLocalTag();
		Maticsoft.Model.CityLocalTag model=bll.GetModel(LocalTagID);
		this.lblLocalTagID.Text=model.LocalTagID.ToString();
		this.txtTagName.Text=model.TagName;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTagName.Text.Trim().Length==0)
			{
				strErr+="TagName不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int LocalTagID=int.Parse(this.lblLocalTagID.Text);
			string TagName=this.txtTagName.Text;


			Maticsoft.Model.CityLocalTag model=new Maticsoft.Model.CityLocalTag();
			model.LocalTagID=LocalTagID;
			model.TagName=TagName;

			Maticsoft.BLL.CityLocalTag bll=new Maticsoft.BLL.CityLocalTag();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
