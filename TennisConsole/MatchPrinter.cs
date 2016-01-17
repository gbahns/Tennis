using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisLogic;
using TennisModel;

namespace TennisConsole
{
	class MatchPrinter
	{
		public static void PrintMatches()
		{
			TennisDb db = new TennisDb();
			TennisDb dbPlayer = new TennisDb();

			Console.WriteLine();
			foreach (var matchRaw in db.Matches)
			{
				var match = matchRaw.ToMatch();
				var playerMatch = match.ToPlayerMatch(1);
				var opponent = dbPlayer.Players.Find(playerMatch.OpponentID);
				//Console.Write(match.ToString().PadRight(80));
				//Console.WriteLine(playerMatch.ToString());
				//Console.WriteLine("{0} Player {1} d. Player {2} {3}-{4} {5}-{6} {7}-{8}{9}", match.Date, playerMatch.OpponentName, match.Score, match.Defaulted ? " default" : "");
				Console.WriteLine("{0},{1},{2},{3}", match.Date, opponent.FullName, playerMatch.Result, playerMatch.Score);
			}
		}
	}
}
