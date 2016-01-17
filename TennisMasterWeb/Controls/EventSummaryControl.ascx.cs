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

namespace Tennis.Controls
{
	public partial class EventSummaryControl : System.Web.UI.UserControl
	{
		void GetData()
		{
			EventTypeEnum eventType = (EventTypeEnum)Enum.Parse(typeof(EventTypeEnum), EventTypeDrowDownList.SelectedValue);
			
			EventMatchSummaryList list = EventMatchSummaryList.Get(1,eventType);
			//PlayerEventSummaryList list = PlayerEventSummaryList.GetPlayerEventSummaryList(1);

			if (GridView2.DataSource == null)
				GridView2.DataSource = list;
			GridView2.DataBind();

			MatchSummary total = MatchSummary.GetTotal(list);

			int i = 0;
			GridView2.FooterRow.Cells[i++].Text = "Total";
			//GridView2.FooterRow.Cells[i++].Text = "";
			GridView2.FooterRow.Cells[i++].Text = "";
			GridView2.FooterRow.Cells[i++].Text = total.MatchesPlayed.ToString();
			GridView2.FooterRow.Cells[i++].Text = "";
			GridView2.FooterRow.Cells[i++].Text = total.MatchesWon.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.MatchesLost.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.MatchesPct.ToString("0.000");
			GridView2.FooterRow.Cells[i++].Text = "";
			GridView2.FooterRow.Cells[i++].Text = total.SetsWon.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.SetsLost.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.SetsPct.ToString("0.000");
			GridView2.FooterRow.Cells[i++].Text = "";
			GridView2.FooterRow.Cells[i++].Text = total.GamesWon.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.GamesLost.ToString();
			GridView2.FooterRow.Cells[i++].Text = total.GamesPct.ToString("0.000");
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			if (!IsPostBack)
			{
				//EventTypeDrowDownList.DataSource = Enum.GetNames(typeof(EventTypeEnum));
				EventTypeDrowDownList.DataBind();
				EventTypeDrowDownList.SelectedValue = "All";
			}
			GetData();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

		}

		protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
		{
		}

		protected void EventTypeDrowDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}