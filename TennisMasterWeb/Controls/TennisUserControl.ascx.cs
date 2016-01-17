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
using TennisObjects.Security;

namespace Tennis.Controls
{
	public partial class TennisUserControl : DataControl<UserIdentity>
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			UsernameTextBox.Focus();
		}

		protected override UserIdentity CreateObject()
		{
			return null;
		}

		protected override UserIdentity GetObject(string id)
		{
			//throw new Exception("The method or operation is not implemented.");
			return null;
		}

		protected override void GetDataFromForm()
		{
			//throw new Exception("The method or operation is not implemented.");
		}

		protected override void CopyDataToForm()
		{
			//throw new Exception("The method or operation is not implemented.");
		}
	}
}