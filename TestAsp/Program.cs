using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using TestAsp.Data;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
/**********SERILOG*****************/
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
/*******************************/

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.LoginPath = "/admin"; });
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => { options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); });
//options.UseSqlite(IConfiguration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
    );
/*********l'ajout pour l'API*******/
//app.UseRouting();
//app.UseEndpoints(endpoints =>endpoints.MapControllers());
/*****************************/
DataContext.CreateDbIfNotExists(app);
app.Run();
