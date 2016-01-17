using System;
using TennisLogic;
using Xunit;

namespace TennisTests.MatchParse
{
	public class isVictoryIndicatorTests
	{
		[Theory]
		[InlineData("W")]
		[InlineData("L")]
		[InlineData("Win")]
		[InlineData("Loss")]
		[InlineData("WIN")]
		[InlineData("LOSS")]
		public void Input_Is_A_Victory_Indicator(string token)
		{
			Assert.True(token.isVictoryIndicator());
		}

		[Theory]
		[InlineData("Will")]
		[InlineData("Lonne")]
		[InlineData("")]
		public void Input_Is_Not_A_Victory_Indicator(string token)
		{
			Assert.False(token.isVictoryIndicator());
		}
	}
}
