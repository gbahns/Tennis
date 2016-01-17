using System;
using TennisLogic;
using Xunit;

namespace TennisTests.MatchParse
{
	public class isScoreTests
	{
		[Theory]
		[InlineData("64")]
		[InlineData("6-4")]
		[InlineData("10")]
		[InlineData("97")]
		[InlineData("13-11")]
		[InlineData("10-4")]
		[InlineData("10(75)")]
		[InlineData("10(74)")]
		[InlineData("36 10(75) 10(74)")]
		[InlineData("63 62")]
		[InlineData("64 64")]
		[InlineData("76(54) 13 10(54)")]
		[InlineData("64 50")]
		[InlineData("62 61")]
		[InlineData("63 62")]
		[InlineData("62 62")]
		[InlineData("74 42")]
		[InlineData("76(13-11) 32")]
		[InlineData("63 03 10(10-8)")]
		[InlineData("62 62")]
		[InlineData("16 63 32(52)")]
		[InlineData("75 63")]
		[InlineData("75 32(53)")]
		[InlineData("75 62")]
		[InlineData("63 60")]
		[InlineData("75 32(53)")]
		[InlineData("60 62")]
		[InlineData("64 26 10(71)")]
		[InlineData("61 61")]
		[InlineData(" 64 64")]
		[InlineData(" 64 10(51)")]
		[InlineData("60 46 10(71)")]
		[InlineData(" 64 10(53)")]
		[InlineData("76(97) 63")]
		[InlineData("6-4 7-5")]
		[InlineData("61 13 10(74)")]
		[InlineData("64 75")]
		[InlineData("06 61 76(74)")]
		public void Input_Is_A_Score(string input)
		{
			//var array = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			//foreach (var token in array)
			//	Assert.True(MatchParser.isScore(token), token);
			Assert.True(MatchParser.isScore(input), input);
		}

		[Theory]
		[InlineData("")]
		[InlineData("63 26 1")]
		[InlineData("10(75")]
		[InlineData("10(75 )")]
		[InlineData("10-75)")]
		[InlineData("0")]
		[InlineData("00")]
		[InlineData("000")]
		[InlineData("5")]
		[InlineData("107")]
		[InlineData("100")]
		[InlineData("999")]
		[InlineData("123")]
		[InlineData("529")]
		[InlineData("1043")]
		[InlineData("W")]
		[InlineData("L")]
		[InlineData("Win")]
		[InlineData("Loss")]
		[InlineData("WIN")]
		[InlineData("LOSS")]
		[InlineData("Will")]
		[InlineData("Lonne")]
		[InlineData("Rutherford")]
		public void Input_Is_Not_A_Score(string token)
		{
			Assert.False(MatchParser.isScore(token));
		}
	}
}
