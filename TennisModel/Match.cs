using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public class Match
	{
		public Match()
		{
			Score = new MatchScore();
		}

		public int ID { get; set; }
		public int EventID { get; set; }
		public DateTime Date { get; set; }
		public int WinnerID { get; set; }
		public int LoserID { get; set; }
		public MatchScore Score { get; set; }
		public bool Defaulted { get; set; }

		#region String Conversions
		private string ToString(bool includeTiebreaks)
		{
			return string.Format("{0} Player {1} d. Player {2} {3}{4}", Date, WinnerID, LoserID, Score.ToString(includeTiebreaks), Defaulted ? " default" : "");
		}

		public override string ToString()
		{
			return ToString(true);
		}

		public string ToStringWithoutTiebreaks(bool includeTiebreaks)
		{
			return ToString(false);
		}
		#endregion

	}
}
