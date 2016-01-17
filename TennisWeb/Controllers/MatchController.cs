using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisData;
using TennisModel;

namespace TennisWeb.Controllers
{
	[HandleError]
	public class MatchController : Controller
	{
		public IEnumerable<Player> PlayerList { get; private set; }
		
		public MatchController()
		{
			using (var db = new TennisDb())
			{
				PlayerList = db.Players.ToArray();
			}
			//using (var dr = TennisObjects.DataAccess.GetAllPlayers())
			//	PlayerList = TennisObjects.Player.GetList(dr);
		}

		public ActionResult Index()
		{
			using (var dr = TennisObjects.DataAccess.GetAllMatches())
				return View(TennisObjects.Info.PlayerMatch.GetListAll(dr));
		}

		public ActionResult Details(int id)
		{
			using (var dr = TennisObjects.DataAccess.GetMatch(id))
				return View(TennisObjects.Match.Get(dr));
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			TennisObjects.Match match;
			using (var dr = TennisObjects.DataAccess.GetMatch(id))
				match = TennisObjects.Match.Get(dr);

			//var playerItems = PlayerList.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.FullName }).ToList();
			ViewBag.WinnerID = new SelectList(PlayerList, "ID", "FullName", match.WinnerID.ToString());
			ViewBag.LoserID = new SelectList(PlayerList, "ID", "FullName", match.LoserID);
			//ViewData["WinnerID"] = ViewBag.WinnerID;

			return View(match);
		}

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
