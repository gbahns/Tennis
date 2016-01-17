using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class PlayerOpponentSummaryList : ReadOnlyListBase<PlayerOpponentSummaryList, PlayerOpponentSummary>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerOpponentSummaryList).ToString());

		#region Shared Methods
		public static PlayerOpponentSummaryList GetPlayerEventSummaryList(long PlayerID)
		{
			return (PlayerOpponentSummaryList)DataPortal.Fetch(new Criteria(PlayerID));
		}
		#endregion

		#region Constructors
		private PlayerOpponentSummaryList()
		{
		}
		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public long PlayerID;
			public Criteria(long PlayerID)
			{
				this.PlayerID = PlayerID;
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_player_summary_opponents", crit.PlayerID))
			{
				IsReadOnly = false;
				while (dr.Read())
					Add(PlayerOpponentSummary.GetPlayerOpponentSummary(dr));
				IsReadOnly = true;
			}
		}
		#endregion

	}
}
