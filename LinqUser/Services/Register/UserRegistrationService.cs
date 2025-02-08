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
        //ساخت Url برای هر کاربر
        public async Task<string> GenerateUniqueSlug(string FirstName)
        {
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/profiles/UserProfile/";
            string slug=FirstName .ToLower().Replace(" ","_")+ "-"+Guid.NewGuid().ToString("N").Substring(0,8);
            return baseUrl+ slug;
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
