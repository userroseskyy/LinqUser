using Microsoft.AspNetCore.Identity;

namespace LinqUser.Models.Users
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileSlug {  get; set; }
        public string? ProfileImageUrl {  get; set; }
    }
}
