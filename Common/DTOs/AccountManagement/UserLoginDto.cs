namespace Common.DTOs.AccountManagement
{
    public record UserLoginDto(string Email,
                               string Password,
                               string LicenseKey);
}
