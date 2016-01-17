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
using TennisObjects;
using System.Drawing;
using Microsoft.VisualBasic;

namespace Tennis
{
	public partial class PlayerMatches : TennisPage
	{
		public static ILog log = LogManager.GetLogger(typeof(PlayerMatches).ToString());

		private PlayerMatchList _FullMatchList;
		private PlayerMatchList _FiteredMatchList;


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			log4net.Config.DOMConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log.config"));
			log.Info("Page_Load started");
			_FullMatchList = PlayerMatchList.GetPlayerMatchList();
			//_FiteredMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);

			log.Info("Page_Load finished");
		}

		PlayerMatchList GetFilteredList()
		{
			TimeSpan.SelectedValue = "All";

			if (Request["eventid"] != null)
			{
				PlayerMatchList list = PlayerMatchList.SelectMatchesByEvent(_FullMatchList, int.Parse(Request["eventid"]));
				TimeSpanLabel.Text = list[0].EventName;
				return list;
			}

			if (Request["opponentid"] != null)
			{
				PlayerMatchList list = PlayerMatchList.SelectMatchesByOpponent(_FullMatchList, int.Parse(Request["opponentid"]));
				TimeSpanLabel.Text = list[0].OpponentName;
				return list;
			}

			if (Request["classificationid"] != null)
			{
				//TimeSpanLabel.Text = Request["eventid"];
				//return PlayerMatchList.SelectMatchesByClassification(_FullMatchList, int.Parse(Request["classificationid"]));
			}

			TimeSpan.SelectedValue = "Last 10";
			return PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);
		}

		protected override void OnLoadComplete(EventArgs e)
		{
			if (_FiteredMatchList == null)
				_FiteredMatchList = GetFilteredList();
			GridView1.DataSource = _FiteredMatchList;
			GridView1.DataBind();

			base.OnLoadComplete(e);
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			PlayerMatch item = e.Row.DataItem as PlayerMatch;

			if (item != null)
				e.Row.Cells[e.Row.Cells.Count - 1].CssClass = item.Result=="W" ? "Win" : "Loss";
		}

		PlayerMatchList GetList()
		{
			switch (TimeSpan.SelectedValue)
			{
				case "Last 10": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 10);
				case "Last 20": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 20);
				case "Last 50": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 50);
				case "Last Month": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Month);
				case "Last 2 Months": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 2, DateInterval.Month);
				case "Last 3 Months": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Quarter);
				case "Last Year": return PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Year);
				case "All": return _FullMatchList;
				default: return null;
			}
		}

		protected void TimeSpan_SelectedIndexChanged(object sender, EventArgs e)
		{
			TimeSpanLabel.Text = TimeSpan.SelectedValue;
			_FiteredMatchList = GetList();
		}

		protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
		{


		}

		protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
		{


		}

		protected void GridView1_DataBound(object sender, EventArgs e)
		{
			WinLossRecord record = new WinLossRecord();
			foreach (PlayerMatch match in _FiteredMatchList)
				if (match.Result == "W")
					record.Won++;
				else
					record.Lost++;
			txtRecord.Text = record.ToString();
		}

	}
}
