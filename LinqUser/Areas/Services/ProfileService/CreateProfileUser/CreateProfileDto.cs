using LinqUser.Areas.Services.ProfileService.AddUserProfile;
using System.ComponentModel.DataAnnotations;

namespace LinqUser.Areas.Services.ProfileService.CreateProfileUser
{
    public class CreateProfileDto
    {
      
            [Required]
            [StringLength(50, MinimumLength = 2)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 2)]
            public string LastName { get; set; }

            [StringLength(500)]
            public string Bio { get; set; }

           
            public IFormFile? ProfileImageUrl { get; set; }

            public List<SocialLinkDto> SocialLinks { get; set; } = new List<SocialLinkDto>();
       
    }
}
