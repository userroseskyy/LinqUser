using LinqUser.Areas.Profile.Models;
using LinqUser.Areas.Services.ProfileService.UserProfile;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.CreateProfileUser
{
    public class CreateProfileUserService : ICreateProfileUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly DataBaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateProfileUserService(UserManager<User> userManager,DataBaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context=context;
            _webHostEnvironment=webHostEnvironment;

        }

        public async Task CreateProfile(CreateProfileDto createProfileDto, ClaimsPrincipal userClaims)
        {
            var userId=userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new Exception("کاربر یافت نشد!");
            }

            var profileExists = await _context.profileUsers.AnyAsync(p => p.UserId == userId);
            if (profileExists)
            {
                throw new Exception("شما قبلاً یک پروفایل ثبت کرده‌اید!");
            }
            var directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "profiles");
            if (!Directory.Exists(directoryPath)) 
            {
                Directory.CreateDirectory(directoryPath);
            }
            var filePath = Path.Combine(directoryPath, createProfileDto.ProfileImageUrl.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await createProfileDto.ProfileImageUrl.CopyToAsync(stream);
            }

            string profileImageUrl = "/images/profiles/" + createProfileDto.ProfileImageUrl.FileName;

            ProfileUser profileUser = new ProfileUser()
                {
                    FirstName=createProfileDto.FirstName,
                    LastName=createProfileDto.LastName,
                    Bio=createProfileDto.Bio,
                    UserId=userId,
                ProfileImageUrl=profileImageUrl,
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
