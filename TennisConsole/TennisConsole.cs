using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisLogic;
using TennisModel;

namespace TennisConsole
{
	class TennisConsole
	{
		static void Main(string[] args)
		{
			try
			{
				MatchLoader.LoadMatchesFromFile(@"..\..\Matches-2016-01-02.csv");
				//MatchPrinter.PrintMatches();
				//FizzBuzz.Execute();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
