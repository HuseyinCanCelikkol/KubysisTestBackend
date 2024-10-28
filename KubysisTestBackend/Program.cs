using BusinessLayer.Abstract.AccountManagement;
using BusinessLayer.Abstract.CompanyManagement;
using BusinessLayer.Abstract.DonationManagement;
using BusinessLayer.Abstract.SystemManagement.RoleManagement;
using BusinessLayer.Concrete.AccountManagement;
using BusinessLayer.Concrete.CompanyManagement;
using BusinessLayer.Concrete.DonationManagement;
using BusinessLayer.Concrete.SystemManagement.RoleManagement;
using dotenv.net;
using EntityLayer;
using EntityLayer.Entities.UserManagement;
using KubysisTestBackend.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
#if DEBUG
DotEnv.Load();
#endif
var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDonationService, DonationManager>();
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey 

	});
	options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<KubysisDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<KubysisIdentityDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<KubysisIdentityDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		var jwtSettings = builder.Configuration.GetSection("Jwt");
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]!)),
			ValidateIssuer = true,
			ValidIssuer = jwtSettings["Issuer"],
			ValidateAudience = true,
			ValidAudience = jwtSettings["Audience"],
			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero
		};
		options.Events = new JwtBearerEvents
		{
			OnAuthenticationFailed = context =>
			{
				// Eğer token geçersizse, hata döndür
				if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
				{
					context.Response.Headers.Append("Token-Expired", "true");
				}
				context.Response.StatusCode = 401; // Unauthorized
				return Task.CompletedTask;
			},
			OnChallenge = context =>
			{
				// Bu kısım da 401 Unauthorized döndürür
				if (!context.Response.HasStarted)
				{
					context.Response.StatusCode = 401;
					context.Response.ContentType = "application/json";
				}
				return Task.CompletedTask;
			}
		};
	});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

await app.RunAsync();
