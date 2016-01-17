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
using log4net;

public partial class _Default : System.Web.UI.Page
{
	public static ILog log = LogManager.GetLogger(typeof(_Default).ToString());

	protected void Page_Load(object sender, EventArgs e)
	{
		log4net.Config.DOMConfigurator.Configure();
		log.Info("Page_Load started");
		log.Info("Page_Load finished");
	}
}
