using BusinessLayer.Abstract.AccountManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.AccountManagement;
using Common.DTOs.UserManagement;
using Common.Models.AccountManagement;
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
		public async Task<Response> AddUser([FromBody] UserAddDto userAddDto)
		{
			return await _accountService.AddUserAsync(userAddDto);
		}

		[HttpPost]
		public async Task<Response<string>> GetJwtToken([FromBody] LoginModel loginModel)
		{
			return await _accountService.GetJwtTokenAsync(loginModel);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<Response<UserInformationsDto>> Login([FromBody] UserLoginDto userLoginDto)
		{
			return await _accountService.LoginAsync(userLoginDto);
		}
	}
}
