using AutoMapper;
using Common.DTOs.UserManagement;
using EntityLayer.Entities.UserManagement;

namespace BusinessLayer.Mappings.UserManagement
{
	public class UserMappingProfile : Profile
	{
		public UserMappingProfile()
		{
			CreateMap<UserAddDto, User>().ReverseMap();
			CreateMap<UserGetByCompanyIdDto, User>().ReverseMap();
			CreateMap<UserGetByIdDto, User>().ReverseMap();
		}
	}
}
