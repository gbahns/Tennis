using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TennisModel
{
	[Table("Matches")]
	public class MatchRaw
	{
		public int ID { get; set; }
		public int EventID { get; set; }
		public DateTime Date { get; set; }
		public int WinnerID { get; set; }
		public int LoserID { get; set; }

		public byte WinnerSet1 { get; set; }
		public byte LoserSet1 { get; set; }
		public byte? WinnerTiebreak1 { get; set; }
		public byte? LoserTiebreak1 { get; set; }

		public byte? WinnerSet2 { get; set; }
		public byte? LoserSet2 { get; set; }
		public byte? WinnerTiebreak2 { get; set; }
		public byte? LoserTiebreak2 { get; set; }

		public byte? WinnerSet3 { get; set; }
		public byte? LoserSet3 { get; set; }
		public byte? WinnerTiebreak3 { get; set; }
		public byte? LoserTiebreak3 { get; set; }

		public byte? WinnerSet4 { get; set; }
		public byte? LoserSet4 { get; set; }
		public byte? WinnerTiebreak4 { get; set; }
		public byte? LoserTiebreak4 { get; set; }

		public byte? WinnerSet5 { get; set; }
		public byte? LoserSet5 { get; set; }
		public byte? WinnerTiebreak5 { get; set; }
		public byte? LoserTiebreak5 { get; set; }

		public bool Defaulted { get; set; }
	}
}
