using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerrasBio.Models;
using System.Data.SqlClient;

namespace BerrasBio.Controllers
{
	public class HomeController : Controller
    {
		public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BerrasBio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		public IActionResult Index()
        {
			using (var conn = new SqlConnection(connectionString))
			using (var cmd = conn.CreateCommand())
			{
				conn.Open();
				cmd.CommandText = "SELECT FilmTitel, Tid FROM Filmer";
				/*cmd.Parameters.AddWithValue("@id", id);*/
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read()){
						//print films 
						Console.WriteLine("Hallå");
					}
				}
			}

			return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
