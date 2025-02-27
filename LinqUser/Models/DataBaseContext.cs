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
        DbSet<ProfileUser> profileUsers { get; set; }
        DbSet<SocialLink>  socialLinks { get; set; }
         

    }
}
