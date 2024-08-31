using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;

namespace BusinessLayer.Abstract.AccountManagement
{
	public interface IAccountService
	{
		Task<Response> AddUserAsync(UserAddDto userAddDto);
	}
}
