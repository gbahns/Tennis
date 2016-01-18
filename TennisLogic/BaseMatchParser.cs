using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;

namespace TennisLogic
{
	public static class BaseMatchParser
	{
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
			setString = setString.Replace(" ", "");
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

	}
}
