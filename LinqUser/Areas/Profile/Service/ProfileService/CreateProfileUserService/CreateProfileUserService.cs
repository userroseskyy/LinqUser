using LinqUser.Areas.Profile.Models;
using LinqUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LinqUser.Areas.Profile.Service.ProfileService.CreateProfileUserService
{
    public class CreateProfileUserService : ICreateProfileUserService
    {
        private readonly DataBaseContext _context;
        public CreateProfileUserService(DataBaseContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> CreateProfileUserAsync(CreateProfileUserDto dto, ClaimsPrincipal userClaim)
        {
            var userId=userClaim.FindFirstValue(ClaimTypes.NameIdentifier);


            var user = await _context.Users.FindAsync(userId);
           

            var profile = new ProfileUser
            {
               
                UserId=user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Bio=dto.Bio,
            
            };
            if (dto.ProfileImageUrl != null && dto.ProfileImageUrl.Length > 0)
            {
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
            
            
            await _context.AddAsync(profile);
            await _context.SaveChangesAsync();
            

            return new OkObjectResult(profile);
        }
    }
}
