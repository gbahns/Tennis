using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TennisData;
using TennisModel;

namespace TennisWeb.Api
{
	public class PlayersController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<Player> Get()
		{
			using (var db = new TennisDb())
			{
				return db.Players.ToArray();
			}
		}

		// GET api/<controller>/5
		public Player Get(int id)
		{
			using (var db = new TennisDb())
			{
				var query = from p in db.Players where p.Id == id select p;
				if (!query.Any())
				{
					//need to throw a 404 exception
					//return HttpStatusCode.NotFound;
				}
				return query.First();
			}
		}

		// POST api/<controller>
		public void Post([FromBody]Player value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]Player value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}