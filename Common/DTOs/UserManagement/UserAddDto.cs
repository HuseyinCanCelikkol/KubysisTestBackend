using Common.Enums.UserManagement;

namespace Common.DTOs.UserManagement
{
	public record UserAddDto
		(
		string Name,
		string Password,
		string Email,
		Role Role,
		int CompanyId,
		int CreateUserId
		);
}
