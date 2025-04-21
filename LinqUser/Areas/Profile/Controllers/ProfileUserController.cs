using LinqUser.Areas.Profile.Service.ProfileService.CreateProfileUserService;
using LinqUser.Areas.Profile.Service.ProfileService.EditeProfile;
using LinqUser.Areas.Profile.Service.ProfileService.GetProfile;
using LinqUser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Controllers
{
    [Area("Profile")]
    public class ProfileUserController : Controller
    {
        private readonly IGetProfileUserService _getProfile;
        private readonly ICreateProfileUserService _createProfile;
        private readonly IEditProfileUserService _editeProfile;

        
        public ProfileUserController(IGetProfileUserService getProfile, ICreateProfileUserService createProfile, IEditProfileUserService editeProfile)
        {
            _getProfile= getProfile;
            _createProfile= createProfile;
            _editeProfile= editeProfile;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
         
            var res =await _getProfile.GetProfileUser(User);
            return View(res);
        }
        [HttpGet]
        public IActionResult CreateProfile()
        {

           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateProfileUserDto dto)
        {

            var profile =await _createProfile.CreateProfileUserAsync(dto, User);
            return View("GetProfile");
        
        }[HttpGet]
        public  async Task<IActionResult> EditeProfile()
        {
          var res=await _editeProfile.GetProfileUserAsync(User);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> EditeProfile(EditeProfileUserDto dto)
        {

            var profile =await _editeProfile.EditProfileUserAsync(dto, User);
            var updatedModel = await _editeProfile.GetProfileUserAsync(User);
            return View(updatedModel);
        
        }

    }
}
