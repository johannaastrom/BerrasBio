using BerrasBio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBio.Data
{
    public class FilmContext : DbContext
    {
		public FilmContext(DbContextOptions<FilmContext> options) : base(options) { }

		public DbSet <Film> Film { get; set; }
		public DbSet <Biljett> Biljett { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Film>().ToTable("Film");
			modelBuilder.Entity<Biljett>().ToTable("Biljett");
		}
	}

	public static class DbInitializer
	{
		public static void Initialize(FilmContext context)
		{
			context.Database.EnsureCreated();
			
			if (context.Film.Any()) // Look if there are any films in database
			{
				return;   // DB has been seeded
			}

			var filmer = new Film[]
			{
			new Film{FilmTitel="Sagan om ringen 17:00"/*,Tid="17:00"*/ },
			new Film{FilmTitel="Harry Potter 18:30"/*,Tid="18:30"*/ },
			new Film{FilmTitel="The Notebook 19:00"/*,Tid="19:00"*/ },
			new Film{FilmTitel="Ensam hemma 20:30"/*,Tid="20:30"*/ },
			new Film{FilmTitel="Scary Movie 22:00"/*,Tid="22:00"*/ }
			};
			foreach (Film s in filmer)
			{
				context.Film.Add(s);
			}
			context.SaveChanges();

			if (context.Biljett.Any()) // Look if there are any tickets in database
			{
				return;   // DB has been seeded
			}

			var biljetter = new Biljett();

			//Här skapas 50 obokade biljetter av varje FilmId
			int maxBiljetter = 50;
			for (int i = 0; i < maxBiljetter; i++)
			{
				context.Biljett.Add(new Biljett { FilmId = 1, Bokad = false });
			}
			for (int i = 0; i < maxBiljetter; i++)
			{
				context.Biljett.Add(new Biljett { FilmId = 2, Bokad = false });
			}
			for (int i = 0; i < maxBiljetter; i++)
			{
				context.Biljett.Add(new Biljett { FilmId = 3, Bokad = false });
			}
			for (int i = 0; i < maxBiljetter; i++)
			{
				context.Biljett.Add(new Biljett { FilmId = 4, Bokad = false });
			}
			for (int i = 0; i < maxBiljetter; i++)
			{
				context.Biljett.Add(new Biljett { FilmId = 5, Bokad = false });
			}
			context.SaveChanges();
		}
	}

}
