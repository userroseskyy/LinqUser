using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.EditeProfileUser
{
    public interface IEditeProfileUserService
    {
        Task EditeProfileUser(EditeProfileUserDto editeProfileUser, ClaimsPrincipal userClaims);
        Task<EditeProfileUserDto> GetProfileForEdit( ClaimsPrincipal userClaims);
    }
}
