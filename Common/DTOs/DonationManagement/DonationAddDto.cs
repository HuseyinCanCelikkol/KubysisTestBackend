using Common.Enums.DonationManagement;

namespace Common.DTOs.DonationManagement
{
	public record DonationAddDto
    (              
        string NameAndSurname,
		DonationType? DonationType,
		DonationClass DonationClass,
		int Amount,
        string PhoneNumber,
		DonationStatus DonationStatus,
		string? Description,
		string CreateUserId,
		int CompanyId
	);
}
