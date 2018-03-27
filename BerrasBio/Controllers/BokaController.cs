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

			var filmLista = _context.Film.ToList();
			var biljettLista = _context.Biljett.ToList();

			filmLista.Insert(0, new Film { FilmId = 0, FilmTitel = "Välj film..." });

			var grupperaFilmer = from b in _context.Biljett.ToList()
								 group b by b.FilmId into filmer
								 orderby filmer ascending
								 select filmer;

			BokaViewModel model = new BokaViewModel();
			model.FilmLista = filmLista;
			model.BiljettLista = biljettLista;

			return View(model);
        }

		public JsonResult Boka(int id)
		{
			if (id == 0)
				return Json("Felaktigt filmval");
			else
			{
				var antal = _context.Biljett.Where(f => f.FilmId == id).Count();
				return Json(antal);
			}
		}
    }
}