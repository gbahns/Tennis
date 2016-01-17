using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class PlayerOpponentSummary
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerOpponentSummary).ToString());

		#region Static Methods
		public static PlayerOpponentSummary Get(SafeDataReader dr)
		{
			PlayerOpponentSummary PlayerOpponentSummary = new PlayerOpponentSummary();
			PlayerOpponentSummary.Fetch(dr);
			return PlayerOpponentSummary;
		}

		public static List<PlayerOpponentSummary> GetList(SafeDataReader dr)
		{
			var list = new List<PlayerOpponentSummary>();
			while (dr.Read())
				list.Add(PlayerOpponentSummary.Get(dr));
			return list;
		}
		#endregion

		#region Constructors
		private PlayerOpponentSummary()
		{
			//Prevent direction creation 
		}
		#endregion

		#region Private Data
		private Int32 _ID;
		private string _Name;
		private WinLossRecord _Matches;
		private WinLossRecord _Sets;
		private WinLossRecord _Games;
		#endregion

		#region Business Properties and Methods
		public Int32 ID
		{
			get { return _ID; }
		}

		public string Name
		{
			get { return _Name; }
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
		public Int32 MatchesPlayed
		{
			get { return Matches.Won + Matches.Lost; }
		}
		public Int32 MatchesWon
		{
			get { return Matches.Won; }
		}
		public Int32 MatchesLost
		{
			get { return Matches.Lost; }
		}
		public double MatchesPct
		{
			get { return Matches.Pct; }
		}

		public Int32 SetsWon
		{
			get { return Sets.Won; }
		}
		public Int32 SetsLost
		{
			get { return Sets.Lost; }
		}
		public double SetsPct
		{
			get { return Sets.Pct; }
		}

		public Int32 GamesWon
		{
			get { return Games.Won; }
		}
		public Int32 GamesLost
		{
			get { return Games.Lost; }
		}
		public double GamesPct
		{
			get { return Games.Pct; }
		}

		public static PlayerOpponentSummary GetTotal(IEnumerable<PlayerOpponentSummary> list)
		{
			PlayerOpponentSummary total = new PlayerOpponentSummary();
			total._Name = "Total";
			foreach (PlayerOpponentSummary item in list)
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