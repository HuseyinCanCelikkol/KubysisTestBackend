using BusinessLayer.Abstract.AccountManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Concrete.AccountManagement
{
	public sealed class AccountManager(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : IAccountService
	{
		private readonly UserManager<IdentityUser> _userManager = userManager;
		private readonly RoleManager<IdentityRole> _roleManager = roleManager;

		public async Task<Response> AddUserAsync(UserAddDto userAddDto)
		{
			try
			{

			}
			catch
			{
				return Response.CreateServerErrorResponse();
			}
		}
	}
}
