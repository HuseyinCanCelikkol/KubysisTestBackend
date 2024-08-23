using AutoMapper;
using Common.DTOs.CompanyManagement;
using EntityLayer.Entities.CompanyManagement;

namespace BusinessLayer.Mappings.CompanyManagement
{
	public class CompanyMappingProfile : Profile
	{
		public CompanyMappingProfile()
		{
			CreateMap<CompanyAddDto, Company>().ReverseMap();
		}
	}
}
