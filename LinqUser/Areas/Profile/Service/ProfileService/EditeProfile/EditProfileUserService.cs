
using LinqUser.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.EditeProfile
{
    public class EditProfileUserService : IEditProfileUserService
    {
        private readonly DataBaseContext _context;
        public EditProfileUserService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> EditProfileUserAsync(EditeProfileUserDto dto, ClaimsPrincipal userClaim)
        {
            var userId = userClaim.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile=await _context.profileUsers.FirstOrDefaultAsync(p=> p.UserId==userId);
            profile.Bio=dto.Bio;
            if (dto.ProfileImageUrl != null && dto.ProfileImageUrl.Length > 0)
            {
                // حذف تصویر قبلی (در صورت وجود)
                if (!string.IsNullOrEmpty(profile.ProfileImageUrl))
                {
                    var oldPath = Path.Combine("wwwroot", profile.ProfileImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                // ذخیره تصویر جدید
                var uploadsFolder = Path.Combine("wwwroot", "images");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.ProfileImageUrl.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ProfileImageUrl.CopyToAsync(stream);
                }

                profile.ProfileImageUrl = "/images/" + uniqueFileName;
            }

            await _context.SaveChangesAsync();
            return true;
        

    }

        public async Task<EditeProfileUserDto> GetProfileUserAsync(ClaimsPrincipal userClaim)
        {
            var userId = userClaim.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile =await _context.profileUsers
           .Where(p => p.UserId == userId)
           .FirstOrDefaultAsync();
            return new EditeProfileUserDto
            {
                Bio=profile.Bio,
                CurrentProfileImageUrl =profile.ProfileImageUrl,
            };
        }
    }
}
