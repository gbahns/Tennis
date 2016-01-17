namespace Tennis.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using TennisObjects;

	/// <summary>
	///		Summary description for SetScoreControl.
	/// </summary>
	public partial class SetScoreControl : System.Web.UI.UserControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Set.Text = ID.Substring(ID.Length - 1);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
		}

		public bool Enabled
		{
			get
			{
				return W.Enabled;
			}
			set
			{
				W.Enabled = WT.Enabled = L.Enabled = LT.Enabled = value;
			}
		}

		public Int32 SetNumber
		{
			get {return Int32.Parse(Set.Text);}
		}

		public bool IsBlank
		{
			get {return string.IsNullOrEmpty(WinnerGames) && string.IsNullOrEmpty(LoserGames) && string.IsNullOrEmpty(WinnerTiebreak) && string.IsNullOrEmpty(LoserTiebreak);}
		}

		public string WinnerGames
		{
			get {return W.Text;}
			set {W.Text = value;}
		}

		public string LoserGames
		{
			get {return L.Text;}
			set {L.Text = value;}
		}

		public string WinnerTiebreak
		{
			get {return WT.Text;}
			set {WT.Text = value;}
		}

		public string LoserTiebreak
		{
			get {return LT.Text;}
			set {LT.Text = value;}
		}

		//public Objects.MatchScore.MatchSet Value
		//{
		//    get
		//    {
		//        if (set.SetPlayed)
		//        {
		//            Objects.MatchScore.MatchSet set = new Tennis.Objects.MatchScore.MatchSet();
		//            valueset.WGames.ToString();
		//            WinnerTiebreak = set.WTiebreak.ToString();
		//            LoserGames = set.LGames.ToString();
		//            LoserTiebreak = set.LTiebreak.ToString();
		//        }
		//        else
		//        {
		//            WinnerGames = "";
		//            WinnerTiebreak = "";
		//            LoserGames = "";
		//            LoserTiebreak = "";
		//        }
		//    }
		//    set
		//    {
		//        InitValue(value);
		//    }
		//}

		public void InitValue(MatchScore.MatchSet set)
		{
			if (set.SetPlayed)
			{
				WinnerGames = set.WGames.ToString();
				WinnerTiebreak = set.WTiebreak.ToString();
				LoserGames = set.LGames.ToString();
				LoserTiebreak = set.LTiebreak.ToString();
			}
			else
			{
				WinnerGames = "";
				WinnerTiebreak = "";
				LoserGames = "";
				LoserTiebreak = "";
			}
		}

		byte tobyte(string s)
		{
			return string.IsNullOrEmpty(s) ? (byte)0 : byte.Parse(s);
		}

		public void GetValue(MatchScore.MatchSet set)
		{
			set.WGames = tobyte(WinnerGames);
			set.LGames = tobyte(LoserGames);
			set.WTiebreak = tobyte(WinnerTiebreak);
			set.LTiebreak = tobyte(LoserTiebreak);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
