using System;
using Csla;
using Bahns.Data;
using Bahns.Util;
using log4net;

namespace TennisObjects
{
	public class PlayerEventSummary : ReadOnlyBase<PlayerEventSummary>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerEventSummary).ToString());

		#region Private Data
		private string _TennisEvent;
		private WinLossRecord _Matches;
		private WinLossRecord _Sets;
		private WinLossRecord _Games;
		private SmartDate mStartDate;
		#endregion

		#region Business Properties and Methods
		public string TennisEvent
		{
			get { return _TennisEvent; }
		}

		public WinLossRecord Matches
		{
			get { return _Matches; }
		}

		public WinLossRecord Sets
		{
			get { return _Sets; }
		}

		public WinLossRecord Games
		{
			get { return _Games; }
		}

		public SmartDate StartDate
		{
			get { return mStartDate; }
		}

		public static PlayerEventSummary GetTotal(PlayerEventSummaryList list)
		{
			PlayerEventSummary total = new PlayerEventSummary();
			total._TennisEvent = "Total";
			foreach (PlayerEventSummary item in list)
			{
				total._Matches.Won += item._Matches.Won;
				total._Matches.Lost += item._Matches.Lost;
				total._Sets.Won += item._Sets.Won;
				total._Sets.Lost += item._Sets.Lost;
				total._Games.Won += item._Games.Won;
				total._Games.Lost += item._Games.Lost;
			}
			return total;
		}
		#endregion

		#region Additional Properties for Data Binding
		public DateTime StartDateValue
		{
			get { return StartDate; }
		}
		public string StartDateText
		{
			get { return StartDate.Text; }
		}
		public long MatchesPlayed
		{
			get { return Matches.Won + Matches.Lost; }
		}
		public long MatchesWon
		{
			get { return Matches.Won; }
		}
		public long MatchesLost
		{
			get { return Matches.Lost; }
		}
		public double MatchesPct
		{
			get { return Matches.Pct; }
		}

		public long SetsWon
		{
			get { return Sets.Won; }
		}
		public long SetsLost
		{
			get { return Sets.Lost; }
		}
		public double SetsPct
		{
			get { return Sets.Pct; }
		}

		public long GamesWon
		{
			get { return Games.Won; }
		}
		public long GamesLost
		{
			get { return Games.Lost; }
		}
		public double GamesPct
		{
			get { return Games.Pct; }
		}
		#endregion

		#region System.Object Overrides
		public override string ToString()
		{
			return string.Format("{0} ({1})", TennisEvent, Matches);
		}

		protected override object GetIdValue()
		{
			return _TennisEvent;
		}
		#endregion

		#region Shared Methods
		public static PlayerEventSummary GetPlayerEventSummary(SafeDataReader dr)
		{
			PlayerEventSummary PlayerEventSummary = new PlayerEventSummary();
			PlayerEventSummary.Fetch(dr);
			return PlayerEventSummary;
		}
		#endregion

		#region Constructors
		private PlayerEventSummary()
		{
			//Prevent direction creation 
		}
		#endregion

		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			_TennisEvent = dr.GetString();
			mStartDate = dr.GetDateTime();
			//mStartDate.FormatString = "Short Date";
			_Matches.Won = dr.GetInt32();
			_Matches.Lost = dr.GetInt32();
			_Sets.Won = dr.GetInt32();
			_Sets.Lost = dr.GetInt32();
			_Games.Won = dr.GetInt32();
			_Games.Lost = dr.GetInt32();
		}
		#endregion

	}
}