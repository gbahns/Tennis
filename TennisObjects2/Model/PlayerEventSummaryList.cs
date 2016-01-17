using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable()]
	public class PlayerEventSummaryList : ReadOnlyListBase<PlayerEventSummaryList, PlayerEventSummary>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerEventSummaryList).ToString());

		#region Business Properties and Methods
		//public PlayerEventSummary item
		//{
		//    get { return (PlayerEventSummary)List.Item(index); }
		//}
		#endregion

		#region Contains
		//public bool Contains(PlayerEventSummary item)
		//{
		//    foreach (PlayerEventSummary child in List)
		//    {
		//        if (child.Equals(item))
		//        {
		//            return true;
		//        }
		//    }
		//    return false;
		//}
		#endregion

		#region Shared Methods
		public static PlayerEventSummaryList GetPlayerEventSummaryList(long PlayerID)
		{
			return (PlayerEventSummaryList)DataPortal.Fetch(new Criteria(PlayerID));
		}
		#endregion

		#region Constructors
		private PlayerEventSummaryList()
		{
			//AllowSort = true;
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
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_player_summary_events", crit.PlayerID))
			{
				IsReadOnly = false;
				while (dr.Read())
					Add(PlayerEventSummary.GetPlayerEventSummary(dr));
				IsReadOnly = true;
			}
		}
		#endregion

	}
}
