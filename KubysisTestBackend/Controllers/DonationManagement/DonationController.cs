using BusinessLayer.Abstract.DonationManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.DonationManagement;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.DonationManagement
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DonationController(IDonationService donationService) : ControllerBase
    {
        private readonly IDonationService _donationService = donationService;

        [HttpGet]
        public async Task<Response<List<DonationGetDto>>> GetDonationsByCompanyId([FromQuery] int companyId)
        {
            return await _donationService.GetDonationsByCompanyIdAsync(companyId);
        }

        [HttpGet]
        public async Task<Response<DonationGetDto>> GetDonationById([FromQuery] int donationId)
        {
            return await _donationService.GetDonationByIdAsync(donationId);
        }

        [HttpPost]
        public async Task<Response> AddDonation([FromBody] DonationAddDto donationAddDto)
        {
            return await _donationService.AddDonationAsync(donationAddDto);
        }

        [HttpPut]
        public async Task<Response> UpdateDonation([FromBody] DonationUpdateDto dto)
        {
            return await _donationService.UpdateDonationAsync(dto);
        }

        [HttpPut]
        public async Task<Response> UpdateStatus([FromBody] UpdateStatusDto dto)
        {
            return await _donationService.UpdateStatusAsync(dto);
        }

    }
}
