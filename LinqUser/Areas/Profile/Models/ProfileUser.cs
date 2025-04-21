using LinqUser.Models.Users;

namespace LinqUser.Areas.Profile.Models
{
    public class ProfileUser
    {
        public string Id { get; set; } = 
            
            Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string? ProfileImageUrl { get; set; }

        public List<SocialLink> SocialLinks { get; set; } = new();
    }
}
