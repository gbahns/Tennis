using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using Csla;
using Bahns.Data;

namespace TennisObjects
{
	[Serializable]
	public class OpponentMatchSummaryList : ReadOnlyListBase<OpponentMatchSummaryList, MatchSummary>
	{

		private static ILog log = LogManager.GetLogger(typeof(PlayerOpponentSummaryList).ToString());

		#region Shared Methods
		public static OpponentMatchSummaryList Get(long id)
		{
			return (OpponentMatchSummaryList)DataPortal.Fetch(new Criteria(id));
		}
		#endregion

		#region Constructors
		private OpponentMatchSummaryList()
		{
		}
		#endregion

		#region Criteria
		[Serializable()]
		private class Criteria
		{
			public long id;
			public Criteria(long id)
			{
				this.id = id;
			}
		}
		#endregion

		#region Data Access
		protected override void DataPortal_Fetch(object Criteria)
		{
			Criteria crit = (Criteria)Criteria;
			using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_match_summary_opponents", crit.id))
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
