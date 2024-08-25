using BusinessLayer.Abstract.CompanyManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.CompanyManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubysisTestBackend.Controllers.CompanyManagement
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class CompanyController(ICompanyService companyService) : ControllerBase
	{
		private readonly ICompanyService _companyService = companyService;

		[HttpPost]
		[AllowAnonymous]

		public async Task<Response> AddCompany(CompanyAddDto companyAddDto)
		{
			return await _companyService.AddCompanyAsync(companyAddDto);
		}
	}
}
