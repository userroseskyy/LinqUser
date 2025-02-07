using LinqUser.Models.Users;
using LinqUser.Services.Login;
using LinqUser.Services.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinqUser.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly ILoginService _loginService;
        private readonly SignInManager<User> _signInManager;


        public RegisterController(SignInManager<User> signInManager,IUserRegistrationService userRegistrationService, ILoginService loginService)
        {
            _userRegistrationService = userRegistrationService;
            _loginService=loginService;
            _signInManager = signInManager;

            

        }

    
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model) 
        {
            if (ModelState.IsValid)
            {
            
                var result = await _userRegistrationService.RegisterUserAsync(model);

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Login", "Register");
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
        [HttpGet]
        public async Task<IActionResult> Login() 
        { 
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login) 
        {
            var result = await _loginService.LoginAsync(login);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); 
            }
            else
            {
                ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است.");
            }

            
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}