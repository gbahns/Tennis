using System;
using Xunit;
using TennisModel;
using System.Collections.Generic;
using TennisLogic;
using System.Diagnostics;

namespace TennisTests
{
	public class MatchParseTests
	{
		[Theory]
		[InlineData("W Gene 64 62 1/5/2013", "W", "Gene", "6-4 6-2", "2013-01-05 6:00 AM", false)]
		[InlineData("W Brian 61 60 12/15/2012", "W", "Brian", "6-1 6-0", "2012-12-15 6:00 AM", false)]
		[InlineData("L	Gilbert	36 10(75) 10(74)	3/20/13 6:15 AM", "L", "Gilbert", "3-6 1-0 (7-5) 1-0 (7-4)", "2013-03-20 6:15", false)]
		[InlineData("L	Scott	63 62	4/3/13 6:00 AM", "L", "Scott", "6-3 6-2", "4/3/13 6:00 AM", false)]
		[InlineData("W	Gene	64 64	4/26/13 12:00 AM", "W", "Gene", "6-4 6-4", "4/26/13 12:00 AM", false)]
		[InlineData("L	Ashish	76(54) 13 10(54)	5/10/13 6:00 AM", "L", "Ashish", "7-6 (5-4) 1-3 1-0 (5-4)", "5/10/13 6:00 AM", false)]
		[InlineData("L	Steve	64 50	5/3/13 6:00 AM", "L", "Steve", "6-4 5-0", "5/3/13 6:00 AM", false)]
		[InlineData("L	Andy Keene	62 61	5/11/13 10:30 AM", "L", "Andy Keene", "6-2 6-1", "5/11/13 10:30 AM", false)]
		[InlineData("L	Joe Rohs	63 62	5/11/13 12:30 PM", "L", "Joe Rohs", "6-3 6-2", "5/11/13 12:30 PM", false)]
		[InlineData("L	Scott	62 62	5/17/13 7:00 AM", "L", "Scott", "6-2 6-2", "5/17/13 7:00 AM", false)]
		[InlineData("L	Scott	74 42	5/24/13 7:00 AM", "L", "Scott", "7-4 4-2", "5/24/13 7:00 AM", false)]
		[InlineData("L	Scott	76(13-11) 32	5/29/13 7:00 AM", "L", "Scott", "7-6 (13-11) 3-2", "5/29/13 7:00 AM", false)]
		[InlineData("L	Scott	63 03 10(10-8)	6/21/13 6:00 AM", "L", "Scott", "6-3 0-3 1-0 (10-8)", "6/21/13 6:00 AM", false)]
		[InlineData("L	Scott	62 62	7/29/13 6:30 AM", "L", "Scott", "6-2 6-2", "2013-07-29 6:30", false)]
		[InlineData("L	Chris Mark	16 63 32(52)	8/2/13 6:00 AM", "L", "Chris Mark", "1-6 6-3 3-2 (5-2)", "8/2/13 6:00 AM", false)]
		[InlineData("L	Scott	75 63	8/9/13 7:00 AM", "L", "Scott", "7-5 6-3", "8/9/13 7:00 AM", false)]
		[InlineData("L	Kalonji	75 32(53)	8/15/13 6:00 AM", "L", "Kalonji", "7-5 3-2 (5-3)", "8/15/13 6:00 AM", false)]
		[InlineData("L	Scott	75 62	8/16/13 7:30 AM", "L", "Scott", "7-5 6-2", "8/16/13 7:30 AM", false)]
		[InlineData("L	Scott	63 60	8/28/13 6:45 AM", "L", "Scott", "6-3 6-0", "8/28/13 6:45 AM", false)]
		[InlineData("L	Chris Mark	75 32(53)	9/11/13 6:00 AM", "L", "Chris Mark", "7-5 3-2 (5-3)", "9/11/13 6:00 AM", false)]
		[InlineData("L	Scott	60 62	9/13/13 6:00 AM", "L", "Scott", "6-0 6-2", "9/13/13 6:00 AM", false)]
		[InlineData("W	Greg Benton	64 26 10(71)	3/5/14 7:00 AM", "W", "Greg Benton", "6-4 2-6 1-0 (7-1)", "3/5/14 7:00 AM", false)]
		[InlineData("L	Gene	61 61	4/2/14 6:00 AM", "L", "Gene", "6-1 6-1", "4/2/14 6:00 AM", false)]
		[InlineData("L	Chris Mark	 64 64	4/4/14 6:00 AM", "L", "Chris Mark", "6-4 6-4", "4/4/14 6:00 AM", false)]
		[InlineData("W	Kalonji	 64 10(51)	4/7/14 6:00 AM", "W", "Kalonji", "6-4 1-0 (5-1)", "4/7/14 6:00 AM", false)]
		[InlineData("L	Jay	60 46 10(71)	4/9/14 6:00 AM", "L", "Jay", "6-0 4-6 1-0 (7-1)", "4/9/14 6:00 AM", false)]
		[InlineData("L	Kalonji	 64 10(53)	4/11/14 6:00 AM", "L", "Kalonji", "6-4 1-0 (5-3)", "4/11/14 6:00 AM", false)]
		[InlineData("w	Garth	76(97) 63	4/18/14 6:00 AM", "W", "Garth", "7-6 (9-7) 6-3", "4/18/14 6:00 AM", false)]
		[InlineData("W	Garth	6-4 7-5	4/25/14 6:00 AM", "W", "Garth", "6-4 7-5", "4/25/14 6:00 AM", false)]
		[InlineData("W	Gene	61 13 10(74)	4/28/14 12:00 AM", "W", "Gene", "6-1 1-3 1-0 (7-4)", "4/28/14 12:00 AM", false)]
		[InlineData("W	Garth	64 75	4/30/14 12:00 AM", "W", "Garth", "6-4 7-5", "4/30/14 12:00 AM", false)]
		[InlineData("W	Gene	06 61 76(74)	5/2/14 12:00 AM", "W", "Gene", "0-6 6-1 7-6 (7-4)", "5/2/14 12:00 AM", false)]
		[InlineData("L Kalonji 64 8am 12/31/2014", "L", "Kalonji", "6-4", "12/31/2014 8:00 AM", false)]
		[InlineData("w Garth 46 62 10(10-5) 7am 12/29/2014", "W", "Garth", "4-6 6-2 1-0 (10-5)", "12/29/2014 7:00 AM", false)]
		[InlineData("L Jesse 75 62  10/20/2014", "L", "Jesse", "7-5 6-2", "10/20/2014 6:00 AM", false)]
		[InlineData("L Jimmy Temple 76(52) 32(53) 10/11/2014", "L", "Jimmy Temple", "7-6 (5-2) 3-2 (5-3)", "10/11/2014 6:00 AM", false)]
		[InlineData("L Garth 75 26 10(86) 9/17/2014", "L", "Garth", "7-5 2-6 1-0 (8-6)", "9/17/2014 6:00 AM", false)]
		[InlineData("W gene 75 32 default 7/25/2014", "W", "gene", "7-5 3-2", "7/25/2014 6:00 AM", true)]
		[InlineData("W Gene 63 64 6am 5/23/2014", "W", "Gene", "6-3 6-4", "5/23/2014 6:00 AM", false)]
		[InlineData("L Chris mark 64 61 5/16/2014", "L", "Chris mark", "6-4 6-1", "5/16/2014 6:00 AM", false)]
		[InlineData("W ? (harpers) 64 61 5/3/2014", "W", "? (harpers)", "6-4 6-1", "5/3/2014 6:00 AM", false)]
		[InlineData("L Steve 62 64 6:00am 8/29/2014", "L", "Steve", "6-2 6-4", "8/29/2014 6:00 AM", false)]
		[InlineData("L Suraj 63 64 6am 3/11/2015", "L", "Suraj", "6-3 6-4", "3/11/2015 6:00 AM", false)]
		[InlineData("L Suraj 63 64 3/11/2015 6am", "L", "Suraj", "6-3 6-4", "3/11/2015 6:00 AM", false)]
		public void ParseMatchString(string input, string result, string opponent, string score, string date, bool isDefault)
		{
			PlayerMatch match = DynamicMatchParser.parseMatch(input);
//			Debug.WriteLine(match.ToString());
			Trace.WriteLine(match.ToString());
//			Console.WriteLine(match.ToString());
			Assert.Equal(result, match.Result);
			Assert.Equal(opponent, match.OpponentName);
			Assert.Equal(DateTime.Parse(date), match.Date);
			Assert.Equal(score, match.Score.ToString());
			Assert.Equal(isDefault, match.Defaulted);
		}

		[InlineData("L Steve 62 64 6:00 am 8/29/2014")]
		[InlineData("L Steve 62 64 6:00 pm 8/29/2014")]
		public void SpaceDelimitedRowCannotHaveSpacesInTimeValue(string input)
		{
			Assert.Throws<FormatException>(() => DynamicMatchParser.parseMatch(input));
		}
	}
}
