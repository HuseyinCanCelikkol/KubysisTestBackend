using Common.Enums.UserManagement;
using EntityLayer.Entities.BaseEntityManagement;
using EntityLayer.Entities.CompanyManagement;

namespace EntityLayer.Entities.UserManagement
{
	public class Users : BaseEntity
	{
		public required string Name { get; set; }
		public required string Password { get; set; }
		public required string Email { get; set; }
		public Role Role { get; set; }
		public int CompanyId { get; set; }
		public virtual Company? Company { get; set; }
	}
}

