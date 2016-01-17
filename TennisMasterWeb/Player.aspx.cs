using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using Csla.Validation;
using TennisObjects;

namespace Tennis
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>

	public partial class PlayerEdit : TennisPage
	{
		public PlayerEdit()
		{
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			PlayerControl1.Focus();
		}
	}
}
