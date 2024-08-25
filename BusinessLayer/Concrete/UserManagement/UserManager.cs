using AutoMapper;
using BusinessLayer.Abstract.UserManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.UserManagement;
using EntityLayer;
using EntityLayer.Entities.UserManagement;

namespace BusinessLayer.Concrete.UserManagement
{
	public class UserManager(KubysisDbContext context, IMapper mapper) : IUserService
	{
		private readonly KubysisDbContext _context = context;
		private readonly IMapper _mapper = mapper;
		public async Task<Response> AddUserAsync(UserAddDto userAddDto)
		{
			try
			{
				User user = _mapper.Map<User>(userAddDto);
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();
				return Response.CreateSuccessResponse();
			}
			catch
			{
				return Response.CreateServerErrorResponse();
			}

		}
	}
}
