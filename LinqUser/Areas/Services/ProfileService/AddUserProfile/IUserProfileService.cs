using LinqUser.Areas.Profile.Models;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Areas.Services.ProfileService.AddUserProfile
{
    public interface IUserProfileService
    {
        Task<ProfileUser?> CreateProfileAsync(UserProfileDto userProfileDto);
    }

    public class UserPofileService : IUserProfileService
    {
        private readonly DataBaseContext _Context;
        public UserPofileService(DataBaseContext Context)
        {
            _Context = Context;
        }
        public Task<ProfileUser?> CreateProfileAsync(UserProfileDto userProfileDto)
        {
            var userProfile = new ProfileUser()
            {
                FirstName = userProfileDto.FirstName,
                LastName = userProfileDto.LastName,
                Bio=userProfileDto.Bio,
                ProfileImageUrl = userProfileDto.ProfileImageUrl,
                SocialLinks=new List<SocialLink>(),
            };
            return Task.FromResult(userProfile);
        }
    }


    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public List<SocialLinkDto> SocialLinks { get; set; }
    }

    public class SocialLinkDto
    {
        public string PlatformName { get; set; }
        public string Url { get; set; }
    }

}
