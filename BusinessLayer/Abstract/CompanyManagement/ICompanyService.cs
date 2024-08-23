using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.CompanyManagement;

namespace BusinessLayer.Abstract.CompanyManagement
{
	public interface ICompanyService
	{
		Task<Response> AddCompanyAsync(CompanyAddDto companyAddDto);
	}
}
