using LinqUser.Areas.Profile.Service.ProfileService.CreateProfileUserService;
using LinqUser.Areas.Profile.Service.ProfileService.EditeProfile;
using LinqUser.Areas.Profile.Service.ProfileService.GetProfile;
using LinqUser.Areas.Profile.Service.ProfileService.UserLinks.CreateLinks;
using LinqUser.Areas.Profile.Service.ProfileService.UserLinks.GetLinks;
using LinqUser.Models;
using LinqUser.Models.Roles;
using LinqUser.Models.Users;
using LinqUser.Services.Login;
using LinqUser.Services.Register;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//AddDataBase
var ConnectionString = builder.Configuration.GetConnectionString("DefultConnectionString");
builder.Services.AddDbContext<DataBaseContext>(Options => Options.UseSqlServer(ConnectionString));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<DataBaseContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IGetProfileUserService, GetProfileUserService>();
builder.Services.AddScoped<ICreateProfileUserService, CreateProfileUserService>();
builder.Services.AddScoped<IEditProfileUserService, EditProfileUserService>();
builder.Services.AddScoped<ICreateUserLinkService, CreateUserLinkService>();
builder.Services.AddScoped<IUserLinkService, UserLinkService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


    

app.Run();
