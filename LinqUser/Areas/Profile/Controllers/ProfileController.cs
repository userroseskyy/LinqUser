using Microsoft.AspNetCore.Mvc;

namespace LinqUser.Areas.Profile.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUserProfile()
        {

            return View();
        }
    }
}
