using System;
namespace TrendMovie.Models
{
	public class MovieResponse
	{
		public int StatusCode { get; set; }
		public string? StatusDescription { get; set; }
		public List<Movie> MovieList { get; set; } = new();
	}
}

