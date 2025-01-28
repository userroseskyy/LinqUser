using Microsoft.AspNetCore.Identity;

namespace LinqUser.Models.Roles
{
    public class Role:IdentityRole
    {
        public string Description { get; set; }
    }
}
