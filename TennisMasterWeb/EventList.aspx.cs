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
using TennisObjects;
using log4net;

namespace Tennis
{
	public partial class EventListPage : TennisPage
	{
		public static ILog log = LogManager.GetLogger(typeof(EventListPage).ToString());

		protected void Page_Load(object sender, EventArgs e)
		{
			//GridView1.DataSource = EventList.GetListAll();
			GridView1.DataSource = EventList.GetList();
			GridView1.DataBind();
		}
	}
}
