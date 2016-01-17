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
	public partial class MatchControl : DataControl<Match>
	{
		#region Fields

		SetScoreControl[] Sets;

		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDate;
		#endregion

		#region Properties
		#endregion

		#region Overrides
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Sets = new SetScoreControl[] { Set1, Set2, Set3, Set4, Set5 };
			Event.Focus();
		}

		protected override Match CreateObject()
		{
			return Match.Create();
		}

		protected override Match GetObject(string id)
		{
			return Match.Fetch(int.Parse(id));
		}

		protected override void GetDataFromForm()
		{
			Object.MatchDate = Date.Text;
			Object.EventID = int.Parse(Event.SelectedValue);
			Object.WinnerID = int.Parse(Winner.SelectedValue);
			Object.LoserID = int.Parse(Loser.SelectedValue);
			for (int i = 0; i < Sets.Length; i++)
				Sets[i].GetValue(Object.Score.MatchSets[i]);
			Object.Score.LoserDefaulted = Defaulted.Checked;
			
		}

		protected override void CopyDataToForm()
		{
			Date.Text = Object.MatchDate;
			Event.SelectedValue = Object.EventID.ToString();
			Winner.SelectedValue = Object.WinnerID.ToString();
			//Winner2.SelectedValue = Object.WinnerID.ToString();
			Loser.SelectedValue = Object.LoserID.ToString();
			//Loser2.SelectedValue = Object.LoserID.ToString();
			for (int i = 0; i < Sets.Length; i++)
				Sets[i].InitValue(Object.Score.MatchSets[i]);
			Defaulted.Checked = Object.Score.LoserDefaulted;
		}

		protected override void Submit_Click(object sender, EventArgs e)
		{
			bool newMatch = Object.IsNew;
			base.Submit_Click(sender, e);
			if (newMatch)
				Response.Redirect("PlayerMatchList.aspx");
		}

		string[] ToArray(PlayerList list)
		{
			System.Collections.Generic.List<string> strings = new System.Collections.Generic.List<string>(list.Count);
			foreach (Player player in list)
			{
				strings.Add(player.FullName.Replace(@"'",@"\'"));
			}
			return strings.ToArray();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			//the base class doesn't recognize the DatePicker control so it can't
			//disable it automatically
			Date.Enabled = EditRequested;

			if (!IsPostBack)
			{
				Winner.DataSource = Object.Winners; //PlayerList.GetDropdownList(false);
				Winner1.AutoCompleteStrings = ToArray(Object.Winners);
				//Winner2.DataSource = Object.Winners;
				Loser.DataSource = Object.Losers; //PlayerList.GetDropdownList(false);
				//Loser2.DataSource = Object.Losers; //PlayerList.GetDropdownList(false);

				if (Object.IsNew)
				{
					//String EventFilter = String.Format("(BeginDate <= #{0}# and EndDate >= #{0}#) or (BeginDate is NULL)", DateTime.Now.ToShortDateString());
					Event.DataSource = Object.Events;
					Date.Text = DateTime.Now.ToShortDateString();
				}
				else
				{
					Event.DataSource = Object.Events; //this is supposed to be the full list when editing an existing match... EventList.GetList(true);
					//CopyDataToForm();
				}

				DataBind();

				Master.StatusText = "Loaded";
			}

			DialogCaption.InnerText = Caption;
		}
		#endregion

		#region Validation
		protected void ScoreValidator_ValidateSet(SetScoreControl Set)
		{
			Int32 SetNumber = Set.SetNumber;

			//set 1 is always required
			//other sets are required only if partially entered or if a later set was also entered
			if (SetNumber > 1)
			{
				if (SetNumber < 5)
				{
					SetScoreControl NextSet = (SetScoreControl)this.FindControl("Set" + (Set.SetNumber + 1));
					if (Set.IsBlank && (NextSet == null || NextSet.IsBlank))
						return;
				}
				else
				{
					if (Set.IsBlank)
						return;
				}
			}

			if (Set.WinnerGames == "")
				throw new System.ApplicationException("Please enter a winner score for " + Set.ID);
			if (Set.LoserGames == "")
				throw new System.ApplicationException("Please enter a loser score for " + Set.ID);

			//if one tiebreak score has been entered, then both must be entered
			//also, if the set scores differ by one, and neither player defaulted, 
			//	then a tiebreak score must be entered
			if (Set.WinnerTiebreak == "" && (Set.LoserTiebreak != "" || Math.Abs(Int32.Parse(Set.WinnerGames) - Int32.Parse(Set.LoserGames)) == 1))
				throw new System.ApplicationException("Please enter a winner tiebreak score for " + Set.ID);
			if (Set.WinnerTiebreak != "" && Set.LoserTiebreak == "")
				throw new System.ApplicationException("Please enter a loser tiebreak score for " + Set.ID);

		}

		protected void ScoreValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			try
			{
				//validate that a score has been entered for each set, as required
				ScoreValidator_ValidateSet(Set1);
				ScoreValidator_ValidateSet(Set2);
				ScoreValidator_ValidateSet(Set3);
				ScoreValidator_ValidateSet(Set4);
				ScoreValidator_ValidateSet(Set5);

				//validate
			}
			catch (System.ApplicationException e)
			{
				args.IsValid = false;
				ScoreValidator.ErrorMessage = e.Message;
			}


		}
		#endregion

	}
}