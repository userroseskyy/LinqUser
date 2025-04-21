using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.EditeProfile
{
    public interface IEditProfileUserService
    {
        Task<EditeProfileUserDto> GetProfileUserAsync(ClaimsPrincipal userClaim);
        Task<bool> EditProfileUserAsync(EditeProfileUserDto dto,ClaimsPrincipal userClaim);
     
    }
}
