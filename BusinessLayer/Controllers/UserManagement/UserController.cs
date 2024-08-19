using EntityLayer;
using EntityLayer.Entities.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Controllers.UserManagement
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class UserController(KubysisDbContext kubysisDbContext) : ControllerBase
	{
		private readonly KubysisDbContext _kubysisDbContext = kubysisDbContext;

		[HttpPost]

		public async Task<IActionResult> AddUser()
		{
			try
			{
				_kubysisDbContext.
			}
			catch(Exception ex) 
			{
				return Problem(statusCode: 500,detail: ex.Message);
			}
		} 
	}
}
