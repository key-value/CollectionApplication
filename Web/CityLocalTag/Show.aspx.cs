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
namespace Maticsoft.Web.CityLocalTag
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
					int LocalTagID=(Convert.ToInt32(strid));
					ShowInfo(LocalTagID);
				}
			}
		}
		
	private void ShowInfo(int LocalTagID)
	{
		Maticsoft.BLL.CityLocalTag bll=new Maticsoft.BLL.CityLocalTag();
		Maticsoft.Model.CityLocalTag model=bll.GetModel(LocalTagID);
		this.lblLocalTagID.Text=model.LocalTagID.ToString();
		this.lblTagName.Text=model.TagName;

	}


    }
}
