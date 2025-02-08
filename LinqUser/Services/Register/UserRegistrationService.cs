using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.Register
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRegistrationService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager=userManager;
            _httpContextAccessor=httpContextAccessor;
        }
        
     

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
              
            };
           


            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }

       
    }


}
