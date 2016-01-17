using System.IO;
namespace TennisConsole
{
	public class MyFileReader : IGenericReader
	{
		StreamReader reader;

		public MyFileReader(string filename)
		{
			this.reader = File.OpenText(filename);
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
