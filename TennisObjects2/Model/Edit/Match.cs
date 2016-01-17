using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Bahns.Data;
using Bahns.Util;
using System.Collections;
using Bahns.Core.BusinessObjects;
using Bahns.Util.Validation;

namespace TennisObjects
{
	/// <summary> 
	/// Represents a tennis match from an objective point of view. 
	/// </summary> 
	/// <remarks> 
	/// Specifies the event that this match was part of, the date it was started, 
	/// the winner and loser, and the score. The 'W' fields in the score indicate 
	/// the number of games won by the winner, and the 'L' fields indicate the 
	/// number of games won by the loser. 
	/// </remarks> 
	public class Match : BusinessBase
	{
		private static ILog log = LogManager.GetLogger(typeof(Match).ToString());

		#region Static Methods
		public static Match Create()
		{
			return new Match();
		}

		public static Match Get(SafeDataReader dr)
		{
			//Util.CheckReadAccess();
			Match item = new Match();
			item.Populate(dr);
			item.MarkOld();
			return item;
		}

		public static Match FromInfo(TennisObjects.Info.Match from)
		{
			//Util.CheckReadAccess();
			Match item = new Match();
			item._EventID = from.EventID;
			item._ID = from.ID;
			item._LoserID = from.LoserID;
			item._MatchDate = from.MatchDate;
			item._Score.FromInfo(from.Score);
			//item.Score = from.Score;
			item._WinnerID = from.WinnerID;
			item.MarkOld();
			item.ValidationRules.CheckRules();
			return item;
		}

		/// <summary> 
		/// Retrieve match as child object 
		/// </summary> 
		/// <param name="dr"></param> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		//internal static Match Fetch(SafeDataReader dr)
		//{
		//    Match Match = new Match();
		//    Match.MarkAsChild();
		//    Match._Fetch(dr);
		//    return Match;
		//}

		/// <summary> 
		/// Retrieve match as root object 
		/// </summary> 
		/// <param name="ID"></param> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		//public static Match Fetch(Int32 ID)
		//{
		//    return (Match)DataPortal.Fetch(new Criteria(ID));
		//}

		//public static void Delete(int ID)
		//{
		//    DataPortal.Delete(new Criteria(ID));
		//    OnDeleted(ID);
		//}
		#endregion

		#region Constructors
		private Match()
		{
			//todo: make sure MarkChild is set when the new match is being created as a child object 
			//MarkAsChild() 
			_Score.PropertyChanged += Child_PropertyChangedGeneric;
			//Saved += new EventHandler<Csla.Core.SavedEventArgs>(_Score.Match_Saved);
			ValidationRules.CheckRules();
		}

		//Sub Score_IsDirtyChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _Score.IsDirtyChanged 
		// Me.OnIsDirtyChanged() 
		//End Sub 
		#endregion

		#region Events
		public static event CreatedEventHandler Created;
		public delegate void CreatedEventHandler(Match obj);
		public static event UpdatedEventHandler Updated;
		public delegate void UpdatedEventHandler(Match obj);
		public static event DeletedEventHandler Deleted;
		public delegate void DeletedEventHandler(int ID);

		public void OnCreated()
		{
			if (Created != null)
			{
				Created(this);
			}
		}

		public void OnUpdated()
		{
			if (Updated != null)
			{
				Updated(this);
			}
		}

		public void OnDeleted()
		{
			if (Deleted != null)
			{
				Deleted(this.ID);
			}
		}

		public static void OnDeleted(int ID)
		{
			if (Deleted != null)
			{
				Deleted(ID);
			}
		}
		#endregion

		#region Private Data
		private Int32 _ID;
		private Int32 _EventID;
		private SmartDate _MatchDate = new SmartDate(DateTime.Now.Date);
		private Int32 _WinnerID;
		private Int32 _LoserID;
		private MatchScore _Score = new MatchScore();

		//private PlayerList _Players = PlayerList.GetList();
		//private PlayerList _Winners = PlayerList.GetDropdownList();
		//private PlayerList _Losers = PlayerList.GetDropdownList();
		//private EventList _Events = EventList.GetDropdownList();
		//[NonSerialized(), NotUndoable()] private bool _ShowAllEvents = false;
		#endregion

		#region Business Properties and Methods
		public Int32 ID
		{
			get { return _ID; }
		}

		public Int32 EventID
		{
			get { return _EventID; }
			set { SetProperty(ref _EventID, value); }
		}

		public SmartDate MatchDate
		{
			get { return _MatchDate; }
			set { SetProperty(ref _MatchDate, value); }
		}

		//public string MatchDate
		//{
		//    get { return _MatchDate.ToShortDateString(); }
		//    set
		//    {
		//        if (_MatchDate.Equals(value))
		//            return;
		//        _MatchDate.Text = value;
		//        PropertyHasChanged();
		//    }
		//}

		//public string MatchTime
		//{
		//    get { return _MatchDate.ToShortTimeString(); }
		//    set
		//    {
		//        if (_MatchDate.Equals(value))
		//            return;
		//        _MatchDate.Text = value;
		//        PropertyHasChanged();
		//    }
		//}

		public Int32 WinnerID
		{
			get { return _WinnerID; }
			set { SetProperty(ref _WinnerID, value); }
		}

		public Int32 LoserID
		{
			get { return _LoserID; }
			set { SetProperty(ref _LoserID, value); }
		}

		//public Player Winner
		//{
		//    get { return _Players.Find(_WinnerID); }
		//}

		//public Player Loser
		//{
		//    get { return _Players.Find(_LoserID); }
		//}

		public MatchScore Score
		{
			get { return _Score; }
		}

		public string ResultString
		{
			get { return ToString(); }
		}

		//Private Function CreatePlayerDropdownList() As PlayerList 
		// Dim list As PlayerList = DirectCast(PlayerList.GetList().Clone(), PlayerList) 
		// list.AddBlankSelection() 
		// Return list 
		//End Function 

		//public PlayerList Winners
		//{
		//    get { return _Winners; }
		//}

		//public PlayerList Losers
		//{
		//    get { return _Losers; }
		//}

		//public EventList Events
		//{
		//    get { return _Events; }
		//}

		//public void FilterEvents(bool allLeagues, bool allTournaments)
		//{
		//    _Events = EventList.GetList(allLeagues, allTournaments, _EventID);
		//    OnIsDirtyChanged();
		//}

		//public override Match Save()
		//{
		//    bool creating = IsNew;
		//    Match match = base.Save();
		//    if (creating)
		//    {
		//        match.OnCreated();
		//    }
		//    else if (IsNew)
		//    {
		//        match.OnDeleted();
		//    }
		//    else
		//    {
		//        //match.OnUpdated();
		//    }
		//    return match;
		//}

		#endregion

		#region System.Object Overrides
		public override string ToString()
		{
			//Player winner = this.Winner;
			//Player loser = this.Loser;
			//if (WinnerID == null || LoserID == null)
			//{
			//    return (IsNew ? "New Match" : "Edit Match");
			//}
			//else
			//{
			//    return string.Format("{0} d. {1} {2}", winner.FullName, loser.FullName, _Score);
			//}
			return string.Format("{0} d. {1} {2}", WinnerID, LoserID, Score);
		}
		#endregion

		#region IsValid and IsDirty
		public override bool IsValid
		{
			get { return base.IsValid && _Score.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _Score.IsDirty; }
		}
		#endregion


		#region Business Rules
		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(BusinessRules.ComboRequired, "EventID");
			ValidationRules.AddRule(BusinessRules.DateRequired, "MatchDate");
			//ValidationRules.AddRule(BusinessRules.DateIsInPast, "MatchDate");

			ValidationRules.AddRule(BusinessRules.ComboRequired, new RuleArgs("WinnerID", "Match winner"));
			ValidationRules.AddRule(BusinessRules.ComboRequired, new RuleArgs("LoserID", "Match loser"));
		}

		protected override void AddInstanceBusinessRules()
		{
			ValidationRules.AddInstanceRule(WinnerNotLoser, "WinnerID");
			ValidationRules.AddInstanceRule(WinnerNotLoser, "LoserID");
		}

		//[BrokenRules.Description("Match winner cannot also be the loser")]
		private bool WinnerNotLoser(object target, RuleArgs e)
		{
			//if the winner has not been selected, don't enforse this rule 
			e.Description = "Match winner cannot also be the loser.";
			return _WinnerID == 0 || _WinnerID != _LoserID;
		}

		private bool SetWinnerIsTiebreakWinner(object target, RuleArgs e)
		{
			return true;
		}

		public override BrokenRulesCollection BrokenRulesCollection
		{
			get
			{
				BrokenRulesCollection rules = base.BrokenRulesCollection;
				foreach (BrokenRule rule in _Score.BrokenRulesCollection)
					rules.Add(rule);
				return rules;
			}
		}

		/*GetAllBrokenRulesString 
		 * 
		 * 
		 * 
		 * 
Public Property GetBrokenRulesString() as String
   Get
      Dim temp as String = ""
      If Not Child1.IsValid Then
         temp &= "Error in Child1" & vbCrLf
      End If
      If Not Child2.IsValid Then
         temp &= "Error in Child2" & vbCrLf
      End If
      ...
      Return temp
   End Get
End Property

		 * */

		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public Int32 ID;
			public Criteria()
			{
			}
			public Criteria(Int32 ID)
			{
				this.ID = ID;
			}
		}
		#endregion

		#region Data Access
		private void Populate(SafeDataReader dr)
		{
			_ID = dr.GetInt32();
			_EventID = dr.GetInt32();
			_MatchDate = dr.GetDateTime();
			_WinnerID = dr.GetInt32();
			_LoserID = dr.GetInt32();
			_Score.Fetch(dr);

			ValidationRules.CheckRules();
		}

		//protected override void DataPortal_Fetch(object Criteria)
		//{
		//    Util.CheckReadAccess();

		//    Criteria crit = (Criteria)Criteria;
		//    using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_match", crit.ID))
		//    {
		//        if (!dr.Read())
		//            throw new RecordNotFoundException(string.Format("Match not found (ID:{0})", crit.ID));

		//        _Fetch(dr);

		//        if (!_Events.Contains(_EventID))
		//        {
		//            FilterEvents(false, false);
		//        }
		//    }
		//    ValidationRules.CheckRules();
		//    MarkOld();
		//}

		DbResultsDictionary DoTheUpdate()
		{
			//Sfg.Util.Data.DbHelper.ExecuteNonQuery("Tennis", "csla_save_match", Sfg.Util.Data.Param.In(
			DbResultsDictionary ret = DbHelper.ExecuteNonQuery("csla_save_match", Util.IDParam(_ID, IsNew), _EventID, _MatchDate.DbValue, _WinnerID, _LoserID,
				_Score.Sets[0].WGames, _Score.Sets[0].LGames, _Score.Sets[0].WTiebreak, _Score.Sets[0].LTiebreak,
				_Score.Sets[1].WGames, _Score.Sets[1].LGames, _Score.Sets[1].WTiebreak, _Score.Sets[1].LTiebreak,
				_Score.Sets[2].WGames, _Score.Sets[2].LGames, _Score.Sets[2].WTiebreak, _Score.Sets[2].LTiebreak,
				_Score.Sets[3].WGames, _Score.Sets[3].LGames, _Score.Sets[3].WTiebreak, _Score.Sets[3].LTiebreak,
				_Score.Sets[4].WGames, _Score.Sets[4].LGames, _Score.Sets[4].WTiebreak, _Score.Sets[4].LTiebreak,
				_Score.LoserDefaulted, null);
			return ret;
		}

		protected override void Update()
		{
			DoTheUpdate();

			bool creating = IsNew;
			if (creating)
			{
				OnCreated();
			}
			else if (IsNew)
			{
				OnDeleted();
			}
			else
			{
				OnUpdated();
			}
		}

		//protected override void DataPortal_Update()
		//{
		//    Util.CheckEditAccess();

		//    //insert or update object data into database 
		//    log.Debug("updating match " + ToString());

		//    DoTheUpdate();
		//}

		//protected override void DataPortal_Insert()
		//{
		//    Util.CheckAddAccess();

		//    //insert or update object data into database 
		//    log.Debug("inserting match " + ToString());

		//    DbResultsDictionary ret = DoTheUpdate();
		//    _ID = (int)ret["@IDout"];
		//    log.Info(string.Format("New id is {0}", _ID));
		//}



		////DataPortal_Delete supports direct object deletion. If we don't want to 
		////support direct deletion, delete this method. 
		//protected override void DataPortal_Delete(object Criteria)
		//{
		//    Util.CheckDeleteAccess();

		//    Criteria crit = (Criteria)Criteria;
		//    DbHelper.ExecuteNonQuery("csla_delete_match", crit.ID);
		//}

		#endregion
	}

}
