using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var myConn = "Server=DESKTOP-6CI4C0U\\SQLSERVER2019;Database=16/07;User Id=sa;Password=passw0rd;Encrypt=False;";
        

builder.Services.AddDbContext<CrmDbContext>(
    options => options.UseSqlServer(myConn));

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
