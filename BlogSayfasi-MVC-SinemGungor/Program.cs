using BlogSayfasi_MVC_SinemGungor.Data.Context;
using BlogSayfasi_MVC_SinemGungor.Models;
using BlogSayfasi_MVC_SinemGungor.Service;
using identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<BlogContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));


builder.Services.AddIdentity<User, Role>(x => x.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<BlogContext>()
                .AddRoles<Role>()
                .AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender, EmailSender>();

//MVC Hizmetleri
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//

builder.Services.ConfigureApplicationCookie( //eklendi
    option =>
    {
        //option.LoginPath = "/Register/Login";
        option.Cookie.Name = "UserCookie";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        option.SlidingExpiration = true; //ekstra zaman iþlem bitene kadar

    }
    );
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
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();