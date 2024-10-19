using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.SystemManagement.RoleManagement;

namespace BusinessLayer.Abstract.SystemManagement.RoleManagement
{
	public interface IRoleService
	{
		Task<Response> AddRoleAsync(AddRoleDto addRoleDto);
	}
}
