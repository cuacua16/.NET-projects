using Microsoft.EntityFrameworkCore;
using OBwebAPI.Models.DataModels;

namespace OBwebAPI.DataAccess {
	public class UniversityDBContext : DbContext {

		//logs
		private readonly ILoggerFactory _loggerFactory;

		public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options) {
			_loggerFactory = loggerFactory;
		}

		//add dbsets (tablas)
		public DbSet<User>? Users { get; set; }
		public DbSet<Course>? Courses { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Student> Students { get; set; }


		//logs
		//OnConfiguring es una funcion de DbContext que podemos sobreescribir
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
			//optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
			//optionsBuilder.EnableSensitiveDataLogging();

			//las de arriba persistirian todo

			optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
				.EnableSensitiveDataLogging()
				.EnableDetailedErrors();
		}


	}
}
