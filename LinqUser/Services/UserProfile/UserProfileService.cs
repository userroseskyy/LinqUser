using LinqUser.Models.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<User> _userManager;
        public UserProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IdentityResult> UpdateUserProfileAsync(string userId, UserProfileDto profileDto)
        {
            var user=await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "کاربر یافت نشد" });
            }

            user.FirstName = profileDto.FirstName;
            user.LastName = profileDto.LastName;

          user.ProfileImageUrl=profileDto.ProfileImageUrl;
           user.Bio= profileDto.Bio;
          

       
            return await _userManager.UpdateAsync(user);
        }


        
    }
}
