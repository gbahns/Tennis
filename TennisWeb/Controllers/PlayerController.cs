using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TennisWeb.Controllers
{
	public class PlayerController : Controller
	{

		public ActionResult Index()
		{
			using (var dr = TennisObjects.DataAccess.GetPlayerOpponentSummary(1))
				return View(TennisObjects.Info.MatchSummary.GetList(dr));
		}

		public ActionResult Details(int id)
		{
			return View(TennisObjects.Player.Get(id));
		}

		public ActionResult Edit(int id)
		{
			return View(TennisObjects.Player.Get(id));
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TennisObjects.Player player)
		{
			if (!ModelState.IsValid)
				return View(player);

			player.Save();
			return RedirectToAction("details", "player", new { id = player.ID });
		}
	}
}
