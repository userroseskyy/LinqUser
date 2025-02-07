using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.Register
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<User> _userManager;
        public UserRegistrationService(UserManager<User> userManager)
        {
            _userManager=userManager;
        }

        public Task<string> GenerateUniqueSlug(string FirstName)
        {
            string slug=FirstName .ToLower().Replace(" ","_")+ "-"+Guid.NewGuid().ToString("N").Substring(0,8);
            return Task.FromResult(slug); ;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
              ProfileSlug =await GenerateUniqueSlug(model.FirstName),
            };
           


            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }

       
    }


}
