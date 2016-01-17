using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisConsole
{
	public class FizzBuzz
	{
		public static void Execute()
		{
			for (int i = 1; i <= 100; i++)
			{
				string s = "";
				if (i % 3 == 0)
					s += "Fizz";
				if (i % 5 == 0)
					s += "Buzz";
				Console.WriteLine(s == "" ? i.ToString() : s);
			}
		}
	}
}
