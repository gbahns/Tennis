using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;

namespace TennisLogic
{
	public static class DynamicMatchParser
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
					List<Set> sets = BaseMatchParser.parseMatchScore(token);
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

		public static PlayerMatch parseMatchMultiLine(this string matchString)
		{
			var match = new PlayerMatch();
			return match;
		}

		public static PlayerMatch CreateMatchFromString(string s)
		{
			Console.Write(s.Replace('\t', ' ').PadRight(45));
			var match = DynamicMatchParser.parseMatch(s);
			match.EventID = 1;
			match.PlayerID = 1;
			Console.Write(match.ToString().PadRight(63));
			return match;
		}
	}
}
