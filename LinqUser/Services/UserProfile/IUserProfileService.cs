using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.UserProfile
{
    public interface IUserProfileService
    {
       
        Task<IdentityResult> UpdateUserProfileAsync(string userId, UserProfileDto profileDto);
    }
}
