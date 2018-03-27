using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BerrasBio.Data;
using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BerrasBio.Controllers
{
	public class BokaController : Controller
	{
		private readonly FilmContext _context;

		public BokaController(FilmContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			ViewData["Message"] = "Boka dina biljetter idag";

			//if (ViewData["Message"] == "Det finns inte tillräckligt många lediga biljetter")
			//{
					//// fixa denna if sats så den fungerar.
			//}
			var filmLista = _context.Film.ToList();
			var biljettLista = _context.Biljett.ToList();

			filmLista.Insert(0, new Film { FilmId = 0, FilmTitel = "Välj film..." });

			BokaViewModel model = new BokaViewModel();
			model.FilmLista = filmLista;
			model.BiljettLista = biljettLista;

			return View(model);
		}

		public ActionResult Boka(BokaViewModel model)
		{
			var antal = _context.Biljett.Where(b => b.FilmId == model.SelectedFilmId && !b.Bokad).Count();
			if (model.AntalBiljetter > antal)
			{
				ViewData["Message"] = "Det finns inte tillräckligt många lediga biljetter";
				return RedirectToAction("Index");
			}
			else
			{
				//var biljettLista = _context.Biljett.Where(b => b.FilmId == model.SelectedFilmId && !b.Bokad).ToList();
				for (int i = 0; i < model.AntalBiljetter; i++)
				{
					var biljettOld = _context.Biljett.Where(b => !b.Bokad && b.FilmId == model.SelectedFilmId).First();
					biljettOld.Bokad = true;
					_context.SaveChanges();
				}
				return View("Bekraftelse");
			}
		}

		public JsonResult GetAntalLedigaBiljetter(int id)
		{
			if (id == 0)
				return Json("Felaktigt filmval");
			else
			{
				var antal = _context.Biljett.Where(b => b.FilmId == id && !b.Bokad).Count();
				return Json(antal);
			}
		}
	}
}