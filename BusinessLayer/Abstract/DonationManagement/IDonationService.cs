using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.CompanyManagement;
using Common.DTOs.DonationManagement;

namespace BusinessLayer.Abstract.DonationManagement
{
    public interface IDonationService
    {
        Task<Response> AddDonationAsync(DonationAddDto donationAddDto);
    }
}
