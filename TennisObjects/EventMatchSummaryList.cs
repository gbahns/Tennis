using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable]
	public class EventMatchSummaryList : ReadOnlyListBase<EventMatchSummaryList, MatchSummary>
	{
		private static ILog log = LogManager.GetLogger(typeof(PlayerOpponentSummaryList).ToString());

		#region Static Methods
		public static EventMatchSummaryList Get(long id)
		{
			return (EventMatchSummaryList)DataPortal.Fetch(new Criteria(id));
		}

		public static EventMatchSummaryList Get(long id, EventTypeEnum eventType)
		{
			return (EventMatchSummaryList)DataPortal.Fetch(new Criteria(id, eventType));
		}
		#endregion

		#region Constructors
		private EventMatchSummaryList()
		{
		}
		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public long id;
			public EventTypeEnum eventType;
			public Criteria(long id)
			{
				this.id = id;
			}
			public Criteria(long id, EventTypeEnum eventType)
			{
				this.id = id;
				this.eventType = eventType;
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_match_summary_events", crit.id, crit.eventType == EventTypeEnum.All ? (object)DBNull.Value : (object)crit.eventType))
			{
				IsReadOnly = false;
				while (dr.Read())
					Add(MatchSummary.Get(dr));
				IsReadOnly = true;
			}
		}
		#endregion
	}
}
