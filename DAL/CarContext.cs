using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ThisIsCar.Models;

namespace ThisIsCar.DAL
{
	public class CarContext : DbContext
	{

		public CarContext() : base("CarContext") {
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<Manufacturer> Manufacturers {
			get;
			set;
		}

		public DbSet<Model> Models {
			get;
			set;
		}

		public DbSet<Modification> Modifications {
			get;
			set;
		}

		public DbSet<Comment> Comments {
			get;
			set;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
