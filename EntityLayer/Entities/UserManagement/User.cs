using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Entities.UserManagement
{
    public class User : IdentityUser
	{
		public int CompanyId { get; set; }
	}
}

