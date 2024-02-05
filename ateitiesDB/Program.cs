using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using ateitiesDB.Repositories;
using ateitiesDB.Services.DtoConverter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configure PostgreSQL connection
builder.Services.AddDbContext<AteitininkaiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AteitisDbContext"))
    );

// Add services to the container.
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IDtoToModel, DtoToModel>();
builder.Services.AddScoped<IUnitsRepository, UnitsRepository>();

// Add MVC services
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

// Map both API controllers and MVC controllers
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
