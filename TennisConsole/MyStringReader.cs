using System.IO;

namespace TennisConsole
{
	public class MyStringReader : IGenericReader
	{
		StringReader reader;

		public MyStringReader(string s)
		{
			this.reader = new StringReader(s);
		}

		public int Peek()
		{
			return reader.Peek();
		}

		public string ReadLine()
		{
			return reader.ReadLine();
		}
	}
}
