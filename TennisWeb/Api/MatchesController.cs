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
    public class MatchesController : ApiController
    {
        // GET api/matches
        public IEnumerable<MatchRaw> Get()
        {
					using (var db = new TennisDb())
					{
						return db.Matches.ToArray();
					}
				}

        // GET api/matches/5
        public MatchRaw Get(int id)
        {
					using (var db = new TennisDb())
					{
						var query = from item in db.Matches where item.ID == id select item;
						if (!query.Any())
						{
							//need to throw a 404 exception
							//return HttpStatusCode.NotFound;
						}
						return query.First();
					}
				}

        // POST api/matches
        public void Post([FromBody]string value)
        {
        }

        // PUT api/matches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/matches/5
        public void Delete(int id)
        {
        }
    }
}
