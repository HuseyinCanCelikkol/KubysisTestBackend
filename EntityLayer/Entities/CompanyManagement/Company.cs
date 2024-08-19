using EntityLayer.Entities.BaseEntityManagement;
using EntityLayer.Entities.UserManagement;

namespace EntityLayer.Entities.CompanyManagement
{
	public class Company : BaseEntity
	{
		public required string Name { get; set; }
		public required string LicenseKey { get; set; }
		public DateTime LicenseKeyExpirationDate { get; set; }
		public virtual ICollection<Users>? Employees { get; set; }

	}
}
