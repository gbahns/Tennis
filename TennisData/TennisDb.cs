using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TennisModel;

namespace TennisData
{
	public class TennisDb : DbContext, ITennisDataSource
	{
		public TennisDb() : base("Tennis")
		{
		}

		public DbSet<Player> Players { get; set; }
		public DbSet<TennisEvent> TennisEvents { get; set; }
		public DbSet<MatchRaw> Matches { get; set; }

		IQueryable<TennisEvent> ITennisDataSource.TennisEvents
		{
			get { return TennisEvents; }
		}

		IQueryable<Player> ITennisDataSource.Players
		{
			get { return Players; }
		}

		IQueryable<MatchRaw> ITennisDataSource.Matches
		{
			get { return Matches; }
		}
	}
}
