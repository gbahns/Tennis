using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisData;
using TennisModel;

namespace TennisConsole
{
	static class PlayerFinder
	{
		static TennisDb db = new TennisDb();
		static TennisDb playersDb = new TennisDb();

		static Dictionary<string, string> PlayerMap = new Dictionary<string, string>()
		{
			{"SURAJ", "SURAJ RAMALINGAM"},
			{"LEE", "LEE WALLACE"},
			{"JOE", "JOE BANNON (CY)"},
			{"SCOTT", "SCOTT SNIDER"},
			{"GENE", "GENE AHLBORN"},
			{"STEVE", "STEVE GILBERT"},
			{"GILBERT", "STEVE GILBERT"},
			{"CHRIS", "CHRIS MARK"},
			{"KALONJI", "KALONJI MARTIN"},
			{"JAY", "JAY AVENIDO"},
			{"GARTH", "GARTH BRANDWEIN"},
			{"ASHISH", "ASHISH BANGAR"},
			{"JESSE", "JESSE BONDOC"},
			{"STEVE MOORE", "STEVE MOORE (QC)"},
			{"TUCK", "TUCK STITES (QC)"},
			{"POTTNER", "MIKE POTTNER"},
			{"? (harpers)", "player unknown"},
		};

		public static string FindPlayers(string name)
		{
			name = name.ToUpper();


			if (PlayerMap.ContainsKey(name))
				name = PlayerMap[name];

			var players = from player in db.Players where name == player.FirstName.ToUpper() + " " + player.LastName.ToUpper() select player;

			if (players.Count() == 0)
				players = from player in db.Players where name == player.FirstName.ToUpper() && name == player.LastName.ToUpper() select player;

			//if (players.Count() == 0)
			//	players = from player in db.Players where name == player.LastName select player;

			//if (players.Count() == 0)
			//{
			//	players = from player in db.Players where name == player.FirstName.ToUpper() || name == player.LastName.ToUpper() select player;
			//	if (players.Count() > 0)
			//		Console.Write("POSSIBLE MATCHES: ");
			//}

			var sb = new StringBuilder();
			foreach (var player in players)
			{
				sb.Append(" " + player.Id + ":" + player.FullName + ";");
			}
			return sb.ToString();
		}

		public static Player FindPlayer(string name)
		{
			if (name.StartsWith("*"))
			{
				Player player = new Player();
				player.FullName = name;
				playersDb.Players.Add(player);
				playersDb.SaveChanges();
				return player;
			}

			name = name.ToUpper();

			if (PlayerMap.ContainsKey(name))
				name = PlayerMap[name];

			var players = from player in db.Players where name == player.FirstName.ToUpper() + " " + player.LastName.ToUpper() select player;

			if (players.Count() != 1)
				players = from player in db.Players where name == player.FirstName.ToUpper() && name == player.LastName.ToUpper() select player;

			if (players.Count() == 0)
			{
				//Console.Write(String.Format("\nPlayer '{0}' not found.  Create new player (y/n)? ", name));
				//var key = Console.ReadKey();
				//Console.WriteLine();
				//if (key.KeyChar != 'y')
				//	throw new ApplicationException(String.Format("Player '{0}' not found.", name));

				Player player = new Player();
				player.FullName = name;
				db.Players.Add(player);
				return player;
			}

			return players.First();
		}
	}
}
