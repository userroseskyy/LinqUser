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
        public EditeProfileUserService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task EditeProfileUser(EditeProfileUserDto editeProfileUser, ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);

            var profile = await _context.profileUsers
                .Include(c => c.SocialLinks)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile == null)
            {
                throw new Exception("پروفایل یافت نشد!");
            }

            profile.FirstName = editeProfileUser.FirstName;
            profile.LastName = editeProfileUser.LastName;
            profile.Bio = editeProfileUser.Bio;

            // بروزرسانی لینک‌های اجتماعی
            profile.SocialLinks = editeProfileUser.SocialLinks.Select(
                p => new SocialLink
                {
                    PlatformName = p.PlatformName,
                    Url = p.Url,
                }).ToList();

            // ذخیره تصویر پروفایل جدید اگر آپلود شده باشد
            if (editeProfileUser.ProfileImage != null)
            {
                var uploadFolder = Path.Combine("wwwroot", "Images", "profiles");

                // حذف تصویر قبلی اگر وجود داشته باشد
                var oldImagePath = Path.Combine(uploadFolder, Path.GetFileName(profile.ProfileImageUrl));
                if (!string.IsNullOrEmpty(profile.ProfileImageUrl) && File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }

                // ساخت نام جدید برای تصویر
                var newFileName = $"{userId}_{Guid.NewGuid()}{Path.GetExtension(editeProfileUser.ProfileImage.FileName)}";
                var newFilePath = Path.Combine(uploadFolder, newFileName);

                // ذخیره تصویر جدید
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await editeProfileUser.ProfileImage.CopyToAsync(stream);
                }

               
                profile.ProfileImageUrl = $"/Images/profiles/{newFileName}";
            }

           
            await _context.SaveChangesAsync();
        }

        public async Task<EditeProfileUserDto> GetProfileForEdit(ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile = await _context.profileUsers
                .Include(p => p.SocialLinks)
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (profile == null)
            {
                throw new Exception("پروفایل یافت نشد!");
            }

            var getProfile = new EditeProfileUserDto
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                ProfileImageUrl = profile.ProfileImageUrl,
                Bio = profile.Bio,
                SocialLinks = profile.SocialLinks.Select(p => new SocialLink
                {
                    PlatformName = p.PlatformName,
                    Url = p.Url,
                }).ToList(),
            };

            return getProfile;
        }
    }
}