using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public struct Set
	{
		public Score Games;
		public Score Tiebreak;

		public override string ToString() { return ToString(true); }

		public string ToString(bool includeTiebreaks)
		{
			if (!Games.Played)
			{
				return "";
			}
			else if (Tiebreak.Played && includeTiebreaks)
			{
				return string.Format("{0}-{1} ({2}-{3})", Games.W, Games.L, Tiebreak.W, Tiebreak.L);
			}
			else
			{
				return string.Format("{0}-{1}", Games.W, Games.L);
			}
		}
	}
}
