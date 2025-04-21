using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.CreateProfileUserService
{
    public interface ICreateProfileUserService
    {
        Task<IActionResult> CreateProfileUserAsync(CreateProfileUserDto dto, ClaimsPrincipal user);
    }
}
