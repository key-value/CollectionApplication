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
namespace Maticsoft.Web.Catalogue
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					string FId= strid;
					ShowInfo(FId);
				}
			}
		}
		
	private void ShowInfo(string FId)
	{
		Maticsoft.BLL.Catalogue bll=new Maticsoft.BLL.Catalogue();
		Maticsoft.Model.Catalogue model=bll.GetModel(FId);
		this.lblFId.Text=model.FId;
		this.lblhref.Text=model.href;
		this.lbltitle.Text=model.title;
		this.lblLocalTagID.Text=model.LocalTagID.ToString();

	}


    }
}
