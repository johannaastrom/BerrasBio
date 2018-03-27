using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
	public class BokaViewModel
	{
		public List<Film> FilmLista { get; set; }
		public List<Biljett> BiljettLista { get; set; }
		public int SelectedFilmId { get; set; }

		public int BokadePlatser { get; set; }
		public int LedigaPlatser { get; set; }
	}
}
