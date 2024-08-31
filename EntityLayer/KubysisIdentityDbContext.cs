using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityLayer
{
	public class KubysisIdentityDbContext(DbContextOptions<KubysisIdentityDbContext> options) : IdentityDbContext<IdentityUser>(options)
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Model.GetEntityTypes()
				.SelectMany(entityType => entityType.GetProperties())
				.Where(property => property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
				.ToList()
				.ForEach(property => property.SetColumnType("timestamp without time zone"));

			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}
	}
}
