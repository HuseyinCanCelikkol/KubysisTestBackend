using Common.Enums.DonationManagement;

namespace Common.DTOs.DonationManagement
{
    public record DonationGetDto(string NameAndSurname,
                             DonationType DonationType,
                             DonationClass DonationClass,
                             int Amount,
                             string PhoneNumber,
                             DonationStatus DonationStatus,
                             DateTime CreateDate);
}
