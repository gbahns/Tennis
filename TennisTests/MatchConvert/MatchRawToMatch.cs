using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisModel;
using TennisLogic;
using Xunit;

namespace TennisTests.MatchConvert
{
	public class MatchRawToMatchTests
	{
		[Theory]
		[InlineData(1, 1, 2, 1, "2013-02-05 7:00 AM", "6-4 6-3", false)]
		[InlineData(2, 1, 2, 1, "2013-01-05 06:00 AM", "6-4 6-2", false)]
		[InlineData(3, 1, 2, 1, "2012-12-15 06:00 AM", "6-1 6-0", false)]
		[InlineData(4, 1, 2, 1, "2013-04-03 06:00 AM", "6-3 6-2", false)]
		[InlineData(5, 1, 2, 1, "2013-04-26 12:00 AM", "6-4 6-4", false)]
		[InlineData(6, 1, 2, 1, "2013-05-03 06:00 AM", "6-4 5-0", false)]
		[InlineData(7, 1, 2, 1, "2013-05-11 10:30 AM", "6-2 6-1", false)]
		[InlineData(8, 1, 2, 1, "2013-05-11 12:30 PM", "6-3 6-2", false)]
		[InlineData(9, 1, 2, 1, "2013-03-20 06:15 AM", "3-6 1-0(7-5) 1-0(7-4)", false)]
		[InlineData(0, 1, 2, 1, "2013-05-10 06:00 AM", "7-6(5-4) 1-3 1-0(5-4)", false)]
		public void MatchRawToMatch(int id, int eventID, int winnerID, int loserID, string date, string score, bool defaulted)
		{
			var matchRaw = new MatchRaw();
			matchRaw.ID = id;
			matchRaw.EventID = eventID;
			matchRaw.WinnerID = winnerID;
			matchRaw.LoserID = loserID;
			matchRaw.Date = DateTime.Parse(date);
			var sets = score.parseMatchScore();

			matchRaw.WinnerSet1 = sets[0].Games.W;
			matchRaw.LoserSet1 = sets[0].Games.L;
			matchRaw.WinnerTiebreak1 = sets[0].Tiebreak.W;
			matchRaw.LoserTiebreak1 = sets[0].Tiebreak.L;

			if (sets.Count >= 2)
			{
				matchRaw.WinnerSet2 = sets[1].Games.W;
				matchRaw.LoserSet2 = sets[1].Games.L;
				matchRaw.WinnerTiebreak2 = sets[1].Tiebreak.W;
				matchRaw.LoserTiebreak2 = sets[1].Tiebreak.L;
			}

			if (sets.Count >= 3)
			{
				matchRaw.WinnerSet3 = sets[2].Games.W;
				matchRaw.LoserSet3 = sets[2].Games.L;
				matchRaw.WinnerTiebreak3 = sets[2].Tiebreak.W;
				matchRaw.LoserTiebreak3 = sets[2].Tiebreak.L;
			}

			if (sets.Count >= 4)
			{
				matchRaw.WinnerSet4 = sets[3].Games.W;
				matchRaw.LoserSet4 = sets[3].Games.L;
				matchRaw.WinnerTiebreak4 = sets[3].Tiebreak.W;
				matchRaw.LoserTiebreak4 = sets[3].Tiebreak.L;
			}

			if (sets.Count >= 5)
			{
				matchRaw.WinnerSet5 = sets[4].Games.W;
				matchRaw.LoserSet5 = sets[4].Games.L;
				matchRaw.WinnerTiebreak5 = sets[4].Tiebreak.W;
				matchRaw.LoserTiebreak5 = sets[4].Tiebreak.L;
			}

			matchRaw.Defaulted = false;

			var match = matchRaw.ToMatch();

			Assert.Equal(matchRaw.ID, match.ID);
			Assert.Equal(matchRaw.EventID, match.EventID);
			Assert.Equal(matchRaw.Date, match.Date);
			Assert.Equal(matchRaw.WinnerID, match.WinnerID);
			Assert.Equal(matchRaw.LoserID, match.LoserID);
			Assert.Equal(matchRaw.WinnerSet1, match.Score.Sets[0].Games.W);
			Assert.Equal(matchRaw.LoserSet1, match.Score.Sets[0].Games.L);
			Assert.Equal(matchRaw.WinnerSet2, match.Score.Sets[1].Games.W);
			Assert.Equal(matchRaw.LoserSet2, match.Score.Sets[1].Games.L);
		}

	}
}
