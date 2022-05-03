using System;
namespace TrendMovie.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
		public string? StatusDescription { get; set; }

        public List<Trend> TrendList { get; set; } = new();
        public List<Movie> MovieList { get; set; } = new();

    }
}

