using BusinessLayer.Abstract.DonationManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.DonationManagement;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.DonationManagement
{
	[Route("[controller]/[action]")]
    [ApiController]
    public class DonationController (IDonationService donationService) : ControllerBase
    {
        private readonly IDonationService   _donationService=donationService;

        [HttpPost]
        public async Task<Response> AddDonation([FromBody] DonationAddDto donationAddDto)
        {
            return await _donationService.AddDonationAsync(donationAddDto);
        }
    }
}
