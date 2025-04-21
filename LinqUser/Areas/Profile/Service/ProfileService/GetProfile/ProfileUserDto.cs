using LinqUser.Areas.Profile.Service.LinkServices;

namespace LinqUser.Areas.Profile.Service.ProfileService.GetProfile
{
    public class ProfileUserDto
    {
        public string Id { get; set; }

        public string FullName { get; set; }
        public string Bio { get; set; }
        public string? ProfileImageUrl { get; set; }

        public List<SocialLinkDto> SocialLinks { get; set; } = new();
    }
}
