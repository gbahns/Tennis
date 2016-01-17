using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;

namespace TennisLogic
{
	public static class MatchConverter
	{
		public static PlayerMatch ToPlayerMatch(this Match source, int playerID)
		{
			var match = new PlayerMatch();
			match.ID = source.ID;
			match.Date = source.Date;
			match.EventID = source.EventID;
			//playerMatch.EventName = match.ev
			//TennisEvent TennisEvent = Match.Events.Find(Match.EventID);
			//TennisEvent TennisEvent = TennisEvent.Get(Match.EventID);
			//playerMatch.EventName = TennisEvent.Name;
			//playerMatch.ClassID = TennisEvent.ClassificationID;
			//playerMatch.ClassName = "";

			match.Result = (playerID == source.WinnerID ? "W" : "L");
			match.OpponentID = (playerID == source.WinnerID ? source.LoserID : source.WinnerID);
			//playerMatch.OpponentName = Player.Get(_OpponentID).FullName;
			match.Score.Sets.AddRange(source.Score.Sets);
			return match;
		}

		public static Match ToMatch(this PlayerMatch source)
		{
			var match = new Match();
			match.ID = source.ID;
			match.EventID = source.EventID;
			match.Date = source.Date;
			match.WinnerID = source.Result == "W" ? source.PlayerID : source.OpponentID;
			match.LoserID = source.Result == "L" ? source.PlayerID : source.OpponentID; ;
			match.Score.Sets.AddRange(source.Score.Sets);
			match.Defaulted = source.Defaulted;

			//playerMatch.EventName = match.ev
			//TennisEvent TennisEvent = Match.Events.Find(Match.EventID);
			//TennisEvent TennisEvent = TennisEvent.Get(Match.EventID);
			//playerMatch.EventName = TennisEvent.Name;
			//playerMatch.ClassID = TennisEvent.ClassificationID;
			//playerMatch.ClassName = "";

			//playerMatch.OpponentName = Player.Get(_OpponentID).FullName;
			return match;
		}

		private static void AddSet(this Match match, byte winnerGames, byte loserGames, byte? winnerTiebreak, byte? loserTiebreak)
		{
			var set = new Set();
			set.Games.W = winnerGames;
			set.Games.L = loserGames;
			if (!set.Games.Played)
				return;
			set.Tiebreak.W = winnerTiebreak.HasValue ? winnerTiebreak.Value : (byte)0;
			set.Tiebreak.L = loserTiebreak.HasValue ? loserTiebreak.Value : (byte)0;
			match.Score.Sets.Add(set);
		}

		private static void AddSet(this Match match, byte? winnerGames, byte? loserGames, byte? winnerTiebreak, byte? loserTiebreak)
		{
			if (winnerGames.HasValue && loserGames.HasValue)
				match.AddSet(winnerGames.Value, loserGames.Value, winnerTiebreak, loserTiebreak);
		}

		public static MatchRaw ToMatchRaw(this Match source)
		{
			var match = new MatchRaw();
			match.ID = source.ID;
			match.EventID = source.EventID;
			match.Date = source.Date;
			match.WinnerID = source.WinnerID;
			match.LoserID = source.LoserID;
			match.Defaulted = source.Defaulted;

			match.WinnerSet1 = source.Score.Sets[0].Games.W;
			match.LoserSet1 = source.Score.Sets[0].Games.L;
			match.WinnerTiebreak1 = source.Score.Sets[0].Tiebreak.W;
			match.LoserTiebreak1 = source.Score.Sets[0].Tiebreak.L;

			if (source.Score.Sets.Count >= 2)
			{
				match.WinnerSet2 = source.Score.Sets[1].Games.W;
				match.LoserSet2 = source.Score.Sets[1].Games.L;
				match.WinnerTiebreak2 = source.Score.Sets[1].Tiebreak.W;
				match.LoserTiebreak2 = source.Score.Sets[1].Tiebreak.L;
			}

			if (source.Score.Sets.Count >= 3)
			{
				match.WinnerSet3 = source.Score.Sets[2].Games.W;
				match.LoserSet3 = source.Score.Sets[2].Games.L;
				match.WinnerTiebreak3 = source.Score.Sets[2].Tiebreak.W;
				match.LoserTiebreak3 = source.Score.Sets[2].Tiebreak.L;
			}

			if (source.Score.Sets.Count >= 4)
			{
				match.WinnerSet4 = source.Score.Sets[3].Games.W;
				match.LoserSet4 = source.Score.Sets[3].Games.L;
				match.WinnerTiebreak4 = source.Score.Sets[3].Tiebreak.W;
				match.LoserTiebreak4 = source.Score.Sets[3].Tiebreak.L;
			}

			if (source.Score.Sets.Count >= 5)
			{
				match.WinnerSet5 = source.Score.Sets[4].Games.W;
				match.LoserSet5 = source.Score.Sets[4].Games.L;
				match.WinnerTiebreak5 = source.Score.Sets[4].Tiebreak.W;
				match.LoserTiebreak5 = source.Score.Sets[4].Tiebreak.L;
			}

			return match;
		}

		public static Match ToMatch(this MatchRaw source)
		{
			var match = new Match();
			match.ID = source.ID;
			match.EventID = source.EventID;
			match.Date = source.Date;
			match.WinnerID = source.WinnerID;
			match.LoserID = source.LoserID;
			match.Defaulted = source.Defaulted;
			match.AddSet(source.WinnerSet1, source.LoserSet1, source.WinnerTiebreak1, source.LoserTiebreak1);
			match.AddSet(source.WinnerSet2, source.LoserSet2, source.WinnerTiebreak2, source.LoserTiebreak2);
			match.AddSet(source.WinnerSet3, source.LoserSet3, source.WinnerTiebreak3, source.LoserTiebreak3);
			match.AddSet(source.WinnerSet4, source.LoserSet4, source.WinnerTiebreak4, source.LoserTiebreak4);
			match.AddSet(source.WinnerSet5, source.LoserSet5, source.WinnerTiebreak5, source.LoserTiebreak5);
			return match;
		}
	}
}
