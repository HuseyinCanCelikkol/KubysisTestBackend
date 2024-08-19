using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Controllers.UserManagement
{
    [Route("[controller]/[action]")]
	[ApiController]
	public class UserController(KubysisDbContext kubysisDbContext) : ControllerBase
	{
		private readonly KubysisDbContext _kubysisDbContext = kubysisDbContext;				
	}
}
