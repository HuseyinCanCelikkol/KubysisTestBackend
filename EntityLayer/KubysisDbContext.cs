using EntityLayer.Entities.CompanyManagement;
using EntityLayer.Entities.DonationManagement;
using EntityLayer.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityLayer
{
	public sealed class KubysisDbContext(DbContextOptions<KubysisDbContext> options) : DbContext(options)
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Donation> Donations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Ignore<User>();
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				foreach (var property in entityType.GetProperties())
				{
					if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
					{
						property.SetColumnType("timestamp without time zone");
					}
				}
			}

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
