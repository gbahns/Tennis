using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public class MatchScore
	{
		public MatchScore()
		{
			Sets = new List<Set>(2);
		}

		public List<Set> Sets { get; set; }

		public string ToString(bool includeTiebreaks)
		{
			System.Text.StringBuilder s = new System.Text.StringBuilder();
			foreach (var set in Sets)
			{
				s.Append(set.ToString(includeTiebreaks));
				s.Append(" ");
			}
			return s.ToString().Trim();
		}

		public override string ToString()
		{
			return ToString(true);
		}

		public string ToStringWithoutTiebreaks()
		{
			return ToString(false);
		}

	}
}
