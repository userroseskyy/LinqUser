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
            var user=await _userManager.FindByIdAsync(userId);

            if (userId != null) 
            {
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




}
