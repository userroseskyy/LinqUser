using LinqUser.Areas.Profile.Models;
using LinqUser.Areas.Services.ProfileService.UserProfile;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.CreateProfileUser
{
    public class CreateProfileUserService : ICreateProfileUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataBaseContext _context;
        public CreateProfileUserService(UserManager<User> userManager,DataBaseContext context)
        {
            _userManager = userManager;
            _context=context;
        }

        public async Task CreateProfile(CreateProfileDto createProfileDto, ClaimsPrincipal userClaims)
        {
            var userId=userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new Exception("کاربر یافت نشد!");
            }
            var user=await _userManager.FindByIdAsync(userId);
            var existingProfile = _context.profileUsers.FirstOrDefault(p=> p.UserId==userId);
            if (existingProfile != null)
            {
                throw new InvalidOperationException("شما قبلاً یک پروفایل ثبت کرده‌اید و امکان ثبت پروفایل جدید ندارید!");
            }
            ProfileUser profileUser = new ProfileUser()
                {
                    FirstName=createProfileDto.FirstName,
                    LastName=createProfileDto.LastName,
                    Bio=createProfileDto.Bio,
                    UserId=userId,
                    ProfileImageUrl=createProfileDto.ProfileImageUrl,
                    SocialLinks=createProfileDto.SocialLinks.Select(p=> 
                    new SocialLink
                    {
                       PlatformName=p.PlatformName,
                       Url=p.Url,
                        
                    }).ToList(),

                };
                _context.profileUsers.Add(profileUser);
                await _context.SaveChangesAsync();
         

           

        }
    }




}
