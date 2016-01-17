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
	public partial class EventControl : DataControl<TennisEvent>
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			EventName.Focus();
		}

		protected override TennisEvent CreateObject()
		{
			return TennisEvent.Create();
		}

		protected override TennisEvent GetObject(string id)
		{
			return TennisEvent.Fetch(int.Parse(id));
		}

		protected override void GetDataFromForm()
		{
			Object.Name = EventName.Text;
			Object.ClassificationID = int.Parse(Classification.SelectedValue);
			Object.BeginDateText = BeginDate.Text;
			Object.EndDateText = EndDate.Text;
			Object.IsLeague = League.Checked;
			Object.IsTournament = Tournament.Checked;
			Object.TeamPlay = TeamPlay.Checked;
		}

		protected override void CopyDataToForm()
		{
			EventName.Text = Object.Name;
			Classification.SelectedValue = Object.ClassificationID.ToString();
			BeginDate.Text = Object.BeginDateText;
			EndDate.Text = Object.EndDateText;
			League.Checked = Object.IsLeague;
			Tournament.Checked = Object.IsTournament;
			TeamPlay.Checked = Object.TeamPlay;
		}

		/// <summary>
		/// The base class is named "TennisEvent", so we need to override the
		/// caption for the UI.
		/// </summary>
		protected override string CaptionDesc
		{
			get { return "Event"; }
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (!IsPostBack)
			{
				//Winner.DataSource = PlayerList.GetDropdownList(false);
				//Loser.DataSource = PlayerList.GetDropdownList(false);
				Classification.DataSource = TennisObjects.ClassificationList.GetDropdownList();

				DataBind();

				Master.StatusText = "Loaded";
			}

			DialogCaption.InnerText = Caption;
		}
	}
}