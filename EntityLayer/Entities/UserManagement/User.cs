using Common.Enums.UserManagement;
using EntityLayer.Entities.BaseEntityManagement;
using EntityLayer.Entities.CompanyManagement;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Entities.UserManagement
{
	public class User : IdentityUser
	{
		public required string Name { get; set; }
		public required string Password { get; set; }
		public Role Role { get; set; }
		public int CompanyId { get; set; }
		public virtual Company? Company { get; set; }
	}
}

