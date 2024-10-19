using AutoMapper;
using BusinessLayer.Abstract.DonationManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.DonationManagement;
using EntityLayer;
using EntityLayer.Entities.DonationManagement;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete.DonationManagement
{
    public class DonationManager(KubysisDbContext context, IMapper mapper) : IDonationService
    {
        private readonly KubysisDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Response> AddDonationAsync(DonationAddDto donationAddDto)
        {
            try
            {
                Donation donation = _mapper.Map<Donation>(donationAddDto);
                await _context.AddAsync(donation);
                await _context.SaveChangesAsync();
                return Response.CreateSuccessResponse();
            }
            catch
            {
                return Response.CreateServerErrorResponse();
            }
        }

        public async Task<Response<List<DonationGetDto>>> GetDonationsByCompanyIdAsync(int companyId)
        {
            try
            {
                return Response<List<DonationGetDto>>.CreateSuccessResponse(
                    _mapper.Map<List<DonationGetDto>>(await _context.Donations.Where(x => x.CompanyId == companyId).ToListAsync())
                    );
            }
            catch
            {

                return Response<List<DonationGetDto>>.CreateServerErrorResponse();
            }
        }
    }
}
