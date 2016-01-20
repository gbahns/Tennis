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
		static TennisDb db = new TennisDb();
		static TennisDb playersDb = new TennisDb();

		class MatchComparer : IComparer<PlayerMatch>
		{
			public int Compare(PlayerMatch x, PlayerMatch y)
			{
				return x.Date.CompareTo(y.Date);
			}
		}

		static string matchFormat = "{0,-60} {1,-21} {2,-3} {3,-22} {4,-20} {5,-25} {6,-28} {7,-20} {8}";

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
				var consoleBuffer = new StringBuilder();

				while (reader.Peek() >= 0)
				{
					var s = reader.ReadLine();
					if (s.Contains("Result"))
					{
						consoleBuffer.AppendFormat(matchFormat,
							s,
							"Date",
							"W/L",
							"Opponent",
							"Home",
							"Score",
							"Event",
							"Location",
							"Comments");
						consoleBuffer.AppendLine();

						columns = s.Split(',');
					}
					else
					{
						var values = StructuredMatchParser.parseRow(s, columns);
						var match = new PlayerMatch();

						match.PlayerID = 1;

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
						consoleBuffer.AppendFormat(matchFormat,
							s.Substring(0, Math.Min(60, s.Length)),
							match.Date.ToString("yyyy-MM-dd hh:mm tt"),
							match.Result,
							(opponent.Id != 0 ? opponent.Id.ToString("D3") : "---") + " " + opponent.FullName,
							opponentHomeClub.ID.ToString("D3") + " " + opponentHomeClub.Name,
							match.Score.ToString(true) + (match.Defaulted ? " default" : ""),
							(match.EventID != 0 ? match.EventID.ToString("D3") : "---") + " " + match.EventName,
							(match.LocationID != 0 ? match.LocationID.ToString("D3") : "---") + " " + match.LocationName,
							match.Comments
							);
						consoleBuffer.AppendLine();

						matchList.Add(match);
					}
				}

				Console.WriteLine(consoleBuffer);

				foreach (var match in matchList)
				{
					Console.Write(match.ToString().PadRight(63));

					var matchToSave = match.ToMatch();

					Console.WriteLine(matchToSave.EventID + ": " + matchToSave);

					var matchRaw = matchToSave.ToMatchRaw();
					db.Matches.Add(matchRaw);
				}

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
