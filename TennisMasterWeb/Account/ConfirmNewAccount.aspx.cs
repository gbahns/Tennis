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

namespace Tennis.Account
{
	public partial class ConfirmNewAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = int.Parse(Request.QueryString["ref"]);
			string uid = Request.QueryString["uid"];
			string email = Request.QueryString["email"];
			TennisObjects.ConfirmUser.Execute(id, uid, email);
		}
	}
}
