using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;

namespace BusinessLayer.Abstract.UserManagement
{
	public interface IUserService
	{
		Task<Response> AddUserAsync(UserAddDto userAddDto);
	}
}
