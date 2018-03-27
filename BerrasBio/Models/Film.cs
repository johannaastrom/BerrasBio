using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
	public class Film
	{
		public int FilmId { get; set; }
		public string FilmTitel { get; set; }
		//public string Tid { get; set; }
		public int AntalBiljetter { get; set; }

		public virtual ICollection<Biljett> Biljetter { get; set; }
	}
}
