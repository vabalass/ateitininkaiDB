using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Repositories;
using AFDB.Services.CSVServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Configure PostgreSQL connection
builder.Services.AddDbContext<AteitininkaiDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AteitisDbContext"));
});


// Add services to the container.
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPledgeRepository, PledgeRepository>();
builder.Services.AddScoped<IServiceCSV, ServiceCSV>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
