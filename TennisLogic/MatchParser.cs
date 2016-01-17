using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;

namespace TennisLogic
{
    public static class MatchParser
    {
		public static bool isVictoryIndicator(this string token)
		{
			HashSet<string> tokenSet = new HashSet<string> { "W", "L", "WIN", "LOSS" };
			return (tokenSet.Contains(token.ToUpper()));
		}

		public static bool isScore(this string token)
		{
			token = token.Trim();

			//two zeroes can't be a valid score
			if (token == "00")
				return false;

			//match the following:
			//1. two digits, e.g. "64"
			//2. two numeric values separated by a dash, e.g. "6-4", "10-7", or "13-11"
			//3. the above followed by a tiebreaks score, e.g. "76(71)", "10(10-7)", or "7-6(7-1)"
			string gamesAndOptionalTiebreakWithOrWithoutDashes = @"^((\d\d|\d+-\d+)(\((\d\d|\d+-\d+)\))?( |$))+$";
			if (System.Text.RegularExpressions.Regex.IsMatch(token, gamesAndOptionalTiebreakWithOrWithoutDashes))
				return true;

			return false;
		}

		public static Score parseScore(this string scoreString)
		{
			if (scoreString.Length == 2)
				scoreString = scoreString.Insert(1, "-");

			string[] scores = scoreString.Split('-');
			Score score = new Score();
			score.W = byte.Parse(scores[0]);
			score.L = byte.Parse(scores[1]);
			return score;
		}

		public static Set parseSetScore(this string setString)
		{
			setString = setString.Replace(" ","");
			string[] scores = setString.Split("()".ToCharArray());
			Set set = new Set();
			set.Games = parseScore(scores[0]);
			if (scores.Length > 1)
				set.Tiebreak = parseScore(scores[1]);
			return set;
		}

		public static List<Set> parseMatchScore(this string scoreString)
		{
			//example: 64
			//example: 6-4
			//example: 64 75
			//example: 36 10(75) 10(74)
			List<Set> setList = new List<Set>(5);
			var array = scoreString.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			foreach (var setString in array)
			{
				var set = parseSetScore(setString);
				setList.Add(set);
			}
			setList.Capacity = setList.Count;
			return setList;
		}

		public static void setResult(PlayerMatch match, string token)
		{
			if (match.Result != "")
				throw new FormatException("Match result is specified twice.");
			match.Result = token.Substring(0, 1).ToUpper();
		}

		public static void setOpponent(PlayerMatch match, string token)
		{
			match.OpponentName = token;
		}

		public static void setScore(PlayerMatch match, string token)
		{
			token = token.ToLower();
			if (token.Contains("default"))
			{
				match.Defaulted = true;
				token = token.Replace("default", "");
			}
			List<Set> sets = parseMatchScore(token);
			match.Score.Sets.AddRange(sets);
		}

		public static PlayerMatch parseMatch(this string matchString)
		{
			var match = new PlayerMatch();
			var matchDate = match.Date;
			var delimiter = matchString.Contains("\t") ? "\t" : matchString.Contains(",") ? "," : " ";
			var array = matchString.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			foreach (var token in array)
			{
				if (isVictoryIndicator(token))
				{
					if (match.Result != "")
						throw new FormatException("Match result is specified twice.");
					match.Result = token.Substring(0, 1).ToUpper();
				}
				else if (isScore(token))
				{
					List<Set> sets = parseMatchScore(token);
					match.Score.Sets.AddRange(sets);
				}
				else if (DateTime.TryParse(token, out matchDate))
				{
					if (!token.ToUpper().Contains('M'))
					{
						if (match.Date != DateTime.MinValue)
						{
							//we already have the time, add the date
							match.Date = matchDate + match.Date.TimeOfDay;
						}
						else
						{
							//set the date and default the time to 6am
							match.Date = matchDate + new TimeSpan(6, 0, 0);
						}
					}
					else
					{
						if (match.Date != DateTime.MinValue)
						{
							//we already have the date, add the time
							match.Date = match.Date.Date + matchDate.TimeOfDay;
						}
						else
						{
							//given just the time, DateTime.TryParse deaults to today's date
							match.Date = matchDate;
						}
					}
				}
				else if (token.ToLower() == "default")
				{
					match.Defaulted = true;
				}
				else if (token.ToLower() == "am" || token.ToLower() == "pm")
				{
					throw new FormatException("Space-delimited rows cannot contain spaces in date-time values.");
				}
				else
				{
					if (match.OpponentName.Length > 0)
						match.OpponentName += " ";
					match.OpponentName += token;
				}
			}
			return match;
		}

		public static PlayerMatch parseMatch(this string matchString, string[] columns)
		{
			var match = new PlayerMatch();
			var matchDate = match.Date;
			var delimiter = matchString.Contains("\t") ? "\t" : matchString.Contains(",") ? "," : " ";
			var array = matchString.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			int currentColumn = 0;

			foreach (var token in array)
			{
				switch (columns[currentColumn])
				{
					case "Result":
						setResult(match, token);
						break;
						
					case "Opponent":
						setOpponent(match, token);
						break;

					case "Score":
						setScore(match, token);
						break;

					case "Date":
						match.Date = DateTime.Parse(token) + new TimeSpan(6, 0, 0);
						break;

					case "Time":
						match.Date = match.Date.Date + DateTime.Parse(token).TimeOfDay;
						break;
				}

				currentColumn++;
			}

			return match;
		}

		public static PlayerMatch parseMatchMultiLine(this string matchString)
		{
			var match = new PlayerMatch();
			return match;
		}
	}
}
