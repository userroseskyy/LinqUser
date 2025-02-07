using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public LoginService(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        public async Task<SignInResult> LoginAsync(LoginDto login)
        {
            var user =await _userManager.FindByEmailAsync(login.UserName);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            var passwordValid= await _userManager.CheckPasswordAsync(user, login.Password);

                if (!passwordValid)
                {
                return SignInResult.Failed;
               
                }
            _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, login.IsPersistent);

              return SignInResult.Success;
        }

           
            
                
           

            
        }
    }

