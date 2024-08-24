using AutoMapper;
using Common.DTOs.DonationManagement;
using EntityLayer.Entities.DonationManagement;

namespace BusinessLayer.Mappings.DonationManagement
{
    public class DonationMappingProfile : Profile
    {
        public DonationMappingProfile() 
        {
            CreateMap<DonationAddDto,Donation>().ReverseMap();
        }
    }
}
