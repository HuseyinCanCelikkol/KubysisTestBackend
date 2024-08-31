using BusinessLayer.Abstract.AccountManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.SystemManagement.AccountManagement
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class AccountController(IAccountService accountService) : ControllerBase
	{
		private readonly IAccountService _accountService = accountService;

		[HttpPost]
		[AllowAnonymous]

		public async Task<Response> AddUser([FromBody] UserAddDto userAddDto)
		{
			return await _accountService.AddUserAsync(userAddDto);
		}
	}
}
