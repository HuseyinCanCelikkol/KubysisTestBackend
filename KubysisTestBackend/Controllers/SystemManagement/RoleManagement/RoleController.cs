using BusinessLayer.Abstract.SystemManagement.RoleManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.SystemManagement.RoleManagement;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.SystemManagement.RoleManagement
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class RoleController(IRoleService roleService) : ControllerBase
	{
		private readonly IRoleService _roleService = roleService;

		[HttpPost]
		public async Task<Response> AddRole([FromBody] AddRoleDto addRoleDto)
		{
			return await _roleService.AddRoleAsync(addRoleDto);
		} 
	}
}
