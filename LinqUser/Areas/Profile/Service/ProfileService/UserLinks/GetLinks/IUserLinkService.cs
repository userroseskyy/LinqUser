using LinqUser.Areas.Profile.Models;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.UserLinks.GetLinks
{
    public interface IUserLinkService
    {
        Task<List<UserLinkDto>> GetUserLinksAsync(ClaimsPrincipal userClaim);
    }
}
