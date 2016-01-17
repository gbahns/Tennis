using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bahns.Data;

namespace TennisObjects.DataAccess
{
	public class Player
	{

		public static IDataReader GetPlayer(int id)
		{
			IDataReader dr = DbHelper.ExecuteReader("csla_get_player", id);
			Util.ReadFirst(dr,"Player not found (ID:{0})", id);
			return dr;
		}
		
	}
}
