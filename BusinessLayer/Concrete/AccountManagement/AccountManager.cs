using BusinessLayer.Abstract.AccountManagement;
using Common.Constant.SystemManagement.ResponseManagement;
using Common.DTOs.AccountManagement;
using Common.DTOs.UserManagement;
using Common.Models.AccountManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Concrete.AccountManagement
{
    public sealed class AccountManager(UserManager<IdentityUser> userManager, IConfiguration configuration) : IAccountService
	{
		private readonly UserManager<IdentityUser> _userManager = userManager;
		private readonly IConfiguration _configuration = configuration;

		public async Task<Response<string>> LoginAsync(UserLoginDto userLoginDto)
		{
            try
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

                if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
                {
                    // Kullanıcı giriş bilgileri doğruysa, JWT token oluştur ve döndür.
                    var token = GenerateJwtToken(user);
                    return Response<string>.CreateSuccessResponse(token);
                }

                return Response<string>.CreateFailureResponse();
            }
            catch
            {
                return Response<string>.CreateServerErrorResponse();
            }
        }
		public async Task<Response> AddUserAsync(UserAddDto userAddDto)
		{
			try
			{
				IdentityUser user = new()
				{
					UserName = userAddDto.Name,
					Email = userAddDto.Email,
				};

				IdentityResult result = await _userManager.CreateAsync(user, userAddDto.Password);
				if (!result.Succeeded)
				{
					return Response.CreateFailureResponse();
				}
				await _userManager.AddToRoleAsync(user, userAddDto.RoleName);

				return Response.CreateSuccessResponse();
			}
			catch
			{
				return Response.CreateServerErrorResponse();
			}
		}

		public async Task<Response<string>> GetJwtTokenAsync(LoginModel loginModel)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(loginModel.Email);

				if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
				{
					// Kullanıcı giriş bilgileri doğruysa, JWT token oluştur ve döndür.
					var token = GenerateJwtToken(user);
					return Response<string>.CreateSuccessResponse(token);
				}

				return Response<string>.CreateFailureResponse();
			}
			catch
			{
				return Response<string>.CreateServerErrorResponse();
			}
		}
		private string GenerateJwtToken(IdentityUser user)
		{
			var jwtSettings = _configuration.GetSection("Jwt");
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(ClaimTypes.NameIdentifier, user.Id)
		};

			var token = new JwtSecurityToken(
				issuer: jwtSettings["Issuer"],
				audience: jwtSettings["Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
