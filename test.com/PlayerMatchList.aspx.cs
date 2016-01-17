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
using Tennis.Objects;

public partial class PlayerMatches : System.Web.UI.Page
{
	private PlayerMatchList _FullMatchList;
	private PlayerMatchList _FiteredMatchList;

    private void Login()
	{
        if (!(System.Threading.Thread.CurrentPrincipal is Tennis.Objects.Security.BusinessPrincipal))
            Tennis.Objects.Security.BusinessPrincipal.Login("gbb", "spanky");
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		Tennis.Objects.BusinessRules.Inititalize();
		Login();
		_FullMatchList = PlayerMatchList.GetPlayerMatchList();
		_FiteredMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);
//		_FullMatchList[0].MatchDate;
		//dataGrid.DataSource = PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);
		//dataGrid.DataBind();
		GridView1.DataSource = PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);
		GridView1.DataBind();
	}
}
