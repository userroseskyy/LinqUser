using LinqUser.Areas.Services.ProfileService.AddUserProfile;
using LinqUser.Areas.Services.ProfileService.CreateProfileUser;
using LinqUser.Areas.Services.ProfileService.EditeProfileUser;
using LinqUser.Areas.Services.ProfileService.UserProfile;
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
builder.Services.AddScoped<IUserProfileService, UserPofileService>();
builder.Services.AddScoped<ICreateProfileUserService,  CreateProfileUserService>();
builder.Services.AddScoped<IEditeProfileUserService, EditeProfileUserService>();


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
