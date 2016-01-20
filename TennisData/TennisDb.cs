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
		public DbSet<TennisEvent> Events { get; set; }
		public DbSet<MatchRaw> Matches { get; set; }
		public DbSet<Location> Locations { get; set; }

		IQueryable<TennisEvent> ITennisDataSource.Events
		{
			get { return Events; }
		}

		IQueryable<Player> ITennisDataSource.Players
		{
			get { return Players; }
		}

		IQueryable<MatchRaw> ITennisDataSource.Matches
		{
			get { return Matches; }
		}

		IQueryable<Location> ITennisDataSource.Locations
		{
			get { return Locations; }
		}
	}
}
