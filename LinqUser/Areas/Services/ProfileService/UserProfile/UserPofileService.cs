using LinqUser.Areas.Profile.Models;
using LinqUser.Areas.Services.ProfileService.AddUserProfile;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.UserProfile
{
    public class UserPofileService : IUserProfileService
    {
        
        private readonly DataBaseContext _context;
        public UserPofileService(DataBaseContext context)
        {
        
            _context=context;
                }



        public async Task<ProfileUserDto> ProfileUserAsync(ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return null; 
            }

            var profile = await _context.profileUsers
               .Include(p=> p.SocialLinks)
               .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile ==null)
            {
                return null;
            }
            var profileDto = new ProfileUserDto
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Bio=profile.Bio,
                ProfileImageUrl=profile.ProfileImageUrl,
                SocialLinks=profile.SocialLinks.Select(
                    s => new SocialLinkDto
                    {
                        PlatformName=s.PlatformName,
                        Url=s.Url,
                    }).ToList()};
            return profileDto;
            
        }
    }

}
