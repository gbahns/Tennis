using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bahns.Data;

namespace TennisObjects.DataAccess
{
	public class TennisEvent
	{

		public static IDataReader GetPlayer(int id)
		{
			IDataReader dr = DbHelper.ExecuteReader("csla_get_player", id);
			Util.ReadFirst(dr,"Player not found (ID:{0})", id);
			return dr;
		}

		//protected override void DataPortal_Fetch(object Criteria)
		//{
		//    Criteria crit = (Criteria)Criteria;
		//    using (SafeDataReader dr = DbHelper.ExecuteReader("csla_get_event", crit.ID))
		//    {
		//        if (!dr.Read())
		//        {
		//            throw new RecordNotFoundException(string.Format("Event not found (ID:{0})", crit.ID));
		//        }
		//        _Fetch(dr);
		//    }
		//    MarkOld();
		//}

		
	}
}
