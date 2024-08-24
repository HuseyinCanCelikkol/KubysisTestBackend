using BusinessLayer.Abstract.CompanyManagement;
using BusinessLayer.Abstract.DonationManagement;
using BusinessLayer.Abstract.UserManagement;
using BusinessLayer.Concrete.CompanyManagement;
using BusinessLayer.Concrete.DonationManagement;
using BusinessLayer.Concrete.UserManagement;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IDonationService,DonationManager>();	
builder.Services.AddScoped<ICompanyService,CompanyManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KubysisDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
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
