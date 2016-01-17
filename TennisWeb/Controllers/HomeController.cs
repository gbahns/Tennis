using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TennisWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}

		[OutputCache(Duration=20)]
		public ActionResult CacheTest()
		{
			ViewBag.Message = "Your contact page.";
			return View(DateTime.Now);
		}

		[ChildActionOnly]
		[OutputCache(Duration=10)]
		public PartialViewResult CurrentTime()
		{
			ViewBag.Message = "Hello from CurrentTime()";
			return PartialView(DateTime.Now);
		}
	}
}
