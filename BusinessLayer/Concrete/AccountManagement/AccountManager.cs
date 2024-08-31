using BusinessLayer.Abstract.AccountManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Concrete.AccountManagement
{
	public sealed class AccountManager(UserManager<IdentityUser> userManager) : IAccountService
	{
		private readonly UserManager<IdentityUser> _userManager = userManager;

		public async Task<Response> AddUserAsync(UserAddDto userAddDto)
		{
			try
			{
				IdentityUser user = new()
				{
					UserName = userAddDto.Name,
					Email = userAddDto.Email,
				};

				IdentityResult result = await _userManager.CreateAsync(user, userAddDto.Password);
				if (!result.Succeeded)
				{
					return Response.CreateFailureResponse();
				}
				await _userManager.AddToRoleAsync(user, userAddDto.RoleName);

				return Response.CreateSuccessResponse();
			}
			catch
			{
				return Response.CreateServerErrorResponse();
			}
		}
	}
}
