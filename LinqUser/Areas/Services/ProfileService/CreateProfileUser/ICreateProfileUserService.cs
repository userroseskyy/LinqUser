using LinqUser.Areas.Services.ProfileService.UserProfile;
using System.Security.Claims;

namespace LinqUser.Areas.Services.ProfileService.CreateProfileUser
{
    public interface ICreateProfileUserService
    {
       
         Task CreateProfile(CreateProfileDto createProfileDto, ClaimsPrincipal claimsPrincipal);
    }




}
