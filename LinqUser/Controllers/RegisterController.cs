using LinqUser.Services.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinqUser.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserRegistrationService _userRegistrationService;

        // تزریق سرویس ثبت‌نام
        public RegisterController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        // صفحه اصلی
        public IActionResult Index()
        {
            return View();
        }

        // نمایش فرم ثبت‌نام
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ثبت‌نام کاربر
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model) 
        {
            if (ModelState.IsValid)
            {
            
                var result = await _userRegistrationService.RegisterUserAsync(model);

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}