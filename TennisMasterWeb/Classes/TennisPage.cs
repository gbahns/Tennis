using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Collections;
using System.Collections.Specialized;
using TennisObjects.Security;
using Csla;
using System.Text;
using Csla.Validation;
using TennisObjects;

namespace Tennis
{
	/// <summary>
	/// Summary description for TennisPage.
	/// </summary>
	public abstract class TennisPage : System.Web.UI.Page
	{
		public TennisPage()
		{
		}

		override protected void OnInit(EventArgs e)
		{
			base.OnInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			Trace.Write(Request.Path);
			base.OnLoad(e);
		}

		protected new Tennis.Master Master
		{
			get { return (Tennis.Master)base.Master; }
		}

	}
}
