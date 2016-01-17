using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bahns.Data;
using Bahns.Util;

namespace TennisObjects.Info
{
	/// <summary>
	/// Summary of matches by event (or is this class more generic than that?)
	/// </summary>
	public class MatchSummary
	{
		#region Static Methods
		public static MatchSummary Get(SafeDataReader dr)
		{
			MatchSummary item = new MatchSummary();
			item.Fetch(dr);
			return item;
		}

		public static List<MatchSummary> GetList(SafeDataReader dr)
		{
			var list = new List<MatchSummary>();
			while (dr.Read())
				list.Add(MatchSummary.Get(dr));
			dr.Close();
			return list;
		}
		#endregion

		#region Constructors
		private MatchSummary()
		{
			//Prevent direction creation 
		}
		#endregion

		#region Private Data
		private Int32 _ID;
		private string _Name = "";
		private SmartDate _startDate;
		private SmartDate _endDate;
		private EventTypeEnum _eventType;
		private bool _teamPlay;
		private int _classificationID;
		private string _classification = "";
		private SmartDate _firstMatchDate;
		private SmartDate _lastMatchDate;
		private WinLossRecord _Matches;
		private WinLossRecord _Sets;
		private WinLossRecord _Games;
		#endregion

		#region Properties
		public Int32 ID
		{
			get { return _ID; }
		}

		public string Name
		{
			get { return _Name; }
		}

		public SmartDate StartDate
		{
			get { return _startDate; }
		}

		public SmartDate EndDate
		{
			get { return _endDate; }
		}

		public EventTypeEnum EventType
		{
			get { return _eventType; }
		}

		public bool TeamPlay
		{
			get { return _teamPlay; }
		}

		public int ClassificationID
		{
			get { return _classificationID; }
		}

		public string Classification
		{
			get { return _classification; }
		}

		public SmartDate FirstMatchDate
		{
			get { return _firstMatchDate; }
		}

		public SmartDate LastMatchDate
		{
			get { return _lastMatchDate; }
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

		#endregion

		#region Additional Properties for Data Binding
		[DisplayName("Matches")]
		public Int32 MatchesPlayed
		{
			get { return Matches.Won + Matches.Lost; }
		}
		[DisplayName("W")]
		public Int32 MatchesWon
		{
			get { return Matches.Won; }
		}
		[DisplayName("L")]
		public Int32 MatchesLost
		{
			get { return Matches.Lost; }
		}
		[DisplayName("Pct")]
		[DisplayFormat(DataFormatString="{0:0.000}")]
		public double MatchesPct
		{
			get { return Matches.Pct; }
		}

		[DisplayName("S-W")]
		public Int32 SetsWon
		{
			get { return Sets.Won; }
		}
		[DisplayName("S-L")]
		public Int32 SetsLost
		{
			get { return Sets.Lost; }
		}
		[DisplayName("S-Pct")]
		[DisplayFormat(DataFormatString = "{0:0.000}")]
		public double SetsPct
		{
			get { return Sets.Pct; }
		}

		[DisplayName("G-W")]
		public Int32 GamesWon
		{
			get { return Games.Won; }
		}
		[DisplayName("G-L")]
		public Int32 GamesLost
		{
			get { return Games.Lost; }
		}
		[DisplayName("G-Pct")]
		[DisplayFormat(DataFormatString = "{0:0.000}")]
		public double GamesPct
		{
			get { return Games.Pct; }
		}

		#endregion

		#region Methods
		public static MatchSummary GetTotal(IList<MatchSummary> list)
		{
			MatchSummary total = new MatchSummary();
			total._Name = "Total";
			foreach (MatchSummary item in list)
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

		#region System.Object Overrides
		public override string ToString()
		{
			return string.Format("{0} ({1})", Name, Matches);
		}
		#endregion

		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			//todo: load object data from data reader 
			//_TennisEvent = TennisObjects.TennisEvent.GetTennisEvent() 
			_ID = dr.GetInt32();
			_Name = dr.GetString();
			_startDate = dr.GetDateTime();
			_endDate = dr.GetDateTime();
			_eventType = (EventTypeEnum)dr.GetInt16();
			_teamPlay = dr.GetBoolean();
			_classificationID = dr.GetInt32();
			_classification = dr.GetString();
			_firstMatchDate = dr.GetDateTime();
			_lastMatchDate = dr.GetDateTime();
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
