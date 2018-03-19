using System;

namespace BerrasBio.Models // här läggs alla modellklasser in
{
	public class Filmer { }
	public class Biljetter { }

	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

	}
}

//public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BerrasBio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

//			using (var conn = new SqlConnection(connectionString))
//			using (var cmd = conn.CreateCommand())
//			{
//				conn.Open();
//				cmd.CommandText = "SELECT FilmTitel, Tid FROM Filmer";
//				/*cmd.Parameters.AddWithValue("@id", id);*/
//				using (var reader = cmd.ExecuteReader())
//				{
//					if (!reader.Read()){
//						//print films 
//						Console.WriteLine("Hallå");
//					}
//				}
//			}
	