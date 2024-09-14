using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.AccountManagement;
using Common.DTOs.UserManagement;
using Common.Models.AccountManagement;

namespace BusinessLayer.Abstract.AccountManagement
{
	public interface IAccountService
	{
		Task<Response> AddUserAsync(UserAddDto userAddDto);
		Task<Response<string>> GetJwtTokenAsync(LoginModel loginModel);
		Task<Response<string>> LoginAsync(UserLoginDto userLoginDto);

    }
}
