using EntityLayer.Entities.DonationManagement;
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

		public DbSet<User> Users { get; set; }

		public DbSet<Donation> Donations { get; set; }
		

		

		

	}
}
