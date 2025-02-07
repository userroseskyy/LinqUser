using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.Register
{
    public interface IUserRegistrationService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDto model);
        Task<string> GenerateUniqueSlug(string userName);
    }


}
