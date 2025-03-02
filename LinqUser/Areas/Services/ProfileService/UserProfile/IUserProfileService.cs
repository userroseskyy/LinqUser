using LinqUser.Areas.Profile.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.UserProfile
{
    public interface IUserProfileService
    {
        Task<ProfileUserDto> ProfileUserAsync(ClaimsPrincipal userClaims);
    }

}
