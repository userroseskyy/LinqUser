﻿using LinqUser.Areas.Profile.Models;
using LinqUser.Models.Roles;
using LinqUser.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinqUser.Models
{
    public class DataBaseContext:IdentityDbContext<User,Role,string>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> Options):base (Options)
        {

        }
       public DbSet<ProfileUser> profileUsers { get; set; }
       public DbSet<SocialLink>  socialLinks { get; set; }
         

    }
}
