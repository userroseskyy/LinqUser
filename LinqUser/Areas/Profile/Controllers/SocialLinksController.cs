using LinqUser.Areas.Profile.Service.ProfileService.UserLinks.CreateLinks;
using LinqUser.Areas.Profile.Service.ProfileService.UserLinks.GetLinks;
using Microsoft.AspNetCore.Mvc;

namespace LinqUser.Areas.Profile.Controllers
{
    [Area("Profile")]
    public class SocialLinksController : Controller
    {
        private readonly ICreateUserLinkService _createUserLink;
        private readonly IUserLinkService _userLink;
        public SocialLinksController(ICreateUserLinkService createUserLink,IUserLinkService userLink)
        {
            _createUserLink = createUserLink;
            _userLink = userLink;
        }
        public async Task<IActionResult> Index()
        {
            var userLinks = await _userLink.GetUserLinksAsync(User);
            return View(userLinks);
        }
        [HttpGet]
        public IActionResult CreateLink()
        {
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> CreateLink(CreateUserLinkDto dto)
        {
           var userLink=await  _createUserLink.CreateUserLinkAsync(dto, User);
            return View(dto);
        }

    }
}
