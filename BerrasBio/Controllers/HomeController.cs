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

        public IActionResult Boka() 
        {
            ViewData["Message"] = "Boka dina biljetter idag";

			var filmLista = _context.Film.ToList(); 
			var biljettLista = _context.Biljett.ToList(); // 'Invalid column name 'FilmId'.' koppla ihop FK rätt!!!

			ViewData["filmer"] = filmLista;
			ViewData["biljetter"] = biljettLista;

			BokaViewModel model = new BokaViewModel();
			model.filmLista = filmLista;
			model.biljettLista = biljettLista; 

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
