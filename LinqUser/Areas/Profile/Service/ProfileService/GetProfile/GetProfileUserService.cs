using LinqUser.Areas.Profile.Models;
using LinqUser.Areas.Profile.Service.LinkServices;
using LinqUser.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.GetProfile
{
    public class GetProfileUserService : IGetProfileUserService
    {
        private readonly DataBaseContext _context;
        public GetProfileUserService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<ProfileUserDto> GetProfileUser(ClaimsPrincipal userClaims)
        {
            
            
            var userid = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            var ProfileUser = await _context.profileUsers
            .Include(p => p.SocialLinks).FirstOrDefaultAsync(p => p.UserId==userid);

            if (ProfileUser == null)
            {
                return null;
            }
            var profile = new ProfileUserDto
            {
                FullName=$"{ProfileUser.FirstName}{" "}{ProfileUser.LastName}",
                Bio=ProfileUser.Bio,
                ProfileImageUrl=ProfileUser.ProfileImageUrl,
                SocialLinks=ProfileUser.SocialLinks.Select(s =>
               new SocialLinkDto
               {
                   PlatformName=s.PlatformName,
                   Url=s.Url,
               }).ToList()
            };
            return profile;

        }
    }
}
