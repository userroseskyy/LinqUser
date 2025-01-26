using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinqUser.Models
{
    public class DataBaseContext:IdentityDbContext<IdentityUser>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> Options):base (Options)
        {

        }
    }
}
