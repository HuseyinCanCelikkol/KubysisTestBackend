using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.DonationManagement;

namespace BusinessLayer.Abstract.DonationManagement
{
    public interface IDonationService
    {
        Task<Response> AddDonationAsync(DonationAddDto donationAddDto);
        Task<Response<List<DonationGetDto>>> GetDonationsByCompanyIdAsync(int companyId);
        Task<Response> UpdateStatusAsync(UpdateStatusDto dto);
    }
}
