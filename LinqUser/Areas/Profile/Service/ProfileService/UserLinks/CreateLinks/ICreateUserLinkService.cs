using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.UserLinks.CreateLinks
{
    public interface ICreateUserLinkService
    {
        Task<bool> CreateUserLinkAsync(CreateUserLinkDto createUserLinkDto, ClaimsPrincipal userClaim);



    }
}
