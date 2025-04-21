using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.GetProfile
{
    public interface IGetProfileUserService
    {
        Task<ProfileUserDto> GetProfileUser(ClaimsPrincipal userClaims);
    }
}
