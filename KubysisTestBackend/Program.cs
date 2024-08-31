using BusinessLayer.Abstract.AccountManagement;
using BusinessLayer.Abstract.CompanyManagement;
using BusinessLayer.Abstract.DonationManagement;
using BusinessLayer.Abstract.SystemManagement.RoleManagement;
using BusinessLayer.Concrete.AccountManagement;
using BusinessLayer.Concrete.CompanyManagement;
using BusinessLayer.Concrete.DonationManagement;
using BusinessLayer.Concrete.SystemManagement.RoleManagement;
using EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KubysisDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<KubysisIdentityDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<KubysisIdentityDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
