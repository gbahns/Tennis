using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;

namespace TennisLogic
{
	public static class StructuredMatchParser
	{


		public static void setResult(PlayerMatch match, string token)
		{
			if (match.Result != "")
				throw new FormatException("Match result is specified twice.");
			match.Result = token.Substring(0, 1).ToUpper();
		}

		public static void setScore(PlayerMatch match, string token)
		{
			token = token.ToLower();
			if (token.Contains("default"))
			{
				match.Defaulted = true;
				token = token.Replace("default", "");
			}
			List<Set> sets = BaseMatchParser.parseMatchScore(token);
			match.Score.Sets.AddRange(sets);
		}

		public static dynamic parseRow(this string matchString, string[] columns)
		{
			var defaults = new Dictionary<string, string>()
			{
				{"Event", "Open Play"},
				{"Location", "Courtyard"},
				{"Club", "Courtyard"},
				{"Time", "6am"},
				{"Comments", ""},
			};

			var delimiter = matchString.Contains("\t") ? "\t" : matchString.Contains(",") ? "," : " ";
			var array = matchString.Split(delimiter.ToCharArray(), StringSplitOptions.None);
			//var values = new Dictionary<string, string>();
			dynamic expando = new ExpandoObject();
			var values = (IDictionary<string, object>)expando;

			for (int i = 0; i < array.Length; i++)
			{
				var key = columns[i];
				var value = array[i];
				if (value == "")
					value = defaults[key];
				values.Add(key, value);
			}

			return values;
		}
	}
}
