using LinqUser.Areas.Profile.Models;
using LinqUser.Models;
using LinqUser.Services.Register;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.UserLinks.CreateLinks
{
    public class CreateUserLinkService : ICreateUserLinkService
    {
        private readonly DataBaseContext _context;
        public CreateUserLinkService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserLinkAsync(CreateUserLinkDto createUserLinkDto, ClaimsPrincipal userClaim)
        {
            var userId = userClaim.FindFirstValue(ClaimTypes.NameIdentifier);
            var profileId = _context.profileUsers.FirstOrDefault(p => p.UserId == userId);
            if (profileId == null)
            {
                return await Task.FromResult(false);
            }

            var userLink = new SocialLink
            {
                Id = Guid.NewGuid().ToString(),
                Url = createUserLinkDto.Url,
                PlatformName = createUserLinkDto.PlatformName,
                UserProfileId=profileId.Id,

            };
            _context.socialLinks.Add(userLink);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);



        }
    }
}
