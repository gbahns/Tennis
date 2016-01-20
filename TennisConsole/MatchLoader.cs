using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisLogic;
using TennisModel;

namespace TennisConsole
{
	public class MatchLoader
	{
		/*static string matchesToImport =
@"L	Gilbert	36 10(75) 10(74)	3/20/13 6:15 AM
L	Scott	63 62	4/3/13 6:00 AM
W	Gene	64 64	4/26/13 12:00 AM
L	Ashish	76(54) 13 10(54)	5/10/13 6:00 AM
L	Steve	64 50	5/3/13 6:00 AM
L	Andy Keene	62 61	5/11/13 10:30 AM
L	Joe Rohs	63 62	5/11/13 12:30 PM
L	Scott	62 62	5/17/13 7:00 AM
L	Scott	74 42	5/24/13 7:00 AM
L	Scott	76(13-11) 32	5/29/13 7:00 AM
L	Scott	63 03 10(10-8)	6/21/13 6:00 AM
L	Scott	62 62	7/29/13 6:30 AM
L	Chris Mark	16 63 32(52)	8/2/13 6:00 AM
L	Scott	75 63	8/9/13 7:00 AM
L	Kalonji	75 32(53)	8/15/13 6:00 AM
L	Scott	75 62	8/16/13 7:30 AM
L	Scott	63 60	8/28/13 6:45 AM
L	Chris Mark	75 32(53)	9/11/13 6:00 AM
L	Scott	60 62	9/13/13 6:00 AM
W	Greg Benton	64 26 10(71)	3/5/14 7:00 AM
L	Gene	61 61	4/2/14 6:00 AM
L	Chris Mark	 64 64	4/4/14 6:00 AM
W	Kalonji	 64 10(51)	4/7/14 6:00 AM
L	Jay	60 46 10(71)	4/9/14 6:00 AM
L	Kalonji	 64 10(53)	4/11/14 6:00 AM
w	Garth	76(97) 63	4/18/14 6:00 AM
W	Garth	6-4 7-5	4/25/14 6:00 AM
W	Gene	61 13 10(74)	4/28/14 12:00 AM
W	Garth	64 75	4/30/14 12:00 AM
W	Gene	06 61 76(74)	5/2/14 12:00 AM
L Kalonji 64 8am 12/31/2014
w Garth 46 62 10(10-5) 7am 12/29/2014
L Steve 61 63 10/22/2014
L Jesse 75 62  10/20/2014
W gene 57 60 61 10/10/2014
L Jim Tempfli 76(52) 32(53) 10/11/2014
L Scott 76(86) 64 10/1/2014
W Garth 63 61 10/3/2014
L Garth 75 26 10(86) 9/17/2014
L Kalonji 75 9/15/2014
W Garth 46 64 60 6am 9/3/2014
L Steve 62 64 6:00am 8/29/2014
W Gene 64 62 8/20/2014
L Garth 61 64 8/15/2014
L Scott 62 61 8/4/2014
W gene 75 32 default 7/25/2014
W gene 63 16 10(53) 7/23/2014
W Kalonji 36 41 10(53) 7/21/2014
L Scott 63 76(75) 7/5/2014
L Scott 64 61 7/14/2014
L Jesse 62 24 10(74) 7/10/2014
L Steve 63 60 7/9/2014
W gene 36 43(74) 10(97) 7/7/2014
W Gene 46 51 10(51) 6/30/2014
L Chris 62 62 7/2/2014
L Kalonji 76(53) 01(15) 10(53) 7/3/2014
W Garth 63 61 6/27/2014
L Kalonji 62 40 6/26/2014
L Scott 64 76(72) 6/6/2014
W Jay 36 52 10(75) 6/4/2014
L Scott 62 26 61 6/2/2014
L Kalonji 65(54) 10(54) 5/30/2014
W Gene 62 76(73) 5/28/2014
W Gene 63 64 6am 5/23/2014
L Chris Mark 64 61 5/16/2014
W Gene 75 63 5/14/2014
W ? (harpers) 64 61 5/3/2014
W Kalonji 76(54) 10(54) 5/12/2014
";

static string matchesToImport =
@"L Scott 61 64 9/21
W Garth 63 62 9/18
W Kalonji 61 23(15) 10(52) 9/14
W John Augsbark (Mercy Anderson) 63 60 9/13/2015 2pm
L Scott 64 61 9/11
L Scott 75 42 9/9
W Kalonji 63 61 9/5
W Gene 63 62 9/4
W Tuck Stites (qc) 64 35 10(52) 8/30/2015 1:30pm
L Scott 63 46 41 8/21
L Steve 61 57 10(53) 8/14
W Gene 61 63 8/12
L Kalonji 26 64 10(74) 7am 8/4
W Gene 61 46 42 6am 8/7
L Scott 61 62 7/31
W Kalonji 46 62 10(52) 7/27
W Garth 46 62 10(72) 7/29
L Joe 62 67(35) 10(53) 6am 7/10
W Kalonji 64 10(53) 6:30am 7/13
W Kalonji 62 31 7/3
L Garth 64 76(86) 7/1
L Jesse 61 62 6am 3/23
L Lee 62 64 6am 4/3
L Scott 63 64 6am 3/20
L Gene 63 64 6:00am  3/18
L Jesse 62 3/16 7:30am
L Suraj 63 64 3/11/2015 6am
";*/

		static TennisDb db = new TennisDb();
		static TennisDb playersDb = new TennisDb();

		class MatchComparer : IComparer<PlayerMatch>
		{
			public int Compare(PlayerMatch x, PlayerMatch y)
			{
				return x.Date.CompareTo(y.Date);
			}
		}

		static string matchFormat = "{0,-102} {1,-21} {2,-3} {3,-22} {4,-20} {5,-25} {6,-28} {7}";

		public static string[] ParseHeaderRow(string s)
		{

			Console.WriteLine(matchFormat,
				s,
				"Date",
				"W/L",
				"Opponent",
				"Home",
				"Score",
				"Event",
				"Location");

			return s.Split(',');
		}

		public static void LoadMatches(IGenericReader reader)
		{
			try
			{
				//Console.WriteLine("Database: " + ConfigPeeker.DbServerAndName("/configuration/connectionStrings/add/@connectionString"));
				Console.WriteLine("DbServer: " + ConfigPeeker.Value("/configuration/connectionStrings/add/@connectionString", "data source"));
				Console.WriteLine("Database: " + ConfigPeeker.Value("/configuration/connectionStrings/add/@connectionString", "initial catalog"));
				//Console.WriteLine("Database: " + ConfigPeeker.Value())
				Console.WriteLine();

				string[] columns = null;
				var matchList = new SortedSet<PlayerMatch>(new MatchComparer());

				while (reader.Peek() >= 0)
				{
					var s = reader.ReadLine();
					if (s.Contains("Result"))
						columns = ParseHeaderRow(s);
					else
					{
						var values = StructuredMatchParser.parseRow(s, columns);
						var match = new PlayerMatch();

						var _event = EventFinder.FindEvent(values.Event);
						match.EventID = _event.ID;
						match.EventName = _event.Name;

						var location = LocationFinder.FindLocation(values.Location);
						match.LocationID = location.ID;
						match.LocationName = location.Name;

						Location opponentHomeClub = LocationFinder.FindLocation(values.Club);
						Player opponent = PlayerFinder.AddOrFindPlayer(values.Opponent, opponentHomeClub);
						match.OpponentID = opponent.Id;
						match.OpponentName = opponent.FullName;
						opponentHomeClub = LocationFinder.GetLocationById(opponent.HomeLocationId);

						StructuredMatchParser.setResult(match, values.Result);
						StructuredMatchParser.setScore(match, values.Score);
						match.Date = DateTime.Parse(values.Date) + DateTime.Parse(values.Time).TimeOfDay;
						match.Comments = values.Comments;

						//Console.WriteLine(opponent.Id + ":" + opponent.FullName);
						Console.WriteLine(matchFormat,
							s,
							match.Date.ToString("yyyy-MM-dd hh:mm tt"),
							match.Result,
							(opponent.Id != 0 ? opponent.Id.ToString("D3") : "---") + " " + opponent.FullName,
							opponentHomeClub.ID.ToString("D3") + " " + opponentHomeClub.Name,
							match.Score.ToString(true) + (match.Defaulted ? " default" : ""),
							(match.EventID != 0 ? match.EventID.ToString("D3") : "---") + " " + match.EventName,
							(match.LocationID != 0 ? match.LocationID.ToString("D3") : "---") + " " + match.LocationName
							);

						matchList.Add(match);
					}
				}

				Console.WriteLine();

				//foreach (var match in matchList)
				//{
				//	Console.Write(match.ToString().PadRight(63));

				//	var matchToSave = match.ToMatch();

				//	Console.WriteLine(matchToSave.EventID + ": " + matchToSave);

				//	var matchRaw = matchToSave.ToMatchRaw();
				//	db.Matches.Add(matchRaw);
				//}

				//Console.WriteLine();
				//Console.Write("Saving new matches...");
				//int result = db.SaveChanges();
				//Console.WriteLine("({0}) Done.", result);

				Console.WriteLine();
				//foreach (var match in db.Matches)
				//{
				//	Console.WriteLine("{0} Player {1} d. Player {2} {3}-{4} {5}-{6} {7}-{8}{9}", match.Date, match.WinnerID, match.LoserID, match.WinnerSet1, match.LoserSet1, match.WinnerSet2, match.LoserSet2, match.WinnerSet3, match.LoserSet3, match.Defaulted ? " default" : "");
				//}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		//public static void LoadMatchesFromString()
		//{
		//	LoadMatches(new MyStringReader(matchesToImport));
		//}

		public static void LoadMatchesFromFile(string filename)
		{
			LoadMatches(new MyFileReader(filename));
		}
	}
}
