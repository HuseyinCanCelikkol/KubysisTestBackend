using Common.Enums.UserManagement;

namespace Common.DTOs.UserManagement
{
	public record UserGetByIdDto(int Id,
								string Email,
								Role Role
					);
}
