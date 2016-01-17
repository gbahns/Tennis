using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using Csla;
using Csla.Core;
using Csla.Validation;
using Bahns.Data;
using Bahns.Util;

namespace TennisObjects
{
	[Serializable()]
	public class PlayerMatch : ReadOnlyBase<PlayerMatch>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerMatch).ToString());

		#region Private Data
		private Int32 _ID;
		private SmartDate _MatchDate = new SmartDate();
		private Int32 _EventID;
		private string _EventName = "";
		private Int32 _ClassID;
		private string _ClassName = "";
		private string _Result = "";
		private Int32 _OpponentID;
		private string _OpponentName = "";
		private MatchScore _Score = new MatchScore();
		#endregion

		#region Properties
		/// <summary> 
		/// Unique identifier in the database table for this match. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public Int32 ID
		{
			get { return _ID; }
		}

		/// <summary> 
		/// Date that this match was played. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public SmartDate MatchDate
		{
			get { return _MatchDate; }
			//set { _MatchDate = value; }
		}

		/// <summary> 
		/// Date that this match was played. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public System.DateTime MatchDateAsDate
		{
			get { return _MatchDate.Date; }
		}

		public Int32 EventID
		{
			get { return _EventID; }
		}

		public string EventName
		{
			get { return _EventName; }
		}

		public Int32 ClassID
		{
			get { return _ClassID; }
		}

		public string ClassName
		{
			get { return _ClassName; }
		}

		/// <summary> 
		/// Returns W or L to indicate whether the player won or lost the match. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public string Result
		{
			get { return _Result; }
		}

		/// <summary> 
		/// Unique identifier in the database table for the opponent played in this match. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public Int32 OpponentID
		{
			get { return _OpponentID; }
		}


		/// <summary> 
		/// Name of the opponent played in this match. 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public string OpponentName
		{
			get { return _OpponentName; }
		}

		/// <summary> 
		/// Return a string showing the score for the match, e.g. "6-4 3-6 7-6" 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public string Score
		{
			get { return _Score.ToString(); }
		}

		/// <summary> 
		/// Return a string showing the score for the match, beginning with a W or L to indicate 
		/// whether the player won or lost, e.g. "W 6-4 3-6 7-6" 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public string ResultScore
		{
			get { return Result + " " + Score; }
		}
		#endregion

		#region "System.Object Overrides"
		public override string ToString()
		{
			//todo: implement ToString() 
			//Return String.Format("{0}", ID) 
			return "";
		}

		public bool Equals(PlayerMatch A)
		{
			//todo: implement Equals 
			//Return _ID = A._ID 
			return false;
		}

		public override int GetHashCode()
		{
			//todo: implement GetHashCode() 
			//Return _ID.GetHashCode() 
			return base.GetHashCode();
		}
		#endregion

		#region "Shared Methods"
		public static PlayerMatch Fetch(SafeDataReader dr)
		{
			return new PlayerMatch(dr);
		}

		public static PlayerMatch Copy(Match Match, int PlayerID)
		{
			return new PlayerMatch(Match, PlayerID);
		}
		#endregion

		#region "Constructors"
		private PlayerMatch()
		{
		}

		private PlayerMatch(SafeDataReader dr)
		{
			_Fetch(dr);
		}

		private PlayerMatch(Match Match, int PlayerID)
		{
			_ID = Match.ID;
			_MatchDate.Text = Match.MatchDate;

			TennisEvent TennisEvent = Match.Events.Find(Match.EventID);
			_EventID = TennisEvent.ID;
			_EventName = TennisEvent.Name;
			_ClassID = TennisEvent.ClassificationID;
			_ClassName = "";

			_Result = (PlayerID == Match.WinnerID ? "W" : "L");
			_OpponentID = (PlayerID == Match.WinnerID ? Match.LoserID : Match.WinnerID);
			_OpponentName = Match.Winners.Find(_OpponentID).FullName;
			_Score = Match.Score;
		}
		#endregion

		#region "Data Access"
		private void _Fetch(SafeDataReader dr)
		{
			_ID = dr.GetInt32();
			_MatchDate = dr.GetDateTime();
			_EventID = dr.GetInt32();
			_EventName = dr.GetString();
			_ClassID = dr.GetInt32();
			_ClassName = dr.GetString();
			_Result = dr.GetString();
			_OpponentID = dr.GetInt32();
			_OpponentName = dr.GetString();
			_Score.Fetch(dr);
		}
		#endregion


		protected override object GetIdValue()
		{
			return _ID;
		}
	}
}
