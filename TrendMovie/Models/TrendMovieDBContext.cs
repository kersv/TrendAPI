using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TrendMovie.Models;

namespace TrendMovie.Models
{
	public class TrendMovieDBContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public TrendMovieDBContext(DbContextOptions<TrendMovieDBContext> options, IConfiguration configuration)
			: base(options)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var connectionString = Configuration.GetConnectionString("TrendMovieService");
			options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
		}

		public DbSet<Trend> Trend { get; set; } = null!;
		public DbSet<Movie> Movie { get; set; } = null!;
		
	}
}

