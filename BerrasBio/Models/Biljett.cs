﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBio.Models
{
	public class Biljett
	{
		public int BiljettId { get; set; }
		public bool Bokad { get; set; }

		public int FilmId { get; set; } 
		public virtual Film Film { get; set; }
	}
}