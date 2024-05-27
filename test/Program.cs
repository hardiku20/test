using Microsoft.EntityFrameworkCore;
using test.DbEntities.Models;
using test.Repositories.IRepositories;
using test.Repositories.Repositories;
using test.Services.IServices;
using test.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession();
builder.Services.AddDbContext<DbHallodocContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DbHallodocContext")));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
