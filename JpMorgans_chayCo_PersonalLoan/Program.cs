using JpMorgans_chayCo_PersonalLoan.DataBaseLogic;
using JpMorgans_chayCo_PersonalLoan.RepositoryLayer;
using JpMorgans_chayCo_PersonalLoan.ServiceLayer;
using JpMorgans_chayCo_PersonalLoanBusinessEntities.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRegistrationRepository, CustomerRegistrationRepository>();
builder.Services.AddScoped<ICustomerRegistrationService, CustomerRegistrationService>();

builder.Services.AddDbContext<HotelmanagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
