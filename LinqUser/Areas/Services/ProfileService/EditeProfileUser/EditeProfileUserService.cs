using LinqUser.Areas.Profile.Models;
using LinqUser.Models;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace LinqUser.Areas.Services.ProfileService.EditeProfileUser
{
    public class EditeProfileUserService : IEditeProfileUserService
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;

        public EditeProfileUserService(DataBaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EditeProfileUser(EditeProfileUserDto editeProfileUser, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return; // اگر کاربر لاگین نبود، متوقف شو

            // پیدا کردن پروفایل کاربر در دیتابیس
            var profileUser = await _context.profileUsers
                .Include(p => p.SocialLinks)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profileUser == null) return; // اگر پروفایل یافت نشد، متوقف شو

            // بروزرسانی اطلاعات
            profileUser.FirstName = editeProfileUser.FirstName;
            profileUser.LastName = editeProfileUser.LastName;
            profileUser.Bio = editeProfileUser.Bio;
            profileUser.ProfileImageUrl = editeProfileUser.ProfileImageUrl;

            // بروزرسانی لینک‌های اجتماعی (اگر نیاز است)
            profileUser.SocialLinks.Clear();
            if (editeProfileUser.SocialLinks != null)
            {
                foreach (var link in editeProfileUser.SocialLinks)
                {
                    profileUser.SocialLinks.Add(new SocialLink
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserProfileId = profileUser.Id,
                        PlatformName = link.PlatformName,
                        Url = link.Url
                    });
                }
            }

            // ذخیره تغییرات در دیتابیس
            _context.profileUsers.Update(profileUser);
            await _context.SaveChangesAsync();
        }
    }
}