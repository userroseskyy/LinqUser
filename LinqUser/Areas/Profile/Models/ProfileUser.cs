using LinqUser.Models.Users;

namespace LinqUser.Areas.Profile.Models
{
    public class ProfileUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string  UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public List<SocialLink> SocialLinks { get; set; }

    }
    public class SocialLink
    {
        public string Id { get; set; }
        public string UserProfileId { get; set; }
        public string PlatformName { get; set; }
        public string Url { get; set; }
        public ProfileUser UserProfile { get; set; }
    }
}
