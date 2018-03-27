using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerrasBio.Models;
using System.Data.SqlClient;
using BerrasBio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BerrasBio.Controllers
{
	public class HomeController : Controller
    {
		private readonly FilmContext _context;

		public HomeController(FilmContext context)
		{
			_context = context;
		}

		public IActionResult Index() 
        {
			return View();
        }

        public IActionResult Boka(int antalBiljetter) 
        {
            ViewData["Message"] = "Boka dina biljetter idag";

			var filmLista = _context.Film.ToList(); 
			var biljettLista = _context.Biljett.ToList();

			BokaViewModel model = new BokaViewModel();
			model.FilmLista = filmLista;
			model.BiljettLista = biljettLista;

			//var LINQ = from b in biljettLista    //klumpa och sortera ihop filmId
			//		   group b by b.FilmId into film
			//		   orderby film ascending
			//		   select film;

			return View(model);
        }

        public IActionResult Trailers()
        {
            ViewData["Message"] = "Se våra trailers här.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		public ActionResult Confirmation()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Create(Biljett biljettId)
		{
			if (ModelState.IsValid)
			{
				_context.Biljett.Add(biljettId);
				_context.SaveChanges();
				//return View("Boka", new { id = biljettId.Bokad });
			}
			return View(biljettId);
		}

		//public ActionResult Submit()
		//{
		//	string output = "Nu har du bokat biljetter.";
		//	ViewData["output"] = output;

		//	if (ModelState.IsValid)
		//	{
		//		//do something with account
		//		return RedirectToAction("Index");
		//	}
		//	return View(output);
		//}
	}
}
