using BusinessLayer.Abstract.UserManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.UserManagement
{
	[Route("[controller]/[action]")]
	[ApiController]  
	public class UserController(IUserService userService) : ControllerBase
	{
		private readonly IUserService _userService = userService;

		[HttpPost]
		[AllowAnonymous]
		public async Task<Response> AddUser([FromBody] UserAddDto userAddDto)
		{
			return await _userService.AddUserAsync(userAddDto);
		}

	}
}
