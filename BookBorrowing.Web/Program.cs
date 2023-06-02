using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookBorrowing.Web.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDbContextConnection' not found.");

builder.Services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Library>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<IdentityDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Client}/{action=Details}/{id?}");

app.MapRazorPages();

app.Run();
