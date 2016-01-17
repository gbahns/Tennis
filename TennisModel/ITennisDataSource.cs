using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisModel
{
	public interface ITennisDataSource
	{
		IQueryable<TennisEvent> TennisEvents { get; }
		IQueryable<Player> Players { get; }
		IQueryable<MatchRaw> Matches { get; }
	}
}
