namespace Common.DTOs.AccountManagement
{
    public record UserInformationsDto(string Id,
                                      string Name,
                                      string Email,
                                      string Role,
                                      int CompanyId,
                                      string Token);
}
