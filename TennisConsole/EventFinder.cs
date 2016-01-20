using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisModel;

namespace TennisConsole
{
	public static class EventFinder
	{
		static TennisDb db = new TennisDb();

		public static TennisEvent[] FindEvents(string name)
		{
			//db.Database.Log = System.Console.WriteLine;
			var events = from _event in db.Events where (_event.Name == name) select _event;
			return events.ToArray();
		}

		public static TennisEvent FindEvent(string name)
		{
			var events = FindEvents(name);
			if (events.Length == 0)
				throw new ApplicationException("No matching events found for '" + name + "'.");
			if (events.Length > 1)
				throw new ApplicationException("Multiple matching events for '" + name + "'.");
			return events.First();
		}
	}
}
