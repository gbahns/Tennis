using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisModel;

namespace TennisConsole
{
	public static class LocationFinder
	{
		static TennisDb db = new TennisDb();

		public static Location[] FindLocations(string name)
		{
			var locations = from location in db.Locations where name == location.Name select location;
			return locations.ToArray();
		}

		public static Location[] FindLocationsContaining(string name)
		{
			var locations = from location in db.Locations where location.Name.Contains(name) select location;
			return locations.ToArray();
		}

		public static Location FindLocation(string name)
		{
			var location = FindLocations(name);
			if (location.Length == 0)
				location = FindLocationsContaining(name);
				//throw new ApplicationException("No matching locations found for '" + name + "'.");
			if (location.Length > 1)
				throw new ApplicationException("Multiple matching locations found for '" + name + "'.");
			return location.First();
		}

		public static Location GetLocationById(int locationId)
		{
			return db.Locations.Find(locationId);
		}
	}
}
