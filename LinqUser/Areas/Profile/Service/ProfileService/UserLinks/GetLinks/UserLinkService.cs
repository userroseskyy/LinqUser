using LinqUser.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.UserLinks.GetLinks
{
    public class UserLinkService : IUserLinkService
    {
        private readonly DataBaseContext _context;
        public UserLinkService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<UserLinkDto>> GetUserLinksAsync(ClaimsPrincipal userClaim)
        {
            var userId = userClaim.FindFirstValue(ClaimTypes.NameIdentifier);

            var profile = await _context.profileUsers
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile == null)
                return new List<UserLinkDto>();

            var links = await _context.socialLinks
                .Where(p => p.UserProfileId == profile.Id)
                .Select(link => new UserLinkDto
                {
                  
                    PlatformName = link.PlatformName,
                    Url = link.Url
                })
                .ToListAsync();

            return links;
        }
    }
}
