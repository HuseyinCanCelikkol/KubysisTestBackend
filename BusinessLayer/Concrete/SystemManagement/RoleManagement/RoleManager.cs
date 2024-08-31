using BusinessLayer.Abstract.SystemManagement.RoleManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.SystemManagement.RoleManagement;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Concrete.SystemManagement.RoleManagement
{
	public sealed class RoleManager(RoleManager<IdentityRole> roleManager) : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager = roleManager;

		public async Task<Response> AddRoleAsync(AddRoleDto addRoleDto)
		{
			try
			{
				if (await _roleManager.RoleExistsAsync(addRoleDto.RoleName))
				{
					
					return Response.CreateFailureResponse();
				}

				// Yeni rol oluştur
				var role = new IdentityRole(addRoleDto.RoleName);
				var result = await _roleManager.CreateAsync(role);

				return Response.CreateSuccessResponse();
			}
			catch
			{
				return Response.CreateServerErrorResponse();
			}
		}
	}
}
