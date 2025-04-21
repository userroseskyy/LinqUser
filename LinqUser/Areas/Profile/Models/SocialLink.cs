namespace LinqUser.Areas.Profile.Models
{
    public class SocialLink
    {
        public string Id { get; set; } 
        public string UserProfileId { get; set; }
        public string PlatformName { get; set; }
        public string Url { get; set; }

        public ProfileUser UserProfile { get; set; }
    }
}
