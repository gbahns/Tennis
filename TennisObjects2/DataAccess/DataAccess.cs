using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bahns.Data;

namespace TennisObjects
{
	public class DataAccess
	{
		internal static void ReadFirst(IDataReader dr, string msg, params object[] args)
		{
			if (!dr.Read())
				throw new RecordNotFoundException(string.Format(msg, args));
		}

		public static IDataReader GetPlayer(int id)
		{
			IDataReader dr = DbHelper.ExecuteReader("csla_get_player", id);
			ReadFirst(dr, "Player not found (ID:{0})", id);
			return dr;
		}

		public static IDataReader GetAllPlayers()
		{
			return DbHelper.ExecuteReader("csla_get_playerlist");
		}

		public static SafeDataReader GetEvent(int id)
		{
			SafeDataReader dr = DbHelper.ExecuteReader("csla_get_event", id);
			ReadFirst(dr, "Event not found (ID:{0})", id);
			return dr;
		}

		public static SafeDataReader GetAllEvents()
		{
			return DbHelper.ExecuteReader("csla_get_eventlist");
		}

		public static SafeDataReader GetAllMatches()
		{
			return DbHelper.ExecuteReader("csla_get_matchlist_personal", 1);
		}

		public static SafeDataReader GetMatch(int id)
		{
			SafeDataReader dr = DbHelper.ExecuteReader("csla_get_match", id);
			ReadFirst(dr, "Match not found (ID:{0})", id);
			return dr;
		}

		public static SafeDataReader GetPlayerOpponentSummary(int id)
		{
			return DbHelper.ExecuteReader("csla_get_match_summary_opponents", id);
		}
	}
}
