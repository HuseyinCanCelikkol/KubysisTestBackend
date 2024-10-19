using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KubysisTestBackend.Middlewares;
public class JwtMiddleware(RequestDelegate next, IConfiguration configuration)
{
	private readonly RequestDelegate _next = next;
	private readonly IConfiguration _configuration = configuration;

	public async Task Invoke(HttpContext context)
	{
		var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ")[^1];
		if (token != null && token.Length > 1)
		{
			await AttachUserToContext(context, token);
		}
		
		await _next(context);
	}

	private async Task AttachUserToContext(HttpContext context, string token)
	{
		try
		{
			var jwtSettings = _configuration.GetSection("Jwt");
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = true,
				ValidIssuer = jwtSettings["Issuer"],
				ValidateAudience = true,
				ValidAudience = jwtSettings["Audience"],
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero // Token süresini hemen geçersiz kılar
			}, out SecurityToken validatedToken);

			var jwtToken = (JwtSecurityToken)validatedToken;
			var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

			// Kullanıcıyı doğrulayıp, context'e ekleyelim
			context.Items["User"] = userId;
		}
		catch (SecurityTokenException)
		{
			// Token geçersizse 401 Unauthorized döndürelim
			context.Response.StatusCode = StatusCodes.Status401Unauthorized;
			await context.Response.WriteAsync("Unauthorized: Invalid or expired token.");
			return; // İsteği burada kes
		}
		catch (Exception)
		{
			// Diğer hatalar için 500 Internal Server Error döndürebilirsin
			context.Response.StatusCode = StatusCodes.Status401Unauthorized;
			await context.Response.WriteAsync("Unauthorized: Invalid or expired token.");
			return;
		}
	}
}