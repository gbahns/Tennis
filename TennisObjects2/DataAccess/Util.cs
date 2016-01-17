using System;
using System.Data;
using Bahns.Data;

namespace TennisObjects.DataAccess
{
	internal class Util
	{
		internal static void ReadFirst(IDataReader dr, string msg, params object[] args)
		{
			if (!dr.Read())
				throw new RecordNotFoundException(string.Format(msg, args));
		}
	}
}
