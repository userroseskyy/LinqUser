using LinqUser.Areas.Profile.Models;

namespace LinqUser.Areas.Profile.Service.ProfileService.CreateProfileUserService
{
    public class CreateProfileUserDto
    {
        
       
        public string Bio { get; set; }
        public IFormFile? ProfileImageUrl { get; set; }

       
    }
}
