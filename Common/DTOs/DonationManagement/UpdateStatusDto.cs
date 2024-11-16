using Common.Enums.DonationManagement;

namespace Common.DTOs.DonationManagement
{
    public record UpdateStatusDto(int Id, DonationStatus NewStatus);
}
