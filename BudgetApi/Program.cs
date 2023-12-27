using BudgetApi.Data;
using BudgetApi.Interfaces;
using BudgetApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(/* Add your authentication scheme here */);
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connection = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")
    : Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();


// Configure Identity
// Configure ASP.NET Core Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication(); 
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
// Map Identity API Endpoints
app.MapIdentityApi<IdentityUser>();
app.MapControllers();
app.Run();