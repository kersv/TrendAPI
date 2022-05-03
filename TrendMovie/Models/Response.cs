using System;
namespace TrendMovie.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
		public string? StatusDescription { get; set; }

        //public List<Trend> Trend { get; set; } = new();
        //public List<Movie> Movie { get; set; } = new();
        //public List<Series> Series { get; set; } = new();
    }
}

