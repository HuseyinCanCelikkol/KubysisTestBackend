namespace Common.DTOs.UserManagement
{
	public record UserAddDto
		(
		string Name,
		string Password,
		string Email,
		string RoleName,
		int CompanyId,
		int CreateUserId
		);
}
