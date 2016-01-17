using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public class PlayerMatch
	{
		public PlayerMatch()
		{
			EventName = "";
			ClassName = "";
			Result = "";
			OpponentName = "";
			Score = new MatchScore();
		}

		public int ID { get; set; }
		public DateTime Date { get; set; }
		public int EventID { get; set; }
		public string EventName { get; set; }
		public int ClassID { get; set; }
		public string ClassName { get; set; }
		public string Result { get; set; }
		public int PlayerID { get; set; }
		public int OpponentID { get; set; }
		public string OpponentName { get; set; }
		public MatchScore Score { get; set; }
		public bool Defaulted { get; set; }

		#region Old Cruft
		//[DisplayName("Date")]
		//[DisplayFormat(DataFormatString = "{0:d}")]
		//public System.DateTime MatchDateAsDate { get; set; }
		//[DisplayName("Event")]
		//[DisplayName("Class")]
		//[DisplayName("Opponent")]
		#endregion

		#region String Conversions
		private string ToString(bool includeTiebreaks)
		{
			return string.Format("{0} {1} {2} {3}{4}", Date, Result, OpponentName, Score.ToString(includeTiebreaks), Defaulted ? " default" : "");
		}

		public override string ToString()
		{
			return ToString(true);
		}

		public string ToStringWithoutTiebreaks(bool includeTiebreaks)
		{
			return ToString(false);
		}

		/// <summary> 
		/// Return a string showing the score for the match, beginning with a W or L to indicate 
		/// whether the player won or lost, e.g. "W 6-4 3-6 7-6" 
		/// </summary> 
		/// <value></value> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		public string ToResultScore
		{
			get { return Result + " " + Score; }
		}
		#endregion
	}
}
