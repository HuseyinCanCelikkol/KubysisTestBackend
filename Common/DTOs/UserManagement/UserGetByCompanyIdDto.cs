using Common.Enums.UserManagement;

namespace Common.DTOs.UserManagement
{
	public record UserGetByCompanyIdDto(int Id,
									 string Email,
									 Role Role);
}
