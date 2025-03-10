using LinqUser.Areas.Profile.Models;

namespace LinqUser.Areas.Services.ProfileService.EditeProfileUser
{
    public class EditeProfileUserDto
    {
      
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public IFormFile ProfileImage { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
    }
}
