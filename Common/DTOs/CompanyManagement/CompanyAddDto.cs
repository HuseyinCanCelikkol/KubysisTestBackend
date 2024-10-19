namespace Common.DTOs.CompanyManagement
{
	public record CompanyAddDto(string Name,
							 string LicenseKey,
							 DateTime LicenseKeyExpirationDate
					);
}
