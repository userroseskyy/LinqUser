using LinqUser.Models.Users;
using LinqUser.Services.UserProfile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinqUser.Areas.Profile.Controllers
{
    [Area("Profile")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;

       private readonly IUserProfileService _userProfileService;
        public UserProfileController(UserManager<User> userManager, IUserProfileService  userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var profileDto = new UserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ProfileImageUrl = user.ProfileImageUrl,
                ProfileSlug=user.ProfileSlug
                
            };

            return View(profileDto);
        }
        [HttpGet]
         public async Task<IActionResult> EditeProfile()
        {
         var user= await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var profileDto = new UserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ProfileSlug=user.ProfileSlug
           
            };



            return View(profileDto);
        }
        [HttpPost]
         public async Task<IActionResult> EditeProfile(UserProfileDto profileDto)
        {
            var user=await _userManager.GetUserAsync(User);

            var result = await _userProfileService.UpdateUserProfileAsync(user.Id, profileDto);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            return View(profileDto);
         
        }
    }
}
