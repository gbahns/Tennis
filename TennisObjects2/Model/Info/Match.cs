using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Bahns.Data;
using Bahns.Util;
using System.Collections;
using Bahns.Core.BusinessObjects;
using Bahns.Util.Validation;

namespace TennisObjects.Info
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
	public class Match
	{
		private static ILog log = LogManager.GetLogger(typeof(Match).ToString());

		#region Shared Methods
		public static Match Create()
		{
			return new Match();
		}

		public static Match Get(SafeDataReader dr)
		{
			//Util.CheckReadAccess();
			Match item = new Match();
			item.Populate(dr);
			return item;
		}

		//public static Match FromEditable(TennisObjects.Info.Match from)
		//{
		//    //Util.CheckReadAccess();
		//    Match item = new Match();
		//    item._EventID = from.EventID;
		//    item._ID = from.ID;
		//    item._LoserID = from.LoserID;
		//    item._MatchDate = from.MatchDate;
		//    item._Score.FromInfo(from.Score); ;
		//    item._WinnerID = from.WinnerID;
		//    item.MarkOld();
		//    return item;
		//}
		#endregion

		#region Constructors
		private Match()
		{
		}
		#endregion

		#region Events
		public static event CreatedEventHandler Created;
		public delegate void CreatedEventHandler(Match obj);
		//public static event UpdatedEventHandler Updated;
		//public delegate void UpdatedEventHandler(Match obj);
		public static event DeletedEventHandler Deleted;
		public delegate void DeletedEventHandler(int ID);

		public void OnCreated()
		{
			if (Created != null)
			{
				Created(this);
			}
		}

		//public void OnUpdated()
		//{
		//    if (Updated != null)
		//    {
		//        Updated(this);
		//    }
		//}

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
		}

		public SmartDate MatchDate
		{
			get { return _MatchDate; }
		}

		public Int32 WinnerID
		{
			get { return _WinnerID; }
		}

		public Int32 LoserID
		{
			get { return _LoserID; }
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
		#endregion

		#region System.Object Overrides
		//public override string ToString()
		//{
		//    Player winner = this.Winner;
		//    Player loser = this.Loser;
		//    if (winner == null | loser == null)
		//    {
		//        return (IsNew ? "New Match" : "Edit Match");
		//    }
		//    else
		//    {
		//        return string.Format("{0} d. {1} {2}", winner.FullName, loser.FullName, _Score);
		//    }
		//}
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
		}
		#endregion
	}

}
