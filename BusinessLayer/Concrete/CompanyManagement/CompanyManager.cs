using AutoMapper;
using BusinessLayer.Abstract.CompanyManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.CompanyManagement;
using EntityLayer;
using EntityLayer.Entities.CompanyManagement;

namespace BusinessLayer.Concrete.CompanyManagement
{
	public class CompanyManager(KubysisDbContext context, IMapper mapper) : ICompanyService
	{
		private readonly KubysisDbContext _context = context;
		private readonly IMapper _mapper = mapper;

		public async Task<Response> AddCompanyAsync(CompanyAddDto companyAddDto)
		{
			try
			{
				Company company = _mapper.Map<Company>(companyAddDto);

				await _context.AddAsync(company);
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
