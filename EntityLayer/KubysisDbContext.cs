using EntityLayer.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer
{
	public sealed class KubysisDbContext : DbContext
	{
		public KubysisDbContext(DbContextOptions<KubysisDbContext> options)
	   : base(options)
		{
		}

		public DbSet<Users> Users { get; set; }

	}
}
