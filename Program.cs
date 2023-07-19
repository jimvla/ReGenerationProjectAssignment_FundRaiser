using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//var myConn = "Server=AMD-FX6300\\SQLSERVER2019;Initial Catalog=Fund;" +
//       "Integrated security=True;TrustServerCertificate=True;";

var myConn = "Server=tcp:regenteam1.database.windows.net,1433;Initial Catalog=RegenTeam1;Persist Security Info=False;User ID=regenadmin;Password=Regenpass2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
