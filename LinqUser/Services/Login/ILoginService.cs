using Microsoft.AspNetCore.Identity;

namespace LinqUser.Services.Login
{
    public interface ILoginService
    {
        Task<SignInResult> LoginAsync(LoginDto login);
    }
}
